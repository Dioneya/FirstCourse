using System;

namespace Laba2Indidid2
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			for (int x = 10; x <= 99; x++) 
			{
				int first = x/10;
				int second = x % 10;
				int sum = first + second;
				if (sum == 0 || sum == 5)
				{
					Console.WriteLine(x);
				}
			}
			Console.ReadKey();
		}
	}
}
