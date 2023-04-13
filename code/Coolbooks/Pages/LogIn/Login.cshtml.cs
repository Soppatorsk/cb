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
        public void OnPost()
        {
            
        }
        public class Credential
        {
            [Required]

            public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Passwordhash { get; set; }
            [Required]
            [Display(Name = "Stamp")]
            public string SecurityStamp { get; set; }

         }
    }

}
