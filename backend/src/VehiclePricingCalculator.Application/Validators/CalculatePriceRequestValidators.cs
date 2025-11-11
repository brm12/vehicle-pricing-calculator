using VehiclePricingCalculator.Application.Dtos;
using FluentValidation;

namespace VehiclePricingCalculator.Application.Validators;
public class VehiclePriceRequestValidator : AbstractValidator<VehiclePriceRequest>
{
    public VehiclePriceRequestValidator()
    {
        RuleFor(x => x.BasePrice)
            .GreaterThan(0)
            .WithMessage("Base price must be greater than 0.")
            .Must(HaveTwoDecimalPlacesOrLess)
            .WithMessage("Base price must have at most 2 decimal places.");

        RuleFor(x => x.VehicleTypeId)
            .GreaterThan(0)
            .WithMessage("Vehicle Type ID must be greater than 0.");
    }

    private bool HaveTwoDecimalPlacesOrLess(decimal basePrice)
    {
        return decimal.Round(basePrice, 2) == basePrice;
    }
}
