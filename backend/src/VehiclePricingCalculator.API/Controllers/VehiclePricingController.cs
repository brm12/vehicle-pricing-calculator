using VehiclePricingCalculator.Application.ApplicationServices;
using VehiclePricingCalculator.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace VehiclePricingCalculator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclePricingController(
    IVehiclePricingService vehiclePricingService,
    IValidator<VehiclePriceRequest> validator) : ControllerBase
{
    private readonly IVehiclePricingService _vehiclePricingService = vehiclePricingService;
    private readonly IValidator<VehiclePriceRequest> _validator = validator;

    [HttpGet("fees")]
    public async Task<IActionResult> GetAvailableFeesAsync()
    {
        var fees = await _vehiclePricingService.GetAvailableFeesAsync();
        return Ok(fees);
    }

    [HttpGet("vehicleTypes")]
    public async Task<IActionResult> GetSupportedVehicleTypesAsync()
    {
        var vehicleTypes = await _vehiclePricingService.GetSupportedVehicleTypesAsync();
        return Ok(vehicleTypes);
    }

    [HttpPost("calculate")]
    public async Task<ActionResult<VehiclePriceResponse>> ComputeVehiclePriceAsync([FromBody] VehiclePriceRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(new
            {
                Errors = validationResult.Errors.Select(e => new
                {
                    Property = e.PropertyName,
                    Message = e.ErrorMessage
                })
            });
        }

        var (totalPrice, feeBreakdown) = await _vehiclePricingService.ComputeVehiclePriceAsync(request.BasePrice, request.VehicleTypeId);

        var response = new VehiclePriceResponse
        {
            TotalPrice = totalPrice,
            FeeBreakdown = feeBreakdown
        };

        return Ok(response);
    }
}
