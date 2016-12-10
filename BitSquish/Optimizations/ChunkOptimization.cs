using System;

namespace BitSquish
{}
	/*/// <summary>
	/// ChunkOptimization is an optimization that searches the binary string
	/// in search of large repeating chunks greater than one digit in length.
	/// 
	/// For instance, 10101010 would be optimized into 4(10)
	/// </summary>
	public class ChunkOptimization : Optimization
	{
		/// <summary>
		/// The optimal step to run this optimization on.
		/// </summary>
		/// <value>The optimal step</value>
		public static readonly int OptimalStep = 1;

		/// <summary>
		/// Gets or sets the required step.
		/// </summary>
		/// <value>The required step.</value>
		public static readonly int RequiredStep = -1;

		/// <summary>
		/// Optimizes the string based on decreasing repetition steps.
		/// </summary>
		/// <param name="unoptimized">The string to optimize</param>
		/// <param name="beginningLevel">How many characters to search for repeats with. Will increase with
		/// O((n!)^3) complexity, so be wary of using high values here.</param>
		public static override string Optimize(string unoptomized, int beginningLevel = 5) {
			string optimized = "";

			for (int levelSearch = beginningLevel; levelSearch > 1; levelSearch--) {
				for(int stepIndex = 0; stepIndex < unoptomized.Length - levelSearch; stepIndex++) {// Gauraunteed to not go over level
					try {
						for(int occur = 0;
					} catch(Exception e) {
						
				}
			}
		}
	}
}

*/