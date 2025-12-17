using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Interfaces;
using WebApplication1.Models.Booking;

namespace WebApplication1.Pages.Boat_Booking
{
    public class CreateModel : PageModel
    {
        // Repositories for bookings, boats, og members
        private readonly IBookingRepository _bookingRepo;
        private readonly IBoatRepository _boatRepo;
        private readonly IMemberRepository _memberRepo;

        public CreateModel(IBookingRepository bookingRepo, IBoatRepository boatRepo, IMemberRepository memberRepo) // Injekterer repositories
        {
            // Initialiserer repositories
            _bookingRepo = bookingRepo;
            _boatRepo = boatRepo;
            _memberRepo = memberRepo;
        }
        [BindProperty] // Binder property til booking
        public Booking Booking { get; set; } = new();

        public SelectList MemberList { get; set; }
        public SelectList BoatList { get; set; }
        // Henter data til dropdown-lister

        public void OnGet() // Håndterer GET-anmodning
        {
            MemberList = new SelectList(_memberRepo.List(), "Id", "FirstName");
            BoatList = new SelectList(_boatRepo.GetAll(), "Id", "Name");
        }

        public IActionResult OnPost() // Håndterer POST-anmodning
        {
            if (!ModelState.IsValid)
                return Page();

            _bookingRepo.Add(Booking);

            return RedirectToPage("Index");
            // Redirecter til index-siden efter oprettelse af booking
        }
    }
}
