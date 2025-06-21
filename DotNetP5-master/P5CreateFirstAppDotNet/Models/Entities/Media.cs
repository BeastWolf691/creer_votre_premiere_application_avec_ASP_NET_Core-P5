namespace P5CreateFirstAppDotNet.Models.Entities
{
    public class Media
    {
        public int Id { get; set; }
        public string Label { get; set; } = null!;
        public string Path { get; set; } = null!;
        public int TypeOfMediaId { get; set; }
        public ICollection<VehicleMedia> VehicleMedia { get; set; } = new List<VehicleMedia>();
        public virtual TypeOfMedia TypeOfMedia { get; set; } = null!;
    }
}
