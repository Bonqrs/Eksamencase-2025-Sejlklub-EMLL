using WebApplication1.Interfaces;
using WebApplication1.Clubs_Boats.models;
using static WebApplication1.Clubs_Boats.models.Boat;


namespace WebApplication1.Services
{
    public class BoatRepository
    {
        private static List<Boat> boats =
        [
            new Boat 
            { 
                Id = 1, 
                Name = "Havfruen", 
                BoatType = BoatType.Sejlbåd,
                Model = 2020,
                YearBuilt = 2020,
                Capacity = 6,
                Price = 150000,
                Status = BoatStatus.Available,
                EngineDescription = "40 HK Yamaha",
                Length = 8.5m,
                Width = 2.8m,
                Height = 1.2m,
                Weight = 1200
            }
        ];

                public List<Boat> GetAll() => boats;

                public Boat? GetById(int id) =>
            boats.FirstOrDefault(b => b.Id == id);

        public void Add(Boat boat)
        {
                    boat.Id = boats.Any() ? boats.Max(x => x.Id) + 1 : 1;
            boats.Add(boat);
        }

        public void Update(Boat boat)
        {
                    var existing = GetById(boat.Id);
            if (existing == null) return;

            existing.Name = boat.Name;
            existing.YearBuilt = boat.YearBuilt;
            existing.BoatType = boat.BoatType;
            existing.Length = boat.Length;
            existing.Width = boat.Width;
            existing.Model = boat.Model;
            existing.Capacity = boat.Capacity;
            existing.Height = boat.Height;
            existing.Weight = boat.Weight;
            existing.Price = boat.Price;
            existing.Status = boat.Status;
            existing.EngineDescription = boat.EngineDescription;
        }

        public void Delete(int id)
        {
            var boat = GetById(id);
            if (boat != null) boats.Remove(boat);
        }
    }
}
