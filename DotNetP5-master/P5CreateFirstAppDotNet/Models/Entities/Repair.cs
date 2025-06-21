using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;
using P5CreateFirstAppDotNet.Models.Entities;


namespace P5CreateFirstAppDotNet.Models.Entities
{
    public class Repair
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime RepairDate { get; set; }
           
        [DataType(DataType.Currency)]
        public decimal RepairCost { get; set; }

        [Required]
        public Vehicle Vehicle { get; set; } = null!;

    }
}