using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ.Topology;
using EasyNetQ;
using SqlSugar.IOC;

namespace MalusAdmin.Common.Components
{
    /// <summary>
    /// 发布消息
    /// </summary>
    public class MQPublish
    {
        private readonly IBus bus;

        public MQPublish(IBus bus)
        {
            this.bus = bus;
        }

 
        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="routingKey"></param>
        /// <param name="data"></param>
        public async Task PublishMessageAsync(string routingKey, object data)
        {
            Console.WriteLine($"MQ消息推送，routingKey ：{routingKey} , 推送数据 ：{System.Text.Json.JsonSerializer.Serialize(data)}");

            var message = new Message<object>(data);
            var advancedBus = bus.Advanced;
            advancedBus.QueueDeclare(routingKey);
            await advancedBus.PublishAsync(Exchange.Default, routingKey, false, message);
         }

        /// <summary>
        /// 发布延迟消息
        /// </summary>
        /// <param name="routingKey"></param>
        /// <param name="data"></param>
        /// <param name="timeout">毫秒</param>
        public void PublishDelayMessage(string routingKey, object data, int timeout)
        {
            var advancedBus = bus.Advanced;
            var message = new Message<object>(data);
            var properties = new MessageProperties();
            properties.Headers.Add("x-delay", timeout);
            var messageData = new Message<object>(message, properties);
            // 建立延时 exchange
            var exDelay = advancedBus.ExchangeDeclare($"{routingKey}_delay_exchange", cfg => cfg.AsDelayedExchange(ExchangeType.Direct));
            // 申明队列
            var qNormal = advancedBus.QueueDeclare($"{routingKey}_delay_queue");
            // 绑定，设置好 RoutingKey
            advancedBus.Bind(exDelay, qNormal, routingKey);

            bus.Advanced.Publish(exDelay, routingKey, false, messageData);
        }

       
    }
}
