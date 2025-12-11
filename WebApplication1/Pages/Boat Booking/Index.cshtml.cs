using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Interfaces;
using WebApplication1.Models.Booking;
using WebApplication1.Models.MemberModel;

namespace WebApplication1.Pages.Boat_Booking
{
    public class IndexModel : PageModel
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IMemberRepository _memberRepo;
        private readonly IBoatRepository _boatRepo;

        public IndexModel(IBookingRepository bookingRepo, IMemberRepository memberRepo, IBoatRepository boatRepo)
        {
            _bookingRepo = bookingRepo;
            _memberRepo = memberRepo;
            _boatRepo = boatRepo;
        }

        public List<BookingDisplay> ActiveBookings { get; set; } = new List<BookingDisplay>();
        public List<BookingDisplay> CompletedBookings { get; set; } = new List<BookingDisplay>();

        public void OnGet()
        {
            ActiveBookings = _bookingRepo
         .List()
        .Where(b => b.EndTime == null)
        .Select(b =>
        {
        var member = _memberRepo.GetById(b.MemberId);
        var boat = _boatRepo.GetById(b.BoatId);

        return new BookingDisplay
        {
            Id = b.Id,
            MemberName = member != null
                ? $"{member.FirstName} {member.LastName}"
                : "Ukendt medlem",

            BoatName = boat?.Name ?? "Ukendt båd",

            Destination = b.Destination,
            StartTime = b.StartTime,
            EndTime = b.EndTime

        };
    })
    .ToList();

            CompletedBookings = _bookingRepo
         .List()
         .Where(b => b.EndTime != null)
         .Select(b =>
         {
             var member = _memberRepo.GetById(b.MemberId);
             var boat = _boatRepo.GetById(b.BoatId);

             return new BookingDisplay
             {
                 Id = b.Id,
                 MemberName = member != null
                     ? $"{member.FirstName} {member.LastName}"
                     : "Ukendt medlem",

                 BoatName = boat?.Name ?? "Ukendt båd",
                 Destination = b.Destination,
                 StartTime = b.StartTime,
                 EndTime = b.EndTime

             };
         }) .ToList();
        }
    }
    public class BookingDisplay
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public string BoatName { get; set; }
        public string Destination { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

    }
}
