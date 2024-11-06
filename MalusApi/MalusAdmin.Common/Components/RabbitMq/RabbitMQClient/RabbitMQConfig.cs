using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Common.Components
{
    public class RabbitMQConfig
    {
        /// <summary>
        /// RabbitMQ 有效。交换机名称。
        /// </summary>
        public string ExChangeName { get; set; } = "event_bus_exchange";

        /// <summary>
        /// RabbitMQ 有效。交换机类型。
        /// </summary>
        public string ExChangeType { get; set; } = "direct";

        /// <summary>
        /// RabbitMQ 有效。队列名称。
        /// 如果是分布式部署，若节点队列名称相同，则只会有一个节点消费消息。
        /// </summary>
        public string QueueName { get; set; } = "event_bus_queue";

        public string HostName { get; set; } = "localhost";

        public int Port { get; set; } = 5672;

        public string UserName { get; set; } = "guest";

        public string Password { get; set; } = "guest";

        public string VirtualHost { get; set; } = "";
    }
}
