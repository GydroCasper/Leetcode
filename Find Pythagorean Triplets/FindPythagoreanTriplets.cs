using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode.Find_Pythagorean_Triplets
{
	public static class FindPythagoreanTriplets
	{
		public static void Go()
		{
			var source = new List<int> {3, 5, 12, 5, 13};
			
			Console.WriteLine(CheckIfPythagoreanTriplet(source));
		}

		private static bool CheckIfPythagoreanTriplet(List<int> source)
		{
			if (source is null || !source.Any()) return false;
			var squaredNumbers = new HashSet<int>();

			for (var i = 0; i < source.Count; i++)
			{
				var squaredNumber = source[i] * source[i];
				if (!squaredNumbers.Contains(squaredNumber)) squaredNumbers.Add(squaredNumber);
			}

			for (var i = 0; i < source.Count; i++)
			{
				var squaredNumber = source[i] * source[i];
				for (var j = i+1; j < source.Count; j++)
				{
					var sum = squaredNumber + source[j] * source[j];
					if (squaredNumbers.Contains(sum)) return true;
				}
			}

			return false;
		}
	}
}
