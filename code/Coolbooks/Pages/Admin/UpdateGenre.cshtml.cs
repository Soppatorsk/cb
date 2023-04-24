using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coolbooks.Pages.Admin
{
    public class UpdateGenreModel : PageModel
    {
        private readonly CoolbooksContext _db;
        public Genre? Genre { get; set; }
        public UpdateGenreModel(CoolbooksContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Genre = _db.Genres.FirstOrDefault(x => x.GenreId == id);
        }
        public async Task<IActionResult> OnPostUpdate(Genre genre)
        {
            //var bookFromDb = _db.Books.FirstOrDefault(x => x.BookId == book.BookId);

            _db.Genres.Update(genre);
            await _db.SaveChangesAsync();
            return RedirectToPage("UpdateGenre", new { id = genre.GenreId });
        }
    }
}
