using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Clubs_Boats.models;
using WebApplication1.Interfaces;

namespace WebApplication1.Pages.Boat_Booking
{
    public class CreateModel : PageModel
    {
        private readonly IBoatRepository _boatRepo;

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
