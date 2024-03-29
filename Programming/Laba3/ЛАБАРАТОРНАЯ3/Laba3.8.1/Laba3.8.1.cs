using System;

namespace Laba3
{
	class MainClass
	{
		public static int detA(int[,] matrix, int N)
		{
			if (N == 2)
			{
				return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
			}

			else if (N == 1)
			{
				return matrix[0, 0];
			}

			else
			{
				int[,] miniMatrix = new int[N-1,N-1];
				int row = 0; int col = 0; int det = 0;

				for (int j = 0; j < N; j++) 
				{
					row = 0;
					for (int k = 1; k < N; k++)
					{
						col = 0;
						for (int s = 0; s < N;s++) 
						{
							if (s != j)
							{
								miniMatrix[row, col] = matrix[k, s];
								col++;
							}
						}
						row++;
					}
					det += (int)(Math.Pow(-1, j + 2) * matrix[0, j] * detA(miniMatrix,N-1));
				}
				return det;
			}
		}

		public static void Main(string[] args)
		{
			Console.WriteLine("Write N");
			int N = Convert.ToInt32(Console.ReadLine());

			int[,] matrix = new int[N, N];

			Random rnd = new Random();

			for (int j = 0; j < N; j++)
			{
				for (int i = 0; i < N; i++)
				{
					matrix[i, j] = rnd.Next(0, 9);
					Console.Write(matrix[i, j] + " ");
				}
				Console.WriteLine();
			}

			Console.WriteLine(detA(matrix, N));

			Console.ReadKey();
		}
	}
}
