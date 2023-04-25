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
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies; //newly added
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;

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
        public async Task<IActionResult> OnPostAsync()
        {

			//Get user input & generate MD5Hash
			var passwordHash = GenerateMD5Hash(Credent.Passwordhash);
			var email = this.Credent.Email;


			//Perform query to check if the user exists
            var user = await _db.SiteUsers.FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == passwordHash);

			if (user != null) { 
			// check user Role
			var role = _db.Userinfos.Where(x => x.UserInfoId == user.UserinfoId)
										.Select(x=>x.Role)
										.FirstOrDefault();
			
            var name = _db.Userinfos.Where(x => x.UserInfoId == user.UserinfoId)
                            .Select(x => x.Firstname)
                            .FirstOrDefault();
            var lastName = _db.Userinfos.Where(x => x.UserInfoId == user.UserinfoId)
                .Select(x => x.Lastname)
                .FirstOrDefault();


				// Creating the security context
				var claim = new List<Claim> { //this is the cookie
						new Claim (ClaimTypes.Role,role),
						new Claim (ClaimTypes.Name,name),
						new Claim (ClaimTypes.Name,lastName),
						new Claim (ClaimTypes.Email,email)
					}; 
				var identity = new ClaimsIdentity(claim,
				CookieAuthenticationDefaults.AuthenticationScheme);
				ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
            // Sign in the principal in
            await HttpContext.SignInAsync(claimsPrincipal);
				var userName = HttpContext.User.Identity;
				// Vad är skillnaden mellan System ClaimsPrincipal och Principal.Identity
               // await HttpContext.SignInAsync(base.User.Identity);
                return RedirectToPage("/Home");
            }
			return Page();


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