using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Interfaces;
using WebApplication1.Services;
using WebApplication1.Clubs_Boats.models;

namespace WebApplication1.Pages.Boats
{
    public class DeleteModel : PageModel
    {
        private readonly BoatRepository boatRepository;

        public DeleteModel(BoatRepository boatRepository)
        {
            this.boatRepository = boatRepository;
        }

        public Boat Boat { get; set; }

        public IActionResult OnGet(int id)
        {
            Boat = boatRepository.GetById(id);
            if (Boat == null)
                return RedirectToPage("Index");

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            boatRepository.Delete(id);
            return RedirectToPage("Index");
        }
    }
}