using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<VehicleModel> VehicleModels { get; set; } = null!;
        public DbSet<Trim> Trims { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Repair> Repairs { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasMany(v => v.Repairs)
                      .WithOne(r => r.Vehicle)
                      .HasForeignKey(r => r.VehicleId);

                entity.HasOne(v => v.Status)
                      .WithMany(s => s.Vehicles)
                      .HasForeignKey(v => v.StatusId)
                      .IsRequired();

                entity.HasOne(v => v.VehicleModel)
                      .WithMany(vm => vm.Vehicles)
                      .HasForeignKey(v => v.VehicleModelId)
                      .IsRequired();

                entity.HasOne(v => v.Trim)
                      .WithMany(t => t.Vehicles)
                      .HasForeignKey(v => v.TrimId)
                      .IsRequired();

                entity.Property(v => v.SalePrice).HasPrecision(18, 2);
                entity.Property(v => v.PurchasePrice).HasPrecision(18, 2);
            });
            modelBuilder.Entity<Repair>(entity =>
            {
                entity.Property(r => r.RepairCost).HasPrecision(18, 2);
            });
        }
    }
}
