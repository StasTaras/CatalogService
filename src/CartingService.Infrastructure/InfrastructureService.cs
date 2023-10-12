using CatalogService.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.Infrastructure
{
    public static class InfrastructureService
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("CategoryServiceDataBaseConnection"));
            });

            services.AddScoped<IApplicationDbContext>(option => option.GetService<ApplicationDbContext>());
        }
    }
}
