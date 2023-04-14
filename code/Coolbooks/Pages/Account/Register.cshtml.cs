using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

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
			var input = this.Credent.Passwordhash;
			var passwordHash = GenerateMD5Hash(input);
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