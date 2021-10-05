using Leetcode.Classes;

namespace Leetcode.Invert_a_Binary_Tree
{
	public static class InvertBinaryTree
	{
		public static void Go()
		{
			var source = new TreeNode<char>('a')
			{
				Left = new TreeNode<char>('b') {Left = new TreeNode<char>('d'), Right = new TreeNode<char>('e')},
				Right = new TreeNode<char>('c') {Left = new TreeNode<char>('f')}
			};

			InvertTree(source);

			source.Print();
		}

		private static void InvertTree(TreeNode<char> node)
		{
			if(node is null) return;
			InvertTree(node.Left);
			InvertTree(node.Right);
			var temp = node.Left;
			node.Left = node.Right;
			node.Right = temp;
		}
	}
}