using System;
using System.Collections.Generic;
using P5CreateFirstAppAspDotNet.Models.Entities;

namespace P5CreateFirstAppAspDotNet.Models.Entities
{
    public enum VehicleStatus
    {
        Available,
        Sold,
        InRepair,
        NotAvailable
    }

    public class Vehicle
    {

        // Propriétés de l'entité Vehicle
        public int VehicleId { get; set; }
        public int VinCode { get; set; }
        public int Year { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public string? Description { get; set; }
        public DateTime? AvailableForSaleDate { get; set; }
        public decimal? SalePrice { get; set; }
        public DateTime? SaleDate { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageThumbnailUrl { get; set; }

        // Statut du véhicule
        public VehicleStatus Status { get; set; } = VehicleStatus.Available;

        // Marge bénéficiaire calculée
        public decimal Margin { get; set; }

        // Coût total des réparations
        public decimal TotalRepairCost => Repairs.Sum(r => r.RepairCost);

        // Prix de revente calculé
        public decimal ResalePrice => PurchasePrice + TotalRepairCost + Margin;

        // Clé étrangère vers Model
        public int ModelId { get; set; }
        public required Model Model { get; set; }

        // Clé étrangère vers Trim (finition)
        public int TrimId { get; set; }
        public required Trim Trim { get; set; } 

        // Un véhicule peut subir plusieurs réparations
        public ICollection<Repair> Repairs { get; set; } = new List<Repair>();
    }
}