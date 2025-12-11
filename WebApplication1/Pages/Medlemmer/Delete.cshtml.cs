using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Interfaces;
using WebApplication1.Models.MemberModel;

namespace WebApplication1.Pages.Medlemmer
{
    public class DeleteModel : PageModel
    {
        private readonly IMemberRepository _repo;

        public DeleteModel(IMemberRepository repo) => _repo = repo;

        [BindProperty]
        public Member Member { get; set; } = null!;

        public IActionResult OnGet(int? id)
        {
            if (id == null) return NotFound();

            var m = _repo.GetById(id.Value);
            if (m == null) return NotFound();

            Member = m;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Member == null || Member.Id == 0) return BadRequest();

            _repo.Delete(Member.Id);
            return RedirectToPage("/Medlemmer/Index");
        }
    }
}
