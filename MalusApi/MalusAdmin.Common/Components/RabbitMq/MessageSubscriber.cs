//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using EasyNetQ;
//using Microsoft.Extensions.Hosting;

//namespace MalusAdmin.Common.Components.RabbitMq
//{
//    public class MessageSubscriber : IHostedService
//    {
//        private readonly IBus _bus;
//        private IDisposable _subscription;

//        public MessageSubscriber(IBus bus)
//        {
//            _bus = bus;
//        }

//        public Task StartAsync(CancellationToken cancellationToken)
//        {
//            //_subscription=_bu
//            //_subscription = _bus.Subscribe<RabbitMessage>("my_subscription_id", HandleMessage);
//            return Task.CompletedTask;
//        }

//        private void HandleMessage(object message)
//        {
//            Console.WriteLine($"Received message: {message.Text}");
//        }

//        public Task StopAsync(CancellationToken cancellationToken)
//        {
//            _subscription?.Dispose();
//            return Task.CompletedTask;
//        }
//    }
//}
