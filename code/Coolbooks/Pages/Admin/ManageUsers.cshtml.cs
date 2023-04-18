using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coolbooks.Pages
{
    public class ManageUsersModel : PageModel
    {
        private readonly CoolbooksContext _db;

        public ManageUsersModel(CoolbooksContext db)
        {
           
        }

        public void OnGet()
        {
        }
    }
}