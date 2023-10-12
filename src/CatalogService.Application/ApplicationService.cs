using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.Application
{
    public static class ApplicationService
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
