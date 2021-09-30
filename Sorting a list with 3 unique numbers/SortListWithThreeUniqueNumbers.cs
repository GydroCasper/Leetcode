using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode.Sorting_a_list_with_3_unique_numbers
{
	public static class SortListWithThreeUniqueNumbers
	{
		public static void Go()
		{
			var source = new[] {3, 3, 2, 1, 3, 2, 1};

			source = Sort(source);

			Console.WriteLine($"Result: {string.Join(" ", source)}");
		}

		private static int[] Sort(int[] source)
		{
			if (source == null || !source.Any()) return source;

			var hits = new Dictionary<int, int> {{1, 0}, {2, 0}, {3, 0}};

			for (var i = 0; i < source.Length; i++)
			{
				if (!hits.ContainsKey(source[i]))
				{
					throw new ArgumentException($"Array contains incorrect number {source[i]}");
				}

				hits[source[i]]++;
			}

			var shift = 0;

			for (var hitIndex = 0; hitIndex < hits.Count; hitIndex++)
			{
				var (key, value) = hits.ElementAt(hitIndex);
				for (var i = 0; i < value; i++)
				{
					source[i + shift] = key;
				}

				shift += value;
			}

			return source;
		}
	}
}