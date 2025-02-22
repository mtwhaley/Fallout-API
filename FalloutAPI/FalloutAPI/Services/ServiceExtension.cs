using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace FalloutAPI.Services
{
    public static class ServiceExtensions
    {
        public static void AddMySqlDbContext<TContext>(this IServiceCollection services, IConfiguration configuration, string connectionStringName)
            where TContext : DbContext
        {
            services.AddDbContext<TContext>(options =>
                options.UseMySql(configuration.GetConnectionString(connectionStringName), 
                                new MySqlServerVersion(new System.Version(8, 0, 30))));
        }
    }
}
