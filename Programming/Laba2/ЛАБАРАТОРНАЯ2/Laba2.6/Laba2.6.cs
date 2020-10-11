using System;

namespace Laba2
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int k = 1;
			while (k == 1) 
			{ 
				try
				{
					Console.WriteLine("Enter number N, 1<N<100");
					int N = Convert.ToInt32(Console.ReadLine());
					int n = N % 10;
					k = 0;

					if (N >= 1 && N <= 100)
					{
						if (n == 1)
						{
							Console.WriteLine("Пользователю " + N + " год");
						}
						else if (n >= 2 && n < 5)
						{
							Console.WriteLine("Пользователю " + N + " года");
						}
						else if (n >= 5 || n == 0)
						{
							Console.WriteLine("Пользователю " + N + " лет");
						}

					}

					else 
					{
						Console.WriteLine("Enter a valid number");
						k = 1;
					}

				}

				catch(FormatException)
				{
					Console.WriteLine("Enter a valid number");
					k = 1;
				}
			}
			Console.ReadKey();

		}
	}
}
