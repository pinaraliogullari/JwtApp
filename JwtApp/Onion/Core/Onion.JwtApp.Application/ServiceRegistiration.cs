using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Onion.JwtApp.Application
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
