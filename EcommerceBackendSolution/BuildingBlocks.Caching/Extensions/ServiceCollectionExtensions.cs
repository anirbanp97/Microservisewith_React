using BuildingBlocks.Caching.Interfaces;
using BuildingBlocks.Caching.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Caching.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRedisCaching(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRedisConnectionFactory, RedisConnectionFactory>();
            services.AddScoped<ICacheManager, RedisCacheManager>();
            return services;
        }
    }
}
