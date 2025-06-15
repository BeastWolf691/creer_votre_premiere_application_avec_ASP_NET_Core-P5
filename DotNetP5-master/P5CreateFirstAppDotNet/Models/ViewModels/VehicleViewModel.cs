using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.ViewModels
{
    public class VehicleViewModel
    {

        [BindNever]
        public int VehicleId { get; set; }

        [StringLength(17, MinimumLength =11, ErrorMessage = "Le code VIN doit contenir entre 11 et 17 caractères.")]
        [RegularExpression(@"^[A-HJ-NPR-Z0-9]+$", ErrorMessage = "Le code VIN contient des caractères invalides.")]
        public string VinCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'année est requise.")]
        [Range(1990, 2100, ErrorMessage = "L'année doit être supérieure ou égale à 1990.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "La marque est requise.")]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Le modèle est requis.")]
        public int VehicleModelId { get; set; }

        [Required(ErrorMessage = "La finition est requise.")]
        public int TrimId { get; set; }

        [Required(ErrorMessage = "La date d'achat est requise.")]
        [DataType(DataType.Date, ErrorMessage = "La date d'achat doit être au format valide.")]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "Le prix d'achat est requis.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Le prix d'achat doit être un nombre valide avec jusqu'à deux décimales.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix d'achat doit être supérieur à zéro.")]
        public string PurchasePrice { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères.")]
        public string? Description { get; set; }

        public DateTime? AvailableForSaleDate { get; set; }

        public string? SalePrice { get; set; } 

        public DateTime? SaleDate { get; set; }

        [Required(ErrorMessage = "Le statut du véhicule est requis.")]
        public int StatusId { get; set; }

        public IFormFile? ImageFile { get; set; }
        public string? ImagePath { get; set; }

        public List<int> SelectedRepairIds { get; set; } = new List<int>();
        public List<Repair>? Repairs { get; set; }
    }
}
