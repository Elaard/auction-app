using AuctionService.Interfaces;
using AuctionService.Services;

namespace AuctionService
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
