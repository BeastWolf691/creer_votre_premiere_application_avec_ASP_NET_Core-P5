using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data.SeedData
{
    public class VehicleModelData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            if (context.VehicleModels.Any())
            {
                return; // DB has been seeded
            }

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

            context.SaveChanges();
        }
    }
}
