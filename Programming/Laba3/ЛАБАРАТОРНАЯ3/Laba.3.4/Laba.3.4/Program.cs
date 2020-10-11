using System;

namespace Laba
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int[,] massive1 = new int[3,3]; int[,] massive2 = new int[3, 3];
			Random rnd = new Random();
			int i = 0; int j = 0;
			//
			Console.WriteLine("Первый массив");
			for (j = 0; j < 3; j++) 
			{
				for (i = 0; i < 3; i++) 
				{
					massive1[i,j] = rnd.Next(0,9);
					Console.Write(massive1[i,j]+" ");
				}
				Console.WriteLine();
			}
			//
			Console.WriteLine("Второй массив");
			for (j = 0; j < 3; j++)
			{
				for (i = 0; i < 3; i++)
				{
					massive2[i, j] = rnd.Next(0,9);
					Console.Write(massive2[i,j]+" ");
				}
				Console.WriteLine();
			}
			//
			Add(massive1, massive2, 0);
			//
			Console.WriteLine("Итоговый массив вычетания");
			Sub(massive1, massive2, 0);

			Console.ReadKey();
		}

		public static void Add(int[,] firstMassive, int[,] secondMassive, int midZnach) 
		{
			int[,] sum = new int[3, 3];
			int sUm = 0;
			Console.WriteLine("Итоговый массив сложения");
			for (int j = 0; j < 3; j++)
			{
				for (int i = 0; i < 3; i++)
				{
					sum[i,j]= firstMassive[i, j]+secondMassive[i, j];
					Console.Write(sum[i,j]+" ");
					sUm += sum[i, j];
				}
				Console.WriteLine();
			}
			Console.WriteLine("Срденее значение:"+sUm/9);

		}

		public static void Sub(int[,] firstMassive, int[,] secondMassive, int midZnach) 
		{
			int[,] dis = new int[3, 3];
			int dIs = 0;
			for (int j = 0; j < 3; j++)
			{
				for (int i = 0; i < 3; i++)
				{
					dis[i,j]=firstMassive[i, j] - secondMassive[i, j];
					dIs += dis[i,j];
					Console.Write(dis[i,j]+" ");
				}
				Console.WriteLine();
			}
			Console.WriteLine("Срденее значение:" + dIs / 9);
		}
	}
}
