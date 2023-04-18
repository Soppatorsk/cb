using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coolbooks.Pages
{
    public class AddAuthorModel : PageModel
    {
        private readonly CoolbooksContext _db;

        public AddAuthorModel(CoolbooksContext db)
        {
           
        }

        public void OnGet()
        {
        }
    }
}