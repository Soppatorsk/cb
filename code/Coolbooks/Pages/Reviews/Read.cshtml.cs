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
        public string UserFullName { get; set; }
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


            SiteUser = _db.SiteUsers
                .Include("Userinfo")
                .FirstOrDefault(b => b.UserId == Review.UserId);

            UserFullName = SiteUser.Userinfo.Firstname + " " + SiteUser.Userinfo.Lastname;
            AuthorFullName = Review.Book.Author.Firstname + " " + Review.Book.Author.Lastname;
        }
    }
}
