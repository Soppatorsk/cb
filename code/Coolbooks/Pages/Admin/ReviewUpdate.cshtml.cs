using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coolbooks.Pages.Admin
{
    public class ReviewUpdateModel : PageModel
	{
		private readonly CoolbooksContext _db;
		public Review? Review { get; set; }
		public IEnumerable<Book> BookList { get; set; }
		public ReviewUpdateModel(CoolbooksContext db)
		{
			_db = db;
		}
		public void OnGet(int id)
        {
			BookList = _db.Books.ToList();

			Review = _db.Reviews.FirstOrDefault(x => x.ReviewId == id);
		}
		public async Task<IActionResult> OnPostUpdate(Review review)
		{
			_db.Reviews.Update(review);
			await _db.SaveChangesAsync();
			return RedirectToPage("/Reviews/Index");
		}
	}
}
