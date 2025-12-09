using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Clubs_Boats.models;
using WebApplication1.Interfaces;

namespace WebApplication1.Pages.Boat_Booking
{
    public class IndexModel : PageModel
    {
        private readonly IBoatRepository _boatRepo;

        public IndexModel(IBoatRepository boatRepo)
        {
            _boatRepo = boatRepo;
        }

        public List<Boat> Boats { get; set; } = new();

        public void OnGet()
        {
            Boats = _boatRepo.List();
        }
    }
}
