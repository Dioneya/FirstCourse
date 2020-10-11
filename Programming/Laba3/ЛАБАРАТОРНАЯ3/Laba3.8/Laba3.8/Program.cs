using System;

namespace Laba3
{
	class MainClass
	{
		public static int M(int[,] matrix, int N, int col)
		{
			int sum = 1; int cnt = 0; int dif = N - 3;
			for (int i = 0; i < N-dif; i++)
			{
				sum *= matrix[col, i];
			}
			for (int j = 1; j < N - 1; j++)
			{
				for (int i = 0; i < N - 1; i++)
				{
					if (i == col)
					{
						cnt = 1;
						continue;
					}
					matrix[i, j] = matrix[i + cnt, j + 1];
				}
				cnt = 0;
			}

			return sum*(matrix[0, 0] * matrix[1, 1] * matrix[2, 2] + matrix[1, 0] * matrix[2, 1] * matrix[0, 2] + matrix[2,0] * matrix[1,0]*matrix[2,1] - matrix[0,2]*matrix[1,1]*matrix[2,0] - matrix[0,1]*matrix[1,0]*matrix[2,2]-matrix[0,0]*matrix[1,2]*matrix[2,1]);
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
			int sum = 0;
			if (N == 3)
			{
				sum = matrix[0, 0] * matrix[1, 1] * matrix[2, 2] + matrix[1, 0] * matrix[2, 1] * matrix[0, 2] + matrix[2, 0] * matrix[1, 0] * matrix[2, 1] - matrix[0, 2] * matrix[1, 1] * matrix[2, 0] - matrix[0, 1] * matrix[1, 0] * matrix[2, 2] - matrix[0, 0] * matrix[1, 2] * matrix[2, 1];
			}
			else if (N == 1)
			{
				sum = matrix[0, 0];
			}
			else if (N == 2)
			{

			}
			else 
			{
				bool minus = false;
				for (int k = 0; k < N; k++)
				{
					if (minus == false)
					{
						sum += M(matrix, N, k);
						minus = true;
					}
					else
					{
						sum -= M(matrix, N, k);
						minus = false;
					}
				}
			}


			Console.WriteLine(sum);

			Console.ReadKey();
		}
	}
}
