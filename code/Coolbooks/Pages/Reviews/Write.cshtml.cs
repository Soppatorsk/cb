using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Coolbooks.Pages.Reviews
{
	public class WriteModel : PageModel
	{
		private readonly CoolbooksContext _db;
		public Book Book { get; set; }
		public Review Review = new Review(); 

		public WriteModel(CoolbooksContext db) => _db = db;
		public void OnGet(int id)
		{
			Book = _db.Books
	   .Include("Genre")
	   .Include("Author")
	   .FirstOrDefault(b => b.BookId == id);

		}
		public void OnPost(int id)
		{
			//TODO redirect and rm
		Book = _db.Books
	   .Include("Genre")
	   .Include("Author")
	   .FirstOrDefault(b => b.BookId == id);

			Review.Title = Request.Form["title"];
			Review.Text = Request.Form["text"];
			Review.Rating = Request.Form["rating"];
			//Review.Title = "test";
			//Review.Text = "longer text here";
			//Review.Rating = "1";

			Review.UserId = 1;
			Review.Created = DateTime.Now;
			Review.BookId = id;
			_db.Add(Review);
			_db.SaveChanges();
		}
	}
}
