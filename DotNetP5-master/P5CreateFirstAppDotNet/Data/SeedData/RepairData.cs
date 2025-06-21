using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data.SeedData
{
    public class RepairData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Repair>().HasData(
                new Repair { Id = 1, VehicleId = 1, RepairDate = new DateTime(2023, 3, 10), RepairCost = 500.00M, Description = "Repair description 1" },
                new Repair { Id = 2, VehicleId = 3, RepairDate = new DateTime(2023, 4, 5), RepairCost = 700.00M, Description = "Repair description 2" },
                new Repair { Id = 3, VehicleId = 4, RepairDate = new DateTime(2023, 5, 20), RepairCost = 600.00M, Description = "Repair description 3" },
                new Repair { Id = 4, VehicleId = 5, RepairDate = new DateTime(2023, 6, 30), RepairCost = 800.00M, Description = "Repair description 4" },
                new Repair { Id = 5, VehicleId = 6, RepairDate = new DateTime(2023, 7, 25), RepairCost = 900.00M, Description = "Repair description 5" },
                new Repair { Id = 6, VehicleId = 7, RepairDate = new DateTime(2023, 8, 15), RepairCost = 1000.00M, Description = "Repair description 6" },
                new Repair { Id = 7, VehicleId = 8, RepairDate = new DateTime(2023, 9, 5), RepairCost = 1100.00M, Description = "Repair description 7" },
                new Repair { Id = 8, VehicleId = 10, RepairDate = new DateTime(2023, 10, 10), RepairCost = 1200.00M, Description = "Repair description 8" }
                );

        }
    }

}
