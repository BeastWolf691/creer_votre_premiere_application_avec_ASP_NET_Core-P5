using System;
using System.Collections.Generic;
using P5CreateFirstAppAspDotNet.Models.Entities;


namespace P5CreateFirstAppAspDotNet.Models.Entities
{
    public class Repair
    {

        // Propriétés de l'entité Repair
        public int RepairId { get; set; }
        public DateTime RepairDate { get; set; }
        public decimal RepairCost { get; set; }
        public string Description { get; set; } = string.Empty;

        // Clé étrangère vers Vehicle
        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

    }
}