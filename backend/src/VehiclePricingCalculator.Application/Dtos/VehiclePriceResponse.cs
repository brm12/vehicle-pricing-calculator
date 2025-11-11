namespace VehiclePricingCalculator.Application.Dtos;

public class VehiclePriceResponse
{
  public decimal TotalPrice { get; set; }
    public List<FeeDto> FeeBreakdown { get; set; } = new();
}
