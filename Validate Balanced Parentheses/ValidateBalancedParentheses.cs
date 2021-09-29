using System;
using System.Collections.Generic;

namespace Leetcode.Validate_Balanced_Parentheses
{
	public static class ValidateBalancedParentheses
	{
		public static void Go()
		{
			var sources = new List<string> {"((()))", "[()]{}", "({[)]", "()(){(())", "", "([{}])()", ")"};

			foreach (var source in sources)
			{
				var result = Validate(source);
				Console.WriteLine($"{source}: {result}");
			}
		}

		private static bool Validate(string source)
		{
			if (string.IsNullOrEmpty(source)) return true;

			var openingBracketsChars = new HashSet<char> {'(', '{', '['};
			var closingBracketsChars = new Dictionary<char, char> {{')', '('}, {'}', '{'}, {']', '['}};

			var parentheses = new Stack<char>();

			foreach (var character in source)
			{
				if(openingBracketsChars.Contains(character)) parentheses.Push(character);
				else if (closingBracketsChars.ContainsKey(character))
				{
					if (parentheses.Count == 0 || parentheses.Pop() != closingBracketsChars[character]) return false;
				}
				else throw new ArgumentException($"Input string contain incorrect character {character}");
			}

			return parentheses.Count == 0;
		}
	}
}