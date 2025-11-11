using VehiclePricingCalculator.Application.Dtos;
using VehiclePricingCalculator.Domain.Entities;

namespace VehiclePricingCalculator.Application.ApplicationServices;
public interface IVehiclePricingService
{
    Task<IEnumerable<Fee>> GetAvailableFeesAsync();
    Task<(decimal totalPrice, List<FeeDto> feeBreakdown)> ComputeVehiclePriceAsync(decimal basePrice, int vehicleTypeId);
    Task<IEnumerable<VehicleType>> GetSupportedVehicleTypesAsync();
}
