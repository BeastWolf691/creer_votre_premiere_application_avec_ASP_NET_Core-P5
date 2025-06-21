using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.Entities
{

    public class Vehicle
    {
        public int Id { get; set; }
        public string Label { get; set; } = null!;
        public string VIN { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int YearOfProductionId { get; set; }
        public int VehicleBrandId { get; set; }
        public int VehicleModelId { get; set; }
        public int? VehicleTrimId { get; set; }
        public VehicleStatus Status { get; set; }

        public virtual YearOfProduction YearOfProduction { get; set; } = null!;
        public virtual VehicleBrand VehicleBrand { get; set; } = null!;
        public virtual VehicleModel VehicleModel { get; set; } = null!;
        public virtual VehicleTrim? VehicleTrim { get; set; }
        public virtual ICollection<VehicleMedia>? VehicleMedia { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
        public virtual ICollection<Sale>? Sales { get; set; }
        public virtual ICollection<Repair>? Repairs { get; set; }

    }

    public enum VehicleStatus
    {
        Maintenance = 0,
        Disponible = 1,
        Vendu = 2
    }

}