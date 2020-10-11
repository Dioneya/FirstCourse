using System;

namespace Individ1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//Вариант 7

			//Метод квадрата-Полибия
			char[,] lettersPolib = { { 'A', 'B', 'C', 'D', 'E' }, { 'F', 'G', 'H', 'I', 'K' }, { 'L', 'M', 'N', 'O', 'P' },{'Q', 'R', 'S', 'T', 'U' },{'V', 'W', 'X', 'Y', 'Z' }};
			Console.WriteLine("Введите строку для шифровки по квадрату-Полибия: ");
			string textPolib = Console.ReadLine();
			for (int indexOfSymbol = 0; indexOfSymbol < textPolib.Length; indexOfSymbol++)
			{
				if (Char.IsUpper(textPolib[indexOfSymbol]))
				{
					for (int i = 0; i < 5; i++)
					{
						for (int j = 0; j < 5; j++)
						{
							if (lettersPolib[i, j] == textPolib[indexOfSymbol])
							{
								if (i==4) 
								{
									i = 0;
								}
								textPolib = textPolib.Replace(Convert.ToString(textPolib[indexOfSymbol]), Convert.ToString((i+1) + "" + j));
							}
							else if (textPolib[indexOfSymbol] == 'J') 
							{
								textPolib = textPolib.Replace(Convert.ToString(textPolib[indexOfSymbol]),"34");
							}
						}
					}
				}
			}
			Console.WriteLine(textPolib);

			//Расшифровка Полиба
			Console.WriteLine("Введите строку для расшифровки");
			string textPolibInvers = Console.ReadLine();
			for (int indexOfSymbol = 0; indexOfSymbol < textPolibInvers.Length; indexOfSymbol++) 
			{
				
				if(Char.IsNumber(textPolibInvers[indexOfSymbol])) 
				{
					string letter = Convert.ToString(textPolibInvers[indexOfSymbol])+Convert.ToString(textPolibInvers[indexOfSymbol+1]);
					int num1 = Convert.ToInt32(Convert.ToString(textPolibInvers[indexOfSymbol]))-1;
					int num2 = Convert.ToInt32(Convert.ToString(textPolibInvers[indexOfSymbol + 1]));
					if (num1 == -1)
					{
						textPolibInvers = textPolibInvers.Replace(letter, Convert.ToString(lettersPolib[4,num2]));
						indexOfSymbol = 0;
					}
					else
					{
						textPolibInvers = textPolibInvers.Replace(letter, Convert.ToString(lettersPolib[num1, num2]));
						indexOfSymbol = 0;
					}
				}
			}
			Console.WriteLine(textPolibInvers);





			//Зашифровка Цезаря 
			char[] lettersCezar = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
			Console.WriteLine("Введите строку для шифровки по сдвигу Цезаря: ");
			string textCezar = Console.ReadLine();
			string textCezarCoded ="";
			for (int indexOfSymbol = 0; indexOfSymbol < textCezar.Length; indexOfSymbol++) 
			{
				for (int i = 0; i < lettersCezar.Length; i++) 
				{
					if (textCezar[indexOfSymbol]==lettersCezar[i]) 
					{
						if (i + 3 > lettersCezar.Length)
						{
							textCezarCoded += lettersCezar[(i + 3) - lettersCezar.Length-1];
						}
						else 
						{
							textCezarCoded += lettersCezar[i + 3]; 
						}

					}
				}
			}
			Console.WriteLine(textCezarCoded);

			//Расшифровка по методу Цезаря
			Console.WriteLine("Введите строку для расшифровки по сдвигу Цезаря: ");
			string textCezarInvers = Console.ReadLine();
			string textCezarDecoded = "";
			for (int indexOfSymbol = 0; indexOfSymbol < textCezarInvers.Length; indexOfSymbol++)
			{
				for (int i = 0; i < lettersCezar.Length; i++)
				{
					if (textCezarInvers[indexOfSymbol] == lettersCezar[i])
					{
						if (i - 3 < 0)
						{
							textCezarDecoded += lettersCezar[(lettersCezar.Length - 1)-(i - 3)];
						}
						else
						{
							textCezarDecoded += lettersCezar[i - 3];
						}

					}
				}
			}
			Console.WriteLine(textCezarDecoded);




			//Зашифровка по методу Полиалфавитного шифра 
			char[,] lettersPolialph = new char [26,26];
			for (int i = 0,cnt = 0; i < 26; i++, cnt++)
			{
				for (int j = 0; j < 26; j++)
				{
					if (j + cnt >= lettersCezar.Length) //lettersCezar - используется как алфавитные буквы для экономии
					{
						lettersPolialph[i, j] = lettersCezar[(j + cnt) - lettersCezar.Length];
					}
					else
					{
						lettersPolialph[i, j] = lettersCezar[j + cnt];
					}
					Console.Write(lettersPolialph[i,j]+" ");
				}
				Console.WriteLine();
			}
			Console.WriteLine("Введите строку для шифровки по полиалфавитному шифру: ");
			string textPolialph = Console.ReadLine();
			string textPolialphCoded ="";
			Console.WriteLine("Введите ключ-слово для шифровки по полиалфавитному шифру: ");
			string key = Console.ReadLine();

			for (int symbol = 0, keyIndex = 0, i = 0, j = 0; symbol < textPolialph.Length; symbol++) 
			{
				if (Char.IsUpper(textPolialph[symbol]))
				{
					for (i = 0; i < lettersCezar.Length; i++)
					{
						if (textPolialph[symbol] == lettersCezar[i])
						{
							break;
						}
					}

					for (j = 0; j < lettersCezar.Length; j++)
					{
						if (keyIndex > key.Length - 1)
						{
							keyIndex = 0;
						}
						else if (key[keyIndex] == lettersCezar[j])
						{
							keyIndex++;
							break;
						}
					}
					textPolialphCoded += lettersPolialph[i, j];
				}
				else 
				{
					textPolialphCoded += textPolialph[symbol];
				}
			}
			Console.WriteLine(textPolialphCoded);

			//Расшифровка по методу полиалфавитного шифра
			Console.WriteLine("Введите строку для расшифровки по полиалфавитному шифру: ");
			string textPolialphInvers = Console.ReadLine();
			string textPolialphDecoded = "";
			Console.WriteLine("Введите ключ-слово для расшифровки по полиалфавитному шифру: ");
			string keyDecoded = Console.ReadLine();
			for (int symbol = 0, keyIndex = 0, i = 0, j = 0; symbol < textPolialph.Length; symbol++)
			{
				if (Char.IsUpper(textPolialphInvers[symbol]))
				{
					for (j = 0; j < lettersCezar.Length; j++)
					{
						if (keyIndex > keyDecoded.Length - 1)
						{
							keyIndex = 0;
						}
						else if (keyDecoded[keyIndex] == lettersCezar[j])
						{
							keyIndex++;
							break;
						}
						else if (keyIndex > textPolialph.Length - 1)
						{
							break;
						}
					}
					for (i = 0; i < lettersCezar.Length; i++)
					{
						if (textPolialphInvers[symbol] == lettersPolialph[i, j])
						{
							break;
						}
					}
					textPolialphDecoded += lettersPolialph[i, 0];
				}
				else 
				{
					textPolialphDecoded += textPolialphInvers[symbol];
				}

			}
			Console.WriteLine(textPolialphDecoded);
			Console.ReadKey();
		}
	}
}
