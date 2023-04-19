using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coolbooks.Pages
{
    public class Index : PageModel
    {
        private readonly CoolbooksContext _db;

        public Index(CoolbooksContext db)
        {
           
        }

        public void OnGet()
        {
        }
    }
}