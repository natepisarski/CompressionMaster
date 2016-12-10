using System;

namespace BitSquish
{
	public abstract class Optimization
	{
		/// <summary>
		/// The optimal step to run this optimization on
		/// </summary>
		/// <value>The optimal step</value>
		public static readonly int OptimalStep = 0;

		/// <summary>
		/// Gets or sets the required step.
		/// </summary>
		/// <value>The required step.</value>
		public static readonly int RequiredStep = 0;

		/// <summary>
		/// Optimize the given unoptomized string
		/// </summary>
		/// <param name="unoptimized">The string to optimize</param>
		public abstract string Optimize(string unoptimized);

		/// <summary>
		/// Takes the optimized string, and reverses this level of the optimization done to it
		/// </summary>
		/// <param name="optimized">Optimized.</param>
		public abstract string Deoptimize(string optimized);

		/// <summary>
		/// Finds the level of optimization that's happened between the unoptimized and optimized string
		/// </summary>
		/// <returns>The percentage (out of 100) that the optimization took place</returns>
		/// <param name="unoptimized">The unoptimized string</param>
		/// <param name="optimized">The optimized string</param>
		public double OptimizationPercent(String unoptimized, String optimized) {
			return (1 - ((double)(optimized.Length)
			/
			((double)unoptimized.Length))) * 100;	
		}
	}
}

