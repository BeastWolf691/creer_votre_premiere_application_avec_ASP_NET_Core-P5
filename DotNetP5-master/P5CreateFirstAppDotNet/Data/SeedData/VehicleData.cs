using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data.SeedData
{
    public class VehicleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            if (context.Vehicles.Any())
            {
                return; // DB has been seeded
            }


            // Création des véhicules
            var vehicle1 = new Vehicle
            {
                VehicleModelId = 1,
                TrimId = 1,
                VinCode = "1HGBH41JXMN109186",
                Year = 2020,
                PurchaseDate = new DateTime(2020, 1, 15),
                PurchasePrice = 15000.00,
                Description = "Toyota Corolla 2020, très bon état, faible kilométrage.",
                AvailableForSaleDate = new DateTime(2021, 1, 15),
                SaleDate = new DateTime(2021, 2, 15),
                StatusId = 2, // Vendu,
                ImagePath = "images/vehicles/default.png",
            };

            var vehicle2 = new Vehicle
            {
                VehicleModelId = 2,
                TrimId = 2,
                VinCode = "1HGBH41JXMN109187",
                Year = 2021,
                PurchaseDate = new DateTime(2021, 3, 10),
                PurchasePrice = 18000.00,
                Description = "Ford Focus 2021, excellent état, très économique.",
                AvailableForSaleDate = new DateTime(2022, 3, 10),
                SaleDate = new DateTime(2022, 4, 10),
                StatusId = 2, // Vendu,
                ImagePath = "images/vehicles/default.png",
            };

            // Ajout en base
            context.Vehicles.AddRange(vehicle1, vehicle2);

            context.SaveChanges();
        }
    }
}
