using System;

namespace Laba2
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int k = 1;
			while (k==1) 
			{
				try
				{
					int N = Convert.ToInt32(Console.ReadLine());
					k = 0;
					byte search = 0;
					if (N > 0)
					{
						for (int x = 0; x <= N; x+=1)
						{
							for (int y = 0; y <=N; y+=1)
							{
								for (int z = 0; z <=N; z+=1)
								{
									int sum = (int)(Math.Pow(x, 3) + Math.Pow(y, 3) + Math.Pow(z, 3));
									if (sum == N)
									{
										Console.WriteLine("{0,3},{1,3},{2,3}", x, y, z);
										search = 1;
									}
								}
							}
							if (search == 0 && x == N) 
							{
								Console.WriteLine("No such combination!");
							}
						}
					}

					else
					{
						Console.WriteLine("Enter a valid number");
						k = 1;
					}
				}
				catch (FormatException) 
				{
					Console.WriteLine("Enter a valid value");
					k = 1;
				}
			}


			Console.ReadKey();
		}
	}
}
