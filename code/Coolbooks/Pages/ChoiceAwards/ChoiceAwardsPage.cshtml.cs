using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coolbooks.Pages.ChoiceAwards
{
    public class ChoiceAwardsPageModel : PageModel
    {
        [BindProperty]
        public int SelectedYear { get; set; }
        private readonly CoolbooksContext _db;
        public ChoiceAwardsPageModel(CoolbooksContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(int selectedYear)
        {
            // do something with the selected year
            // ...

            return RedirectToPage("ChoiceAwardsPage", new { SelectedYear = selectedYear });
        }
    }
}
