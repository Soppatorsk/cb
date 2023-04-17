using Azure.Identity;
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
        public SiteUser SiteUser { get; set; }
        public Like NewLike = new Like();


        public string UserFullName { get; set; }
        public string AuthorFullName = string.Empty;
        public int Likes = 0;
        public int Dislikes = 0;

        private readonly CoolbooksContext _db;
        public ReadModel(CoolbooksContext db) => _db = db;

        public void LoadPage(int id)
        {

             Review = _db.Reviews
           .Include("Book")
           .FirstOrDefault(b => b.ReviewId == id);

            Book = _db.Books
                .Include("Author")
                .FirstOrDefault(b => b.BookId == Review.BookId);

            SiteUser = _db.SiteUsers
                .Include("Userinfo")
                .FirstOrDefault(b => b.UserId == Review.UserId);

            UserFullName = SiteUser.Userinfo.Firstname + " " + SiteUser.Userinfo.Lastname;
            AuthorFullName = Review.Book.Author.Firstname + " " + Review.Book.Author.Lastname;

            Likes = _db.Likes.Where(x => x.ReviewId == id && x.Like1 == "Like")
                .Count();

            Dislikes = _db.Likes.Where(x => x.ReviewId == id && x.Like1 == "Dislike")
                .Count();


        }
        public void OnGet(int id)
        {
            LoadPage(id);
        }

        public void OnPostFlag(int id)
        {
            LoadPage(id);

			Review = _db.Reviews
            .Where(r => r.ReviewId == id).FirstOrDefault();
            Review.Status = "Flagged";
            _db.SaveChanges();

        }

        public void OnPostRemove(int id)
        {
            LoadPage(id);

			Review = _db.Reviews
            .Where(r => r.ReviewId == id).FirstOrDefault();
            Review.Status = "Removed";
            _db.SaveChanges();

        }

        public void OnPostLike(int id)
        {
            LoadPage(id);

            Review = _db.Reviews.Where(r => r.ReviewId == id).FirstOrDefault();  
            
                NewLike.ReviewId = id;
                NewLike.Like1 = Request.Form["Vote"];

                //TODO user
                NewLike.UserId = 1;

                if (true /* TODO User no previous vote */ ) _db.Add(NewLike);
                _db.SaveChanges();
        }

    }
}
