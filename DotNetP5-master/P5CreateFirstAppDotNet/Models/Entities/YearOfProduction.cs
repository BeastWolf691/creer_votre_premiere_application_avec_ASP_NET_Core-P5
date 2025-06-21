namespace P5CreateFirstAppDotNet.Models.Entities
{
    public class YearOfProduction
    {
        public int Id { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
