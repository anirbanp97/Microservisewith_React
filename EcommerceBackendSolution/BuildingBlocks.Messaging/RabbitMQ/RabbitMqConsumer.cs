using BuildingBlocks.Messaging.Interfaces;
using BuildingBlocks.Messaging.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.RabbitMQ
{
    public class RabbitMqConsumer : IMessageConsumer
    {
        private readonly RabbitMqOptions _options;

        public RabbitMqConsumer(IOptions<RabbitMqOptions> options)
        {
            _options = options.Value;
        }

        public void Consume<T>(string queueName, Action<T> handleMessage)
        {
            var factory = new ConnectionFactory
            {
                HostName = _options.HostName,
                UserName = _options.UserName,
                Password = _options.Password
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(body));

                if (message != null)
                    handleMessage(message);
            };

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        }
    }
}
