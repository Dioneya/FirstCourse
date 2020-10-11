using System;

namespace Laba4
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Enter string");
			string text = Console.ReadLine();
            //Первый способ
            Console.WriteLine("Первый способ:");
			for (int i = 0; i < text.Length; i++) 
			{
                bool check = true;
				for (int j = 0; j < text.Length; j++) 
				{
					if (text[i] == text[j] && i!=j) 
					{
						check = false;
					}
				}
				if (check)
				{
					Console.Write(text[i]+" ");
				}
			}
			Console.WriteLine();


			//второй способ
			Console.WriteLine("Второй способ:");
			for (int i = 0; i < text.Length; i++)
			{
				if (text.IndexOf(text[i])==text.LastIndexOf(text[i])) 
				{
					Console.Write(text[i] + " ");
				}
			}

			Console.ReadKey();
		}
	}
}
