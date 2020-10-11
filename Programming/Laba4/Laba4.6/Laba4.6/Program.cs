using System;
using System.Text.RegularExpressions;

namespace Laba4
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string mathExpression = Console.ReadLine();
			Regex number = new Regex(@"((?<=\d)[+*\/^-]|[()]|\-?[\d.]+)");
			MatchCollection numbers = number.Matches(mathExpression);
			foreach (Match match in numbers)
			{
				int num = int.Parse(match.Value);
				Console.WriteLine(num);
			}
			Console.ReadKey();
		}
	}
}
