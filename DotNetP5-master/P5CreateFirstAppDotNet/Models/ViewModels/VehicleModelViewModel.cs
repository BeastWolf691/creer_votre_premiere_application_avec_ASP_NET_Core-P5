using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace P5CreateFirstAppDotNet.Models.ViewModels
{
    public class VehicleModelViewModel
    {
        
        [BindNever]
        public int ModelId { get; set; }

        [Required(ErrorMessage = "Le nom du modèle est requis.")]
        [StringLength(100, ErrorMessage = "Le nom du modèle ne peut pas dépasser 100 caractères.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ0-9\s'-]+$", ErrorMessage = "Le nom du modèle contient des caractères invalides.")]
        public string Name { get; set; } = string.Empty;
    }
}
