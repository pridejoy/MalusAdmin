//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Hosting;
//using RabbitMQ.Client.Events;

//namespace MalusAdmin.Common.Components.RabbitMQClient
//{
//    /// <summary>
//    /// 用来消费消息队列的
//    /// </summary>
//    public class RabbitMqHostedService : IHostedService, IDisposable
//    {
//        private readonly IRabbitMQService _rabbitMqService; 
//        private EventingBasicConsumer _consumer;
//        private CancellationTokenSource _cancellationTokenSource;
         
//        public RabbitMqHostedService(IRabbitMQService rabbitMqService)
//        {
//            _rabbitMqService = rabbitMqService; 
//        }

//        public  Task StartAsync(CancellationToken cancellationToken)
//        {
//            Console.WriteLine("开始消费RabbitMq");
//            var c = _rabbitMqService.ConsumeMessageAsync("myRoutingKey").Result;
//            Console.WriteLine("收到消息：" + c);
//             c = _rabbitMqService.ConsumeMessageAsync("myRoutingKey").Result;
//            Console.WriteLine("收到消息2：" + c);
//            //_cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

//            // 设置消费者
//            //_consumer = new EventingBasicConsumer(_rabbitMqService.GetChannel());
//            //_consumer.Received += Consumer_Received;

//            //// 开始接收消息
//            //_rabbitMqService.ConsumeMessageAsync("myRoutingKey");

//            return Task.CompletedTask;
//        }

//        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
//        {
//            var body = e.Body.ToArray();
//            var message = Encoding.UTF8.GetString(body);
//            Console.WriteLine($"Received message: {message}");

//            // 处理消息
//            // 这里可以添加你的业务逻辑

           
//        }

//        public Task StopAsync(CancellationToken cancellationToken)
//        {
//            Console.WriteLine("停止消费RabbitMq");
//            return Task.CompletedTask;
//        }

//        public void Dispose()
//        {
//            _rabbitMqService.Dispose();
//        }
//    }
//}
