using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Coolbooks.Pages.Reviews
{
    public class ReadModel : PageModel
    {
        public Book Book { get; set; }
        public Review Review { get; set; }
        public string AuthorFullName = string.Empty;
        private readonly CoolbooksContext _db;
        public ReadModel(CoolbooksContext db) => _db = db;
        public void OnGet(int id)
        {

            Review = _db.Reviews
           .Include("Book")
           .FirstOrDefault(b => b.ReviewId == id);

            Book = _db.Books
                .Include("Author")
                .FirstOrDefault(b => b.BookId == Review.BookId);

            AuthorFullName = Book.Author.Firstname + " " + Book.Author.Lastname;
        }
    }
}
