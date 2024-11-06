//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using EasyNetQ; 
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Options;
//using RabbitMQ.Client;

//namespace MalusAdmin.Common.Components
//{
//    public static class RabbitMqExtension
//    {
          //弃用
//        public static IServiceCollection AddRabbitMqClientExtension(this IServiceCollection services)
//        { 
//            services.AddSingleton<IConnectionFactory>(sp =>
//            {
//                var options = sp.GetService<IOptions<RabbitMQConfig>>()?.Value;
//                var connectionFactory = new ConnectionFactory();

//                if (!string.IsNullOrEmpty(options?.HostName)) connectionFactory.HostName = options.HostName;
//                if (options?.Port != null) connectionFactory.Port = options.Port;
//                if (!string.IsNullOrEmpty(options?.UserName)) connectionFactory.UserName = options.UserName;
//                if (!string.IsNullOrEmpty(options?.Password)) connectionFactory.Password = options.Password;
//                if (!string.IsNullOrEmpty(options?.VirtualHost)) connectionFactory.Password = options.VirtualHost;

//                return connectionFactory;
//            });

//            // 消费服务
//            //services.AddHostedService<RabbitMqHostedService>();
//            //services.AddSingleton<IRabbitMQService, RabbitMQService>();

//            return services;
//        }
//    }


   
//}
