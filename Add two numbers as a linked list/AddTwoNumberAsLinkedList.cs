using System;
using Leetcode.Classes;

namespace Leetcode.Add_two_numbers_as_a_linked_list
{
	public static class AddTwoNumberAsLinkedList
	{
		public static void Go()
		{
			var l1 = new LinkedNode<byte>(2) {Next = new LinkedNode<byte>(4) {Next = new LinkedNode<byte>(3)}};
			var l2 = new LinkedNode<byte>(5) {Next = new LinkedNode<byte>(6) {Next = new LinkedNode<byte>(4)}};

			var result = AddTwoNumbers(l1, l2);

			while (result is not null)
			{
				Console.WriteLine(result.Value);
				result = result.Next;
			}
		}

		private static LinkedNode<byte> AddTwoNumbers(LinkedNode<byte> l1, LinkedNode<byte> l2)
		{
			if (l1 is null && l2 is null) return null;

			var result = new LinkedNode<byte>();
			var currentNode1 = l1;
			var currentNode2 = l2;
			var shift = 0;
			var resultCurrentNode = result;

			do
			{
				var currentValue1 = currentNode1?.Value ?? 0;
				var currentValue2 = currentNode2?.Value ?? 0;

				ValidateIfValueOneDigitOnly(currentValue1, nameof(l1));
				ValidateIfValueOneDigitOnly(currentValue2, nameof(l2));

				var sum = currentValue1 + currentValue2 + shift;
				var value = sum % 10;
				shift = sum / 10;
				resultCurrentNode.Value = (byte)value;

				if (currentNode1?.Next is not null || currentNode2?.Next is not null)
				{
					resultCurrentNode.Next = new LinkedNode<byte>();
					resultCurrentNode = resultCurrentNode.Next;
				}

				currentNode1 = currentNode1?.Next;
				currentNode2 = currentNode2?.Next;

			} while (currentNode1 is not null || currentNode2 is not  null);

			return result;
		}

		private static void ValidateIfValueOneDigitOnly(byte currentValue, string paramValue)
		{
			if (currentValue / 10 != 0) throw new ArgumentException("Value is not one digit only", nameof(paramValue));
		}
	}
}