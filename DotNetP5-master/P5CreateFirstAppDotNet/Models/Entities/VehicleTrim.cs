using System;
using System.Collections.Generic;
using P5CreateFirstAppDotNet.Models.Entities;


namespace P5CreateFirstAppDotNet.Models.Entities
{
    public class VehicleTrim
    {
        public int Id { get; set; }
        public string TrimLabel { get; set; } = null!;
        public virtual ICollection<VehicleModelVehicleTrim> VehicleModelVehicleTrims { get; set; } = new List<VehicleModelVehicleTrim>();
    }
}