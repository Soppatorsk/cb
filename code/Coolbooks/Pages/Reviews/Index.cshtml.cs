using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Coolbooks.Pages.Reviews
{
	public class IndexModel : PageModel
	{
		private readonly CoolbooksContext _db;
		public Book Book { get; set; }
		public IEnumerable<Review> Reviews { get; set; }
		public string UserFullName = string.Empty;
		public Review Review { get; set; }

		public IndexModel(CoolbooksContext db) => _db = db;

		//Picking book for new review
		public List<SelectListItem> Options { get; set; }

		public void LoadPage()
		{
			Reviews = _db.Reviews
				.Include("Book")
				.Include("User.Userinfo")
				.Where(x => x.Status != "Removed")
				.ToList();

			Options = _db.Books.Select(a =>
			new SelectListItem
			{
				Value = a.BookId.ToString(),
				Text = a.Title
			}).ToList();
		}
		
		public void OnGet()
		{
			LoadPage();
		}

		public void OnPostRemove()
		{
			LoadPage();
			Review = _db.Reviews
            .Where(r => r.ReviewId == int.Parse(Request.Form["id"])).FirstOrDefault();
            Review.Status = "Removed";
            _db.SaveChanges();

		}
	}
}
