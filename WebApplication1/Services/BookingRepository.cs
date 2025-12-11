using WebApplication1.Interfaces;
using WebApplication1.Models.Booking;

namespace WebApplication1.Services
{
    public class BookingRepository : IBookingRepository
    {
        private List<Booking> bookings = new();
        public List<Booking> List() => bookings;
        public Booking? Get(int id) => bookings.FirstOrDefault(b => b.Id == id);

        public void Add(Booking b)
        {
            b.Id = bookings.Count == 0 ? 1 : bookings.Max(x => x.Id) + 1;
            bookings.Add(b);
        }

        public void Update(Booking b)
                    {
            var existing = Get(b.Id);
            if (existing == null) return;
            {
                existing.BoatId = b.BoatId;
                existing.MemberId = b.MemberId;
                existing.StartTime = b.StartTime;
                existing.EndTime = b.EndTime;
                existing.Destination = b.Destination;
            }
        }

        public void Delete(int id)
        {
            var b = Get(id);
            if (b != null)
                bookings.Remove(b);
        }

        public List<Booking> GetActiveBookings() =>
            bookings.Where(b => b.EndTime == null).ToList();
    }
}
