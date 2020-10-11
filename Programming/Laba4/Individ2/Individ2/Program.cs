using System;
using System.Text.RegularExpressions;
namespace Individ2
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Введите текст:");
			string text = Console.ReadLine();
			//Первый способ
			{
				char[] trigger = { 'a', 'o', 'e', 'u', 'i' };
				string textEdit = "";
				string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < words.Length; i++)
				{
					string word = words[i];

					if (word[0] == 'a' || word[0] == 'o' || word[0] == 'e' || word[0] == 'u' || word[0] == 'i')
					{
						if (word[word.Length-1] == 'a' || word[word.Length - 1] == 'o' || word[word.Length - 1] == 'e' || word[word.Length - 1] == 'u' || word[word.Length - 1] == 'i') 
						{
							
						}
						else
						{
							textEdit += words[i] + " ";
						}
					}
					else 
					{
						textEdit += words[i] + " ";
					}
				}
				Console.WriteLine(textEdit);
			}
			//Второй способ
			{
				string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				string textEdit = "";
				for (int i = 0; i < words.Length; i++)
				{
					if (words[i].IndexOfAny(new char[] { 'a', 'o', 'e', 'u', 'i' }) == 0 && words[i].LastIndexOfAny(new char[] { 'a', 'o', 'e', 'u', 'i' }) == words[i].Length - 1)
					{

					}
					else
					{
						textEdit += words[i] + " ";
					}
				}
				Console.WriteLine(textEdit);
			}
			/*Regex triggers = new Regex(@"\b[a,e,o,i,u]\w+[a,e,o,i,u]");
			Regex doubleSpaces = new Regex(@"\s+");
			string textEdit = triggers.Replace(text,string.Empty);
			textEdit = doubleSpaces.Replace(textEdit," ");
			Console.WriteLine(textEdit);
			*/
			Console.ReadKey();
		}
	}
}
