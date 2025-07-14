
using BuildingBlocks.Messaging.Interfaces;
using BuildingBlocks.Messaging.Models;
using BuildingBlocks.Messaging.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitMqMessaging(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMqOptions>(configuration.GetSection("RabbitMq"));
            services.AddSingleton<IMessagePublisher, RabbitMqPublisher>();
            services.AddSingleton<IMessageConsumer, RabbitMqConsumer>();
            return services;
        }
    }
}
