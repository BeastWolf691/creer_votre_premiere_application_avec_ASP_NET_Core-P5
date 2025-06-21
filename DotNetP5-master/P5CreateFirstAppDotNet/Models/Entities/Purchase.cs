using System.ComponentModel.DataAnnotations;

namespace P5CreateFirstAppDotNet.Models.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime PurchaseDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal? PurchasePrice { get; set; }

        [Required]
        public Vehicle Vehicle { get; set; } = null!;
    }
}
