using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Coolbooks.Pages.Admin
{
    public class UpdateBookModel : PageModel
    {
        private readonly CoolbooksContext _db;
        public Book? Book { get; set; }
        public IEnumerable<Author>? AuthorList { get; set; }
        public IEnumerable<Genre>? GenreList { get; set; }
		public bool Taken { get; set; }

		private readonly IWebHostEnvironment _environment;

        public List<string> FileList { get; set; }

        public UpdateBookModel(CoolbooksContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
            FileList = new List<string>();
        }
        public void OnGet(int id)
        {

            AuthorList = _db.Authors.ToList();
            GenreList = _db.Genres.ToList();

            Book = _db.Books
            .Include("Genre")
            .Include("Author")
            .FirstOrDefault(b => b.BookId == id);



            var imageFolder = Path.Combine(_environment.WebRootPath, "Images");
            var imageFiles = Directory.GetFiles(imageFolder)
                .Where(file => Path.GetExtension(file).ToLower() == ".jpg"
                                           || Path.GetExtension(file).ToLower() == ".png");

            foreach (var file in imageFiles)
            {
                FileList.Add(Path.GetFileName(file));
            }
        }
        public async Task<IActionResult> OnPostUpdate(Book book, IFormFile postedFile)
        {
            string wwwPath = _environment.WebRootPath;
            string contentPath = _environment.ContentRootPath;

            string path = Path.Combine(_environment.WebRootPath, "Images");
            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);

            bool test = true;

            string filename;
            if (postedFile == null)
            {
                filename = book.Imagepath;
                test = false;
            }
            else
            {
                filename = Path.GetFileName(postedFile.FileName);
            }

            if (test)
            {
                using (FileStream stream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
            }


			var isbnTaken = await _db.Books.FirstOrDefaultAsync(x => x.Isbn == book.Isbn);


			if (test)
            {
                book.Imagepath = "/Images/" + filename;
            }
            else
            {
                book.Imagepath = filename;
            }

			if (isbnTaken != null)
			{
				ModelState.AddModelError("Book.Isbn", "There is already a book with this ISBN");
				string errorMsg = "There is already a book with this ISBN";
				//return Page();
				return RedirectToPage("AddBook", new { isTaken = errorMsg });
			}
			else
			{
				//book.Imagepath = "/Images/" + filename;

				_db.Books.Update(book);
				await _db.SaveChangesAsync();
				return RedirectToPage("UpdateBook", new { id = book.BookId });
			}


			//_db.Books.Update(book);
   //         await _db.SaveChangesAsync();
   //         return RedirectToPage("UpdateBook", new { id = book.BookId });
        }
    }
}
