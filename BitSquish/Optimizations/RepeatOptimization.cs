using System;

namespace BitSquish
{
	/// <summary>
	/// The Repeat Optimization is an optimization for recognizing strings of
	/// repeated binary values. For instance,
	/// 11100010 would simply turn into 313010
	/// </summary>
	public class RepeatOptimization : Optimization
	{
		/// <summary>
		/// The optimal step to run this optimization on.
		/// </summary>
		/// <value>The optimal step</value>
		public static new readonly int OptimalStep = 2;

		/// <summary>
		/// Gets or sets the required step.
		/// </summary>
		/// <value>The required step.</value>
		public static new readonly int RequiredStep = 1;

		/// <summary>
		/// Optimizes the given binary string using the Repeating search method
		/// </summary>
		/// <param name="unoptimized">The string to optimize</param>
		public override string Optimize(string unoptimized) {

			string optimized = "";

			// Counter is used to count how many repeated binary digits there are
			int counter = 0;

			// Makes string access less expensive
			char[] characters = unoptimized.ToCharArray ();

			//      Index         Length of string     If we optimized, jump to end of optimization. Add 1 otherwise
			for (int i = 0; i < unoptimized.Length; i += counter == 0 ? 1 : counter) {

				char current = characters [i];

				// Count how many of the same digits in a row we have
				for (counter = 0;

					(i + counter) < unoptimized.Length && // Not going over end of list
					characters [i + counter].Equals (current) && // We have repeating digits
					counter <= 9; // We don't wind up with 101 when we mean "10(1)" FIXME

					counter++)
					;

				// We optimized, add how much we optimized and what it was
				if (counter > 1)
					optimized += ("" + counter + current);

				// We didn't optimize, just put the digit
				else
					optimized += ("" + current);
			}

			Console.WriteLine (OptimizationPercent (unoptimized, optimized) + "% optimized");
			return optimized;
		}

		/// <summary>
		/// Takes the optimized string, and reverses this level of the optimization done to it
		/// </summary>
		/// <param name="optimized"></param>
		public override string Deoptimize(string optimized) {
			string deoptimized = "";

			// Just go through the whole string
			for (int i = 0; i < optimized.Length; i++) {

				// If either are zero or one, just add it to the string
				if (optimized [i] == '0' || optimized [i] == '1')
					deoptimized += optimized [i];

				else { // Some number was found 
					
					// Find out how many times it was optimized
					int times = int.Parse(optimized[i].ToString());

					for (int deopt = times; deopt > 0; deopt--)
						deoptimized += optimized [i + 1];

					i++; // We have to jump 2 places to skip the number and argument
					continue;
				}	

				if ("01".Contains (deoptimized [deoptimized.Length - 1].ToString()))
					continue;
				else
					throw new Exception ();
			}

			return deoptimized;
		}
	}
}

