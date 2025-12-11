using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Clubs_Boats.models;
using WebApplication1.Interfaces;
using WebApplication1.Models.Booking;
using WebApplication1.Models.MemberModel;

namespace WebApplication1.Pages.Boats
{
    public class CreateModel : PageModel
    {
        private readonly IBoatRepository _boatRepo;
        private readonly IMemberRepository _memberRepo;
        private readonly IBookingRepository _bookingRepo;

        public CreateModel(IBoatRepository boatRepo)
        {
            _boatRepo = boatRepo;
        }

        

        [BindProperty]
        public Boat Boat { get; set; } = new();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _boatRepo.Add(Boat);
            

            return RedirectToPage("Index");
        }
        public void OnGet()
        {
            
        }

        
    }
}
