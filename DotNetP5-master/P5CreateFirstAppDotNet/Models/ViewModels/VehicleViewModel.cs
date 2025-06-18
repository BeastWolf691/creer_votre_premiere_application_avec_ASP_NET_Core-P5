using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.ViewModels
{
    public class VehicleViewModel
    {
        public int VehicleId { get; set; }

        [StringLength(17, MinimumLength = 11, ErrorMessage = "Le code VIN doit contenir entre 11 et 17 caractères.")]
        [Display(Name = "Code VIN")]
        public string? VinCode { get; set; }

        [Required(ErrorMessage = "L'année est requise.")]
        [Range(1990, 2100, ErrorMessage = "L'année doit être supérieure ou égale à 1990.")]
        [Display(Name = "Année de sortie")]
        public int Year { get; set; }

        [Required(ErrorMessage = "La marque est requise.")]
        [Display(Name = "Marque")]
        public int BrandId { get; set; }
        public string? BrandName { get; set; }

        [Required(ErrorMessage = "Le modèle est requis.")]
        [Display(Name = "Modèle")]
        public int VehicleModelId { get; set; }
        public string? VehicleModelName { get; set; }

        [Required(ErrorMessage = "La finition est requise.")]
        [Display(Name = "Finition")]
        public int TrimId { get; set; }
        public string? TrimName { get; set; }

        [Required(ErrorMessage = "La date d'achat est requise.")]
        [DataType(DataType.Date, ErrorMessage = "La date d'achat doit être au format valide.")]
        [Display(Name = "Date d'achat")]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "Le prix d'achat est requis.")]
        [Display(Name = "Prix d'achat")]
        public string PurchasePrice { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères.")]
        public string? Description { get; set; }

        [Display(Name = "Disponible à la vente")]
        public DateTime? AvailableForSaleDate { get; set; }

        [Display(Name = "Prix de vente")]
        public string? SalePrice { get; set; }

        [Display(Name = "Date de vente")]
        public DateTime? SaleDate { get; set; }

        [Required(ErrorMessage = "Le statut du véhicule est requis.")]
        [Display(Name = "Statut")]
        public int StatusId { get; set; }
        public string? StatusName { get; set; }

        [Display(Name = "Image du véhicule")]
        public IFormFile? ImageFile { get; set; }
        public string? ImagePath { get; set; }

        public List<int> SelectedRepairIds { get; set; } = new List<int>();
        public List<Repair>? Repairs { get; set; }
        public VehicleModel? VehicleModel { get; set; }
    }
}
