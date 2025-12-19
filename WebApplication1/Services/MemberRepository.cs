using WebApplication1.Clubs_Boats.models;
using WebApplication1.Interfaces;
using WebApplication1.Models.MemberModel;

namespace WebApplication1.Services
{
    public class MemberRepository : IMemberRepository
    {
        private static List<Member> members = new List<Member>()
        {
            new Member { Id = 1, FirstName="Jonas", LastName="Hansen", Email="test@test.dk", Phone="12345678" }
        };

        public List<Member> List() => members;

        public Member GetById(int id) =>
            members.FirstOrDefault(m => m.Id == id);

        public void Add(Member m)
        {
            m.Id = members.Any() ? members.Max(x => x.Id) + 1 : 1;
            members.Add(m);
        }

        public void Update(Member m)
        {
            var existing = GetById(m.Id);
            if (existing == null) return;

            existing.FirstName = m.FirstName;
            existing.LastName = m.LastName;
            existing.Email = m.Email;
            existing.Phone = m.Phone;
            existing.Address = m.Address;
            existing.IsActive = m.IsActive;
        }

        public void Delete(int id)
        {
            var m = GetById(id);
            if (m != null) members.Remove(m);
        }
    }
}
