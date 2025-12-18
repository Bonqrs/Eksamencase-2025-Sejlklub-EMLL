using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Interfaces;
using WebApplication1.Services;
using WebApplication1.Clubs_Boats.models;

namespace WebApplication1.Pages.Boats
{
    // Opretter en ny båd
    public class CreateModel : PageModel
    {
        private readonly IBoatRepository _boatRepo;

        public CreateModel(IBoatRepository boatRepo)
        {
            _boatRepo = boatRepo;
        }
         //gør så Boat objektet tilgængeligt for data binding i Razor Page
        [BindProperty]
        public Boat Boat { get; set; } = new();

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _boatRepo.Add(Boat);
            return RedirectToPage("Index");
        }
    }
}