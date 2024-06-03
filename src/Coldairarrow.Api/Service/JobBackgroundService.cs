using Coldairarrow.Business.Inbox;
using Coldairarrow.Util;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Service
{
    public class JobBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public JobBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Task.Run(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(120));
                JobHelper.SetIntervalJob(() => {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var emailOrderBusiness = scope.ServiceProvider.GetRequiredService<ItemailorderBusiness>();
                        emailOrderBusiness.AutoDispatchOrder();
                    }
                }, TimeSpan.FromSeconds(60));
            });
        }
    }
}
