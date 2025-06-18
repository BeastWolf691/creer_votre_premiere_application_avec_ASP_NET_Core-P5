using System;
using System.Collections.Generic;
using P5CreateFirstAppDotNet.Models.Entities;


namespace P5CreateFirstAppDotNet.Models.Entities
{
    public class VehicleModel
    {

        // Propriétés de l'entité Model
        public int VehicleModelId { get; set; }
        public string Name { get; set; } = string.Empty;

        // Clé étrangère vers Brand
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }

        public ICollection<Trim> Trims { get; set; } = new List<Trim>();
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}