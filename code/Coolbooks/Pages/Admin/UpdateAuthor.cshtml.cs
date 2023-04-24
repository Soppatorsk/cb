using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coolbooks.Pages.Admin
{
    public class UpdateAuthorModel : PageModel
    {
        private readonly CoolbooksContext _db;
        public Author? Author { get; set; }

        public UpdateAuthorModel(CoolbooksContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Author = _db.Authors.FirstOrDefault(x => x.AuthorId == id);
        }
        public async Task<IActionResult> OnPostUpdate(Author author)
        {
            //var bookFromDb = _db.Books.FirstOrDefault(x => x.BookId == book.BookId);

            _db.Authors.Update(author);
            await _db.SaveChangesAsync();
            return RedirectToPage("UpdateAuthor", new { id = author.AuthorId });
        }
    }
}
