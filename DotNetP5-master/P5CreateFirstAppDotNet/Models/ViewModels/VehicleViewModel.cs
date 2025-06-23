using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public string Label { get; set; } = null!;
        public string VIN { get; set; } = null!;
        [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ ,\.]+$",ErrorMessage = "Seules les lettres, accents, espaces, virgules et points sont autorisés.")]
        public string? Description { get; set; }
        public int YearOfProductionId { get; set; }
        public int VehicleBrandId { get; set; }
        public int VehicleModelId { get; set; }
        public int? VehicleTrimId { get; set; }
        public VehicleStatus Status { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PurchaseDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal? PurchasePrice { get; set; }

        public string? RepairDescription { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RepairDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal? RepairCost { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SaleDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal? SalePrice { get; set; }
        public List<IFormFile>? MediaFiles { get; set; }

        [BindNever]
        public int? YearOfProduction { get; set; }
        [BindNever]
        public string? BrandName { get; set; }
        [BindNever]
        public string? ModelName { get; set; }
        [BindNever]
        public string? TrimName { get; set; }
        [BindNever]
        public string? MediaPath { get; set; }
        [BindNever]
        public string? MediaLabel { get; set; }

        public ICollection<VehicleMedia>? VehicleMedia { get; set; } = new List<VehicleMedia>();

        [BindNever]
        public IEnumerable<SelectListItem>? VehicleBrands { get; set; }
        [BindNever]
        public IEnumerable<SelectListItem>? VehicleModels { get; set; }
        [BindNever]
        public IEnumerable<SelectListItem>? VehicleTrims { get; set; }
        [BindNever]
        public IEnumerable<SelectListItem>? YearsOfProduction { get; set; }
        public List<Repair>? Repairs { get; set; } = new();

    }
}
