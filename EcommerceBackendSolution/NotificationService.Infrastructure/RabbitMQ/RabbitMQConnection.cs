using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MongoDB.Driver.WriteConcern;

namespace NotificationService.Infrastructure.RabbitMQ
{
    public class RabbitMQConnection
    {
        private readonly ConnectionFactory _factory;
        private IConnection _connection;

        public RabbitMQConnection(string hostname)
        {
            _factory = new ConnectionFactory() { HostName = hostname };
            _connection = _factory.CreateConnection();
        }

        public IModel CreateChannel() => _connection.CreateModel();
    }
}
