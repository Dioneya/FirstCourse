using System;

namespace Individ2
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Введите x");
			double x = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите b");
			double b = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите a");
			double a = Convert.ToDouble(Console.ReadLine());
			double znamenatel1 = x+b;
			double znamenatel = Math.Exp(a * x) - 1;
			if (znamenatel1 <= 0 || znamenatel == 0)
			{
				Console.WriteLine("область недопустимых значений");
			}
			else
			{
				double tg = Math.Pow(Math.Tan((x + b) * (x + b)), 2);
				double S = Math.Pow(x, 3) * tg + a / Math.Sqrt(x + b);
				double Q = (b * (Math.Pow(x, 2) - a) / (Math.Exp(a * x) - 1));
				Console.WriteLine("S = " + S + " Q = " + Q);

			}
			Console.ReadKey();
		}
	}
}
