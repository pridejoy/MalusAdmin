//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using RabbitMQ.Client;

//namespace MalusAdmin.Common.Components
//{
//    public interface IRabbitMQService
//    { 
//        // 异步发布消息到指定的交换机和路由键
//        Task PublishMessageAsync(string routingKey, object message);

//        // 异步从指定的队列消费消息
//        Task<string> ConsumeMessageAsync(string queueName);
  
//        // 释放RabbitMQ资源
//        void Dispose();
//    }
//}
