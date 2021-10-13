using System;
using System.Collections.Generic;

namespace Leetcode.Create_a_Simple_Calculator
{
	public static class CreateSimpleCalculator
	{
		public static void Go()
		{
			var source = "- ( 3 + ( 2 - 1 ) )";

			Console.WriteLine(Calculate(source));
		}

		private static int Calculate(string source)
		{
			if (string.IsNullOrEmpty(source)) return 0;
			var (result, _) = CalculateExpression(source, 0);
			return result;
		}

		private static (int, int) CalculateExpression(string source, int index)
		{
			var isPlus = true;
			var result = 0;
			while (index < source.Length)
			{
				if (int.TryParse(source[index].ToString(), out var digit))
				{
					if (isPlus) result += digit;
					else result -= digit;
				}
				else if(source[index] is '+' or '-')
				{
					isPlus = source[index] == '+';
				}
				else if(source[index] == '(')
				{
					var (sum, newIndex) = CalculateExpression(source, index + 1);
					index = newIndex;
					if (isPlus) result += sum;
					else result -= sum;
				}
				else if(source[index] == ')')
				{
					return (result, index);
				}

				index++;
			}

			return (result, index);
		}
	}
}