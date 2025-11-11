using VehiclePricingCalculator.Domain.Entities;

namespace VehiclePricingCalculator.Application.Dtos;

public class FeeDto
{
    public int Id { get; set; }
    public int FeeTypeId { get; set; }
    public string FeeTypeName { get; set; } = string.Empty;
    public decimal CalculatedFee { get; set; }
}

public static class FeeMapper
{
    public static FeeDto ToDto(Fee fee, decimal calculatedFee)
    {
        return new FeeDto
        {
            Id = fee.Id,
            FeeTypeId = fee.FeeType.Id,
            FeeTypeName = fee.FeeType.Name,
            CalculatedFee = calculatedFee
        };
    }
}
