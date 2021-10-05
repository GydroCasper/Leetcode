using System;
using Leetcode.Classes;

namespace Leetcode.Floor_and_Ceiling_of_a_Binary_Search_Tree
{
	public class FloorAndCeilingOfBinarySearchTree
	{
		public static void Go()
		{
			var source = new TreeNode<int>(8)
			{
				Left = new TreeNode<int>(4) {Left = new TreeNode<int>(2), Right = new TreeNode<int>(6)},
				Right = new TreeNode<int>(12) {Left = new TreeNode<int>(10), Right = new TreeNode<int>(14)}
			};

			const int target = 5;

			var result = FindFloorAndCeiling(source, target);
			Console.WriteLine(result);
		}

		private static (int?, int?) FindFloorAndCeiling(TreeNode<int> node, int target, int? floor = null,
			int? ceiling = null)
		{
			if (node is null) return (floor, ceiling);
			if (node.Value == target) return (floor, ceiling);

			return node.Value < target
				? FindFloorAndCeiling(node.Right, target, node.Value, ceiling)
				: FindFloorAndCeiling(node.Left, target, floor, node.Value);
		}
	}
}
