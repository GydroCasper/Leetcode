using System;

namespace Leetcode.Edit_Distance
{
	public static class EditDistance
	{
		public static void Go()
		{
			var first = "biting";
			var second = "sitting";

			Console.WriteLine(FindEditDistance(first, second));
		}

		private static int FindEditDistance(string first, string second)
		{
			if (first is null) throw new ArgumentException("String is null", nameof(first));
			if (second is null) throw new ArgumentException("String is null", nameof(second));

			var i = 0;
			var j = 0;
			var distance = 0;

			while (i < first.Length || j < second.Length)
			{
				if (i >= first.Length)
				{
					distance++;
					j++;
					continue;
				}

				if (j >= second.Length)
				{
					distance++;
					i++;
					continue;
				}

				if (first[i] != second[j])
				{
					distance++;
					if (i < first.Length - 1 && first[i + 1] == second[j])
					{
						i++;
						continue;
					}

					if (j < second.Length - 1 && first[i] == second[j + 1])
					{
						j++;
						continue;
					}
				}

				i++;
				j++;
			}

			return distance;
		}
	}
}
