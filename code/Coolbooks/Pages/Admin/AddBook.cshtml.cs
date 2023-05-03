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
        public IEnumerable<Author> Authors { get; set; } 
        public IEnumerable<Genre> Genres { get; set; }
        public bool Taken { get; set; }

        private readonly IWebHostEnvironment _environment;
        public List<string> FileList { get; set; }

        public AddBookModel(CoolbooksContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
            FileList = new List<string>();
        }


        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAdd(Book book)
        {
          
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> OnPostUpdate(Book book, IFormFile postedFile)
        {
            string wwwPath = _environment.WebRootPath;
            string contentPath = _environment.ContentRootPath;

            string path = Path.Combine(_environment.WebRootPath, "Images");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string filename = Path.GetFileName(postedFile.FileName);

            using (FileStream stream = new FileStream(Path.Combine(path, filename), FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }

            var isbnTaken = await _db.Books.FirstOrDefaultAsync(x => x.Isbn == book.Isbn);

            //if (isbnTaken)
            if (isbnTaken != null)
            {
                //ModelState.AddModelError("Book.Isbn", "There is already a book with this ISBN");
                //string errorMsg = "There is already a book with this ISBN";
                
                return RedirectToPage("AddBook", new {isTaken = true } );
            }
            else
            {
                book.Imagepath = "/Images/" + filename;

                _db.Books.Update(book);
                await _db.SaveChangesAsync();
                return RedirectToPage("AddBook");
            }
            
        }

        public class ListBooks
        {
            public string SelectBooks { get; set; }

        }

        public void OnGet(bool isTaken)
        {
            Books = _db.Books.Include("Author").Include("Genre").ToList();
            Authors = _db.Authors.ToList();
            Genres = _db.Genres.ToList();

            if (isTaken == false)
            {
                Taken = true;
            }

        }
    }
}