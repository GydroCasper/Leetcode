using System;
using System.Collections.Generic;

namespace Leetcode.Longest_Substring_Without_Repeating_Characters
{
	public static class LongestSubstringWithoutRepeatingCharacters
	{
		public static void Go()
		{
			//const string source = "abrkaabcdefghijjxxx";
			const string source = "abrkabcdef";

			var result = FindLongestSubstringWithoutRepeating(source);

			Console.WriteLine(result);
		}

		private static int FindLongestSubstringWithoutRepeating(string source)
		{
			if (string.IsNullOrEmpty(source)) return 0;

			var charsDict = new Dictionary<char, int>();
			var maxLength = 0;

			for (var i = 0; i < source.Length; i++)
			{
				if (charsDict.ContainsKey(source[i]))
				{
					var charsDictWithoutTail = new Dictionary<char, int>();
					var lastIndex = charsDict[source[i]];

					foreach (var (key, _) in charsDict)
					{
						if (charsDict[key] <= lastIndex)
						{
							var length = i - charsDict[key];
							if (maxLength < length) maxLength = length;
						}
						else
						{
							charsDictWithoutTail.Add(key, charsDict[key]);
						}
					}

					charsDict = charsDictWithoutTail;
				}

				charsDict.Add(source[i], i);
			}

			return charsDict.Count > maxLength ? charsDict.Count : maxLength;
		}
	}
}