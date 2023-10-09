using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RETO.CodeSkills.Application.Interfaces;
using RETO.CodeSkills.Infrastructure.Persistence.DbContexts;


namespace RETO.CodeSkills.Infrastructure
{
    public static class ConfigureService1
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBRETOContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DBRETO"));

            });

            services.AddScoped<IApplicationDbContext, DBRETOContext>();

            return services;
        }
    }
}
