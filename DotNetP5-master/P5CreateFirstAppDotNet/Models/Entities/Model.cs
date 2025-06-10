using System;
using System.Collections.Generic;
using P5CreateFirstAppDotNet.Models.Entities;


namespace P5CreateFirstAppDotNet.Models.Entities
{
    public class Model
    {

        // Propriétés de l'entité Model
        public int ModelId { get; set; }
        public string Name { get; set; } = string.Empty;

        // Clé étrangère vers Brand
        public int BrandId { get; set; }
        public required Brand Brand { get; set; }

        // Un modèle peut avoir plusieurs véhicules associés
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}