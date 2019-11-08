using NUnit.Framework;

namespace Kata_5.Tests.DependenciesTestsNS
{
	[TestFixture]
    public class DependenciesTests
    {
		[Test]
		public static void PragMain()
		{
			var deps = new Builder();
			deps.AddLine("a b c");
			deps.AddLine("b c e");
			deps.AddLine("c g");
			deps.AddLine("d a f");
			deps.AddLine("e f");
			deps.AddLine("f h");

			string desiredResult  = "a b c g e f h \n" +
								"b c g e f h \n" +
								"c g \n" +
								"e f h \n" +
								"g\n" +
								"d a b c g e f h \n" +
								"f h \n" +
								"h\n";
			Assert.AreEqual(desiredResult, deps.PrintTransientDependencies());
		}

		[Test]
		public static void PragCircular()
		{
			var deps = new Builder();
			deps.AddLine("a b");
			deps.AddLine("b c");
			deps.AddLine("c a");

			string desiredResult  = "a b c \n" +
								"b c a \n" +
								"c a b \n";
			Assert.AreEqual(desiredResult, deps.PrintTransientDependencies());
		}
	}
}
