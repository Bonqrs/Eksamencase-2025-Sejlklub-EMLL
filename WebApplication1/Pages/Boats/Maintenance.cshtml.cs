using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Clubs_Boats.models;
using WebApplication1.Services;

namespace WebApplication1.Pages.Boats
{
    public class MaintenanceModel : PageModel
    {
        private readonly BoatRepository boatRepo;
        private readonly MaintenanceRepository maintenanceRepo;

        public MaintenanceModel(BoatRepository boatRepo, MaintenanceRepository maintenanceRepo)
        {
            this.boatRepo = boatRepo;
            this.maintenanceRepo = maintenanceRepo;
        }

        public Boat? Boat { get; set; }
        public List<Maintenance> MaintenanceLogs { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            Boat = boatRepo.GetById(id);
            if (Boat == null)
                return RedirectToPage("Index");

            // hent vedligeholdelseslog
            MaintenanceLogs = maintenanceRepo.GetByBoatId(id);
            return Page();
        }
    }
}
