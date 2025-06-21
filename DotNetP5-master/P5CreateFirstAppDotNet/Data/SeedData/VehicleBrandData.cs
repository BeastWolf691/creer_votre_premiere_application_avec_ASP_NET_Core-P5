using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data.SeedData
{
    public class VehicleBrandData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleBrand>().HasData(
                new VehicleBrand { Id = 1, Brand = "Toyota" },
                new VehicleBrand { Id = 2, Brand = "Ford" },
                new VehicleBrand { Id = 3, Brand = "Honda" },
                new VehicleBrand { Id = 4, Brand = "Chevrolet" },
                new VehicleBrand { Id = 5, Brand = "Nissan" },
                new VehicleBrand { Id = 6, Brand = "Volkswagen" },
                new VehicleBrand { Id = 7, Brand = "Renault" },
                new VehicleBrand { Id = 8, Brand = "Peugeot" },
                new VehicleBrand { Id = 9, Brand = "Citroën" },
                new VehicleBrand { Id = 10, Brand = "Jeep" },
                new VehicleBrand { Id = 11, Brand = "Mazda" }
            );
        }

    }
}

