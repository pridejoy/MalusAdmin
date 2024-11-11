using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace MalusAdmin.Common.Components
{
    public class SubscribeWorker : BackgroundService
    {
        private readonly MQSubscribe _Service;

        public SubscribeWorker(MQSubscribe  Service)
        {
            _Service = Service;
        }

        // 执行逻辑
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _Service.Init(); 
        }
    }
}
