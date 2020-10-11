using System;

namespace Laba10
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var rnd = new Random();
			int[] arr = new int[100];
			for (int i = 0; i < arr.Length; i++)
			{
				int rndMoney = rnd.Next(0, 7);
				MoneyGenerator(arr, i, rndMoney);
				Console.Write(arr[i]+" ");
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine("Отсортированный методом - подсчёта");

			CountingSort(arr, 0, arr.Length-1);

			foreach (int sortedMoney in arr)
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.Write(sortedMoney + " ");
			}

			Console.ReadKey();
		}

		public static void MoneyGenerator(int[] arr, int i, int rndMoney)
		{
			const int oneDollarCase = 0;
			const int twoDollarsCase = 1;
			const int fiveDollarsCase = 2;
			const int tenDollarsCase = 3;
			const int twentyDollarsCase = 4;
			const int fiftyDollarsCase = 5;
			const int oneHundredDollarsCase = 6;

			switch (rndMoney) 
			{
				case oneDollarCase:
					arr[i] = 1;
					break;
				case twoDollarsCase:
					arr[i] = 2;
					break;
				case fiveDollarsCase:
					arr[i] = 5;
					break;
				case tenDollarsCase:
					arr[i] = 10;
					break;
				case twentyDollarsCase:
					arr[i] = 20;
					break;
				case fiftyDollarsCase:
					arr[i] = 50;
					break;
				case oneHundredDollarsCase:
					arr[i] = 100;
					break;
				default:
					break;	
			}
		}

		public static void CountingSort(int[] arr, int left, int right) 
		{
			int min = 0, max = 0;

			for (int i = left; i <= right; i++) 
			{
				if (arr[i] < min)
				{
					min = arr[i];
				}
				else if (arr[i]>max) 
				{
					max = arr[i];
				}
			}

			int bn = max - min + 1;

			int[] buckets = new int[bn];

			for (int i = left; i <= right; i++) 
			{
				buckets[arr[i] - min]++;
			}

			int index = 0;
			for (int i = min; i <= max; i++) 
			{
				for (int j = 0; j < buckets[i - min]; j++) 
				{
					arr[index++] = i;
				}
			}
		}
	}
}
