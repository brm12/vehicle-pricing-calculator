using VehiclePricingCalculator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace VehiclePricingCalculator.Infrastructure.Persistence;
internal class VehicleBidDbContext(DbContextOptions<VehicleBidDbContext> options) : DbContext(options)
{
    public DbSet<Fee> Fees { get; set; }
    public DbSet<FeeType> FeeTypes { get; set; }
    public DbSet<VehicleType> VehicleTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var feeEntity = modelBuilder.Entity<Fee>();

        feeEntity.HasOne(f => f.FeeType)
            .WithMany()
            .HasForeignKey(f => f.FeeTypeId);

        feeEntity.HasOne(f => f.VehicleType)
            .WithMany()
            .HasForeignKey(f => f.VehicleTypeId);

        feeEntity.Property(f => f.Percentage).HasPrecision(18, 2);
        feeEntity.Property(f => f.MinPriceAmount).HasPrecision(18, 2);
        feeEntity.Property(f => f.MaxPriceAmount).HasPrecision(18, 2);
        feeEntity.Property(f => f.MinFeeAmount).HasPrecision(18, 2);
        feeEntity.Property(f => f.MaxFeeAmount).HasPrecision(18, 2);
        feeEntity.Property(f => f.FixedAmount).HasPrecision(18, 2);
    }
}
