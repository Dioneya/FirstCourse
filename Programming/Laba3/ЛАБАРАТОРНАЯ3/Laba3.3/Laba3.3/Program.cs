using System;

namespace Laba3
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int d = 1;
			while (d == 1) 
			{
				try
				{
					d = 0;

					Console.WriteLine("Enter k value");
					int k = Convert.ToInt32(Console.ReadLine());
					int[] massive = new int[k + 4]; // дабавляем +4 значения в строке, чтобы были видны изменения в перемещении 
					int i = 0;
					int num = k + 4; // всего чисел, нужная переменная чтобы из неё сохранять положения предедущего массива
					int cycle = 0;
					for (i = 0; i < k + 4; i++)
					{
						massive[i] = i;
						Console.Write(massive[i] + " ");
					}
					Console.WriteLine();
					Console.WriteLine("Первоначальный массив");
					while (cycle != 5)
					{
						num -= 4;
						if (num <= 0) //сброс в случае перехода в отриц число 
						{
							num = k + 4;
						}

						for (i = num; i < k + 4; i++)//цикл который выводит числа после перемещения
						{
							Console.Write(massive[i] + " ");
						}
						for (i = 0; i < num; i++) // цикл который выводит числа которые не вышли за границы, после перемещения
						{
							Console.Write(massive[i] + " ");
						}

						Console.WriteLine();
						cycle++;
					}

				}
				catch 
				{
					Console.WriteLine("Не ломайте код, пожалуйста))))");
					d = 1;
				}
				Console.ReadKey();
			}
		}
	}
}
