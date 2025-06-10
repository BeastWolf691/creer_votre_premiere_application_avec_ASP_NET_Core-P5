using System;
using System.Collections.Generic;
using P5CreateFirstAppDotNet.Models.Entities;


namespace P5CreateFirstAppDotNet.Models.Entities
{
    public class Trim
    {
        // Propriétés de l'entité Trim
        public int TrimId { get; set; }
        public string Name { get; set; } = string.Empty;

        // Une finition peut être associé à plusieurs véhicules
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}