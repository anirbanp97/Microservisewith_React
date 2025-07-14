using Fluent.Infrastructure.FluentStartup;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Consumers
{
    public class EmailNotificationConsumer
    {
        private readonly IModel _channel;
        private readonly EmailService _emailService;

        public EmailNotificationConsumer(IModel channel)
        {
            _channel = channel;
            _emailService = new EmailService();
        }

        public void Start()
        {
            _channel.QueueDeclare(queue: "email_notifications", durable: false, exclusive: false, autoDelete: false);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"📩 Received from Queue: {message}");
                await _emailService.SendEmailAsync("user@example.com", "Notification", message);
            };

            _channel.BasicConsume(queue: "email_notifications", autoAck: true, consumer: consumer);
        }
    }
}
