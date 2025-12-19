using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Clubs_Boats.models;
using WebApplication1.Services;

namespace WebApplication1.Pages.Boats
{
    public class DetailsModel : PageModel
    {
        private readonly BoatRepository _repo;
        private readonly MaintenanceRepository _maintenanceRepo;

        public DetailsModel(BoatRepository repo, MaintenanceRepository maintenanceRepo)
        {
            _repo = repo;
            _maintenanceRepo = maintenanceRepo;
        }

        public Boat? Boat { get; set; }
        public List<Maintenance> MaintenanceLogs { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            Boat = _repo.GetById(id);
            if (Boat == null)
                return RedirectToPage("Index");

            MaintenanceLogs = _maintenanceRepo.GetByBoatId(id);
            return Page();
        }
    }
}