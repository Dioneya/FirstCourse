using System;
using System.Collections.Generic;
namespace Laba9
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var firstList = new DoublyLinkedList<int>();
			var secondList = new Stack<int>();
			var rnd = new Random();

			for (int i = 0; i < 10; i++) 
			{
				int number = rnd.Next(0, 20);
				if (i == 0)
				{
					firstList.AddFirst(number);
				}
				else 
				{
					firstList.Add(number);
				}
			}

			Console.WriteLine("Значения первого списка");

			foreach (int output in firstList) 
			{
				Console.Write(output+" ");
			}

			foreach (int number in firstList) 
			{
				secondList.Add(number);
			}

			Console.WriteLine();
			Console.WriteLine("Значения второго списка");
			secondList.PrintAll();

			Console.ReadKey();
		}
	}
}

