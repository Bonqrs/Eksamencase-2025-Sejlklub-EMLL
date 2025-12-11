namespace WebApplication1.Clubs_Boats.models
{
    public class Maintenance
    {
        public int Id { get; set; }
        public int BoatId { get; set; }  
        public DateTime Date { get; set; }
        public MaintenanceType Type { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
