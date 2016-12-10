using System;
using NUnit.Framework;

namespace BitSquish
{
	[TestFixture]
	public class Test
	{
		[Test]
		public static void TestEverything() {
			BinaryIO.Input input = new BinaryIO.Input ("testfile.txt");

			Assert.True (
				input.BinaryString.Contains ("1") && input.BinaryString.Contains ("0"),
				input.BinaryString
			);
		}
	}
}

