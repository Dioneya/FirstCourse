using System;
using System.IO;
namespace Laba9
{
	class MainClass
	{
		public static void Selected(CircularLinkedList<string> members,int wordLength) 
		{
			int count = 0;
			foreach (string name in members)
			{
				if (count == wordLength)
				{
					Console.WriteLine(name);
				}
				count++;
			}
		}

		public static void Main(string[] args)
		{
			var members = new CircularLinkedList<string>();
			string path = @"C:\Users\user\Documents\Projects\ЛАБАРАТОРНАЯ 9\Laba9.3\Имена.txt";
			using (var fileRead = new StreamReader(path)) 
			{
				while (fileRead.Peek() > -1) 
				{
					members.Add(fileRead.ReadLine());
				}
			}

			foreach (string member in members) 
			{
				Console.Write(member +" ");
			}
			Console.WriteLine();
			Console.WriteLine("С кого начать отсчёт?");
			string name = "";
			while (!members.Contains(name)) 
			{
				name = Console.ReadLine();
				if (!members.Contains(name)) 
				{
					Console.WriteLine("Введите верное имя");
				}
			}

			Console.WriteLine("Введите считалочку");
			string text = Console.ReadLine();
			string[] word = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			members.Swap(name);
			Selected(members, word.Length);

			Console.ReadKey();
		}
	}
}
