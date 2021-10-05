using System;
using System.Collections.Generic;

namespace Leetcode.Classes
{
	public class TreeNode<T>
	{
		public TreeNode(T value)
		{
			Value = value;
		}

		public T Value;

		public TreeNode<T> Left;
		public TreeNode<T> Right;

		public void Print()
		{
			var result = new List<List<T>>();
			GatherNodes(this, 0, result);

			for (var i = 0; i < result.Count; i++)
			{
				foreach (var value in result[i])
				{
					for (var j = 0; j < (result.Count - i); j++)
					{
						Console.Write(' ');
					}

					Console.Write(value);
				}

				Console.WriteLine();
			}
		}

		private static void GatherNodes(TreeNode<T> node, int level, IList<List<T>> result)
		{
			if (node == null) return;
			if (result.Count <= level) result.Add(new List<T>());
			result[level].Add(node.Value);
			GatherNodes(node.Left, level+1,result);
			GatherNodes(node.Right, level+1,result);
		}
	}
}