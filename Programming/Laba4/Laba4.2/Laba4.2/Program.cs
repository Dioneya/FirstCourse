using System;

namespace Laba4
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Введите первую строку");
			string text = Console.ReadLine()+" ";
			string text2 = "";

			//Первый способ
			{
				int cnt = 1;
				string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < words.Length; i++)
				{
					if (words[i] == "-" || words[i] == " " || words[i] == ",")
					{
						text2 += words[i]+" ";
					}
					else
					{
						string word = words[i];
						if (word[word.Length - 1] == ',')
						{
							word=word.Replace(',','(');
							word += cnt + ")" + ", ";
							text2 += word;
							cnt++;
						}
						else 
						{
							text2 += words[i]+"("+cnt + ") ";
							cnt++;
						}
					}
				}

				Console.WriteLine(text2);
			}
			//Второй способ
			{
				Console.WriteLine("Второй способ:");
				string text3 = "";
				int cnt = 0;
				for (int i = 0; i < text.Length; i++)
				{
					if (text[i] == ' ' || text[i] == ',' || text[i] == '-')
					{
						cnt++;
						text3 += "(" + cnt + ")";
						while (i < text.Length)
						{
							if (Char.IsLetter(text[i]))
							{
								text3 += text[i];
								break;
							}
							else
							{
								text3 += text[i];
								i++;
							}

						}
					}
					else
					{
						text3 += text[i];
					}
				}
				Console.WriteLine(text3);
			}
			Console.ReadKey();
		}
	}
}
