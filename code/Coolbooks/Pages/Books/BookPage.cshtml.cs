using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Coolbooks.Pages.Books
{
    public class BookPageModel : PageModel
    {
        private readonly CoolbooksContext _db;
        public Book Book { get; set; }
        //public IEnumerable<Book> Book { get; set; }

        public BookPageModel(CoolbooksContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            //Book = _db.Books.Include("Genre").Where(b => b.BookId == id);
            //Book = _db.Books.Find(id);
            //Book = _db.Books.Include(b => b.Genre).FirstOrDefault(b => b.GenreId == id);
            //Book = _db.Books
            //    .Include(b => b.Genre)
            //    .FirstOrDefault(b => b.GenreId == id)
            //;
            Book = _db.Books
    .Include("Genre")
    .Include("Author")
    .FirstOrDefault(b => b.BookId == id);
        }
    }
}
