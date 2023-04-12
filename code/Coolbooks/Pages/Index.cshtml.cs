using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coolbooks.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CoolbooksContext _db;

        public IndexModel(CoolbooksContext db)
        {
           
        }

        public void OnGet()
        {
        }
    }
}