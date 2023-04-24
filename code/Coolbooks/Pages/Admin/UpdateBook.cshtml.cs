using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Coolbooks.Pages.Admin
{
    public class UpdateBookModel : PageModel
    {
        private readonly CoolbooksContext _db;
        public Book? Book { get; set; }
        public UpdateBookModel(CoolbooksContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Book = _db.Books
            .Include("Genre")
            .Include("Author")
            .FirstOrDefault(b => b.BookId == id);
        }

    }
}
