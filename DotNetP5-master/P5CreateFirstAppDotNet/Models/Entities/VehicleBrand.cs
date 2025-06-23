using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Models.Entities
{
    public class VehicleBrand
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;        public virtual ICollection<VehicleModel> VehicleModels { get; set; } = new List<VehicleModel>();
        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}