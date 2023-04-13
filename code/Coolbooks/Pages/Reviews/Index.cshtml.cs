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

		public IndexModel(CoolbooksContext db) => _db = db;

		//Write your own?
		public List<SelectListItem> Options { get; set; }

		public void OnGet()
		{
			Reviews = _db.Reviews
				.Include("Book")
				.ToList();

			Options = _db.Books.Select(a =>
			new SelectListItem
			{
				Value = a.BookId.ToString(),
				Text = a.Title
			}).ToList();
		}
	}
}
