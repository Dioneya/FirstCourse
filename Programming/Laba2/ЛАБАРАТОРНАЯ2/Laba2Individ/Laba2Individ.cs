using System;

namespace Laba2Individ
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int k = 1;
			while (k==1)
			{
				try
				{
					Console.WriteLine("Enter first number");
					double x = Convert.ToDouble(Console.ReadLine());
					Console.WriteLine("Enter second number");
					double y = Convert.ToDouble(Console.ReadLine());
					Console.WriteLine("Enter third number");
					double z = Convert.ToDouble(Console.ReadLine());
					int number = 0;
					k = 0;
					if (x > y && x > z)
					{
						number = 1;
					}
					else if (y > x && y > z)
					{
						number = 2;
					}

					else
					{
						number = 3;
					}

					switch (number)
					{
						case 1:
							if (y > z)
							{
								Console.WriteLine(x - z);
							}
							else
							{
								Console.WriteLine(x - y);
							}
							break;
						case 2:
							if (x > z)
							{
								Console.WriteLine(y - z);
							}
							else
							{
								Console.WriteLine(y - x);
							}
							break;
						case 3:
							if (x > y)
							{
								Console.WriteLine(z - y);
							}
							else
							{
								Console.WriteLine(z - x);
							}
							break;
					}
				}

				catch
				{
					Console.WriteLine("Enter a valid numbers");
					k = 1;
				}
			}
			Console.ReadKey();
		}
	}
}
