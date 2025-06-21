using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data.SeedData
{
    public class TypeOfMediaData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeOfMedia>().HasData(
                new TypeOfMedia { Id = 1, Type = "Image" },
                new TypeOfMedia { Id = 2, Type = "PDF" },
                new TypeOfMedia { Id = 3, Type = "Doc" }
                );
        }
    }
}
