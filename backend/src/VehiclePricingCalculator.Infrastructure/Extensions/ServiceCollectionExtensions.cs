using VehiclePricingCalculator.Domain.Repositories;
using VehiclePricingCalculator.Infrastructure.Persistence;
using VehiclePricingCalculator.Infrastructure.Repositories;
using VehiclePricingCalculator.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VehiclePricingCalculator.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VehicleBidDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("VehiclePricingDb")));

        services.AddScoped<IFeeSeeder, FeeSeeder>();
        services.AddScoped<IVehiclePricingRepository, VehiclePricingRepository>();
    }
}
