using VehiclePricingCalculator.Domain.Entities;
using VehiclePricingCalculator.Domain.Repositories;
using VehiclePricingCalculator.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace VehiclePricingCalculator.Infrastructure.Repositories;
internal class VehiclePricingRepository(VehicleBidDbContext dbContext) : IVehiclePricingRepository
{
    public async Task<IEnumerable<Fee>> GetFeesAsync()
    {
        return await dbContext.Fees
            .Include(f => f.FeeType)
            .Include(f => f.VehicleType)
            .ToListAsync();
    }

    public async Task<IEnumerable<VehicleType>> GetVehicleTypesAsync()
    {
        return await dbContext.VehicleTypes.ToListAsync();
    }
}
