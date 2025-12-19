namespace WebApplication1.Models.MemberModel
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
// En nem og hurtig class som der sætter strings og andet til hjemmesiden, for at administrere og se informationer om medlemmerne