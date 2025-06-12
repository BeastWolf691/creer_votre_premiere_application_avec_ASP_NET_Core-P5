namespace P5CreateFirstAppDotNet.Models.Entities
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    }
}