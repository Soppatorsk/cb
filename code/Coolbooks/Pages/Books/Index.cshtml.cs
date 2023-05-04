using Coolbooks.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Coolbooks.Pages.Books
{
   // [Authorize(Roles = "User,Admin,Moderator")]
    public class IndexModel : PageModel
    {
        private readonly CoolbooksContext _db;
        public IEnumerable<Book> Books { get; set; }
        public List<SelectListItem> Genres { get; set; }
        public int SelectedGenre = 0;
        public List<SelectListItem> Authors { get; set; }
        public int SelectedAuthor = 0;
        public IndexModel(CoolbooksContext db)
        {
            _db = db;
        }

        public void LoadPage()
        {
            Genres = _db.Genres.Select(a =>
            new SelectListItem
            {
                Value = a.GenreId.ToString(),
                Text = a.Name
            }).ToList();

            Authors = _db.Authors.Select(a =>
                new SelectListItem
                {
                    Value = a.AuthorId.ToString(),
                    Text = a.Lastname + " " + a.Firstname
                }).ToList();
        }
        public void OnGet()
        {
            LoadPage();
            getData();

        }
        public void OnPostFilter(int genre, int author)
        {
            LoadPage();
            SelectedGenre = genre;
            SelectedAuthor = author;
            getData();
        }
        
        public void getData()
        {
            var query = _db.Books.AsQueryable();
            query = query
                .Include("Genre")
                .Include("Author");

            query = SelectedGenre != 0 ? query.Where(x => x.GenreId == SelectedGenre) : query;  
            query = SelectedAuthor != 0 ? query.Where(x => x.AuthorId == SelectedAuthor) : query;  
            Books = query.ToList();

        }
    }
}
