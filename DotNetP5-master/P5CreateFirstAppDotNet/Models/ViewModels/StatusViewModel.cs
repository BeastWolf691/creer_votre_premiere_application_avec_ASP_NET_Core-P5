using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace P5CreateFirstAppDotNet.Models.ViewModels
{
    public class StatusViewModel
    {
        [BindNever]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Le nom de la marque est requis.")]
        [StringLength(50, ErrorMessage = "Le nom de la marque ne peut pas dépasser 50 caractères.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\s]+$", ErrorMessage = "Le nom du statut contient des caractères invalides.")]
        public string Name { get; set; } = string.Empty;
    }
}
