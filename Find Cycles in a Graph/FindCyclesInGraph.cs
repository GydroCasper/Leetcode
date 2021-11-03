using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode.Find_Cycles_in_a_Graph
{
	public class FindCyclesInGraph
	{
		public static void Go()
		{
			var source = new List<List<int>> { new() { 1,2 }, new() { 0, 2 }, new() { 0,1 } };

			Console.WriteLine(FindCycles(source));
		}

		private static bool FindCycles(List<List<int>> graph)
		{
			if (graph is null || !graph.Any()) return false;

			var vertices = new HashSet<int>();

			for (var i = 0; i < graph.Count; i++)
			{
				if(vertices.Contains(i)) continue;
				if (FindCycles(graph, vertices, i)) return true;
			}

			return false;
		}

		private static bool FindCycles(List<List<int>> graph, HashSet<int> vertices, int currentNode, int? prevNode = null)
		{
			var edges = graph[currentNode];
			if (edges is null || !edges.Any()) return false;
			vertices.Add(currentNode);

			foreach (var edge in edges)
			{
				if (edge == prevNode) continue;
				if (vertices.Contains(edge)) return true;
				if (FindCycles(graph, vertices, edge, currentNode)) return true;
			}

			return false;
		}
	}
}
