using WebApplication1.Models.Booking;
using WebApplication1.Models.MemberModel;
using WebApplication1.Services;

namespace WebApplication1.Interfaces
{
    public interface IMemberRepository
    {
        List<Member> List();
        Member? GetById(int id);
        void Add(Member m);
        void Update(Member m);
        void Delete(int id);
    }
}
// Interface der definerer metoder til at hente, oprette, opdatere og slette medlemmer.