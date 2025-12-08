using System.Collections.Generic;
using WebApplication1.Clubs_Boats.models;


namespace WebApplication1.Interfaces
{
    public interface IBoatRepository
    {
        List<Boat> List();
        Boat? Get(int id);
        void Add(Boat boat);
        void Update(Boat boat);
        void Delete(int id);
    }
}
