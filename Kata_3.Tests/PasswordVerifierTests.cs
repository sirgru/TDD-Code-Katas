using NUnit.Framework;
using System;

namespace Kata_3.Tests.PasswordVerifierTestsNS
{
	[TestFixture]
	class PasswordVerifierTests
	{
		[Test]
		public void Verify_LogerThan8Chars_True()
		{
			bool result = PasswordVerifier.Verify("1234567890");
			Assert.AreEqual(true, result);
		}

		[Test]
		public void Verify_ShorterThan8Chars_Throws()
		{
			var ex = Assert.Throws<ArgumentException>(() => PasswordVerifier.Verify("aaaa"));
			StringAssert.Contains("too short", ex.ToString());
		}

		[Test]
		public void Verify_NullInput_Throws()
		{
			var ex = Assert.Throws<ArgumentException>(() => PasswordVerifier.Verify(null));
			StringAssert.Contains("cannot be null", ex.ToString());
		}

		[Test]
		public void Verify_AllLower_Throws()
		{
			var ex = Assert.Throws<ArgumentException>(() => PasswordVerifier.Verify("asdddddddddddddddddddddddd"));
			StringAssert.Contains("at least one uppercase character", ex.ToString());
		}

		[Test]
		public void Verify_AllUpper_Throws()
		{
			var ex = Assert.Throws<ArgumentException>(() => PasswordVerifier.Verify("ASDDDDDDDDDDDDDDDDDD1DDDDDDDDD"));
			StringAssert.Contains("at least one lowercase character", ex.ToString());
		}

		[Test]
		public void Verify_AllSatisfied_True()
		{
			bool result = PasswordVerifier.Verify("aSddddddddddddd1dddd");
			Assert.AreEqual(true, result);
		}
	}
}
