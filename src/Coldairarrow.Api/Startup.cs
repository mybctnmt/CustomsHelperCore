using Coldairarrow.Api.Converters;
using Coldairarrow.Api.Extentions;
using Coldairarrow.Api.Service;
using Coldairarrow.Business.Inbox;
using Coldairarrow.Util;
using EFCore.Sharding;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using StackExchange.Redis;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Coldairarrow.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            services.AddControllers(options =>
            {
                options.Filters.Add<ValidFilterAttribute>();
                options.Filters.Add<GlobalExceptionFilter>();
                
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.GetType().GetProperties().ForEach(aProperty =>
                {
                    var value = aProperty.GetValue(JsonExtention.DefaultJsonSetting);
                    aProperty.SetValue(options.SerializerSettings, value);
                });
                options.SerializerSettings.Converters.Add(new CustomDecimalConverter());

            });
            services.AddHttpContextAccessor();

            //swagger
            services.AddOpenApiDocument(settings =>
            {
                settings.AllowReferencesWithProperties = true;
                settings.AddSecurity("身份认证Token", Enumerable.Empty<string>(), new OpenApiSecurityScheme()
                {
                    Scheme = "bearer",
                    Description = "Authorization:Bearer {your JWT token}<br/><b>授权地址:/Base_Manage/Home/SubmitLogin</b>",
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Type = OpenApiSecuritySchemeType.Http
                });
            });

            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue; //not recommended value
                options.MultipartBodyLengthLimit = long.MaxValue; //not recommended value
            });

            //jwt
            services.AddJwt(_configuration);

            var redisConfiguration = _configuration.GetSection("Redis:Configuration").Value;
            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConfiguration));

            // 注册SocketListenerBackgroundService作为托管服务，并注入Redis连接
            //services.AddHostedService(provider => new SocketListenerBackgroundService(
            //    provider.GetRequiredService<IConnectionMultiplexer>(),
            //    IPAddress.Any,
            //    12345
            //));
            var connectionString = _configuration["Database:BaseDb:ConnectionString"];
            #if DEBUG
                if (!connectionString.Contains("182.92.238.65"))
                {
                    services.AddHostedService<SocketListenerBackgroundService>();
                    services.AddHostedService<JobBackgroundService>();
                }
            #else
                services.AddHostedService<SocketListenerBackgroundService>();
                services.AddHostedService<JobBackgroundService>();
            #endif
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //跨域
            app.UseCors(x =>
                {
                    x.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .DisallowCredentials();
                })
                .UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                })
                .UseMiddleware<RequestBodyMiddleware>()
                .UseMiddleware<RequestLogMiddleware>()
                .UseDeveloperExceptionPage()
                .UseStaticFiles(new StaticFileOptions
                {
                    ServeUnknownFileTypes = true,
                    DefaultContentType = "application/octet-stream"
                })
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers().RequireAuthorization();
                })
                .UseOpenApi()//添加swagger生成api文档（默认路由文档 /swagger/v1/swagger.json）
                .UseSwaggerUi3();

        }
    }
}
