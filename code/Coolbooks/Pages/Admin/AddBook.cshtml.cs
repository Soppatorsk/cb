using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coolbooks.Pages
{
    public class AddBookModel : PageModel
    {
        private readonly CoolbooksContext _db;

        public AddBookModel(CoolbooksContext db)
        {
           
        }

        public void OnGet()
        {
        }
    }
}