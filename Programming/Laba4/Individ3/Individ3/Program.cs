using System;
using System.Text.RegularExpressions;
namespace Individ3
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string text = Console.ReadLine();
			Regex regex = new Regex(@"\W+[)]+");
			MatchCollection smiles = regex.Matches(text);
			foreach(Match match in smiles )
			{
				Console.WriteLine(match);
			}
			Console.ReadKey();
		}
	}
}
