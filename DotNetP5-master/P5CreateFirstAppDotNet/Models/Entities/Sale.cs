using System.ComponentModel.DataAnnotations;

namespace P5CreateFirstAppDotNet.Models.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime? SaleDate { get; set; }
        //[Column(TypeName = "decimal(18,2)")]        
        [DataType(DataType.Currency)]
        public decimal SalePrice { get; set; }

        [Required]
        public Vehicle Vehicle { get; set; } = null!;
    }
}
