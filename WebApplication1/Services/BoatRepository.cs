using WebApplication1.Interfaces;
using WebApplication1.Clubs_Boats.models;


namespace WebApplication1.Services
{
    public class BoatRepository : IBoatRepository
    {
        private List<Boat> boats = new();

        public List<Boat> List() => boats;

        public Boat? Get(int id) =>
            boats.FirstOrDefault(b => b.Id == id);

        public void Add(Boat boat)
        {
            boat.Id = boats.Count == 0 ? 1 : boats.Max(x => x.Id) + 1;
            boats.Add(boat);
        }

        public void Update(Boat boat)
        {
            var existing = Get(boat.Id);
            if (existing == null) return;

            existing.Name = boat.Name;
            existing.BoatTypeId = boat.BoatTypeId;
            existing.Capacity = boat.Capacity;
            existing.YearBuilt = boat.YearBuilt;
        }

        public void Delete(int id)
        {
            var boat = Get(id);
            if (boat != null)
                boats.Remove(boat);
        }
    }
}
