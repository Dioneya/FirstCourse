using System;

namespace Laba3
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int j = 0;
			int i = 0;	
			int num = 0;
			int[,] massive = new int [7,7];

			for (j = 0; j <7; j++) 
			{
				for (i = 0; i < 7; i++) 
				{
					num++;
					massive[i, j] = num;
					Console.Write(massive[i,j]+" ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
			for (i = 0; i < 7; i++) 
			{
				for (j = 6; j!= -1; j--) 
				{
					Console.Write(massive[i,j]+" ");
				}
				Console.WriteLine();
			}

			Console.ReadKey();

		}
	}
}
