using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Interfaces;
using WebApplication1.Models.Booking;

namespace WebApplication1.Pages.Boat_Booking
{
    public class IndexModel : PageModel
    {
        private readonly IBookingRepository _bookingRepo;

        public IndexModel(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public List<Booking> ActiveBookings { get; set; }
        public List<Booking> CompletedBookings { get; set; }

        public void OnGet()
        {
            var all = _bookingRepo.List();
            ActiveBookings = all.Where(b => b.EndTime == null).ToList();
            CompletedBookings = all.Where(b => b.EndTime != null).ToList();
        }
    }
}
