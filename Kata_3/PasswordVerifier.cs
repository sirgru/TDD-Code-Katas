using System;
using System.Linq;

namespace Kata_3
{
	public class PasswordVerifier
	{
		public static bool Verify(string input)
		{
			if (input == null) throw new ArgumentException("Password cannot be null");

			bool isTooShort = IsTooShort(input);

			bool hasAllUppercase = HasAllUppercase(input);
			if (hasAllUppercase) throw new ArgumentException("Password must have at least one lowercase character.");

			bool hasAllLowercase = HasAllLowercase(input);

			bool hasNumber = HasNumber(input);

			int score = (isTooShort? 0 : 1) + (hasAllLowercase? 0 : 1) + (hasNumber? 1 : 0);
			if (score > 1) return true;

			if (isTooShort) throw new ArgumentException("Password too short");
			if (hasAllLowercase) throw new ArgumentException("Password must have at least one uppercase character.");
			if (!hasNumber) throw new ArgumentException("Password must have at least one number.");

			throw new Termination("Should not reach this");
		}

		static bool IsTooShort(string input)
		{
			return input.Length <= 8;
		}

		static bool HasLetter(string input)
		{
			return input.Any(x => char.IsLetter(x));
		}

		static bool HasAllLowercase(string input)
		{
			return (input.ToLower() == input) && HasLetter(input);
		}

		static bool HasAllUppercase(string input)
		{
			return (input.ToUpper() == input) && HasLetter(input);
		}

		static bool HasNumber(string input)
		{
			return input.Any(x => char.IsNumber(x));
		}
	}
}
