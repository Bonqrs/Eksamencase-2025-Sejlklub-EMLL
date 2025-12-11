using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Clubs_Boats.models;
using WebApplication1.Services;

namespace WebApplication1.Pages.Boats
{
    public class AddMaintenanceModel : PageModel
    {
        private readonly MaintenanceRepository maintenanceRepo;
        private readonly BoatRepository boatRepo;

        public AddMaintenanceModel(MaintenanceRepository maintenanceRepo, BoatRepository boatRepo)
        {
            this.maintenanceRepo = maintenanceRepo;
            this.boatRepo = boatRepo;
        }

        [BindProperty]
        public Maintenance Maintenance { get; set; } = new();
        
        public Boat? Boat { get; set; }

        public IActionResult OnGet(int boatId)
        {
            Boat = boatRepo.GetById(boatId);
            if (Boat == null)
                return RedirectToPage("Index");

            Maintenance.BoatId = boatId;
            Maintenance.Date = DateTime.Today;
            return Page();
        }

        public IActionResult OnPost()
        {
            maintenanceRepo.Add(Maintenance);
            return RedirectToPage("Maintenance", new { id = Maintenance.BoatId });
        }
    }
}
