using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Coolbooks.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly CoolbooksContext _db;
        public IEnumerable<Book> Books { get; set; }

        public IndexModel(CoolbooksContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Books = _db.Books
                .Include("Genre")
                .Include("Author")
                .ToList();
        }
    }
}
