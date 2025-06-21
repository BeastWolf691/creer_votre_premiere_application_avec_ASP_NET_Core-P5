using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data.SeedData
{
    public class VehicleTrimData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleTrim>().HasData(

            new VehicleTrim { Id = 1, TrimLabel = "Base" },
            new VehicleTrim { Id = 2, TrimLabel = "SE" },
            new VehicleTrim { Id = 3, TrimLabel = "LE" },
            new VehicleTrim { Id = 4, TrimLabel = "S" },
            new VehicleTrim { Id = 5, TrimLabel = "SE" },
            new VehicleTrim { Id = 6, TrimLabel = "Titanium" },
            new VehicleTrim { Id = 7, TrimLabel = "LX" },
            new VehicleTrim { Id = 8, TrimLabel = "EX" },
            new VehicleTrim { Id = 9, TrimLabel = "Touring" }
            );
        }
    }
}
