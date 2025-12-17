using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WebApplication1.Services;
using WebApplication1.Clubs_Boats.models;
using WebApplication1.Interfaces;

namespace WebApplication1.Pages.Boats
{
    public class IndexModel : PageModel
    {
        private readonly IBoatRepository _boatRepo;

        public IndexModel(IBoatRepository boatRepo)
        {
            _boatRepo = boatRepo;
        }

        public List<Boat> Boats { get; set; }

        public void OnGet()
        {
            Boats = _boatRepo.GetAll();
            string? Searchstring = Request.Query["search"];
            if (!String.IsNullOrEmpty(Searchstring))
            {
                ViewData["search"] = Searchstring;
                Boats = Boats.Where(b => b.Name.ToLower().Contains(Searchstring.ToLower()) ||
                               b.BoatType.ToString().ToLower().Contains(Searchstring.ToLower()) ||
                               b.EngineDescription.ToLower().Contains(Searchstring.ToLower()))
                   .ToList();
            }

        Boats = Boats.OrderBy(b => b.Name).ToList();
            // Viser både i alfabetisk rækkefølge efter navn

        }
    }
}
