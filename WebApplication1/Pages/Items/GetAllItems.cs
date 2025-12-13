using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Services;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Clubs_Boats.models;
using WebApplication1.Models.MemberModel;

namespace WebApplication1.Pages.Items
{
    public class GetAllItemsModel : PageModel
    {
        private readonly BoatRepository _BoatRepository;
        private readonly MaintenanceRepository _MaintenanceRepository;
        private readonly MemberRepository _MemberRepository;
       // private readonly BookingRepository _BookingRepository;

        public GetAllItemsModel(BoatRepository boatRepository,BookingRepository bookingRepository, MaintenanceRepository maintenanceRepository, MemberRepository memberRepository)
        {
            _BoatRepository = boatRepository;
            _MaintenanceRepository = maintenanceRepository;
            _MemberRepository = memberRepository;
            Searchstring = string.Empty;
        }
        public List<Boat>? Boats { get; set; } = new();
        //public List<Booking>? Bookings { get; set; } = new(); vent til booking er her
        public List<Maintenance>? Maintenances { get; set; } = new();
        public List<Member>? Members { get; set; } = new();

        [BindProperty]
        public string Searchstring { get; set; }

        public void OnGet()
        {
            Boats = _BoatRepository.List();
            Maintenances = _MaintenanceRepository.List();
            Members = _MemberRepository.List();
        }

        public IActionResult OnPostSearch()
        {
            Boats = _BoatRepository.List()
                .Where(b => b.Name.ToLower().Contains(Searchstring.ToLower()) ||
                            b.BoatType.ToString().ToLower().Contains(Searchstring.ToLower()) ||
                            b.EngineDescription.ToLower().Contains(Searchstring.ToLower()))
                .ToList();

            Members = _MemberRepository.List()
                .Where(m => m.FirstName.ToLower().Contains(Searchstring.ToLower()) ||
                            m.LastName.ToLower().Contains(Searchstring.ToLower()) ||
                            m.Email.ToLower().Contains(Searchstring.ToLower()))
                .ToList();

            Maintenances = _MaintenanceRepository.List()
                .Where(v => v.Description.ToLower().Contains(Searchstring.ToLower()) ||
                            v.Type.ToString().ToLower().Contains(Searchstring.ToLower()))
                .ToList();

            return Page();
        }
    }
}
