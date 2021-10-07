using System;

namespace Leetcode.Maximum_In_A_Stack
{
	public static class MaximumInStack
	{
		public static void Go()
		{
			var s = new MaxStack();
			s.Push(1);
			s.Push(2);
			s.Push(3);
			s.Push(2);
			Console.WriteLine(s.Max());
			s.Pop();
			s.Pop();
			Console.WriteLine(s.Max());
		}
	}
}
