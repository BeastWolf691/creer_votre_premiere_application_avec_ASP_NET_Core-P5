namespace P5CreateFirstAppDotNet.Models.Entities
{
    public class VehicleModelVehicleTrim
    {
        public int VehicleModelId { get; set; }
        public int VehicleTrimId { get; set; }

        public virtual VehicleModel VehicleModel { get; set; } = null!;
        public virtual VehicleTrim VehicleTrim { get; set; } = null!;
    }
}
