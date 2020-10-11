using System;
using System.Collections.Generic;
using System.Collections;

namespace Laba9.Net
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var firstList = new List<int>();
			var secondList = new Stack<int>();
			var rnd = new Random();

			for (int i = 0; i < 10; i++)
			{
				int number = rnd.Next(0, 20);
				if (i == 0)
				{
					firstList.Add(number);
				}
				else
				{
					firstList.Add(number);
				}
			}

			Console.WriteLine("Значения первого списка");

			foreach (int output in firstList)
			{
				Console.Write(output + " ");
			}

			foreach (int number in firstList)
			{
				secondList.Push(number);
			}

			Console.WriteLine();
			Console.WriteLine("Значения второго списка");
			foreach (int output in secondList) 
			{
				Console.Write(output + " ");
			}

			Console.ReadKey();
		}
	}
}
