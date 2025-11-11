using VehiclePricingCalculator.Application.Dtos;
using FluentValidation.TestHelper;

namespace VehiclePricingCalculator.Application.Validators.Tests;

[TestClass]
public class VehiclePriceRequestValidatorTests
{
    private VehiclePriceRequestValidator? _validator;

    [TestInitialize]
    public void Setup()
    {
        _validator = new VehiclePriceRequestValidator();
    }

    [TestMethod]
    public void Should_Have_Error_When_BasePrice_Is_Zero()
    {
        var model = new VehiclePriceRequest { BasePrice = 0, VehicleTypeId = 1 };
        var result = _validator!.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.BasePrice);
    }

    [TestMethod]
    public void Should_Have_Error_When_BasePrice_Is_Negative()
    {
        var model = new VehiclePriceRequest { BasePrice = -1, VehicleTypeId = 1 };
        var result = _validator!.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.BasePrice);
    }

    [TestMethod]
    public void Should_Not_Have_Error_When_BasePrice_Is_Positive()
    {
        var model = new VehiclePriceRequest { BasePrice = 100, VehicleTypeId = 1 };
        var result = _validator!.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.BasePrice);
    }

    [TestMethod]
    public void Should_Have_Error_When_VehicleTypeId_Is_Zero()
    {
        var model = new VehiclePriceRequest { BasePrice = 100, VehicleTypeId = 0 };
        var result = _validator!.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.VehicleTypeId);
    }

    [TestMethod]
    public void Should_Have_Error_When_VehicleTypeId_Is_Negative()
    {
        var model = new VehiclePriceRequest { BasePrice = 100, VehicleTypeId = -1 };
        var result = _validator!.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.VehicleTypeId);
    }

    [TestMethod]
    public void Should_Not_Have_Error_When_VehicleTypeId_Is_Positive()
    {
        var model = new VehiclePriceRequest { BasePrice = 100, VehicleTypeId = 1 };
        var result = _validator!.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.VehicleTypeId);
    }
}

