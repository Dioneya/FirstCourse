using System;

namespace Laba3
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int k = 1;
			while (k == 1) 
			{
				try
				{
					k = 0;





					Console.WriteLine("Enter massive value");
					int members = Convert.ToInt32(Console.ReadLine());
					int[] massive = new int[members];
					Random random = new Random();
					int newLine = 0;

					Console.WriteLine("Numbers of Massive:");

					for (int i = 0; i < members; i++)
					{
						if (i % 10 == 0)
						{
							Console.WriteLine();
						}
						int number = random.Next(-35, 45);
						massive[i] = number;
						Console.Write(massive[i] + " ");
					}
					Console.WriteLine();
					Console.WriteLine("Invert numbers of Massive:");

					for (int d = members - 1; d != -1; d--)
					{
						if (massive[d] >= 0)
						{
							newLine++;
							if (newLine % 10 == 0) { Console.WriteLine(); }
							Console.Write(massive[d] + " ");
						}
					}






				}

				catch  
				{
					Console.WriteLine("Не ломайте код, пожалуйста)))))");
					k = 1;
				}
			}

			Console.ReadKey();
		}
			
	}
}
