using AutoMapper.Configuration;
using Coldairarrow.Business.Inbox;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Extentions
{
    public static class HangfireExtension
    {
        //public static void AddMyHangfire(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration _configuration)
        //{
        //    var dbOptions = _configuration.GetSection("Database:BaseDb").Get<DatabaseOptions>();
        //    services.AddHangfire(hangfire => hangfire
        //            .UseStorage(new MySqlStorage(dbOptions.ConnectionString, new MySqlStorageOptions
        //            {
        //                QueuePollInterval = TimeSpan.FromSeconds(5), // 检查作业队列的间隔时间为 5 秒
        //                TablesPrefix = "hangfire_"
        //            })));

        //    // Add the processing server as IHostedService
        //    services.AddHangfireServer();
        //    //Hangfire的数据库可以跟应用程序共用一个库，也可以单独用一个数据库，里面大概不到10个表。
        //}

        //public static void UseMyHangFire(this IApplicationBuilder app, bool isUseDashboard = true)
        //{
        //    if (isUseDashboard)
        //    {
        //        //是否使用web页面的后台管理
        //        //配置控制台页面路径，以及生产环境配置账号密码登录验证。
        //        app.UseHangfireDashboard("/hangfire", new DashboardOptions
        //        {
        //            Authorization = new[] { new HangfireDashboardLoginFilter() }
        //        });

        //    }
        //    //RecurringJob.AddOrUpdate<ItemailorderBusiness>("AutoDispatchOrder", x => x.AutoDispatchOrder(), Cron.MinuteInterval(1));
            
        //}
    }
}
