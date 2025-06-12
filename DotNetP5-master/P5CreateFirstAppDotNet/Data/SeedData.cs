using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Data;

namespace P5CreateFirstAppDotNet.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            if (context.Statuses.Any() || context.Brands.Any() || context.VehicleModels.Any() || context.Trims.Any() || context.Repairs.Any() || context.Vehicles.Any())
            {
                return; // DB has been seeded
            }

            var status1 = new Status { Name = "Disponible" };
            var status2 = new Status { Name = "Vendu" };
            var status3 = new Status { Name = "En réparation" };
            var status4 = new Status { Name = "Non disponible" };
            context.Statuses.AddRange();


            var brand1 = new Brand { Name = "Toyota" };
            var brand2 = new Brand { Name = "Ford" };
            var brand3 = new Brand { Name = "Honda" };
            var brand4 = new Brand { Name = "Chevrolet" };
            var brand5 = new Brand { Name = "Nissan" };
            var brand6 = new Brand { Name = "Volkswagen" };
            var brand7 = new Brand { Name = "Renault" };
            var brand8 = new Brand { Name = "Peugeot" };
            var brand9 = new Brand { Name = "Citroën" };
            var brand10 = new Brand { Name = "Jeep" };
            var brand11 = new Brand { Name = "Mazda" };
            context.Brands.AddRange(brand1, brand2, brand3, brand4, brand5, brand6, brand7, brand8, brand9, brand10, brand11);


            var model1 = new VehicleModel { Name = "Corolla", BrandId = 1 };
            var model2 = new VehicleModel { Name = "Focus", BrandId = 2 };
            var model3 = new VehicleModel { Name = "Civic", BrandId = 3 };
            var model4 = new VehicleModel { Name = "Impala", BrandId = 4 };
            var model5 = new VehicleModel { Name = "Altima", BrandId = 5 };
            var model6 = new VehicleModel { Name = "Golf", BrandId = 6 };
            var model7 = new VehicleModel { Name = "Clio", BrandId = 7 };
            var model8 = new VehicleModel { Name = "208", BrandId = 8 };
            var model9 = new VehicleModel { Name = "C3", BrandId = 9 };
            var model10 = new VehicleModel { Name = "Wrangler", BrandId = 10 };
            var model11 = new VehicleModel { Name = "CX-5", BrandId = 11 };
            context.VehicleModels.AddRange(model1, model2, model3, model4, model5, model6, model7, model8, model9, model10, model11);

            var trim1 = new Trim { Name = "Base", VehicleModelId = 1 };
            var trim2 = new Trim { Name = "SE", VehicleModelId = 1 };
            var trim3 = new Trim { Name = "LE", VehicleModelId = 1 };
            var trim4 = new Trim { Name = "S", VehicleModelId = 2 };
            var trim5 = new Trim { Name = "SE", VehicleModelId = 2 };
            var trim6 = new Trim { Name = "Titanium", VehicleModelId = 2 };
            var trim7 = new Trim { Name = "LX", VehicleModelId = 3 };
            var trim8 = new Trim { Name = "EX", VehicleModelId = 3 };
            var trim9 = new Trim { Name = "Touring", VehicleModelId = 3 };
            context.Trims.AddRange(trim1, trim2, trim3, trim4, trim5, trim6, trim7, trim8, trim9);

            // Ajout des réparations de base
            var repair1 = new Repair { Name = "Changement d'huile", RepairCost = 50 };
            var repair2 = new Repair { Name = "Remplacement des freins", RepairCost = 200 };
            var repair3 = new Repair { Name = "Réparation de la climatisation", RepairCost = 150 };
            context.Repairs.AddRange(repair1, repair2, repair3);

            context.SaveChanges();

            // Création des véhicules
            var vehicle1 = new Vehicle
            {
                VehicleId = 1,
                VehicleModelId = 1,
                TrimId = 1,
                VinCode = "1HGBH41JXMN109186",
                Year = 2020,
                PurchaseDate = new DateTime(2020, 1, 15),
                PurchasePrice = 15000.00,
                Description = "Toyota Corolla 2020, très bon état, faible kilométrage.",
                AvailableForSaleDate = new DateTime(2021, 1, 15),
                SaleDate = new DateTime(2021, 2, 15),
                StatusId = 2, // Vendu
                Repairs = new List<Repair> { repair1, repair2 } // réutilisation des objets Repair ajoutés en base
            };
            // Calcul automatique du SalePrice
            vehicle1.CalculateSalePrice();

            var vehicle2 = new Vehicle
            {
                VehicleId = 2,
                VehicleModelId = 2,
                TrimId = 2,
                VinCode = "1HGBH41JXMN109187",
                Year = 2021,
                PurchaseDate = new DateTime(2021, 3, 10),
                PurchasePrice = 18000.00,
                Description = "Ford Focus 2021, excellent état, très économique.",
                AvailableForSaleDate = new DateTime(2022, 3, 10),
                SaleDate = new DateTime(2022, 4, 10),
                StatusId = 2 // Vendu
                             // Pas de réparations ici
            };
            vehicle2.CalculateSalePrice();

            // Ajout en base
            context.Vehicles.AddRange(vehicle1, vehicle2);

            context.SaveChanges();
        }
    }
}
