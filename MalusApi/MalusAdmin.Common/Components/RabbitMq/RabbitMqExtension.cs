using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

namespace MalusAdmin.Common.Components.RabbitMq
{
    public static class RabbitMqExtension
    {
        
        public static IServiceCollection AddRabbitMqExtension(this IServiceCollection services)
        {
            // 获取RabbitMQ连接字符串
            //string mqConnetion = AppSettings.RabbitMqConnetion;

            //var rabbitMQConfig = Configuration.GetSection("RabbitMQ").Get<RabbitMQConfig>();

            //services.AddSingleton<IConnection>(x =>
            //{
            //    var factory = new ConnectionFactory()
            //    {
            //        HostName = rabbitMQConfig.Host,
            //        Port = rabbitMQConfig.Port,
            //        UserName = rabbitMQConfig.Username,
            //        Password = rabbitMQConfig.Password
            //    };
            //    return factory.CreateConnection();
            //});

            //services.AddSingleton<PublishMessage>();

            // 注入EasyNetQ的IBus实例
            //services.AddSingleton(RabbitHutch.CreateBus(mqConnetion));

            //v8版本
            //services.AddEasyNetQ("host=myServer;virtualHost=myVirtualHost;username=mike;password=topsecret")
            //   .UseSystemTextJson(); ;
            // 注册订阅服务
            //services.AddSingleton<IHostedService, MessageSubscriberHostedService>();



            return services;
        }
    }


   
}
