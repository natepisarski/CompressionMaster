using System;
using System.Collections.Generic;

namespace BitSquish
{
	/// <summary>
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
		public static new readonly int OptimalStep = 1;

		/// <summary>
		/// Gets or sets the required step.
		/// </summary>
		/// <value>The required step.</value>
		public static new readonly int RequiredStep = -1;

		/// <summary>
		/// The beginning level. It will search for items this long before searching for smaller ones
		/// </summary>
		public int BeginningLevel;

		/// <summary>
		/// The ending level, the lowest where it will look for patterns
		/// </summary>
		public int EndingLevel;

		/// <summary>
		/// Initializes a new instance of the <see cref="BitSquish.ChunkOptimization"/> class.
		/// This will set how efficient you want the compression to be
		/// </summary>
		/// <param name="beginningLevel">Beginning level</param>
		public ChunkOptimization (int beginningLevel, int endingLevel)
		{
			BeginningLevel = beginningLevel;
			EndingLevel = endingLevel;
		}

		/// <summary>
		/// Optimizes the string based on decreasing repetition steps.
		/// </summary>
		/// <param name="unoptimized">The string to optimize</param>
		/// <param name="beginningLevel">How many characters to search for repeats with. Will increase with
		/// O((n!)^3) complexity, so be wary of using high values here.</param>
		public override string Optimize (string unoptomized)
		{
			string original = unoptomized;
			string optimized = "";

			List<string> foundPatterns = new List<string> ();

			int stepIndex;
							
			for (stepIndex = 0; stepIndex < unoptomized.Length; stepIndex++) {// Gauraunteed to not go over level
				int count, firstIndex = 0;
				string repeated = "";

				for (int level = BeginningLevel; level >= EndingLevel; level--) {
					if (level + level > unoptomized.Length)
						continue;

					//Console.WriteLine (unoptomized.Substring (stepIndex, level) + " " + unoptomized.Substring (level, level));

					for (count = 0; 

						stepIndex + level <= unoptomized.Length && // Test to see if testing the next sequence will go out of bounds

					(unoptomized.Substring (stepIndex, level).Equals (repeated) || // See if the pattern has continued
					unoptomized.Substring (stepIndex, level).Equals (
						unoptomized.Substring (level, level)));
						count++) {

						// Set where we found the first pattern
						if (count == 0)
							firstIndex = stepIndex;

						repeated = unoptomized.Substring (stepIndex, level);
						stepIndex += level;
					}

					// Remove the pattern from the list that we just found
					if (count > 1) {
						unoptomized = unoptomized.Remove (firstIndex, count * repeated.Length);
						stepIndex = firstIndex;
					}

					if (count > 1 && !(foundPatterns.Contains (repeated))) {
						optimized += $"{count}({repeated})";
					} else {
						if (stepIndex == unoptomized.Length) {
							Console.WriteLine ($"[ChunkOptimizer]: Optimized {this.OptimizationPercent(original, optimized)}%");
							return optimized;
						}
						optimized += unoptomized [stepIndex];

						unoptomized = unoptomized.Substring (1, unoptomized.Length - 1);
					}				

					if (!repeated.Equals ("")) // Recognize this pattern as to not copy it again
						foundPatterns.Add (repeated);
					
				}
			}

			Console.WriteLine ($"[ChunkOptimizer]: Optimized {this.OptimizationPercent(original, optimized)}%");
			return optimized + unoptomized;
		}

		/// <summary>
		/// Takes the optimized string, and reverses this level of the optimization done to it.
		/// This will expand everything found within parenthesis until there are no longer any parenthesis left.
		/// Even "20(15(5))" is meant to be a valid expansion at some point.
		/// </summary>
		/// <param name="optimized">The optimized string</param>
		public override string Deoptimize (string optimized)
		{
			return "";
		}
	}
}

