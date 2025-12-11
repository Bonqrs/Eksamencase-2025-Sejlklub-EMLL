using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Clubs_Boats.models;
using WebApplication1.Services;
using WebApplication1.Interfaces;

namespace WebApplication1.Pages.Boats
{
    public class MaintenanceModel : PageModel
    {
        private readonly IBoatRepository _boatRepo;
        private readonly MaintenanceRepository maintenanceRepo;

        public MaintenanceModel(IBoatRepository boatRepo, MaintenanceRepository maintenanceRepo)
        {
            _boatRepo = boatRepo;
            this.maintenanceRepo = maintenanceRepo;
        }

        public Boat? Boat { get; set; }
        public List<Maintenance> MaintenanceLogs { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            Boat = _boatRepo.GetById(id);
            if (Boat == null)
                return RedirectToPage("Index");

            // hent vedligeholdelseslog
            MaintenanceLogs = maintenanceRepo.GetByBoatId(id);
            return Page();
        }
    }
}
