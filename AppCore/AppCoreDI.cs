

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure;

namespace AppCore
{
    public static class AppCoreDI
    {
        public static IServiceCollection AddAppCore(this IServiceCollection services, IConfiguration configuration)
        {
            InfrastructureDI.AddInfrastructure(services, configuration);

            return services;
        }
    }
}
