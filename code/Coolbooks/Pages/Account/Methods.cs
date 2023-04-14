using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace Coolbooks.Pages.Account
{
	public class Methods
	{
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

		public string GenerateSecurityStamp()
		{
			// Generate a new security stamp
			string securityStamp = Guid.NewGuid().ToString();

			// Return the security stamp
			return securityStamp;
		}

		public bool VerifyPasswordHash(string hashedPassword, string plainTextPassword)
		{
			// Create an instance of PasswordHasher
			var passwordHasher = new PasswordHasher<IdentityUser>();

			// Verify the hashed password
			var passwordVerificationResult = passwordHasher.VerifyHashedPassword(null, hashedPassword, plainTextPassword);

			// Check the password verification result
			return passwordVerificationResult == PasswordVerificationResult.Success;
		}

		public bool VerifySecurityStamp(IdentityUser user, string securityStamp)
		{
			// Check if the user's security stamp matches the provided security stamp
			return user.SecurityStamp == securityStamp;
		}
	}
}