

using AppCore.Interfaces;
using AppCore.Services;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppCore
{
    public static class AppCoreDI
    {
        public static IServiceCollection AddAppCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            InfrastructureDI.AddInfrastructure(services, configuration);

            services.AddScoped<IAuctionService, AuctionServiceHandler>();
            services.AddScoped<ISubjectService, SubjectService>();

            return services;
        }
    }
}
