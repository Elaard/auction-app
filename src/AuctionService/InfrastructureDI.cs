using AuctionService.Interfaces;
using AuctionService.Repositories;
using Microsoft.EntityFrameworkCore;


namespace AuctionService
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuctionDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("NpgsqlConnection"));
            });

            services.AddScoped<IAuctionRepository, AuctionRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();

            return services;
        }
    }
}
