using Leetcode.Classes;

namespace Leetcode.Maximum_In_A_Stack
{
	public class MaxStack
	{
		private LinkedNode<int> _rootNode;
		private LinkedNode<int> _maxRootNode;

		public void Push(int value)
		{
			var node = new LinkedNode<int>(value);

			if (_rootNode == null)
			{
				_rootNode = node;
				_maxRootNode = new LinkedNode<int>(value);
				return;
			}

			node.Next = _rootNode;
			_rootNode = node;

			var newMaxNode =
				new LinkedNode<int>(_maxRootNode.Value < node.Value ? node.Value : _maxRootNode.Value)
				{
					Next = _maxRootNode
				};

			_maxRootNode = newMaxNode;
		}

		public int? Pop()
		{
			var result = _rootNode;

			if (_rootNode != null)
			{
				_rootNode = _rootNode.Next;
				_maxRootNode = _maxRootNode.Next;
			}

			return result?.Value;
		}

		public int? Max()
		{
			return _maxRootNode?.Value;
		}
	}
}
