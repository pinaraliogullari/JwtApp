using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Persistence.Context;
using Onion.JwtApp.Persistence.Repositories;

namespace Onion.JwtApp.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OnionJwtContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
