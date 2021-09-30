using System;
using Leetcode.Classes;

namespace Leetcode.Reverse_a_Linked_List
{
	public static class ReverseLinkedList
	{
		public static void Go()
		{
			var source = Initialize();

			var (head, _) = ReverseListRecursively(source);
			source.Next = null;

			Console.WriteLine("Recursive result:");
			head?.Print();

			source = Initialize();
			head = ReverseIteratively(source);

			Console.WriteLine();
			Console.WriteLine("Iterative result:");
			head?.Print();
		}

		private static LinkedNode<int> Initialize()
		{
			var source = new LinkedNode<int>(4)
			{
				Next = new LinkedNode<int>(3)
				{
					Next = new LinkedNode<int>(2)
					{
						Next = new LinkedNode<int>(1)
						{
							Next = new LinkedNode<int>(0)
						}
					}
				}
			};
			return source;
		}

		private static (LinkedNode<T>, LinkedNode<T>) ReverseListRecursively<T>(LinkedNode<T> head)
		{
			if (head is null) return (null, null);
			if (head.Next is null) return (head, head);
			var (newHead, tail) = ReverseListRecursively(head.Next);
			tail.Next = head;
			return (newHead, head);
		}

		private static LinkedNode<T> ReverseIteratively<T>(LinkedNode<T> head)
		{
			if (head is null) return null;
			var currentNode = head;
			LinkedNode<T> prevNode = null;

			while (true)
			{
				var nextNode = currentNode.Next;
				var temp = nextNode.Next;
				if (nextNode.Next is not null)
				{
					nextNode.Next = currentNode;
				}

				currentNode.Next = prevNode;
				prevNode = nextNode;
				currentNode = temp;

				if (currentNode.Next is null)
				{
					currentNode.Next = prevNode;
					return currentNode;
				}
			}
		}
	}
}