using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Middleware.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<BuildingBlocks.Middleware.Middleware.ExceptionMiddleware>();
            app.UseMiddleware<BuildingBlocks.Middleware.Middleware.RequestLoggingMiddleware>();
            return app;
        }
    }
}
