using Humanizer;
using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data.SeedData
{
    public class VehicleData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, Label = "Vehicle 1", VIN = "1HGCM82633A123456", Description = "Vehicle description 1", YearOfProductionId = 1, VehicleBrandId = 1, VehicleModelId = 4, VehicleTrimId = 1, Status = VehicleStatus.Disponible },
                new Vehicle { Id = 2, Label = "Vehicle 2", VIN = "1HGCM82633A654321", Description = "Vehicle description 2", YearOfProductionId = 2, VehicleBrandId = 2, VehicleModelId = 2, VehicleTrimId = 1, Status = VehicleStatus.Maintenance },
                new Vehicle { Id = 3, Label = "Vehicle 3", VIN = "1HGCM82633A789456", Description = "Vehicle description 3", YearOfProductionId = 3, VehicleBrandId = 3, VehicleModelId = 3, VehicleTrimId = 2, Status = VehicleStatus.Maintenance },
                new Vehicle { Id = 4, Label = "Vehicle 4", VIN = "1HGCM82633A987654", Description = "Vehicle description 4", YearOfProductionId = 4, VehicleBrandId = 4, VehicleModelId = 4, VehicleTrimId = 3, Status = VehicleStatus.Disponible },
                new Vehicle { Id = 5, Label = "Vehicle 5", VIN = "1HGCM82633A456789", Description = "Vehicle description 5", YearOfProductionId = 5, VehicleBrandId = 5, VehicleModelId = 5, VehicleTrimId = 4, Status = VehicleStatus.Vendu },
                new Vehicle { Id = 6, Label = "Vehicle 6", VIN = "1HGCM82633A321654", Description = "Vehicle description 6", YearOfProductionId = 6, VehicleBrandId = 6, VehicleModelId = 6, VehicleTrimId = 5, Status = VehicleStatus.Disponible },
                new Vehicle { Id = 7, Label = "Vehicle 7", VIN = "1HGCM82633A159753", Description = "Vehicle description 7", YearOfProductionId = 7, VehicleBrandId = 7, VehicleModelId = 7, VehicleTrimId = 6, Status = VehicleStatus.Disponible },
                new Vehicle { Id = 8, Label = "Vehicle 8", VIN = "1HGCM82633A357951", Description = "Vehicle description 8", YearOfProductionId = 8, VehicleBrandId = 8, VehicleModelId = 8, VehicleTrimId = 7, Status = VehicleStatus.Vendu },
                new Vehicle { Id = 9, Label = "Vehicle 9", VIN = "1HGCM82633A753159", Description = "Vehicle description 9", YearOfProductionId = 9, VehicleBrandId = 9, VehicleModelId = 9, VehicleTrimId = 8, Status = VehicleStatus.Maintenance },
                new Vehicle { Id = 10, Label = "Vehicle 10", VIN = "1HGCM82633A852963", Description = "Vehicle description 10", YearOfProductionId = 10, VehicleBrandId = 10, VehicleModelId = 10, VehicleTrimId = 9, Status = VehicleStatus.Disponible }
                );
        }
    }

}
