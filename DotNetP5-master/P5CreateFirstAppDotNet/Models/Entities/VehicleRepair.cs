namespace P5CreateFirstAppDotNet.Models.Entities
{
    public class VehicleRepair
    {

        public int VehicleRepairId { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;
        public int RepairId { get; set; }
        public Repair Repair { get; set; } = null!;
    }
}
