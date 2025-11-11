namespace VehiclePricingCalculator.Application.Dtos;
public class VehiclePriceRequest
{
    public decimal BasePrice { get; set; }
    public int VehicleTypeId { get; set; } = default!;
}
