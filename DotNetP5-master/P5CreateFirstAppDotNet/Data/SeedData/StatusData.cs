using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data.SeedData
{
    public class StatusData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            if (context.Statuses.Any())
            {
                return; // DB has been seeded
            }

            var status1 = new Status { Name = "Disponible" };
            var status2 = new Status { Name = "Vendu" };
            var status3 = new Status { Name = "En réparation" };
            var status4 = new Status { Name = "Non disponible" };
            context.Statuses.AddRange(status1, status2, status3, status4);

            context.SaveChanges();
        }
    }
}
