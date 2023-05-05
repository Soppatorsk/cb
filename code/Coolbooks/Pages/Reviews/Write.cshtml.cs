using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace Coolbooks.Pages.Reviews
{
	public class WriteModel : PageModel
	{
		private readonly CoolbooksContext _db;
		public Book Book { get; set; }
		public Review Review = new Review();
		public string AuthorFullName = string.Empty;
		public AspNetUser tmpUser { get; set; }
		public WriteModel(CoolbooksContext db) => _db = db;
		public string UserId { get; set; }
		public void OnGet(int id)
		{
			UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Console.WriteLine(UserId);
			//TODO check if valid BookID
			Book = _db.Books
	   .Include("Genre")
	   .Include("Author")
	   .FirstOrDefault(b => b.BookId == id);

			AuthorFullName = Book.Author.Firstname + " " + Book.Author.Lastname;
		}
		public void OnPost(int id)
		{
			UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Console.WriteLine(UserId);

			//TODO get tmp user
			tmpUser = _db.AspNetUsers.FirstOrDefault();
			//TODO user
			//Review.Id = tmpUser.Id;

			//TODO redirect instead?
		Book = _db.Books
	   .Include("Genre")
	   .Include("Author")
	   .FirstOrDefault(b => b.BookId == id);

			Review.Title = Request.Form["title"];
			Review.Text = Request.Form["text"];
			Review.Rating = int.Parse(Request.Form["rating"]);
			Review.Status = "Public";

			Review.Id = UserId;
            Review.Created = DateTime.Now;
			Review.BookId = id;
			_db.Add(Review);
			_db.SaveChanges();
		}
	}
}
