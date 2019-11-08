using NUnit.Framework;

namespace Kata_4.Tests.RomanNumersTestsNS
{
	[TestFixture]
	public class RomanNumersTests
	{
		[Test]
		public void Test1()
		{
			Assert.AreEqual(1941, RomanNumerals.Evaluate("MCMXLI"));
			Assert.AreEqual("MCMXLI", RomanNumerals.Convert(1941));
		}

		[Test]
		public void Test2()
		{
			Assert.AreEqual(1159, RomanNumerals.Evaluate("MCLIX"));
			Assert.AreEqual("MCLIX", RomanNumerals.Convert(1159));
		}

		[Test]
		public void Test3()
		{
			Assert.AreEqual(1398, RomanNumerals.Evaluate("MCCCXCVIII"));
			Assert.AreEqual("MCCCXCVIII", RomanNumerals.Convert(1398));
		}

		[Test]
		public void Test4()
		{
			Assert.AreEqual(2882, RomanNumerals.Evaluate("MMDCCCLXXXII"));
			Assert.AreEqual("MMDCCCLXXXII", RomanNumerals.Convert(2882));
		}
	}
}
