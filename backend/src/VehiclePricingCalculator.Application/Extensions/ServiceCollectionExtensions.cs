using VehiclePricingCalculator.Application.ApplicationServices;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using VehiclePricingCalculator.Application.BusinessLogic;

namespace VehiclePricingCalculator.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IVehiclePricingService, VehiclePricingService>();
        services.AddScoped<IPricingCalculationService, PricingCalculationService>();
        
        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
    }
}
