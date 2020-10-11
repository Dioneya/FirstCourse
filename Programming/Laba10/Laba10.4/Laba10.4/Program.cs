using System;
using System.Collections.Generic;
using System.Collections;
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
			//СОЗДАНИЕ ТАБЛИЦЫ РАССТОЯНИЙ МЕЖДУ ГОРОДАМИ, где a[i,j] - расстояние между городом, если нет прямого пути, то a[i,j] = -1
			//Таблица была взята на основе 3-его задания
			int[,] a = {
				{-1,40,80,-1,-1,-1,-1,-1}, //1
				{40,-1,-1,-1,-1,150,80,-1}, //2 
				{80,-1,-1,60,-1,40,-1,150}, //3 
				{-1,-1,60,-1,120,-1,-1,-1}, //4
				{-1,-1,-1,120,-1,50,-1,-1}, //5
				{-1,150,40,-1,50,-1,-1,-1}, //6
				{-1,80,-1,-1,-1,-1,-1,150}, //7
				{-1,-1,150,-1,-1,-1,150,-1}  //8
			};


			var graph = new Graph(a, 8);


			int i = 0;
			ColorfulText("Введите № города от 1-8\n",ConsoleColor.Cyan);
			InitializeAndCheckVar(ref i);

			//СОЗДАНИЕ СЛОВАРЯ ДЛЯ ХРАНЕНИЯ ВСЕХ СЛУЧАЕВ ВСТРЕТИВЧШИХ НА ПУТИ И ИХ РАССТОЯНИЕ

			var dictionary_of_distance = new Dictionary<string, int>();
			ColorfulText("Маршруты для городов\n", ConsoleColor.DarkGreen);

			for (int j = 0; j < 8; j++) 
			{
				/*Чтобы облегчить работы программы и дейстововать к методу динамического программирование, 
				проверим, не имеются ли у нас результаты данного подсчёта, чтобы не делать подсчёт снова*/

				if (!dictionary_of_distance.ContainsKey(i + " " + j + 1))
				{
					if (i != j+1) 
					{
						var stackBFS = graph.BFS(i - 1, j); 
						ShowPath(stackBFS);
						Console.WriteLine();
						AddToDitionary(stackBFS, a, ref dictionary_of_distance, i); // метод в котором происходит расчипление всего пути полученного стэка и добавление результатов в словарь
					}

				}

			}

			foreach (KeyValuePair<string,int> keyValue in dictionary_of_distance) 
			{
				if (keyValue.Value <= 200)
					Console.WriteLine(keyValue.Key +" - "+keyValue.Value);
			}
			Console.ReadKey();
		}

		public static void AddToDitionary(Stack<int> stack, int[,] a, ref Dictionary<string, int> dict, int start_pos) 
		{
			int prev_num = -1;

			int sum = 0;
			foreach (int i in stack) 
			{
				if (prev_num == -1) 
					prev_num = i;
				else 
				{
					sum += a[prev_num, i];
					prev_num = i;
					dict[(start_pos) + " " + (i+1)] = sum;
				}
			}
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
				Console.Write((cnt == 0) ? Convert.ToString(i + 1) : "->" + (i + 1)); //если элемент был первым, то вывести просто i+1, иначе вывести с указателем "->"
				cnt++;
			}
		}
	}
}
