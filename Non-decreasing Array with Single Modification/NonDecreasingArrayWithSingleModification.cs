using System;
using System.Linq;
using Leetcode.Classes;

namespace Leetcode
{
	public static class NonDecreasingArrayWithSingleModification
	{
		public static void Go()
		{
			var sources = new[] {new[] {13, 4, 7}, new[] {13, 4, 1}, new[] { 1, 2, 1, 0 } };

			foreach (var source in sources)
			{
				var result = CheckIfAlmostNonDecreasingArray(source);
				Console.WriteLine($"{string.Join(' ', source)} -> {result}");
			}
		}

		private static bool CheckIfAlmostNonDecreasingArray(int[] source)
		{
			if (source is null || !source.Any()) return true;

			var isElementChanged = false;

			for (var i = 0; i < source.Length; i++)
			{
				if (i >= source.Length - 1) continue;
				if(source[i+1] >= source[i]) continue;
				if (isElementChanged) return false;
				isElementChanged = true;
			}

			return true;
		}
	}
}