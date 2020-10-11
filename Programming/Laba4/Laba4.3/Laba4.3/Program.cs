using System;
using System.Text;
namespace Laba4
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Введите предложение");
			string textOriginal = Console.ReadLine();

			//первый способ
			string[] words = new string[4];
			char[] trigger = { ' ' };
			for (int startIndex = 0, cnt = 0; startIndex < textOriginal.Length; startIndex = textOriginal.IndexOfAny(trigger, startIndex) + 1) 
			{
				if (cnt == 0) 
				{
					textOriginal += " ";
				}
				for (int i = startIndex; i != textOriginal.IndexOfAny(trigger, startIndex); i++) 
				{
					if (i > textOriginal.Length)
					{
						break;
					}
					else 
					{
						words[cnt] += textOriginal[i];
					}
				}
				cnt++;
			}
			string textEdit1 = "";
			for (int i = words.Length - 1; i > -1; i--) 
			{
				textEdit1 += words[i]+" "; 
			}
			Console.WriteLine(textEdit1);

			//Второй способ
			string[] word = textOriginal.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			StringBuilder textStingBuilder = new StringBuilder(10);
			for (int i = word.Length - 1; i > -1; i--) 
			{
				textStingBuilder.Append(word[i]+" ");
			}
			Console.WriteLine(textStingBuilder);

			Console.ReadKey();
		}
	}
}
