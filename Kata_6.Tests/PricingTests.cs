using NUnit.Framework;

namespace Kata_6.Tests.PricingTestsNS
{
	[TestFixture]
	class PricingTests
	{
		public Pricing GetPricing()
		{
			var pricing = new Pricing();
			pricing.AddItemWithSpecialPricing('A', 50, 3, 130);
			pricing.AddItemWithSpecialPricing('B', 30, 2, 45);
			pricing.AddItem('C', 20);
			pricing.AddItem('D', 15);
			return pricing;
		}

		[Test]
		public void Test_Checkout()
		{
			var checkout = new Checkout(GetPricing());
			Assert.AreEqual(0f, checkout.GetTotal(""));
			Assert.AreEqual(50f, checkout.GetTotal("A"));
			Assert.AreEqual(80f, checkout.GetTotal("AB"));
			Assert.AreEqual(115f, checkout.GetTotal("CDBA"));

			Assert.AreEqual(100f, checkout.GetTotal("AA"));
			Assert.AreEqual(130f, checkout.GetTotal("AAA"));
			Assert.AreEqual(180f, checkout.GetTotal("AAAA"));
			Assert.AreEqual(230f, checkout.GetTotal("AAAAA"));
			Assert.AreEqual(260f, checkout.GetTotal("AAAAAA"));

			Assert.AreEqual(160f, checkout.GetTotal("AAAB"));
			Assert.AreEqual(175f, checkout.GetTotal("AAABB"));
			Assert.AreEqual(190f, checkout.GetTotal("AAABBD"));
			Assert.AreEqual(190f, checkout.GetTotal("DABABA"));
		}

		[Test]
		public void Test_IncrementalCheckout()
		{
			var ic = new IncrementalCheckout(GetPricing());
			Assert.AreEqual(0f, ic.GetTotal());
			ic.Scan('A');
			Assert.AreEqual(50f, ic.GetTotal());
			ic.Scan('B');
			Assert.AreEqual(80f, ic.GetTotal());
			ic.Scan('A');
			Assert.AreEqual(130f, ic.GetTotal());
			ic.Scan('A');
			Assert.AreEqual(160f, ic.GetTotal());
			ic.Scan('B');
			Assert.AreEqual(175f, ic.GetTotal());
		}
	}
}
