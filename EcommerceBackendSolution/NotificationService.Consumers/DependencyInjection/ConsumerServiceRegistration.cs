using NotificationService.Consumers.Consumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Consumers.DependencyInjection
{
    public static class ConsumerServiceRegistration
    {
        public static IServiceCollection AddConsumerServices(this IServiceCollection services)
        {
            services.AddHostedService<EmailNotificationConsumer>();
            services.AddHostedService<SmsNotificationConsumer>();
            return services;
        }
    }
}
