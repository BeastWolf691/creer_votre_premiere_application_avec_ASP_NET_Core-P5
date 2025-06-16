using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace P5CreateFirstAppDotNet.Models.ViewModels
{
    public class TrimViewModel
    {
        [BindNever]
        public int TrimId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Le nom de la finition ne peut pas dépasser 50 caractères.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\s'-]+$", ErrorMessage = "Le nom de la finition ne peut contenir que des lettres, des espaces, des apostrophes et des tirets.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le modèle de véhicule est requis.")]
        public int VehicleModelId { get; set; }
    }
}
