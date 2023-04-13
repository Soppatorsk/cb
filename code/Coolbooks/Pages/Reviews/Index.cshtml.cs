using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Coolbooks.Pages.Reviews
{
	public class IndexModel : PageModel
	{
		private readonly CoolbooksContext _db;
		public Book Book { get; set; }
		public IEnumerable<Review> Reviews { get; set; } 

		public IndexModel(CoolbooksContext db) => _db = db;

		public void OnGet()
		{
			Reviews = _db.Reviews
				.Include("Book")
				.ToList();
		}
	}
}
