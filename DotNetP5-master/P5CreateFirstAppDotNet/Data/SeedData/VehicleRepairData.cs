using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data.SeedData
{
    public class VehicleRepairData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (context.VehicleRepairs.Any())
            {
                return;
            }

            // Exemple : Le véhicule avec l'ID 1 a eu deux réparations (ID 1 et 2)
            var vr1 = new VehicleRepair { VehicleId = 1, RepairId = 1 };
            var vr2 = new VehicleRepair { VehicleId = 1, RepairId = 2 };

            // Le véhicule 2 a eu une seule réparation
            var vr3 = new VehicleRepair { VehicleId = 2, RepairId = 3 };

            context.VehicleRepairs.AddRange(vr1, vr2, vr3);
            context.SaveChanges();

            //Récupérer les véhicules concernés avec leurs réparations
            var vehiclesWithRepairs = context.Vehicles
                .Include(v => v.VehicleRepairs)
                .ThenInclude(vr => vr.Repair)
                .ToList();

            //Calculer le salePrice pour chaque véhicule
            foreach (var vehicle in vehiclesWithRepairs)
            {
                vehicle.CalculateSalePrice();
            }

            // Sauvegarder les modifications
            context.SaveChanges();
        }
    }
}
