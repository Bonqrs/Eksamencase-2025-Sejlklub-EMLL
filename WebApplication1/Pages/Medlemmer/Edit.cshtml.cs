using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Interfaces;
using WebApplication1.Models.MemberModel;

namespace WebApplication1.Pages.Medlemmer
{
    public class EditModel : PageModel
    {
        private readonly IMemberRepository _repo;

        public EditModel(IMemberRepository repo) => _repo = repo;

        [BindProperty]
        public Member Member { get; set; } = new();

        // get henter medlem og viser edit siden 
        public IActionResult OnGet(int? id)
        {
            if (id == null) return NotFound();

            var m = _repo.GetById(id.Value);
            if (m == null) return NotFound();

            Member = m;
            return Page();
        }

        // valider og opater meldem: hvis ugldigt viser den siden igen.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repo.Update(Member);
            return RedirectToPage("/Medlemmer/Index");
        }
    }
}
