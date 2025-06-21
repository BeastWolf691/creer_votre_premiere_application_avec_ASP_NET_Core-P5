using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data.SeedData
{
    public class VehicleModelData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleModel>().HasData(

            new VehicleModel { Id = 1, Model = "Corolla", VehicleBrandId = 1 },
            new VehicleModel { Id = 2, Model = "Focus", VehicleBrandId = 2 },
            new VehicleModel { Id = 3, Model = "Civic", VehicleBrandId = 3 },
            new VehicleModel { Id = 4, Model = "Impala", VehicleBrandId = 4 },
            new VehicleModel { Id = 5, Model = "Altima", VehicleBrandId = 5 },
            new VehicleModel { Id = 6, Model = "Golf", VehicleBrandId = 6 },
            new VehicleModel { Id = 7, Model = "Clio", VehicleBrandId = 7 },
            new VehicleModel { Id = 8, Model = "208", VehicleBrandId = 8 },
            new VehicleModel { Id = 9, Model = "C3", VehicleBrandId = 9 },
            new VehicleModel { Id = 10, Model = "Wrangler", VehicleBrandId = 10 },
            new VehicleModel { Id = 11, Model = "CX-5", VehicleBrandId = 11 }
            );
        }
    }
}
