using System;

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

		public void Print()
		{
			var currentValue = this;

			while (currentValue != null)
			{
				Console.Write(currentValue.Value.ToString());
				currentValue = currentValue.Next;
				if(currentValue != null) Console.Write(" -> ");
			}
		}
	}
}