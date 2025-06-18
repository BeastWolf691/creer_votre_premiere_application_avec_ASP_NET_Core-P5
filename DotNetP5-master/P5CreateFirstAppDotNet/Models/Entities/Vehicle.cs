using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.Entities
{

    public class Vehicle
    {
        // Propriétés de l'entité Vehicle
        public int VehicleId { get; set; }
        public string? VinCode { get; set; }
        public int Year { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double PurchasePrice { get; set; }
        public string? Description { get; set; }
        public DateTime? AvailableForSaleDate { get; set; }
        public double? SalePrice { get; set; }
        public DateTime? SaleDate { get; set; }
        public string? ImagePath { get; set; }

        // Statut du véhicule
        public int? StatusId { get; set; }
        public Status? Status { get; set; }

        // Marge bénéficiaire calculée
        private const double DefaultMargin = 500;

        // Coût total des réparations
        public double TotalRepairCost => VehicleRepairs.Sum(vr => vr.Repair.RepairCost);

        // Clé étrangère vers Brand (marque)
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }

        // Clé étrangère vers Model
        public int? VehicleModelId { get; set; }
        public VehicleModel? VehicleModel { get; set; }

        // Clé étrangère vers Trim (finition)
        public int? TrimId { get; set; }
        public Trim? Trim { get; set; }

        // Un véhicule peut subir plusieurs réparations
        public ICollection<VehicleRepair> VehicleRepairs { get; set; } = new List<VehicleRepair>();

        public void CalculateSalePrice()
        {
            // Si le prix de vente n'est pas défini, on le calcule
            SalePrice = PurchasePrice + TotalRepairCost + DefaultMargin;

        }
    }
}