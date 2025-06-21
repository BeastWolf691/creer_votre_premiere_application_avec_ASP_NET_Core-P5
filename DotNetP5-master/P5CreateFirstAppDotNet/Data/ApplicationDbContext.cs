using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Data.SeedData;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<VehicleBrand> VehicleBrands { get; set; } = null!;
        public DbSet<VehicleModel> VehicleModels { get; set; } = null!;
        public DbSet<VehicleTrim> VehicleTrims { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Repair> Repairs { get; set; } = null!;
        public DbSet<VehicleModelVehicleTrim> VehicleModelVehicleTrims { get; set; } = null!;
        public DbSet<Media> Medias { get; set; } = null!;
        public DbSet<VehicleMedia> VehicleMedias { get; set; } = null!;
        public DbSet<TypeOfMedia> TypeOfMedias { get; set; } = null!;
        public DbSet<Purchase> Purchases { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;
        public DbSet<YearOfProduction> YearOfProductions { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleModel)
                .WithMany(vm => vm.Vehicles)
                .HasForeignKey(v => v.VehicleModelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VehicleModel>()
                .HasOne(vm => vm.VehicleBrand)
                .WithMany(vb => vb.VehicleModels)
                .HasForeignKey(vm => vm.VehicleBrandId);

            modelBuilder.Entity<VehicleModelVehicleTrim>()
                .HasOne(vmvt => vmvt.VehicleTrim)
                .WithMany(vt => vt.VehicleModelVehicleTrims)
                .HasForeignKey(vmvt => vmvt.VehicleTrimId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VehicleModelVehicleTrim>()
                .HasKey(vmvt => new { vmvt.VehicleModelId, vmvt.VehicleTrimId });

            modelBuilder.Entity<VehicleMedia>()
                .HasKey(vm => new { vm.VehicleId, vm.MediaId });

            modelBuilder.Entity<VehicleMedia>()
                .HasOne(vm => vm.Vehicle)
                .WithMany(v => v.VehicleMedia)
                .HasForeignKey(vm => vm.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VehicleMedia>()
                .HasOne(vm => vm.Media)
                .WithMany(m => m.VehicleMedia)
                .HasForeignKey(vm => vm.MediaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Purchase>()
                .Property(p => p.PurchasePrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Repair>()
                .Property(r => r.RepairCost)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Sale>()
                .Property(s => s.SalePrice)
                .HasPrecision(18, 2);

            YearOfProductionData.SeedData(modelBuilder);
            TypeOfMediaData.SeedData(modelBuilder);
            VehicleBrandData.SeedData(modelBuilder);
            VehicleModelData.SeedData(modelBuilder);
            VehicleModelVehicleTrimData.SeedData(modelBuilder);
            VehicleTrimData.SeedData(modelBuilder);
            VehicleData.SeedData(modelBuilder);
            VehicleMediaData.SeedData(modelBuilder);
            MediaData.SeedData(modelBuilder);
            PurchaseData.SeedData(modelBuilder);
            RepairData.SeedData(modelBuilder);
            SaleData.SeedData(modelBuilder);
        }

    }
}
