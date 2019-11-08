using Kata_2;
using NUnit.Framework;

namespace Kata_1.Tests
{
	[TestFixture]
    public class StringCalculatorTests
    {
		[Test]
		public void NoInput()
		{
			var c = new StringCalculator();
			Assert.AreEqual(0, c.Add(null));
			Assert.AreEqual(0, c.Add(""));
		}

		[Test]
		public void OneNumber()
		{
			var c = new StringCalculator();
			Assert.AreEqual(1, c.Add("1"));
			Assert.AreEqual(1, c.Add("1,"));
			Assert.AreEqual(1, c.Add(",1"));
			Assert.AreEqual(1, c.Add(", 1		,"));
		}

		[Test]
		public void TwoNumbers()
		{
			var c = new StringCalculator();
			Assert.AreEqual(3, c.Add("1,2"));
			Assert.AreEqual(3, c.Add("1,   2,"));
			Assert.AreEqual(3, c.Add("1,	,2"));
		}

		[Test]
		public void ThreeNumbers()
		{
			var c = new StringCalculator();
			Assert.AreEqual(6, c.Add("1,2,3"));
			Assert.AreEqual(6, c.Add(" 1,   2,		3,,"));
		}

		[Test]
		public void MoreNumbers()
		{
			Assert.AreEqual(10, new StringCalculator().Add("1,2,3,4"));
		}

		[Test]
		public void MultipleSeparators()
		{
			Assert.AreEqual(6, new StringCalculator().Add("1\n2,3"));
		}

		[Test]
		public void Add_CustomDelimiter_Accepts()
		{
			Assert.AreEqual(3, new StringCalculator().Add("//;\n1;2"));
		}

		[Test]
		public void Add_ImproperEndingOfCustomDelimiter_ThrowsException()
		{
			var ex = Assert.Throws<InputException>(() => new StringCalculator().Add("//;1;2"));
		}

		[Test]
		public void Add_NegativeNumbers_ThrowsException()
		{
			var ex = Assert.Throws<InputException>(() => new StringCalculator().Add("-1, -2"));
			StringAssert.Contains("-1 -2", ex.Message);
		}

		[Test]
		public void TimesCalled()
		{
			var c = new StringCalculator();
			c.Add("1,2");
			c.Add("2,3");
			Assert.AreEqual(2, c.calledCount);
		}

		[Test]
		public void EventCall()
		{
			string giveninput = null;
			var c = new StringCalculator();
			c.addOccured += delegate (string input, int result) {
				giveninput = input;
			};

			c.Add("1,2");

			Assert.AreEqual("1,2", giveninput);
		}

		[Test]
		public void Add_NumbersGreaterThan1000_AreIgnored()
		{
			Assert.AreEqual(1, new StringCalculator().Add("1,1001"));
		}

		[Test]
		public void Add_CustomLengthDelimiter_Accepts()
		{
			Assert.AreEqual(6, new StringCalculator().Add("//[***]\n1***2***3"));
		}

		[Test]
		public void Add_MultipleDelimiters_Accepts()
		{
			int result = new StringCalculator().Add("//[*][%]\n1*2%3");
			Assert.AreEqual(6, result);
		}

		[Test]
		public void Add_MultipleCustomLengthDelimiters_Accepts()
		{
			int result = new StringCalculator().Add("//[**][%%%%]\n1**2%%%%3");
			Assert.AreEqual(6, result);
		}

		[Test]
		public void Add_MultipleDelimitersOneEmpty_Throws()
		{
			var ex = Assert.Throws<InputException>(() => new StringCalculator().Add("//[**][%%%%][]\n1**2%%%%3"));
		}

		class TestLogger : ILogger
		{
			public string message;
			public void Log(string output)
			{
				message = output;
			}
		}

		[Test]
		public void Add_Logger_Logs()
		{
			var custLog = new TestLogger();
			var c = new StringCalculator(custLog);
			c.Add("1,2");
			Assert.AreEqual("3", custLog.message);
		}

		class TestWebService : IWebService
		{
			public string message;
			public void Notify(string message)
			{
				this.message = message;
			}
		}

		[Test]
		public void Add_WebService_Receives()
		{
			var custWebService = new TestWebService();
			var c = new StringCalculator(null, custWebService);
			try {
				c.Add("1,-2");
			}
			catch { }
			Assert.IsTrue(custWebService.message.Contains("Negatives"));
		}
	}
}
