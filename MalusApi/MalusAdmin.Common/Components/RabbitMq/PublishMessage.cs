//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using EasyNetQ;
//using RabbitMQ.Client;

//namespace MalusAdmin.Common.Components.RabbitMq
//{
//    public class PublishMessage
//    {

//        private readonly IConnection _rabbitMQConnection;
//        public PublishMessage(IConnection rabbitMQConnection)
//        {
//            _rabbitMQConnection = rabbitMQConnection;
//        }

      

//        public void PublishMyMessage(string exchangeName, string routingKey, Object message)
//        {
//            using (var channel = _rabbitMQConnection.CreateModel())
//            {
//                channel.QueueDeclare(queue: "my_queue",
//                                     durable: false,
//                                     exclusive: false,
//                                     autoDelete: false,
//                                     arguments: null);

//                var body = Encoding.UTF8.GetBytes(message.ToJson());

//                channel.BasicPublish(exchange: "",
//                                      routingKey: "my_queue",
//                                      basicProperties: null,
//                                      body: body);
               
//            }
//        }
//    }
//}
