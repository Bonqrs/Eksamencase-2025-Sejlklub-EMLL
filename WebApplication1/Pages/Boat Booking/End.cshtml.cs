using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Interfaces;

namespace WebApplication1.Pages.Boat_Booking
{
    public class EndModel : PageModel
    {
        private readonly IBookingRepository _bookingRepo;

        public EndModel(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public IActionResult OnGet(int id)
        {
            var booking = _bookingRepo.Get(id);

            if (booking == null)
                return RedirectToPage("Index");

            booking.EndTime = DateTime.Now;
            _bookingRepo.Update(booking);

            return RedirectToPage("Index");
        }
    }
}
