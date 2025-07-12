using BuildingBlocks.Caching.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BuildingBlocks.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly IDatabase _db;

        public RedisCacheManager(IRedisConnectionFactory connectionFactory)
        {
            _db = connectionFactory.GetConnection().GetDatabase();
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _db.StringGetAsync(key);
            return value.HasValue ? JsonSerializer.Deserialize<T>(value) : default;
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            var json = JsonSerializer.Serialize(value);
            await _db.StringSetAsync(key, json, expiry);
        }

        public async Task RemoveAsync(string key)
        {
            await _db.KeyDeleteAsync(key);
        }
    }
}
