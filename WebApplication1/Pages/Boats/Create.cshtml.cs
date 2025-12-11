using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WebApplication1.Services;
using WebApplication1.Clubs_Boats.models;

namespace WebApplication1.Pages.Boats
{
    public class CreateModel : PageModel
    {
        private readonly BoatRepository repo;

        public CreateModel(BoatRepository repo)
        {
            this.repo = repo;
        }

        [BindProperty]
        public Boat Boat { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            repo.Add(Boat);
            return RedirectToPage("Index");
        }
    }
}