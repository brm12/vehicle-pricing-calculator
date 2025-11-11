using VehiclePricingCalculator.Domain.Entities;

namespace VehiclePricingCalculator.Application.BusinessLogic;
public interface IPricingCalculationService
{
    (decimal totalFee, List<(Fee fee, decimal calculatedFee)> feeDetails) ComputeFees(decimal basePrice, int vehicleTypeId, List<Fee> fees);
    (decimal calculatedFee, List<Fee> appliedFees) ProcessFee(decimal basePrice, int vehicleTypeId, Fee fee);
}