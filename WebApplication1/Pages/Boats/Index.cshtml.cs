using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WebApplication1.Services;
using WebApplication1.Clubs_Boats.models;
using WebApplication1.Interfaces;

namespace WebApplication1.Pages.Boats
{
    public class IndexModel : PageModel
    {
        private readonly BoatRepository repo;

        public IndexModel(BoatRepository repo)
        {
            this.repo = repo;
        }

        public List<Boat> Boats { get; set; }

        public void OnGet()
        {
            Boats = repo.GetAll();
        }
    }
}
