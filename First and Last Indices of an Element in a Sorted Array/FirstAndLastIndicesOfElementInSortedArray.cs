using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode.First_and_Last_Indices_of_an_Element_in_a_Sorted_Array
{
	public class FirstAndLastIndicesOfElementInSortedArray
	{
		public static void Go()
		{
			var sources = new List<(int[], int)>
			{
				(new[] {1, 3, 3, 5, 7, 8, 9, 9, 9, 15}, 9),
				(new[] {100, 150, 150, 153}, 150),
				(new[] {1, 2, 3, 4, 5, 6, 10}, 9),
				(new[] {1, 2, 2, 2, 2, 3, 4, 7, 8, 8}, 2),
				(new [] {7,7,7,7,7,7,7,7,7}, 7),
				(new [] {1,7,7,7,7,7,7,7,7}, 7)
			};

			foreach (var source in sources)
			{
				var (array, target) = source;
				var (firstIndex, lastIndex) = FindIndices(array, 0, array.Length - 1, target);

				Console.WriteLine(
					$"Array: {string.Join(" ", array)}. Target: {target}. Result: {firstIndex} {lastIndex}");
			}
		}

		private static (int, int) FindIndices(int[] source, int startIndex, int endIndex, int target)
		{
			if (source == null || !source.Any()) return (-1, -1);
			if (source[startIndex] > target) return (-1, -1);
			if(source[endIndex] < target) return (-1, -1);

			if (endIndex == startIndex) return source[startIndex] == target ? (startIndex, endIndex) : (-1, -1);
			if (endIndex - startIndex == 1)
			{
				if(source[startIndex] == target && source[endIndex] != target) return (startIndex, startIndex);
				if (source[startIndex] != target && source[endIndex] == target) return (endIndex, endIndex);
				if (source[startIndex] == target && source[endIndex] == target) return (startIndex, endIndex);
				return (-1, -1);
			}

			var middleIndex = (endIndex + startIndex) / 2;

			if (source[middleIndex] > target) return FindIndices(source, startIndex, middleIndex, target);
			if (source[middleIndex] < target) return FindIndices(source, middleIndex, endIndex, target);

			var (firstIndex, _) = FindIndices(source, startIndex, middleIndex, target);
			var (_, lastIndex) = FindIndices(source, middleIndex, endIndex, target);

			firstIndex = firstIndex != -1 ? firstIndex : middleIndex;
			lastIndex = lastIndex != -1 ? lastIndex : middleIndex;
			return (firstIndex, lastIndex);
		}
	}
}
