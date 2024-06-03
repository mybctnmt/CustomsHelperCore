using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Coldairarrow.Util.Helper
{
    public class HeartbeatServer
    {
        private ConcurrentDictionary<Socket, DateTime> clientLastHeartbeat = new ConcurrentDictionary<Socket, DateTime>();
        private bool running = true;

        public void StartServer(int port)
        {
            IPAddress ip = IPAddress.Any;
            IPEndPoint localEndPoint = new IPEndPoint(ip, port);

            using Socket listener = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(10);

            LogHelper.LogInformation("Server is listening for connections...");

            while (running)
            {
                Socket clientSocket = listener.Accept();
                clientLastHeartbeat[clientSocket] = DateTime.Now;
                ThreadPool.QueueUserWorkItem(HandleClient, clientSocket);
            }
        }

        private void HandleClient(object client)
        {
            Socket clientSocket = (Socket)client;
            byte[] bytes = new byte[1024];
            string data;

            while (true)
            {
                try
                {
                    int bytesRec = clientSocket.Receive(bytes);
                    data = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    if (data == "heartbeat")
                    {
                        clientLastHeartbeat[clientSocket] = DateTime.Now;
                        LogHelper.LogInformation("Heartbeat received from client.");
                    }
                    else
                    {
                        LogHelper.LogInformation("Data received: {0}", data);
                    }
                }
                catch (SocketException)
                {
                    LogHelper.LogInformation("Client disconnected.");
                    clientSocket.Close();
                    clientLastHeartbeat.TryRemove(clientSocket, out _);
                    return;
                }
            }
        }

        public void CheckHeartbeats(object stateInfo)
        {
            DateTime now = DateTime.Now;
            foreach (var client in clientLastHeartbeat.Keys)
            {
                if (now.Subtract(clientLastHeartbeat[client]).TotalSeconds > 30) // 30 seconds timeout
                {
                    LogHelper.LogInformation("Client timed out.");
                    client.Close();
                    clientLastHeartbeat.TryRemove(client, out _);
                }
            }
        }

        public void StopServer()
        {
            running = false;
        }
    }
}
