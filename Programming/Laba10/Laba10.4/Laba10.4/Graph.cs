using System;
using System.Collections.Generic;
namespace Laba10
{
	public class Graph
	{

		private int vertices = 0;

		private int[,] graph = null;



		public Graph(int[,] adj, int num_Of_Vert)
		{
			graph = adj;
			vertices = num_Of_Vert;
		}

		public Stack<int> backChain(int[] p, int startPos, int endPos)
		{
			int pos = endPos;

			var pathStack = new Stack<int>();
			pathStack.Push(pos);

			while (pos != startPos)
			{
				pos = p[pos];
				pathStack.Push(pos);
			}

			return pathStack;
		}

		public Stack<int> BFS(int startPos, int endPos)
		{
			var q = new Queue<int>();

			// array for tracking path
			int[] vPath = new int[vertices];

			int[] checkedv = new int[vertices];
			q.Enqueue(startPos);
			checkedv[startPos] = 1;

			while (q.Count > 0)
			{
				int i = q.Dequeue();

				for (int j = 0; j < vertices; j++)
				{
					if (graph[i, j] > -1 && checkedv[j] == 0)
					{
						checkedv[j] = 1;
						q.Enqueue(j);
						vPath[j] = i;

						if (j == endPos)
						{
							return backChain(vPath, startPos, endPos);
						}
					}
				}
			}
			return null;
		}

	}
}
