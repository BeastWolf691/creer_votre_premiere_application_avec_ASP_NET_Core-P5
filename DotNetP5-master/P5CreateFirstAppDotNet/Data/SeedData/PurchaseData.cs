using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data.SeedData
{
    public class PurchaseData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>().HasData(
                new Purchase { Id = 1, VehicleId = 1, PurchaseDate = new DateTime(2023, 1, 15), PurchasePrice = 15000.00M },
                new Purchase { Id = 2, VehicleId = 2, PurchaseDate = new DateTime(2023, 2, 20), PurchasePrice = 20000.00M },
                new Purchase { Id = 3, VehicleId = 3, PurchaseDate = new DateTime(2023, 3, 10), PurchasePrice = 18000.00M },
                new Purchase { Id = 4, VehicleId = 4, PurchaseDate = new DateTime(2023, 4, 5), PurchasePrice = 22000.00M },
                new Purchase { Id = 5, VehicleId = 5, PurchaseDate = new DateTime(2023, 5, 25), PurchasePrice = 25000.00M },
                new Purchase { Id = 6, VehicleId = 6, PurchaseDate = new DateTime(2023, 6, 30), PurchasePrice = 30000.00M },
                new Purchase { Id = 7, VehicleId = 7, PurchaseDate = new DateTime(2023, 7, 15), PurchasePrice = 27000.00M },
                new Purchase { Id = 8, VehicleId = 8, PurchaseDate = new DateTime(2023, 8, 20), PurchasePrice = 32000.00M },
                new Purchase { Id = 9, VehicleId = 9, PurchaseDate = new DateTime(2023, 9, 10), PurchasePrice = 29000.00M }
                );
        }
    }
}
