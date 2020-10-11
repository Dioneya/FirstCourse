using System;
using System.Collections.Generic;
namespace Laba9
{
	
	class MainClass
	{
		

		public static void Main(string[] args)
		{
			int N = 100000;
			var cube = new Dictionary<string, int>();
			N = (int)(Math.Pow(N, 0.33));         
			for (int x = 0; x <= N; x++)
			{
				for (int y = 0; y <= N; y++)
				{
					for (int z = 0; z <= N; z++)
					{
						var sum = (int)(Math.Pow(x, 3) + Math.Pow(y, 3) + Math.Pow(z, 3));
						cube.Add(x + "+" + y + "+" + z, sum);
					}
				}
			}
			int[] check = new int[100001];
			foreach (KeyValuePair<string, int> matches in cube)
			{
				if (matches.Value<=100000) 
				{
					check[matches.Value]++;
				}
			}
			for (int i = 0; i < 100001; i++)
			{
				if (check[i]>=6) 
				{
					Console.WriteLine(i);
				}
			}

			Console.ReadKey();
		}
	}
}
