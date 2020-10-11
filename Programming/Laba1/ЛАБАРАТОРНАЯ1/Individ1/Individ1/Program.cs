using System;

namespace Individ1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Введите ФИО");
			string name = Console.ReadLine();
			Console.WriteLine("Введите Тип (Т/С)");
			string type = Console.ReadLine();
			Console.WriteLine("Введте год рождения");
			int year = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите стаж (опыт (лет))");
			int exp = Convert.ToInt32(Console.ReadLine());

			string[,] table = new string[5,4];
			table[0, 0] = "ФИО";
			table[0, 1] = "Тип";
			table[0, 2] = "Год Рождения";
			table[0, 3] = "Опыт(лет)";
			table[1, 0] = "Петров А.А.";
			table[1, 1] = "Т";
			table[1, 2] = "1950";
			table[1, 3] = "22";
			table[2, 0] = "Шишкин С.К.";
			table[2, 1] = "Т";
			table[2, 2] = "1984";
			table[2, 3] = "8";
			table[3, 0] = "Кравченко Г.А.";
			table[3, 1] = "С";
			table[3, 2] = "1981";
			table[3, 3] = "10";
			table[4, 0] = name;
			table[4, 1] = type;
			table[4, 2] = Convert.ToString(year);
			table[4, 3] = Convert.ToString(exp);

			Console.WriteLine("{0,-20} {1,-15} {2,-30} {3,-20}",table[0, 0],table[0,1],table[0,2],table[0,3]);
			Console.WriteLine("{0,-20} {1,-15} {2,-30} {3,-20}",table[1, 0],table[1, 1],table[1, 2],table[1, 3]);
			Console.WriteLine("{0,-20} {1,-15} {2,-30} {3,-20}",table[2, 0],table[2, 1],table[2, 2],table[2, 3]);
			Console.WriteLine("{0,-20} {1,-15} {2,-30} {3,-20}",table[3, 0],table[3, 1],table[3, 2],table[3, 3]);
			Console.WriteLine("{0,-20} {1,-15} {2,-30} {3,-20}",table[4, 0],table[4, 1],table[4, 2],table[4, 3]);
			Console.ReadKey();
		}
	}
}
