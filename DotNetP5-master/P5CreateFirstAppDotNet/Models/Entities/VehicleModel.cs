using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using P5CreateFirstAppDotNet.Models.Entities;


namespace P5CreateFirstAppDotNet.Models.Entities
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public int VehicleBrandId { get; set; }

        public virtual VehicleBrand VehicleBrand { get; set; } = null!;
        public virtual ICollection<VehicleModelVehicleTrim> VehicleModelVehicleTrims { get; set; } = new List<VehicleModelVehicleTrim>();
        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}