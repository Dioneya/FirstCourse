using System;

namespace Laba2
{
	class MainClass
	{
		static int Factorial(int y) 
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
					Console.WriteLine("Enter x");
					int x = Convert.ToInt32(Console.ReadLine());
					Console.WriteLine("Enter q");
					int q = Convert.ToInt32(Console.ReadLine());
					double sum = 1;
					k -= 1;
					int i = 0;
					int fact = 0;
					double znach1 = 0;
					for (double znach = 0; znach < q || -znach1 < q;)

					{
						znach1 = -Math.Pow(x, 2) / Factorial(fact + 2);
						x = (int)Math.Pow(x, 2);
						fact += 2;
						i += 1;
						znach = Math.Pow(x, 2) / Factorial(fact + 2);
						x = (int)Math.Pow(x, 2);
						fact += 2;
						sum = sum+znach1+znach;
						i += 1;
						if (znach > q)
						{
							sum = sum - znach;
							i -= 1;
						}
						if (-znach1 > q)
						{
							sum = sum - znach1;
							i -= 1;
						}
					}

					if (i == 0)
					{
						i += 1;
					}
					Console.WriteLine("Значение cos(x)= "+Math.Cos(sum));
					Console.WriteLine("Колличество слагаемых = "+i);
				}

				catch
				{
					Console.WriteLine("Enter a valid value");
					k = 1;
				}

				Console.ReadKey();
			}
		}
	}
}
