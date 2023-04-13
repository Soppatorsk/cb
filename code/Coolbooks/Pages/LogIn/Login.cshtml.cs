using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.ComponentModel.DataAnnotations;

namespace Coolbooks.Pages.LogIn
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credent { get; set; }


        public void OnGet()
        {
        }
    public class Credential
        {
            [Required]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Passwordhash { get; set; }
            [Required]
            public string SecurityStamp { get; set; }

         }
    }

}
