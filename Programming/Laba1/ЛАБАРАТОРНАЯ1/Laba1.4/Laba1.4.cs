using System;

namespace Laba1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Введите x");
			int x = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите y");
			int y = Convert.ToInt32(Console.ReadLine());

			x = y + x;
			y = x - y;
			x = x - y;

			Console.WriteLine("Переменная x = "+x);
			Console.WriteLine("Переменная y = "+y);
			Console.ReadKey();

		}
	}
}
