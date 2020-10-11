using System;
using System.IO;
namespace Laba8
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string pathToSortedDat = @"C:\Users\user\Documents\Projects\ЛАБАРАТОРНАЯ 7\Laba7.2\sorted.dat";
			string lineWithNumbers = string.Empty;

			using (var sortReader = new StreamReader(pathToSortedDat)) 
			{
				lineWithNumbers = sortReader.ReadLine();
			}

			string[] ofNums = lineWithNumbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			Console.WriteLine("Введите значение для поиска");
			string search = Convert.ToString(checkValidInput());
			Console.WriteLine("линейный поиск");
			linearSearch(search, ofNums);
			Console.WriteLine();
			Console.WriteLine("бинарный поиск");
			binare(search, ofNums);
			Console.WriteLine();
			Console.WriteLine("интерполяционный поиск");
			interpolationSearch(search, ofNums);

			Console.ReadKey();
		}

		static int checkValidInput() 
		{
			bool isPass = false;
			int  search = 0;
			while (isPass==false) 
			{
				try
				{
					search = Convert.ToInt32(Console.ReadLine());
					isPass = true;
				}

				catch
				{
					Console.WriteLine("Неверное значение для проверки");
				}

			}
			return search;
		}

		static void linearSearch(string search, string[] inSort) 
		{
			bool isFinded = false;
			int[] position = new int[inSort.Length];
			var start = DateTime.Now;
			int cnt = 0;
			for (int i = 0, indexOfPositionArr=0; i < inSort.Length; i++, cnt++)
			{
				if (inSort[i] == search) 
				{
					position[indexOfPositionArr] = i;
					indexOfPositionArr++;
					isFinded = true;
				}
			}
			var end = DateTime.Now;
			TimeSpan interval = end-start;
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
					Console.Write(matches+" ");
					cntFor = true;

				}
				Console.Write("Время на поиск: {0} Количество сравнений: {1}",interval,cnt);
			}

		}

		static void binare(string search, string[] inSort) 
		{
			int mid = inSort.Length / 2;
			bool isFinded = false;
			int cnt = 0;
			int key = Convert.ToInt32(search);
			int numOfMid = Convert.ToInt32(inSort[mid]);
			int indexOfPositionArr = 0;
			int[] position = new int[inSort.Length];
			var start = DateTime.Now;
			if (key > numOfMid)
			{

				for (int i = 0; i < mid; i++,cnt++)
				{
					if (inSort[i] == search)
					{
						position[indexOfPositionArr] = i;
						indexOfPositionArr++;
						isFinded = true;
					}
				}
			}
			else
			{
				for( int i = mid; i < inSort.Length; i++,cnt++)
				{
					if (inSort[i] == search)
					{
						position[indexOfPositionArr] = i;
						indexOfPositionArr++;
						isFinded = true;
					}
				}

			}
			var end = DateTime.Now;
			var interval = end - start;
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
			}
		}

		static void interpolationSearch(string search, string[] inSort)
		{
			bool isFinded = false;
			int left = 0;
			int[] position = new int[inSort.Length];
			int key = Convert.ToInt32(search);
			int indexOfPositionArr = 0;
			int right = inSort.Length-1;
			int cnt = 0;
			int firstNumInSort = Convert.ToInt32(inSort[left]);
			int lastNumInSort = Convert.ToInt32(inSort[right]);
			var start = DateTime.Now;
			int mid = left+(((key-firstNumInSort)*(right-left))/(lastNumInSort-firstNumInSort)); //формула интерполяционного нахождения

				right = mid;
				left = mid;
				while (left != 0)
				{
					cnt++;
					if (Convert.ToInt32(inSort[left]) != key)
					{
						break;
					}
					else
					{
						position[indexOfPositionArr] = left;
						indexOfPositionArr++;
						left--;
						isFinded = true;
					}
				}
				while (right != inSort.Length-1)
				{
					cnt++;
					if (Convert.ToInt32(inSort[left]) != key)
					{
						break;
					}
					else
					{
						position[indexOfPositionArr] = right;
						indexOfPositionArr++;
						right++;
						isFinded = true;
					}
				}
			var end = DateTime.Now;
			TimeSpan interval = end - start;
			if (isFinded==false) 
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
			}
		}
	}
}
