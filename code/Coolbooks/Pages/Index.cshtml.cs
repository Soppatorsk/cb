using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Coolbooks.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CoolbooksContext _db;

        public IndexModel(CoolbooksContext db)
        {
           
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if(User.Identity.IsAuthenticated)
            {
                _db.Userinfos.Include("SiteUser");
                return Page();
            }
            return Challenge();
        }
    }
}