using System;
using System.Collections.Generic;

namespace Leetcode.Longest_Palindromic_Substring
{
	public static class LongestPalindromicSubstring
	{
		public static void Go()
		{
			var sources = new List<string> {"banana", "million", "abc", "abba", "ana"};

			foreach (var source in sources)
			{
				Console.WriteLine($"Source: {source}. Result: {FindLongestPalindrome(source)}");
			}
		}

		private static string FindLongestPalindrome(string source)
		{
			var longestPalindrome = string.Empty;
			if (string.IsNullOrEmpty(source)) return longestPalindrome;

			for (var i = 0; i < source.Length; i++)
			{
				if (i < source.Length - 1 && source[i] == source[i + 1])
				{
					longestPalindrome = LongestPalindrome(source, i, longestPalindrome, 1);
				}
				else
				{
					longestPalindrome = LongestPalindrome(source, i, longestPalindrome, 0);
				}
			}

			return longestPalindrome;
		}

		private static string LongestPalindrome(string source, int i, string longestPalindrome, int shift)
		{
			var j = 1;
			while (i + j + shift < source.Length && i - j >= 0 && source[i - j] == source[i + j + shift])
			{
				if (source[(i - j)..(i + j + shift)].Length > longestPalindrome.Length)
				{
					longestPalindrome = source[(i - j)..(i + j + 1 + shift)];
				}

				j++;
			}

			return longestPalindrome;
		}
	}
}