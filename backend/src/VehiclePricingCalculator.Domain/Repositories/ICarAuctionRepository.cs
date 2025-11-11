using VehiclePricingCalculator.Domain.Entities;

namespace VehiclePricingCalculator.Domain.Repositories;
public interface IVehiclePricingRepository
{
    Task<IEnumerable<Fee>> GetFeesAsync();
    Task<IEnumerable<VehicleType>> GetVehicleTypesAsync();
}
