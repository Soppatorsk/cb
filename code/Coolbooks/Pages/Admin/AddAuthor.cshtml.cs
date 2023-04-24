using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coolbooks.Pages
{
    public class AddAuthorModel : PageModel
    {
        private readonly CoolbooksContext _db;
        public IEnumerable<Author> Authors { get; set; }

        public AddAuthorModel(CoolbooksContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Author Author { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Authors.Add(Author);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Admin/Index");
        }

        public class ListAuthors
        {
            public string SelectAuthors { get; set; }
        }

        public void OnGet()
        {
            Authors = _db.Authors.ToList();

        }
    }
}