namespace Leetcode.Classes
{
	public class LinkedNode<T>
	{
		public LinkedNode()
		{
		}

		public LinkedNode(T value)
		{
			Value = value;
		}

		public T Value;

		public LinkedNode<T> Next;
	}
}