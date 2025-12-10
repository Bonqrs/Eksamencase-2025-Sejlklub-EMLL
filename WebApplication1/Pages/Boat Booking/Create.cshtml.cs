using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Interfaces;
using WebApplication1.Models.Booking;

namespace WebApplication1.Pages.Boat_Booking
{
    public class CreateModel : PageModel
    {

        private readonly IBookingRepository _bookingRepo;
        private readonly IBoatRepository _boatRepo;
        private readonly IMemberRepository _memberRepo;

        public CreateModel(IBookingRepository bookingRepo, IBoatRepository boatRepo, IMemberRepository memberRepo)
        {
            _bookingRepo = bookingRepo;
            _boatRepo = boatRepo;
            _memberRepo = memberRepo;
        }
        [BindProperty]
        public Booking Booking { get; set; } = new();

        public SelectList MemberList { get; set; }
        public SelectList BoatList { get; set; }


        public void OnGet()
        {
            MemberList = new SelectList(_memberRepo.List(), "Id", "FirstName");
            BoatList = new SelectList(_boatRepo.List(), "Id", "Name");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _bookingRepo.Add(Booking);

            return RedirectToPage("Index");
        }
    }
}
