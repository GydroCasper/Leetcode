using System;
using System.Collections.Generic;

namespace Leetcode.Number_of_Ways_to_Climb_Stairs
{
	public static class NumberOfWaysToClimbStairs
	{
		public static void Go()
		{
			var sources = new List<int> {4, 5, 0, 20, 1, 2, 3};

			foreach (var source in sources)
			{
				Console.WriteLine($"{source}: {CalculateNumberOfWaysToClimbStairs(source)}");
			}
		}

		private static int CalculateNumberOfWaysToClimbStairs(int n)
		{
			if (n < 0) throw new ArgumentException("Steps count cannot be negative");
			if (n == 0) return 0;
			var result = new int[n+2];
			result[0] = 0;
			result[1] = 1;
			result[2] = 2;

			for (var i = 2; i <= n+1; i++)
			{
				result[i] = result[i - 2] + result[i - 1];
			}

			return result[n+1];
		}
	}
}
