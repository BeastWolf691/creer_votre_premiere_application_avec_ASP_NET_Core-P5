using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Data;

namespace P5CreateFirstAppDotNet.Data
{
    public class BrandData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            if (context.Brands.Any())
            {
                return; // DB has been seeded
            }

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

            context.SaveChanges();
        }
    }
}

