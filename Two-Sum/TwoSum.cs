using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode.Two_Sum
{
	public static class TwoSum
	{
		public static void Go()
		{
			var source = new[] {4, 7, 1, -3, 2};
			var target = 5;

			var result = CheckIfThereAreSumOf(source, target);

			Console.WriteLine(result);
		}

		private static bool CheckIfThereAreSumOf(int[] source, int target)
		{
			if (source == null || !source.Any()) return false;

			var remainders = new HashSet<int>();

			for (var i = 0; i < source.Length; i++)
			{
				if (remainders.Contains(source[i])) return true;
				remainders.Add(target - source[i]);
			}

			return false;
		}
	}
}
