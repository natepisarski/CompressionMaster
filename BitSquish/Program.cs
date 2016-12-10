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

			ChunkOptimization co = new ChunkOptimization (5, 3);

			string optimized = co.Optimize ("11011010101010");



			Console.WriteLine (
				optimized
			);
		}
	}
}
