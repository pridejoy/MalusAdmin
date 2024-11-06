//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Options;
//using RabbitMQ.Client.Events;
//using RabbitMQ.Client;

//namespace MalusAdmin.Common.Components
//{
//    public class RabbitMQService : IRabbitMQService, IDisposable
//    {
//        private readonly IConnectionFactory _connectionFactory;
//        private IConnection _connection;
//        private IModel _channel;

//        private bool _started;
//        private readonly SemaphoreSlim _startLock = new SemaphoreSlim(1, 1);
//        public RabbitMQService(IConnectionFactory connectionFactory)
//        {
//            _connectionFactory = connectionFactory;
//            _connection = _connectionFactory.CreateConnection();
//            _channel = _connection.CreateModel();
//        }
         
//        /// <summary>
//        /// 异步发布消息到指定的交换机和路由键
//        /// </summary>
//        /// <param name="exchangeName"></param>
//        /// <param name="routingKey">就是queueName</param>
//        /// <param name="message"></param>
//        /// <returns></returns>
//        public async Task PublishMessageAsync(string routingKey, object message)
//        {
//            await Task.Run(() =>
//            {
//                // 发布消息到RabbitMQ
//                _channel.BasicPublish(exchange: "",
//                                     routingKey: routingKey,
//                                     basicProperties: null,
//                                     body: Encoding.UTF8.GetBytes(message.ToJson()));
//            });
//        }

//        // 异步从指定的队列消费消息
//        public async Task<string> ConsumeMessageAsync(string queueName)
//        {
//            var tcs = new TaskCompletionSource<string>(); // 用于异步等待消息的TaskCompletionSource
//            var consumer = new EventingBasicConsumer(_channel); // 创建一个事件驱动的消费者
//            consumer.Received += (model, ea) =>
//            {
//                var body = ea.Body.ToArray(); // 获取消息体
//                var message = Encoding.UTF8.GetString(body); // 将消息体转换为字符串
//                Console.WriteLine( "消费消息："+ message);
//                tcs.SetResult(message); // 设置Task的结果
//                _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false); // 确认消息
//            };
//            _channel.BasicConsume(queue: queueName, // 从指定队列消费消息
//                                 autoAck: false,
//                                 consumer: consumer);
//            return await tcs.Task; // 等待并返回消息
//        }


//        public virtual async void StartSubscribe()
//        {
          

//            if (_started)
//            {
//                return;
//            }

//            _startLock.Wait();

//            try
//            {
//                if (!_started)
//                {
//                    var QueueName = "myRoutingKey";

//                    await ConsumeMessageAsync(QueueName);

//                    _started = true;
//                }
//            }
//            finally
//            {
//                _startLock.Release();
//            }
//        }


//        // 释放RabbitMQ资源
//        public void Dispose()
//        {
//            _channel?.Close(); // 关闭通道
//            _connection?.Close(); // 关闭连接
//            _channel?.Dispose(); // 释放通道资源
//            _connection?.Dispose(); // 释放连接资源
//        }
//    }
//}
