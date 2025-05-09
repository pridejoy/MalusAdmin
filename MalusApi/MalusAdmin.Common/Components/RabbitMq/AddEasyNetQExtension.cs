using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MalusAdmin.Common.Components
{
    public static class EasyNetQExtension
    {
        //<PackageReference Include="EasyNetQ" Version="7.8.0" />
        //<PackageReference Include = "EasyNetQ.DI.Microsoft" Version="7.8.0" />
        public static IServiceCollection AddEasyNetQExtension(this IServiceCollection services)
        {
            var RabbitMqConnetion = App.Configuration["RabbitMqConnetion"]?.ToString();
            if (RabbitMqConnetion == null) throw new NullReferenceException("配置读取失败");

            services.RegisterEasyNetQ(RabbitMqConnetion); 
            
            services.AddTransient<MQPublish>();

            services.AddTransient<MQSubscribe>();
            //添加消息处理
            services.AddHostedService<SubscribeWorker>();

            return services;
        }

    }
}
