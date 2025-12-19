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

        // Listen af både der vises på siden
        public List<Boat> Boats { get; set; }

        
        public void OnGet()
        {
            // Hent
            Boats = _boatRepo.GetAll();
            
            // Tjek om der er en søgetekst i URL (?search=tekst)
            string? Searchstring = Request.Query["search"];
            
            // hvis søgetekst, filter bådene
            if (!String.IsNullOrEmpty(Searchstring))
            {
                // Gem søgeteksten så den vises i søgefeltet
                ViewData["search"] = Searchstring;
                
                // Filter behold kun både hvor navn, type eller motor matcher søgeteksten
                Boats = Boats.Where(b => 
                    b.Name.ToLower().Contains(Searchstring.ToLower()) ||
                    b.BoatType.ToString().ToLower().Contains(Searchstring.ToLower()) ||
                    b.EngineDescription.ToLower().Contains(Searchstring.ToLower()))
                    .ToList();
            }

            Boats = Boats.OrderBy(b => b.Name).ToList();
            // Vises både i alfabetisk rækkefølge efter navn på båd

        }
    }
}
