using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data.SeedData
{
    public class TrimData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            if (context.Trims.Any())
            {
                return; // DB has been seeded
            }

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

            context.SaveChanges();
        }
    }
}
