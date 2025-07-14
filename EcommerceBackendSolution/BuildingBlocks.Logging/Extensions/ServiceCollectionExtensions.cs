using BuildingBlocks.Logging.Interfaces;
using BuildingBlocks.Logging.MongoLogger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Logging.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoLogger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ILogWriter, MongoLogWriter>();
            return services;
        }
    }
}
