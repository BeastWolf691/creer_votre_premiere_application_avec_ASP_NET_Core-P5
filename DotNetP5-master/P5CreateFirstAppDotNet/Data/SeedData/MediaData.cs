using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Data.SeedData
{
    public class MediaData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Media>().HasData(
                new Media { Id = 1, Label = "Car 1 Image", Path = "/images/vehicles/Car (1).jpg", TypeOfMediaId = 1 },
                new Media { Id = 2, Label = "Car 2 Image", Path = "/images/vehicles/Car (2).jpg", TypeOfMediaId = 1 },
                new Media { Id = 3, Label = "Car 3 Image", Path = "/images/vehicles/Car (3).jpg", TypeOfMediaId = 1 },
                new Media { Id = 4, Label = "Car 4 Image", Path = "/images/vehicles/Car (4).jpg", TypeOfMediaId = 1 },
                new Media { Id = 5, Label = "Car 5 Image", Path = "/images/vehicles/Car (5).jpg", TypeOfMediaId = 1 },
                new Media { Id = 6, Label = "Car 6 Image", Path = "/images/vehicles/Car (6).jpg", TypeOfMediaId = 1 },
                new Media { Id = 7, Label = "Car 7 Image", Path = "/images/vehicles/Car (7).jpg", TypeOfMediaId = 1 },
                new Media { Id = 8, Label = "Car 8 Image", Path = "/images/vehicles/Car (8).jpg", TypeOfMediaId = 1 },
                new Media { Id = 9, Label = "Car 9 Image", Path = "/images/vehicles/Car (9).jpg", TypeOfMediaId = 1 },
                new Media { Id = 10, Label = "Car 10 Image", Path = "/images/vehicles/Car (10).jpg", TypeOfMediaId = 1 }
                );
        }
    }
}
