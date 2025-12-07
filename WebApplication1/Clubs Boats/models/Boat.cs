namespace WebApplication1.Clubs_Boats.models
{
    public class Boat
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int BoatTypeId { get; set; } = 0;
        public double Model { get; set; } = 0;
        public int YearBuilt { get; set; } = 0;
        public int Capacity { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public BoatStatus Status { get; set; } = BoatStatus.Available;
        public string EngineDescription { get; set; } = string.Empty;
        public decimal Length { get; set; } = 0;
        public decimal Width { get; set; } = 0;
        public decimal Height { get; set; }= 0;
        public decimal Weight { get; set; } = 0;
        public List<Maintenance> Maintenances { get; set; } = new List<Maintenance>();


        public enum BoatStatus
        {
            Available,
            Unavailable,
            UnderMaintenance
        }

    }
}
