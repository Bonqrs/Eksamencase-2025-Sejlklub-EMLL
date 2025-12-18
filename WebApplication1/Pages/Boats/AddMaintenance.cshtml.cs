using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Clubs_Boats.models;
using WebApplication1.Services;
using WebApplication1.Interfaces;

namespace WebApplication1.Pages.Boats
{
    public class AddMaintenanceModel : PageModel // Model for at tilføje vedligeholdelse til en båd
    {
        private readonly MaintenanceRepository maintenanceRepo;
        private readonly IBoatRepository _boatRepo;

        public AddMaintenanceModel(MaintenanceRepository maintenanceRepo, IBoatRepository boatRepo) // Injekterer repositories
        {
            this.maintenanceRepo = maintenanceRepo;
            _boatRepo = boatRepo;
        }
        

        [BindProperty]
        public Maintenance Maintenance { get; set; } = new();
        
        public Boat? Boat { get; set; }

        public IActionResult OnGet(int boatId) // Håndterer GET anmodning
        {
            Boat = _boatRepo.GetById(boatId); 
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
