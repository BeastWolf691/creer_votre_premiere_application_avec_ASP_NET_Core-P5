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
        public DbSet<VehicleRepair> VehicleRepairs { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasOne(v => v.Status)
                      .WithMany(s => s.Vehicles)
                      .HasForeignKey(v => v.StatusId)
                      .OnDelete(DeleteBehavior.Restrict);


                entity.HasOne(v => v.VehicleModel)
                      .WithMany(vm => vm.Vehicles)
                      .HasForeignKey(v => v.VehicleModelId)
                      .OnDelete(DeleteBehavior.Restrict);


                entity.HasOne(v => v.Trim)
                      .WithMany(t => t.Vehicles)
                      .HasForeignKey(v => v.TrimId)
                      .OnDelete(DeleteBehavior.Restrict);
                   

                entity.Property(v => v.SalePrice).HasPrecision(18, 2);
                entity.Property(v => v.PurchasePrice).HasPrecision(18, 2);
            });

            modelBuilder.Entity<Repair>(entity =>
            {
                entity.Property(r => r.RepairCost).HasPrecision(18, 2);
                
                entity.HasMany(r => r.VehicleRepairs)
                      .WithOne(vr => vr.Repair)
                      .HasForeignKey(vr => vr.RepairId);
            });

            modelBuilder.Entity<VehicleRepair>(entity =>
            {
                entity.HasKey(vr => new { vr.VehicleId, vr.RepairId });

                entity.HasOne(vr => vr.Vehicle)
                      .WithMany(v => v.VehicleRepairs)
                      .HasForeignKey(vr => vr.VehicleId);

                entity.HasOne(vr => vr.Repair)
                      .WithMany(r => r.VehicleRepairs)
                      .HasForeignKey(vr => vr.RepairId);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasIndex(b => b.Name).IsUnique();
            });

            modelBuilder.Entity<VehicleModel>(entity =>
            {
                entity.HasIndex(vm => new { vm.Name, vm.BrandId }).IsUnique();
            });

            modelBuilder.Entity<Trim>(entity =>
            {
                entity.HasIndex(t => new { t.Name, t.VehicleModelId }).IsUnique();
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasIndex(s => s.Name).IsUnique();
            });


        }
    }
}
