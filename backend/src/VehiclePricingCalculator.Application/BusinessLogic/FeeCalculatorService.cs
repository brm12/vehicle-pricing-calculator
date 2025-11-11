using VehiclePricingCalculator.Domain.Entities;

namespace VehiclePricingCalculator.Application.BusinessLogic;

public class PricingCalculationService : IPricingCalculationService
{
    private const int CURRENCY_DECIMAL_PLACES = 2;

    public (decimal calculatedFee, List<Fee> appliedFees) ProcessFee(decimal basePrice, int vehicleTypeId, Fee fee)
    {
        if (fee == null)
            throw new ArgumentNullException(nameof(fee));

        if (IsVehicleTypeMismatch(fee, vehicleTypeId))
            return (0, new List<Fee>());

        var appliedFees = new List<Fee>();
        decimal calculatedFee = 0;

        if (HasFixedAmount(fee))
        {
            if (fee.MinPriceAmount.HasValue || fee.MaxPriceAmount.HasValue)
            {
                if (IsWithinPriceRange(fee, basePrice))
                {
                    calculatedFee = fee.FixedAmount!.Value;
                    appliedFees.Add(fee);
                }
            }
            else
            {
                calculatedFee = fee.FixedAmount!.Value;
                appliedFees.Add(fee);
            }
        }
        else if (HasPercentage(fee))
        {
            calculatedFee = basePrice * fee.Percentage!.Value;
            appliedFees.Add(fee);

            if (IsBelowMinFee(fee, calculatedFee))
                calculatedFee = fee.MinFeeAmount!.Value;

            if (IsAboveMaxFee(fee, calculatedFee))
                calculatedFee = fee.MaxFeeAmount!.Value;
        }

        return (calculatedFee, appliedFees);
    }

    public (decimal totalFee, List<(Fee fee, decimal calculatedFee)> feeDetails) ComputeFees(decimal basePrice, int vehicleTypeId, List<Fee> fees)
    {
        if (basePrice < 0)
            throw new ArgumentException("Base price cannot be negative.", nameof(basePrice));
        
        if (fees == null)
            throw new ArgumentNullException(nameof(fees));
        
        if (vehicleTypeId <= 0)
            throw new ArgumentException("Vehicle type ID must be greater than zero.", nameof(vehicleTypeId));

        decimal totalFee = 0;
        var feeDetails = new List<(Fee fee, decimal calculatedFee)>();

        foreach (var fee in fees)
        {
            var (calculatedFee, appliedFees) = ProcessFee(basePrice, vehicleTypeId, fee);
            if (calculatedFee == 0)
                continue;

            calculatedFee = Math.Round(calculatedFee, CURRENCY_DECIMAL_PLACES);
            totalFee += calculatedFee;
            feeDetails.Add((fee, calculatedFee));
        }

        totalFee = Math.Round(totalFee, CURRENCY_DECIMAL_PLACES);
        return (totalFee, feeDetails);
    }

    private bool IsVehicleTypeMismatch(Fee fee, int vehicleTypeId)
    {
        return fee.VehicleType != null && fee.VehicleType.Id != vehicleTypeId;
    }

    private bool HasPercentage(Fee fee)
    {
        return fee.Percentage.HasValue;
    }

    private bool IsBelowMinFee(Fee fee, decimal calculatedFee)
    {
        return fee.MinFeeAmount.HasValue && calculatedFee < fee.MinFeeAmount.Value;
    }

    private bool IsAboveMaxFee(Fee fee, decimal calculatedFee)
    {
        return fee.MaxFeeAmount.HasValue && calculatedFee > fee.MaxFeeAmount.Value;
    }

    private bool IsWithinPriceRange(Fee fee, decimal basePrice)
    {
        bool isAboveMin = !fee.MinPriceAmount.HasValue || basePrice >= fee.MinPriceAmount.Value;
        bool isBelowMax = !fee.MaxPriceAmount.HasValue || basePrice <= fee.MaxPriceAmount.Value;
        return isAboveMin && isBelowMax;
    }

    private bool HasFixedAmount(Fee fee)
    {
        return fee.FixedAmount.HasValue;
    }
}