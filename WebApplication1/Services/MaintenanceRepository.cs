using WebApplication1.Clubs_Boats.models;

namespace WebApplication1.Services
{
    public class MaintenanceRepository
    {
        // test data
        private static List<Maintenance> logs = new List<Maintenance>
        {
            new Maintenance
            {
                Id = 1,
                BoatId = 1,
                Date = new DateTime(2024, 5, 15),
                Type = MaintenanceType.Paint,
                Description = "Bundmaling udført"
            },
            new Maintenance
            {
                Id = 2,
                BoatId = 1,
                Date = new DateTime(2024, 8, 20),
                Type = MaintenanceType.Repair,
                Description = "Rorpind repareret"
            }
        };

        public List<Maintenance> GetByBoatId(int boatId)
        {
            return logs.Where(m => m.BoatId == boatId).OrderByDescending(m => m.Date).ToList();
        }

        public void Add(Maintenance m)
        {
            m.Id = logs.Count > 0 ? logs.Max(x => x.Id) + 1 : 1;
            logs.Add(m);
        }

        public void Delete(int id)
        {
            var m = logs.FirstOrDefault(x => x.Id == id);
            if (m != null) logs.Remove(m);
        }
    }
}

