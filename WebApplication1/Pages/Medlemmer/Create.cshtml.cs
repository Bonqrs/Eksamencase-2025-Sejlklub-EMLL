using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Interfaces;
using WebApplication1.Models.MemberModel;

namespace WebApplication1.Pages.Medlemmer
{
    public class CreateModel : PageModel
    {
        private readonly IMemberRepository _repo;

        public CreateModel(IMemberRepository repo) => _repo = repo;

        [BindProperty]
        public Member Member { get; set; } = new();

        public void OnGet()
        {
        }

        // Valdier og gemmmer: hvis ugyldig viser den siiden igen 
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repo.Add(Member);
            return RedirectToPage("/Medlemmer/Index");
        }
    }
}