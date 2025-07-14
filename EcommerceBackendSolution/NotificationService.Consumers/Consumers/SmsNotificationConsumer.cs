using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Consumers.Consumers
{
    public class SmsNotificationConsumer : BackgroundService
    {
        private readonly ISmsSender _smsSender;
        private IModel _channel;
        private IConnection _connection;

        public SmsNotificationConsumer(ISmsSender smsSender)
        {
            _smsSender = smsSender;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "sms_queue", durable: false, exclusive: false, autoDelete: false);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                await _smsSender.SendSmsAsync("1234567890", message);
            };
            _channel.BasicConsume(queue: "sms_queue", autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }
    }
}
