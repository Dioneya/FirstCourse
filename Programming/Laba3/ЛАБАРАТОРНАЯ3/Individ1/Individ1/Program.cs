using System;

namespace Individ1
{
	class MainClass
	{

		/*
			0  0  0  0  0  0  0  0  0
			1  0  0  0  0  0  0  0  26 
			2  8  0  0  0  0  0  21 27
			3  9  13 0  0  0  18 22 28
			4  10 14 16 0  17 19 23 29
			5  11 15 0  0  0  20 24 30
			6  12 0  0  0  0  0  25 31
			7  0  0  0  0  0  0  0  32
			0  0  0  0  0  0  0  0  0 

		*/
		public static void Main(string[] args)
		{
			int[,] arr = new int[9, 9];

			for (int j = 0; j < 9; j++) 
			{
				for (int i = 0; i < 9; i++) 
				{
					arr[i, j] = 0;
				}
			}
			int zero = 0;
			int znach =  7;
			int number = 0;

			for (int i = 0; i < 9; i++, znach -= 2) 
			{
				for (int j = 0; j < znach; j++) 
				{
					number++;
					zero = (9-znach)/2;
					arr[i, j+zero] = number;
					if (znach <= 0) 
					{
						break;
					}

				}
			}
			znach = -1;
			for (int i = 4; i < 9; i++, znach += 2) 
			{
				for (int j = 0; j < znach; j++) 
				{
					number++;
					zero = (9 - znach) / 2;
					arr[i, j + zero] = number;
				}
			}

			Console.WriteLine();

			for (int j = 0; j < 9; j++)
			{
				for (int i = 0; i < 9; i++)
				{
					Console.Write("{0,-3}",arr[i, j]);
				}
				Console.WriteLine();
			}

			Console.ReadKey();
		}
	}
}
