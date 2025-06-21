using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data.SeedData
{
    public class VehicleMediaData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMedia>().HasData(
            new VehicleMedia { VehicleId = 1, MediaId = 1 },
            new VehicleMedia { VehicleId = 2, MediaId = 2 },
            new VehicleMedia { VehicleId = 3, MediaId = 3 },
            new VehicleMedia { VehicleId = 4, MediaId = 4 },
            new VehicleMedia { VehicleId = 5, MediaId = 5 },
            new VehicleMedia { VehicleId = 6, MediaId = 6 },
            new VehicleMedia { VehicleId = 7, MediaId = 7 },
            new VehicleMedia { VehicleId = 8, MediaId = 8 },
            new VehicleMedia { VehicleId = 9, MediaId = 9 },
            new VehicleMedia { VehicleId = 10, MediaId = 10 }
            );
        }
    }
}
