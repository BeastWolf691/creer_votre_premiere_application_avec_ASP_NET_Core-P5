namespace P5CreateFirstAppDotNet.Models.Entities
{
    public class VehicleMedia
    {
        public int VehicleId { get; set; }
        public int MediaId { get; set; }

        public virtual Vehicle Vehicle { get; set; } = null!;
        public virtual Media Media { get; set; } = null!;
    }
}
