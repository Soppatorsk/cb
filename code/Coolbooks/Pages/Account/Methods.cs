using Microsoft.AspNetCore.Identity;

namespace Coolbooks.Pages.Account
{
	public class Methods
	{
		public string GeneratePasswordHash(string password)
		{
			// Create an instance of PasswordHasher
			var passwordHasher = new PasswordHasher<IdentityUser>();

			// Hash the password
			string hashedPassword = passwordHasher.HashPassword(null, password);

			// Return the hashed password
			return hashedPassword;
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