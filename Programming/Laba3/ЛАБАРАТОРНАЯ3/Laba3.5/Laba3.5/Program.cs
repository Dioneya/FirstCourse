using System;

namespace Laba3
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int[,] massive1 = new int[5, 5];
			int[,] massive2 = new int[5, 5];
			int[,] massive3 = new int[5, 5];
			Random rnd = new Random();
			int znach = 0;
			for (int j = 0; j < 5; j++) 
			{
				for (int i = 0; i < 5; i++)
				{
					massive1[i, j] = rnd.Next(0,9);
					Console.Write(massive1[i, j]+" ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			for (int j = 0; j < 5; j++)
			{
				for (int i = 0; i < 5; i++)
				{
					massive2[i, j] = rnd.Next(0, 9);
					Console.Write(massive2[i, j]+" ");
				}
				Console.WriteLine();
			}

			Console.WriteLine();
			for (int j = 0; j < 5; j++)
			{
				for (int i = 0; i < 5; i++)
				{
					for (int k = 0; k < 5; k++)
					{
						znach += massive1[k, j] * massive2[i, k];
					}
					massive3[i, j] = znach;
					znach = 0;
					Console.Write(massive3[i,j]+" ");

				}
				Console.WriteLine();
			}




			Console.ReadKey();







		}
	}
}