using System;

namespace BitSquish
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			BinaryIO.Input input = new BinaryIO.Input ("testfile.txt");

			Console.WriteLine (input.BinaryString);
			Console.WriteLine ();

			RepeatOptimization ro = new RepeatOptimization ();

			string optimized = ro.Optimize (input.BinaryString);
		}
	}
}
