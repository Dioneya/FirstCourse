
using System;

namespace Laba8
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			
			bool repeat = true;
			while (repeat) 
			{
				Console.WriteLine("Введите тестовую строку");
				string testString = Console.ReadLine();
				Console.WriteLine("ВВедите образец для поиска");
				string key = Console.ReadLine();
				KMP(testString, key);
				Console.WriteLine();
				BoyerMoor(testString, key);

			}
		}
		//=============================================================================

		static void KMP(string testString, string key)
		{
			bool isFinded = false;
			int[] position = new int[testString.Length];
			int indexOfPosition = 0;
			int cnt = 0;
			var start = DateTime.Now;
			for (int i = 0; i < testString.Length; i++,cnt++)
			{
				if (testString[i] == key[0])
				{
					if (Convert.ToString(testString[i]) == key)
					{
						position[indexOfPosition] = i;
						indexOfPosition++;
						cnt++;
						isFinded = true;
					}
					else
					{
						int indexOfKey = 1;
						for (int j = i + 1; j < testString.Length; j++, indexOfKey++,cnt++)
						{
							if (testString[j] != key[indexOfKey])
							{
								i = j;
								j = testString.Length - 1;
							}

							else if (testString[j] == key[key.Length - 1])
							{
								position[indexOfPosition] = i;
								indexOfPosition++;
								i = j;
								isFinded = true;
								break;
							}
						}
					}

				}
			}
			var end = DateTime.Now;
			TimeSpan interval = end - start;
			if (isFinded == false)
			{
				Console.WriteLine("Не найдено");
			}

			else 
			{
				bool cntFor = false;
				Console.Write("Найдено совпадение в позициях элемента(ов): ");
				foreach (int matches in position)
				{
					if (cntFor && matches == 0)
					{
						break;
					}
					Console.Write(matches + " ");
					cntFor = true;

				}
				Console.Write("Время на поиск: {0} Количество сравнений: {1}", interval, cnt);
				Console.WriteLine();
			}
		}
		//================================================================================
		static int[] BadCharactersTable(string key) 
		{
			int size = key.Length;

			int[] badShift = new int[1104];
			for (int i = 0; i < 1104; i++) 
			{
				badShift[i] = -1;
			}
			for (int i = 0; i < size-1; i++) 
			{
				badShift[(int)key[i]] = i;
			}
			return badShift;
		}

		static int max(int a, int b) 
		{
			if (a > b)
			{
				return a;
			}
			else 
			{
				return b;
			}
		}

		static void BoyerMoor(string testString, string key) 
		{
			bool isFinded = false;
			int[] position = new int[testString.Length];
			int indexOfPosition = 0;
			int cnt = 0;
			int[] badchar = BadCharactersTable(key);
			int stringSize = testString.Length;
			int keySize = key.Length;
			int shift = 0;
			var start = DateTime.Now;
			while (shift <= (stringSize - keySize)) 
			{
				cnt++;
				int j = keySize - 1;
				while (j >= 0 && key[j] == testString[shift + j]) 
				{
					j--;
				}

				if (j < 0)
				{
					position[indexOfPosition] = shift;
					indexOfPosition++;
					cnt++;
					isFinded = true;
					if (shift + keySize < stringSize)
					{
						shift += keySize - badchar[testString[shift + keySize]];

					}
					else 
					{
						shift += 1;
					}
				}
				else 
				{
					shift += max(1, j - badchar[testString[shift + j]]);
				}
			}
			var end = DateTime.Now;
			TimeSpan interval = end - start;

			if (isFinded == false)
			{
				Console.WriteLine("Не найдено");
			}

			else
			{
				bool cntFor = false;
				Console.Write("Найдено совпадение в позициях элемента(ов): ");
				foreach (int matches in position)
				{
					if (cntFor && matches == 0)
					{
						break;
					}
					Console.Write(matches + " ");
					cntFor = true;

				}
				Console.Write("Время на поиск: {0} Количество сравнений: {1}", interval, cnt);
				Console.WriteLine();
			}
		}

	}
}
