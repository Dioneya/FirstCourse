using System;

namespace Laba1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int x = Convert.ToInt32(Console.ReadLine());

			double result = 3 * Math.Pow(x, 4) - 5 * Math.Pow(x, 3) + 2 * Math.Pow(x, 2) - x + 7;

			Console.Write(result);
			Console.ReadKey();
		}
	}
}
