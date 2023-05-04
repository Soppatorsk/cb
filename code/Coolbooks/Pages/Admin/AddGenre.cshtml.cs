using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Coolbooks.Pages
{
    public class AddGenreModel : PageModel
    {
        private readonly CoolbooksContext _db;
        public IEnumerable<Genre> Genres { get; set; }

        public AddGenreModel(CoolbooksContext db)
        {
           _db = db;
        }
        [BindProperty]
        public Genre Genre { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Genres.Add(Genre);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Admin/AddGenre");
        }

        public class ListGenres
        {
            public string SelectGenres { get; set; }
        }

        public void OnGet()
        {
            Genres = _db.Genres.ToList();

        }
    }
}