using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppAspDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Model> Models { get; set; } = null!;
        public DbSet<Trim> Trims { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Repair> Repairs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasOne(v => v.Model)
                      .WithMany(m => m.Vehicles)
                      .HasForeignKey(v => v.ModelId);
                entity.HasOne(v => v.Trim)
                      .WithMany(t => t.Vehicles)
                      .HasForeignKey(v => v.TrimId);
                entity.HasMany(v => v.Repairs)
                      .WithOne(r => r.Vehicle)
                      .HasForeignKey(r => r.VehicleId);
                entity.Property(v => v.Status)
                        .HasConversion<string>()
                        .IsRequired();
                entity.Property(v => v.Margin).HasPrecision(18, 2);
                entity.Property(v => v.PurchasePrice).HasPrecision(18, 2);
                entity.Property(v => v.SalePrice).HasPrecision(18, 2);
            });
            modelBuilder.Entity<Repair>(entity =>
            {
                entity.Property(r => r.RepairCost).HasPrecision(18, 2);
            });
        }
    }
}
