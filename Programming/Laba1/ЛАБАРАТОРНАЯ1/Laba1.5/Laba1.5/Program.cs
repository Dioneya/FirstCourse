using System;

namespace Laba1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Введите первый катет");
			int a = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите второй катет");
			int b = Convert.ToInt32(Console.ReadLine());

			double S = (double)(a * b) / 2;
			double c = Math.Sqrt(a*a+b*b);
			double P = a+b+c;
			Console.WriteLine("Площадь = "+S+" Периметр = "+P );
			Console.ReadKey();
		}
	}
}
