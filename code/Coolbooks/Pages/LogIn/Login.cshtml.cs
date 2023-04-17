using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Coolbooks.Pages.LogIn
{
	public class LoginModel : PageModel
	{
		[BindProperty]
		public Credential Credent { get; set; }
		// Inject IHttpContextAccessor for session management
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly CoolbooksContext _db;

		// Check if user is already logged in !Under construction!
		public void OnGet()
		{
			//if (_httpContextAccessor.HttpContext.Session.GetString("UserId") != null)
			//{
			//	Response.Redirect("/Home");
			//}
		}
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                // Get user input & generate MD5Hash
                var passwordHash = this.Credent.Passwordhash; // byter plats på input & passwordHash *input*
			//	var passwordHash = GenerateMD5Hash(input);
                var email = this.Credent.Email;

                // Perform query to check if the user exists 
				var user = await _db.SiteUsers.FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == passwordHash);
                 if(user != null)
                {
					// if User is found, set session variables
					_httpContextAccessor.HttpContext.Session.SetString("UserId", user.UserId.ToString());
					_httpContextAccessor.HttpContext.Session.SetString("UserName", user.Email);

					// Redirect to home page
					return RedirectToPage("/Home");
				}
                else
                {
                    // if User not found
                    ModelState.AddModelError(string.Empty, "Invalid email or password. ");
                    return Page();
                }
			
            }
            return null;
      
        }
        public class Credential
		{
			[Required]

			public string Email { get; set; }
			[Required]
			[DataType(DataType.Password)]
			[Display(Name = "Password")]
			public string Passwordhash { get; set; }
		 
			
		}

		public LoginModel(CoolbooksContext db, IHttpContextAccessor httpContextAccessor)
		{
			_db = db;
			_httpContextAccessor = httpContextAccessor;
		}
 
		public string GenerateMD5Hash(string input)
		{
			// Create an instance of MD5 hash algorithm
			using (var md5 = MD5.Create())
			{
				// Convert the input string to byte array
				byte[] inputBytes = Encoding.UTF8.GetBytes(input);

				// Compute the hash value of the input bytes
				byte[] hashBytes = md5.ComputeHash(inputBytes);

				// Convert the hash bytes to a hexadecimal string
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					stringBuilder.Append(hashBytes[i].ToString("x2"));
				}

				// Return the hexadecimal string as the MD5 hash
				return stringBuilder.ToString();
			}
		}

	}
}