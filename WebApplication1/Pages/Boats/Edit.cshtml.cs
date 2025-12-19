using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Interfaces;
using WebApplication1.Services;
using WebApplication1.Clubs_Boats.models;

namespace WebApplication1.Pages.Boats
{
    // Rediger en båd
    public class EditModel : PageModel
    {
        private readonly IBoatRepository _boatRepo;

        public EditModel(IBoatRepository boatRepo)
        {
            _boatRepo = boatRepo;
        }

        // båden der redigeres
        [BindProperty]
        public Boat Boat { get; set; }



        public IActionResult OnGet(int id)
        {
            Boat = _boatRepo.GetById(id);
            if (Boat == null)
                return RedirectToPage("Index");

            return Page();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _boatRepo.Update(Boat);
            return RedirectToPage("Index");
        }
    }
}