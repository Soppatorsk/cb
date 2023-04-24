using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Coolbooks.Pages
{
    public class AddBookModel : PageModel
    {
        private readonly CoolbooksContext _db;
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Author> Authors { get; set; } //nytt
        public IEnumerable<Genre> Genres { get; set; }


        public AddBookModel(CoolbooksContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAdd(Book book)
        {
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Books.Add(Book);
            await _db.SaveChangesAsync();

       

            return RedirectToPage("/Admin/Index");
        }

        public class ListBooks
        {
            public string SelectBooks { get; set; }

        }

        public void OnGet()
        {
            Books = _db.Books.Include("Author").Include("Genre").ToList();
            Authors = _db.Authors.ToList(); //nytt
            Genres = _db.Genres.ToList();
            

        }
    }
}