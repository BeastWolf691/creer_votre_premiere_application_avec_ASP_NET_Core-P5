using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data.SeedData
{
    public class RepairData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            if (context.Repairs.Any())
            {
                return; // DB has been seeded
            }

            // Ajout des réparations de base
            var repair1 = new Repair { Name = "Changement d'huile", RepairCost = 50 };
            var repair2 = new Repair { Name = "Remplacement des freins", RepairCost = 200 };
            var repair3 = new Repair { Name = "Réparation de la climatisation", RepairCost = 150 };
            context.Repairs.AddRange(repair1, repair2, repair3);

            context.SaveChanges();
        }
    }
}
