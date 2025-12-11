using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Interfaces;
using WebApplication1.Models.MemberModel;

namespace WebApplication1.Pages.Medlemmer
{
    public class IndexModel : PageModel
    {
        private readonly IMemberRepository repo;

        public IndexModel(IMemberRepository repo)
        {
            this.repo = repo;
        }

        public List<Member> Members { get; set; } = new();

        public void OnGet()
        {
            Members = repo.List();
        }
    }
}