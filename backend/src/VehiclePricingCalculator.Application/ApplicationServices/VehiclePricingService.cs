using VehiclePricingCalculator.Application.Dtos;
using VehiclePricingCalculator.Application.BusinessLogic;
using VehiclePricingCalculator.Domain.Entities;
using VehiclePricingCalculator.Domain.Repositories;

namespace VehiclePricingCalculator.Application.ApplicationServices;
public class VehiclePricingService(IVehiclePricingRepository vehiclePricingRepository, IPricingCalculationService pricingCalculator) : IVehiclePricingService
{
    public async Task<IEnumerable<Fee>> GetAvailableFeesAsync()
    {
        return await vehiclePricingRepository.GetFeesAsync();
    }

    public async Task<(decimal totalPrice, List<FeeDto> feeBreakdown)> ComputeVehiclePriceAsync(decimal basePrice, int vehicleTypeId)
    {
        var fees = await vehiclePricingRepository.GetFeesAsync();
        var (totalFee, feeDetails) = pricingCalculator.ComputeFees(basePrice, vehicleTypeId, fees.ToList());

        var feeDetailDtos = feeDetails.Select(fd => FeeMapper.ToDto(fd.fee, fd.calculatedFee)).ToList();

        return (basePrice + totalFee, feeDetailDtos);
    }

    public async Task<IEnumerable<VehicleType>> GetSupportedVehicleTypesAsync()
    {
        return await vehiclePricingRepository.GetVehicleTypesAsync();
    }

}