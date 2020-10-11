using System;

namespace Laba1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string number = Console.ReadLine();
			char[] parse = number.ToCharArray();
			string[] invert = new string[parse.Length];
			invert[0] =Convert.ToString(parse[2]);
			invert[1] = Convert.ToString(parse[1]);
			invert[2] = Convert.ToString(parse[0]);


			Console.WriteLine(invert[0]+invert[1]+invert[2]);
			Console.ReadKey();
		}
	}
}
