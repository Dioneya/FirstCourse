using System;

namespace Laba4
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string[] arrString = new string[7];
			for (int i = 0; i < 7; i++)
			{
				arrString[i] = Console.ReadLine();
			}
			int minSpaces = 10000;
			int minSpaceIndex = 0;
			bool[] hadMinSpace = new bool [7]; 
			//Первый способ
			Console.WriteLine("=======Первый способ=======");
			for (int i = 0; i < arrString.Length; i++)
			{
				int cntSpace = 0;
				for (int j = 0; j < arrString[i].Length; j++)
				{
					string line = arrString[i];
					if (line[j]==' ') 
					{
						cntSpace++;
					}

					if (line[j] == '.' && line[j+1] == 'c' && line[j+2] == 'o' && line[j+3] == 'm') 
					{
						if (j + 3 == line.Length - 1)
						{
							Console.WriteLine(arrString[i]);
						}
						else if (line[j+4]==' ') 
						{
							Console.WriteLine(arrString[i]);
						}

					}
				}
				if (cntSpace < minSpaces)
				{
					minSpaces = cntSpace;
					hadMinSpace[minSpaceIndex] = false;
					minSpaceIndex = i;
					hadMinSpace[minSpaceIndex] = true;
				}
				else if (cntSpace==minSpaces) 
				{
					minSpaceIndex = i;
					hadMinSpace[i] = true;
				}
			}
			Console.WriteLine("Минимальное значение пробелов в строке: ");
			for (int i = 0; i < hadMinSpace.Length; i++) 
			{
				if (hadMinSpace[i]) 
				{
					Console.WriteLine(arrString[i]);
				}
			}

			//Второй способ
			Console.WriteLine("========Второй способ======");
			int minSpaces1 = 10000;
			int minSpaceIndex1 = 0;
			bool[] hadMinSpace1 = new bool[7];
			for (int i = 0; i < 7; i++)
			{
				bool hasCom = false;
				string[] word = arrString[i].Split(' ');
				if (word.Length-1<minSpaces1) 
				{
					minSpaces1 = word.Length-1;
					hadMinSpace1[minSpaceIndex1] = false;
					minSpaceIndex1 = i;
					hadMinSpace1[minSpaceIndex1] = true;
				}
				else if (word.Length - 1 == minSpaces1)
				{
					minSpaceIndex1 = i;
					hadMinSpace1[i] = true;
				}
				for (int j = 0; j < word.Length; j++)
				{
					string subword = word[j];
					if (subword.IndexOf(".com")>-1) 
					{
						if (subword.LastIndexOf(".com") == subword.Length - 4)
						{
							hasCom = true;
						}
					}
				}
				if(hasCom) 
				{
					Console.WriteLine(arrString[i]);
				}
			}
			Console.WriteLine("Минимальное значение пробелов в строке: ");
			for (int i = 0; i < hadMinSpace1.Length; i++)
			{
				if (hadMinSpace1[i])
				{
					Console.WriteLine(arrString[i]);
				}
			}

			Console.ReadKey();
		}
	}
}
