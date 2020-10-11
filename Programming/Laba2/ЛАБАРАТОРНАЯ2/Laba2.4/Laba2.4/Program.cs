using System;

namespace Laba2
{
	class MainClass
	{
		static double Factorial(double y)
		{
			if (y == 0)
			{
				return 1;
			}
			return y * Factorial(y - 1);
		}
		public static void Main(string[] args)
		{
			int k = 1;
			while (k == 1)
			{
				try
				{
					double x = Convert.ToDouble(Console.ReadLine());
					x = x * Math.PI / 180;
					double q = Convert.ToDouble(Console.ReadLine());
					int i = 0;
					int oPerator = 0;
					double cos = 1;
					double znachenieFactAndPow = 2;
					double znach = 1;
					do
					{
						znach = Math.Pow(x, znachenieFactAndPow) / Factorial(znachenieFactAndPow);
						znachenieFactAndPow += 2;

						if (oPerator == 0) { cos = cos - znach; i++; oPerator = 1; }
						else if (oPerator == 1) { cos = cos + znach; i++; oPerator = 0;}
					}
					while (znach > q);
					Console.WriteLine(cos);
					Console.WriteLine(i);
				}

				catch
				{
					Console.WriteLine("Enter a valid value");
					k = 1;
				}


			}
			Console.ReadKey();
		}
	}
}
