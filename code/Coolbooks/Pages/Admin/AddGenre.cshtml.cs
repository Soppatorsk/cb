using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coolbooks.Pages
{
    public class AddGenreModel : PageModel
    {
        private readonly CoolbooksContext _db;

        public AddGenreModel(CoolbooksContext db)
        {
           
        }

        public void OnGet()
        {
        }
    }
}