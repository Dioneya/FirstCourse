using System;

namespace Individ2
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
					k = 0;
					int[] arr = new int[6];
					int i = 0;
					Console.WriteLine("Введите значения массивов");
					while (i < 6)
					{
						arr[i] = Convert.ToInt32(Console.ReadLine());
						i++;
					}
					bool trueOrFalse = true;
					int sum = arr[0] + arr[5];
					for (i = 1; i < 3; i++)
					{
						if (arr[i] + arr[6 - i] != sum)
						{
							trueOrFalse = false;
							Console.WriteLine("FALSE");
							break;
						}
					}

					if (trueOrFalse == true)
					{
						Console.WriteLine("TRUE");
					}
					k = 1;
					Console.ReadKey();
				}

				catch 
				{
					k = 1;
					Console.WriteLine("Не ломайте код, пожалуйста)))");
				}
			}

		}
	}
}
