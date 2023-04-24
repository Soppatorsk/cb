using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Coolbooks.Pages.Admin
{
    public class UpdateBookModel : PageModel
    {
        private readonly CoolbooksContext _db;
        public Book? Book { get; set; }
        public IEnumerable<Author>? AuthorList { get; set; }
        public IEnumerable<Genre>? GenreList { get; set; }
        public UpdateBookModel(CoolbooksContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {

            AuthorList = _db.Authors.ToList();
            GenreList = _db.Genres.ToList();

            Book = _db.Books
            .Include("Genre")
            .Include("Author")
            .FirstOrDefault(b => b.BookId == id);
        }
        public async Task<IActionResult> OnPostUpdate(Book book)
        {
            //var bookFromDb = _db.Books.FirstOrDefault(x => x.BookId == book.BookId);

             _db.Books.Update(book);
            await _db.SaveChangesAsync();
            return RedirectToPage("UpdateBook", new { id = book.BookId });
        }

    }
}
