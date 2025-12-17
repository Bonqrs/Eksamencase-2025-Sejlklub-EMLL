using System.Collections.Generic;
using WebApplication1.Clubs_Boats.models;


namespace WebApplication1.Interfaces
{
    public interface IBoatRepository
    {
        List<Boat> GetAll();
        Boat? GetById(int id);
        void Add(Boat boat);
        void Update(Boat boat);
        void Delete(int id);
    }
}
// Interface der definerer metoder til at hente, oprette, opdatere og slette både.