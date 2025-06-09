using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace P5CreateFirstAppDotNet.Models.ViewModels
{
    public class BrandViewModel
    {
        [BindNever]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Le nom de la marque est requis.")]
        [StringLength(100, ErrorMessage = "Le nom de la marque ne peut pas dépasser 100 caractères.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\s'-]+$", ErrorMessage = "Le nom de la marque contient des caractères invalides.")]
        public string Name { get; set; } = string.Empty;
    }
}
