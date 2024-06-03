using Coldairarrow.Business.Inbox;
using Coldairarrow.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Service
{
    public class SocketListenerBackgroundService : BackgroundService
    {
        private readonly Timer _timer;
        private readonly TcpListener _listener;
        private readonly IConnectionMultiplexer _redis;
        private readonly IServiceProvider _serviceProvider;
        public SocketListenerBackgroundService(IConnectionMultiplexer redis, IConfiguration configuration, IServiceProvider serviceProvider, IHostEnvironment env)
        {
            _redis = redis;
            _serviceProvider = serviceProvider;
            var ipAddress = IPAddress.Parse(configuration["SocketListenerSettings:IPAddress"]);
            var port = int.Parse(configuration["SocketListenerSettings:Port"]);
            _listener = new TcpListener(ipAddress, port);
            TimerCallback callback = new TimerCallback(Tick);
            _timer = new Timer(callback, null, TimeSpan.FromSeconds(120), TimeSpan.FromSeconds(60));
        }
        private async void Tick(Object stateInfo)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var emailOrderBusiness = scope.ServiceProvider.GetRequiredService<ItemailorderBusiness>();
                List<string> activeClients = await GetActiveClientIdsAsync();
                Console.WriteLine("Redis活动客户端：" + string.Join(",", activeClients));
                await emailOrderBusiness.UpdateActiveClients(activeClients);
            }
        }
        private async Task<List<string>> GetActiveClientIdsAsync()
        {
            var activeClientKeys = new List<string>();
            try
            {
                var db = _redis.GetDatabase();
                var server = _redis.GetServer(db.IdentifyEndpoint());

                // Use SCAN command to iterate through the keyspace for active clients
                await foreach (var key in server.KeysAsync(pattern: "activeClient:*"))
                {
                    activeClientKeys.Add(key.ToString().Replace("activeClient:", ""));
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogWarning(ex.Message);
            }

            return activeClientKeys;
           
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _listener.Start();

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var client = await _listener.AcceptTcpClientAsync();
                    _ = HandleClientAsync(client, stoppingToken);
                }
            }
            finally
            {
                _listener.Stop();
            }

        }

        private async Task HandleClientAsync(TcpClient client, CancellationToken stoppingToken)
        {
            var db = _redis.GetDatabase();

            try
            {
                // 不再使用 using 语句，以避免自动关闭和释放 client 和 networkStream
                var networkStream = client.GetStream();

                // 假设客户端首先发送其ID
                var clientIdBuffer = new byte[19]; // GUID字符串的长度
                var byteCount = await networkStream.ReadAsync(clientIdBuffer, 0, clientIdBuffer.Length, stoppingToken);
                if (byteCount == 0)
                {
                    throw new InvalidOperationException("No client ID received.");
                }

                string clientId = Encoding.UTF8.GetString(clientIdBuffer, 0, byteCount);

                string clientKey = $"activeClient:{clientId}";

                Console.WriteLine(clientKey);

                // Set the client key with a 1-minute expiration
                await db.StringSetAsync(clientKey, DateTimeOffset.UtcNow.ToUnixTimeSeconds(), TimeSpan.FromSeconds(120));

                // 维持与客户端的连接
                while (!stoppingToken.IsCancellationRequested && client.Connected)
                {
                    // 这里应该是处理客户端请求的代码
                    // 例如，读取更多数据或等待客户端发送数据
                    // 注意：你需要适当地实现读取数据和处理数据的逻辑

                    // 示例：假设我们等待客户端发送消息
                    byte[] buffer = new byte[1024];
                    int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length, stoppingToken);
                    if (bytesRead == 0)
                    {
                        // 客户端已经关闭了连接
                        break;
                    }

                    // Update the client timestamp in the hash
                    await db.StringSetAsync(clientKey, DateTimeOffset.UtcNow.ToUnixTimeSeconds(), TimeSpan.FromSeconds(120));
                }
            }
            catch (OperationCanceledException)
            {
                // 忽略由于取消读/写操作时停止服务而抛出的异常
            }
            catch (Exception ex)
            {
                // 记录或按需处理异常
                LogHelper.LogInformation(ex.ToString());
            }
            finally
            {
                //if (!string.IsNullOrEmpty(clientId))
                //{
                //    // Remove the client key as the client has disconnected
                //    await db.KeyDeleteAsync($"activeClient:{clientId}");
                //}

                //// Update the active client list after a client disconnects
                //using (var scope = _serviceProvider.CreateScope())
                //{
                //    var emailOrderBusiness = scope.ServiceProvider.GetRequiredService<ItemailorderBusiness>();
                //    List<string> activeClients = await GetActiveClientIdsAsync();
                //    await emailOrderBusiness.UpdateActiveClients(activeClients);
                //}

                // Cleanup resources
                client.Dispose();
            }
        }
    }
}
