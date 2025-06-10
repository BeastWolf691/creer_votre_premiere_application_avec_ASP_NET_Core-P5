using System;
using System.Collections.Generic;
using P5CreateFirstAppDotNet.Models.Entities;


namespace P5CreateFirstAppDotNet.Models.Entities
{
    public class Repair
    {

        // Propriétés de l'entité Repair
        public int RepairId { get; set; }
        public decimal RepairCost { get; set; }
        public string Name { get; set; } = string.Empty;

        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

    }
}