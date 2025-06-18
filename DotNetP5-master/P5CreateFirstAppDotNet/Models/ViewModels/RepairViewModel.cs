using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace P5CreateFirstAppDotNet.Models.ViewModels
{
    public class RepairViewModel
    {
        public int RepairId { get; set; }

        [Required(ErrorMessage = "Le coût de la réparation est requis.")]
        [RegularExpression(@"^\d+(\,\d{1,2})?$", ErrorMessage = "Le coût de la réparation doit être un nombre valide avec jusqu'à deux décimales.")]
        public string RepairCost { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le nom de la réparation est requis.")]
        [StringLength(100, ErrorMessage = "Le nom de la réparation ne peut pas dépasser 100 caractères.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Le nom de la réparation ne peut contenir que des lettres.")]
        public string Name { get; set; } = string.Empty;
    }
}
