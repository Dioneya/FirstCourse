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
					Console.WriteLine("Enter the number of terms:");
					int n = Convert.ToInt32(Console.ReadLine());


					double[] znach = new double[n];
					double j = 1;
					double pi = 0;
					int i = 0;
					k = k - 1;
					while (i < n)
					{
						double sum = 1 / j; //подсчёт положительного знаменателя 
						j = j + 2; //увеличение на 2 знаменатель
						double sum1 = -1 / j; // подсчёт отриц знаменателя 
						j = j + 2;
						pi = pi + sum + sum1; //прибавление к pi последующие суммы слагаемых
						i += 2;
						if (i > n) //если значение перевалило за n, то вычитаем последнее значение
						{
							pi = pi - sum1;
						}
					}
					Console.WriteLine("Pi is:");
					Console.WriteLine(pi/4);
				}

				catch (FormatException)
				{
					Console.WriteLine("Enter a valid value");
					k = 1;

				}

			}
			Console.ReadKey();
		}
	}
}
