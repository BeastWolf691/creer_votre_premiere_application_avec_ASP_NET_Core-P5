using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data.SeedData
{
    public class SaleData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().HasData(
                new Sale { Id = 1, VehicleId = 5, SaleDate = new DateTime(2023, 1, 15), SalePrice = 20000.00M },
                new Sale { Id = 2, VehicleId = 3, SaleDate = new DateTime(2023, 2, 20), SalePrice = 15000.00M }
            );
        }
    }
}
