using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Coolbooks.Pages
{
    public class HomeModel : PageModel
    {
        private readonly CoolbooksContext _db;
        public IEnumerable<Book> Books { get; set; }

        public HomeModel(CoolbooksContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Books = _db.Books.Include("Author").ToList();
            
        }
    }
}