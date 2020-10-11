using System;

namespace Laba1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string x = Console.ReadLine();

			string d = x[x.IndexOf(',') + 1].ToString();

			Console.WriteLine(d);
			Console.ReadKey();
		}
	}
}
