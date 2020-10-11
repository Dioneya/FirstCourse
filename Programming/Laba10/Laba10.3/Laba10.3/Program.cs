using System;
using System.Collections;
using System.Collections.Generic;

namespace Laba10
{
	class MainClass
	{
		static void ColorfulText(string a, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.Write(a);
			Console.ResetColor();
		}

		public static void Main(string[] args)
		{
			int[,] matrixAdj = {
				{0,1,1,0,0,0,0,0}, //1
				{1,0,0,0,0,1,1,0}, //2
				{1,0,0,1,0,1,0,1}, //3
				{0,0,1,0,1,0,0,0}, //4
				{0,0,0,1,0,1,0,0}, //5
				{0,1,1,0,1,0,0,0}, //6
				{0,1,0,0,0,0,0,1}, //7
				{0,0,1,0,0,0,1,0}  //8
			};

			var graph = new Graph(matrixAdj,8);

			int X=0; int Y=0;


			Console.Write("Введите вершину ");
			ColorfulText("X\n",ConsoleColor.Cyan);
			InitializeAndCheckVar(ref X);

			Console.Write("Введите вершину ");
			ColorfulText("Y\n",ConsoleColor.Cyan);
			InitializeAndCheckVar(ref Y);

			ColorfulText("В виде матрицы инцидентности:\n", ConsoleColor.Magenta);

			ColorfulText("DFS:\n",ConsoleColor.Green);
			var DFS = graph.DFS(X-1,Y-1);
			ShowPath(DFS);
			Console.WriteLine();

			ColorfulText("BFS:\n", ConsoleColor.Green);
			var BFS = graph.BFS(X-1,Y-1);
			ShowPath(BFS);
			Console.WriteLine();

			//======================Связным списком=================================
			ColorfulText("В виде связного списка:\n", ConsoleColor.Magenta);

			var graph1 = new Dictionary<int, List<int>>();
			graph1[1] = new List<int> { 2, 3 };
			graph1[2] = new List<int> { 1, 6, 7 };
			graph1[3] = new List<int> { 1, 4, 6, 8 };
			graph1[4] = new List<int> { 3, 5 };
			graph1[5] = new List<int> { 4, 6 };
			graph1[6] = new List<int> { 2, 3, 5 };
			graph1[7] = new List<int> { 2, 8 };
			graph1[8] = new List<int> { 3, 7 };

			var graphLink = new GraphLink(graph1,8);
			ColorfulText("DFS:\n", ConsoleColor.Green);
			var DFS_Link = graphLink.DFS(X - 1, Y - 1);
			ShowPath(DFS_Link);
			Console.WriteLine();

			ColorfulText("BFS:\n", ConsoleColor.Green);
			var BFS_Link = graphLink.BFS(X - 1, Y - 1);
			ShowPath(BFS_Link);

			Console.ReadKey();
		}

		public static void InitializeAndCheckVar(ref int i) 
		{
			bool isPass = false;
			while (!isPass)
			{
				try
				{
					i = Convert.ToInt32(Console.ReadLine());
					if (i > 0 && i <= 8)
						isPass = true;
					else
						Console.WriteLine("Введите верное значение");
				}
				catch
				{
					Console.WriteLine("Введите верное значение");
				}
			}
		}

		static void ShowPath(Stack<int> stack) 
		{
			int cnt = 0;
			foreach (int i in stack)
			{
				Console.Write( (cnt==0) ? Convert.ToString(i + 1) : "->"+(i + 1));
				cnt++;
			}
		}
	}
}
