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
	}
}