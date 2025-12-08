namespace WebApplication1.Models.Booking
{
    public class Booking
    {
        public int Id { get; set; }
        public int BoatId { get; set; }
        public int MemberId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Destination { get; set; } = "";
        public bool IsActive => EndTime == null;
    }
}