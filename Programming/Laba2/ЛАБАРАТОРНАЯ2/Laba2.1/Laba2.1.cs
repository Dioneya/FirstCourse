using System;

namespace Laba2
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int i = 1;
			while (i == 1)
			{
				try
				{
					double a = Convert.ToDouble(Console.ReadLine());
					double b = Convert.ToDouble(Console.ReadLine());
					double c = Convert.ToDouble(Console.ReadLine());
					i =+ 1;

					double D = Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);
					double x1 = (-b - D) / (2 * a);
					double x2 = (-b + D) / (2 * a);


					if (D > 0)
					{
						if (x1 == x2)
						{

							Console.WriteLine("Аргумент: {0}", x1);
						}

						else
						{
							Console.WriteLine("Первый аргумент: {0,10}  Второй аргумент: {1,10}", x1, x2);
						}
					}

					else
					{
						Console.WriteLine("Не имеет действительных корней");
						Console.WriteLine("Вывод: x+iy; x-iy");
						Console.WriteLine(Math.Pow(a, 2) - Math.Pow(b, 2) * (-1));

					}

				}

				catch (FormatException)
				{
					Console.WriteLine("Введите верные значения");
					i = 1;
				}

			}

			Console.ReadKey();
		}
	}
}
