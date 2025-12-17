using WebApplication1.Models.Booking;
using System.Collections.Generic;


namespace WebApplication1.Interfaces;

public interface IBookingRepository
{
    List<Booking> List();
    Booking? Get(int id);
    void Add(Booking b);
    void Update(Booking b);
    void Delete(int id);

    List<Booking> GetActiveBookings();
}
// Henter alle aktive bookinger fra databasen