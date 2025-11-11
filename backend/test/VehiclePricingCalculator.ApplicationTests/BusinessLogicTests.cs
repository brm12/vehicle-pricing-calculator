using VehiclePricingCalculator.Application.BusinessLogic;
using VehiclePricingCalculator.Domain.Entities;

namespace VehiclePricingCalculator.Tests;

[TestClass]
public class BusinessLogicTests
{
    private readonly PricingCalculationService _calculator = new();

    [TestMethod]
    public void TestCase_398_Common_ShouldEqual_550_76()
    {
        decimal basePrice = 398.00m;
        int vehicleTypeId = 1; 
        var fees = GetTestFees();
        
        var (totalFee, feeDetails) = _calculator.ComputeFees(basePrice, vehicleTypeId, fees);
        var totalPrice = basePrice + totalFee;
        
        Assert.AreEqual(550.76m, Math.Round(totalPrice, 2));
    }

    [TestMethod]
    public void TestCase_501_Common_ShouldEqual_671_02()
    {
        decimal basePrice = 501.00m;
        int vehicleTypeId = 1; 
        var fees = GetTestFees();
        
        var (totalFee, feeDetails) = _calculator.ComputeFees(basePrice, vehicleTypeId, fees);
        var totalPrice = basePrice + totalFee;
        
        Assert.AreEqual(671.02m, Math.Round(totalPrice, 2));
    }

    [TestMethod]
    public void TestCase_57_Common_ShouldEqual_173_14()
    {
        decimal basePrice = 57.00m;
        int vehicleTypeId = 1; 
        var fees = GetTestFees();
        
        var (totalFee, feeDetails) = _calculator.ComputeFees(basePrice, vehicleTypeId, fees);
        var totalPrice = basePrice + totalFee;
        
        Assert.AreEqual(173.14m, Math.Round(totalPrice, 2));
    }

    [TestMethod]
    public void TestCase_1800_Luxury_ShouldEqual_2167_00()
    {
        decimal basePrice = 1800.00m;
        int vehicleTypeId = 2; 
        var fees = GetTestFees();
        
        var (totalFee, feeDetails) = _calculator.ComputeFees(basePrice, vehicleTypeId, fees);
        var totalPrice = basePrice + totalFee;
        
        Assert.AreEqual(2167.00m, Math.Round(totalPrice, 2));
    }

    [TestMethod]
    public void TestCase_1100_Common_ShouldEqual_1287_00()
    {
        decimal basePrice = 1100.00m;
        int vehicleTypeId = 1; 
        var fees = GetTestFees();
        
        var (totalFee, feeDetails) = _calculator.ComputeFees(basePrice, vehicleTypeId, fees);
        var totalPrice = basePrice + totalFee;
        
        Assert.AreEqual(1287.00m, Math.Round(totalPrice, 2));
    }

    [TestMethod]
    public void TestCase_1000000_Luxury_ShouldEqual_1040320_00()
    {
        decimal basePrice = 1000000.00m;
        int vehicleTypeId = 2; 
        var fees = GetTestFees();
        
        var (totalFee, feeDetails) = _calculator.ComputeFees(basePrice, vehicleTypeId, fees);
        var totalPrice = basePrice + totalFee;
        
        Assert.AreEqual(1040320.00m, Math.Round(totalPrice, 2));
    }

    [TestMethod]
    public void ComputeFees_WithMinimumFee_ShouldApplyMinimum()
    {
        decimal basePrice = 50m;
        int vehicleTypeId = 1;
        var fees = GetTestFees();
        
        var (totalFee, feeDetails) = _calculator.ComputeFees(basePrice, vehicleTypeId, fees);
        
        var buyerFee = feeDetails.FirstOrDefault(f => f.fee.FeeType.Name == "Buyer");
        Assert.IsNotNull(buyerFee.fee);
        Assert.AreEqual(10m, buyerFee.calculatedFee);
    }

    [TestMethod]
    public void ComputeFees_WithMaximumFee_ShouldApplyMaximum()
    {
        decimal basePrice = 1000m;
        int vehicleTypeId = 1;
        var fees = GetTestFees();
        
        var (totalFee, feeDetails) = _calculator.ComputeFees(basePrice, vehicleTypeId, fees);
        
        var buyerFee = feeDetails.FirstOrDefault(f => f.fee.FeeType.Name == "Buyer");
        Assert.IsNotNull(buyerFee.fee);
        Assert.AreEqual(50m, buyerFee.calculatedFee);
    }

    private List<Fee> GetTestFees()
    {
        return new List<Fee>
        {
            new Fee
            {
                Id = 1,
                Percentage = 0.1m,
                MinFeeAmount = 10,
                MaxFeeAmount = 50,
                FeeTypeId = 1,
                VehicleTypeId = 1,
                FeeType = new FeeType { Id = 1, Name = "Buyer" },
                VehicleType = new VehicleType { Id = 1, Name = "Common" }
            },
            new Fee
            {
                Id = 2,
                Percentage = 0.1m,
                MinFeeAmount = 25,
                MaxFeeAmount = 200,
                FeeTypeId = 1,
                VehicleTypeId = 2,
                FeeType = new FeeType { Id = 1, Name = "Buyer" },
                VehicleType = new VehicleType { Id = 2, Name = "Luxury" }
            },
            new Fee
            {
                Id = 3,
                Percentage = 0.02m,
                FeeTypeId = 2,
                VehicleTypeId = 1,
                FeeType = new FeeType { Id = 2, Name = "Seller" },
                VehicleType = new VehicleType { Id = 1, Name = "Common" }
            },
            new Fee
            {
                Id = 4,
                Percentage = 0.04m,
                FeeTypeId = 2,
                VehicleTypeId = 2,
                FeeType = new FeeType { Id = 2, Name = "Seller" },
                VehicleType = new VehicleType { Id = 2, Name = "Luxury" }
            },
            new Fee
            {
                Id = 5,
                FixedAmount = 5,
                MinPriceAmount = 1,
                MaxPriceAmount = 500,
                FeeTypeId = 3,
                FeeType = new FeeType { Id = 3, Name = "Association" }
            },
            new Fee
            {
                Id = 6,
                FixedAmount = 10,
                MinPriceAmount = 500,
                MaxPriceAmount = 1000,
                FeeTypeId = 3,
                FeeType = new FeeType { Id = 3, Name = "Association" }
            },
            new Fee
            {
                Id = 7,
                FixedAmount = 15,
                MinPriceAmount = 1000,
                MaxPriceAmount = 3000,
                FeeTypeId = 3,
                FeeType = new FeeType { Id = 3, Name = "Association" }
            },
            new Fee
            {
                Id = 8,
                FixedAmount = 20,
                MinPriceAmount = 3000,
                FeeTypeId = 3,
                FeeType = new FeeType { Id = 3, Name = "Association" }
            },
            new Fee
            {
                Id = 9,
                FixedAmount = 100,
                FeeTypeId = 4,
                FeeType = new FeeType { Id = 4, Name = "Storage" }
            }
        };
    }
}