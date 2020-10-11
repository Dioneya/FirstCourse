using System;

namespace Laba3
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int[] massive = {2,1,3,4};
			Console.WriteLine("Значения массива:1, 2, 3, 4");
			Console.WriteLine();
			sumIteractive(0);
			Console.WriteLine("Сложение значений при помощи рекурсии:");
			Console.WriteLine(sumRecursive(massive,4));
			Console.WriteLine("Нахождение минимального значения при помощи итерации");
			Console.WriteLine(minIteractive(massive, 4));
			Console.WriteLine("Нахождение минимального значения при помощи рекурсии");
			Console.WriteLine(minRecirsive(massive, 4, 99, 0));
			Console.ReadKey();
		}
		public static void sumIteractive(int massive)
		{
			Console.WriteLine("Сложение значений при помощи итерации:");
			int[] massive1 =new int[4];
			massive1[0] = 1; massive1[1] = 2; massive1[2] = 3; massive1[3] = 4;
			int sum = 0;
			for (int i = 0; i < 4; i++) 
			{
				sum += massive1[i];
			}
			Console.WriteLine(sum);
		}
		public static int sumRecursive(int[] massive, int i)
		{
			if (i > 0)
			{
				return massive[i - 1] + sumRecursive(massive, i - 1);
			}
			else
				return 0;
		}

		public static int minIteractive(int[] massive, int i) 
		{
			int min = massive[0];
			for (int j = 0; j < i;)
			{
				j++;
				if (massive[j] < min)
				{
					min = massive[j];
					return min;
				}
				else {
					return min;
				}

			}
			return min;
		}

		public static int minRecirsive(int[] massive, int size, int min, int i) 
		{
			if (i < size)
			{
				if (massive[i] < min)
				{
					min = massive[i];
				}
				i++;
				return minRecirsive(massive, size, min, i);
			}
			else 
			{
				return min;
			}
		}

	}
}
