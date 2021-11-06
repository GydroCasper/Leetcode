using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode.Word_Search
{
	public static class WordSearch
	{
		public static void Go()
		{
			var matrix = new List<List<char>>
			{
				new() { 'F', 'A', 'C', 'I' }, 
				new() { 'O', 'B', 'Q', 'P' }, 
				new() { 'A', 'N', 'O', 'B' },
				new() { 'M', 'A', 'S', 'S' }
			};

			var word = "FOAM";

			Console.WriteLine(FindWord(matrix, word));
		}

		private static bool FindWord(List<List<char>> matrix, string word)
		{
			if (matrix is null || !matrix.Any() || !matrix.First().Any()) return false;

			for (var i = 0; i < matrix.Count; i++)
			{
				for (var j = 0; j < matrix.First().Count; j++)
				{
					var rowShift = 0;
					var columnShift = 0;
					var wordShift = 0;

					while (i+rowShift < matrix.Count && wordShift < word.Length && matrix[i+rowShift][j] == word[wordShift])
					{
						rowShift++;
						wordShift++;
					}

					if (wordShift == word.Length) return true;

					wordShift = 0;

					while (j + columnShift < matrix.Count && wordShift < word.Length && matrix[i][j+columnShift] == word[wordShift])
					{
						columnShift++;
						wordShift++;
					}

					if (wordShift == word.Length) return true;
				}
			}

			return false;
		}
	}
}