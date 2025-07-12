using IdentityService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<UserRepository>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
