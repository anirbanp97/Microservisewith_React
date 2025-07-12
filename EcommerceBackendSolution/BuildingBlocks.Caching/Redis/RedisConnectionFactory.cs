using BuildingBlocks.Caching.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Caching.Redis
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        private readonly Lazy<ConnectionMultiplexer> _connection;

        public RedisConnectionFactory(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Redis") ?? "localhost";
            _connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(connectionString));
        }

        public ConnectionMultiplexer GetConnection() => _connection.Value;
    }
}
