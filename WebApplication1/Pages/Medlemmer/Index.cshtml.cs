using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WebApplication1.Services;
using WebApplication1.Models.MemberModel;

namespace WebApplication1.Pages.Medlemmer
{
    public class IndexModel : PageModel
    {
        private readonly MemberRepository repo;

        public IndexModel(MemberRepository repo)
        {
            this.repo = repo;
        }

        public List<Member> Members { get; set; }

        public void OnGet()
        {
            Members = repo.GetAll();
        }
    }
}