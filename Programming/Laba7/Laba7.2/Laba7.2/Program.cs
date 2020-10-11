using System;
using System.IO;
namespace Laba7
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string path = @"C:\Users\user\Documents\Projects\ЛАБАРАТОРНАЯ 7\Laba7.2\sorted.dat";
			int[] arr = new int[100000];
			var rnd = new Random();
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = rnd.Next(0,50);
			}
			int[] arrSorted = FastSort(arr);
			int[] arrInvers = new int[arr.Length];
			for (int i = arr.Length-1; i > -1; i--) 
			{
				arrInvers[i] = arrSorted[i];
			}
			using (var textWrite = new StreamWriter(path, false)) 
			{
				Console.WriteLine("Сортировка - выборкой (по убыванию)");
				foreach (int selection in SelectionSort(arr))
				{
					textWrite.Write(selection + " ");
				}
				Console.WriteLine();
				textWrite.WriteLine();

				Console.WriteLine("Сортировка - выборкой (отсортированного массива по возрастанию)");
				foreach (int selection in SelectionSort(arrInvers))
				{
					textWrite.Write(selection + " ");
				}
				Console.WriteLine();
				textWrite.WriteLine();

				Console.WriteLine("Сортировка - выборкой (отсортированного массива по убыванию)");
				foreach (int selection in SelectionSort(arrSorted))
				{
					textWrite.Write(selection + " ");
				}
				Console.WriteLine();
				textWrite.WriteLine();

				Console.WriteLine("Сортировка - вставкой (по убыванию)");
				foreach (int insert in InsertionSort(arr))
				{
					textWrite.Write(insert + " ");
				}
				Console.WriteLine();
				textWrite.WriteLine();

				Console.WriteLine("Сортировка - вставкой (отсортированного массива по возрастанию)");
				foreach (int insert in InsertionSort(arrInvers))
				{
					textWrite.Write(insert + " ");
				}
				Console.WriteLine();
				textWrite.WriteLine();

				Console.WriteLine("Сортировка - вставкой (отсортированного массива по убыванию)");
				foreach (int insert in InsertionSort(arrSorted))
				{
					textWrite.Write(insert + " ");
				}
				Console.WriteLine();
				textWrite.WriteLine();

				Console.WriteLine("Пузырьковая соритировка (по убыванию)");
				foreach (int bubble in BubbleSort(arr))
				{
					textWrite.Write(bubble + " ");
				}
				Console.WriteLine();
				textWrite.WriteLine();

				Console.WriteLine("Пузырьковая соритировка (отсортированного массива по возрастанию)");
				foreach (int bubble in BubbleSort(arrInvers))
				{
					textWrite.Write(bubble + " ");
				}
				Console.WriteLine();
				textWrite.WriteLine();

				Console.WriteLine("Пузырьковая соритировка (отсортированного массива по убыванию)");
				foreach (int bubble in BubbleSort(arrSorted))
				{
					textWrite.Write(bubble + " ");
				}
				Console.WriteLine();
				textWrite.WriteLine();

				Console.WriteLine("Соритировка Шейкера (по убыванию)");
				foreach (int shaker in ShakerSort(arr))
				{
					textWrite.Write(shaker + " ");
				}
				Console.WriteLine();
				textWrite.WriteLine();

				Console.WriteLine("Соритировка Шейкера (отсортированного массива по возрастанию)");
				foreach (int shaker in ShakerSort(arrInvers))
				{
					textWrite.Write(shaker + " ");
				}
				Console.WriteLine();
				textWrite.WriteLine();

				Console.WriteLine("Соритировка Шейкера (отсортированного массива по убыванию)");
				foreach (int shaker in ShakerSort(arrSorted))
				{
					textWrite.Write(shaker + " ");
				}
				Console.WriteLine();
				textWrite.WriteLine();

				Console.WriteLine("Соритировка Шелла (по убыванию)");
				foreach (int shell in Shell(arr))
				{
					textWrite.Write(shell + " ");
				}
				Console.WriteLine();
				textWrite.WriteLine();

				Console.WriteLine("Соритировка Шелла (отсортированного массива по возрастанию)");
				foreach (int shell in Shell(arrInvers))
				{
					textWrite.Write(shell + " ");
				}
				Console.WriteLine();
				textWrite.WriteLine();

				Console.WriteLine("Соритировка Шелла (по убыванию)");
				foreach (int shell in Shell(arrSorted))
				{
					textWrite.Write(shell + " ");
				}
			}
			Check(path);
			Console.ReadKey();
		}
		//--------------------------------------------------------------------------------------------------------------
		static int[] FastSort(int[] arr)
		{
			for (int i = 1; i < arr.Length; i++)
			{
				int temp = arr[i];
				int j = i;
				while (j > 0 && temp > arr[j - 1])
				{
					arr[j] = arr[j - 1];
					j--;
				}
				arr[j] = temp;
			}
			return arr;
		}
		//--------------------------------------------------------------------------------------------------------------
		static int[] SelectionSort(int[] arr) 
		{
			var start = DateTime.Now;
			int cnt = 0;
			int swap = 0;
			for (int i = 0; i < arr.Length - 1; i++)
			{
				int max = i;
				for (int j = i + 1; j < arr.Length; j++,cnt++)
				{
					if (arr[j] > arr[max])
					{
						max = j;
					}
				}
				int temp = arr[i];
				arr[i] = arr[max];
				arr[max] = temp;
				swap++;
			}
			var end = DateTime.Now;
			TimeSpan interval = end - start;
			Console.WriteLine("время сортировки:{0}; количество сравнений:{1}; количество обменов:{2}",interval,cnt,swap);
			return arr;
		}

		static int[] InsertionSort(int[] arr) 
		{
			int cnt = 0;
			int swap = 0;
			var start = DateTime.Now;
			for (int i = 1; i < arr.Length; i++,cnt++)
			{
				int temp = arr[i];
				int j = i;
				while (j > 0 && temp > arr[j-1]) 
				{
					arr[j] = arr[j - 1];
					j--;
				}
				arr[j] = temp;
				swap++;
			}
			var end = DateTime.Now;
			TimeSpan interval = end - start;
			Console.WriteLine("время сортировки:{0}; количество сравнений:{1}; количество обменов:{2}", interval, cnt, swap);
			return arr;
		}
		static int[] BubbleSort(int[] arr)
		{
			int cnt = 0;
			var start = DateTime.Now;
			int swap = 0;
			for (int i = 0; i < arr.Length - 1; i++,swap++) 
			{
				for (int j = i + 1; j < arr.Length - i - 1; j++,cnt++) 
				{
					if (arr[j]>arr[i]) 
					{
						int temp = arr[i];
						arr[i] = arr[j];
						arr[j] = temp;
					}
				}
			}
			var end = DateTime.Now;
			TimeSpan interval = end - start;
			Console.WriteLine("время сортировки:{0}; количество сравнений:{1}; количество обменов:{2}", interval,cnt,swap);
			return arr;
		}

		static int[] ShakerSort(int[] arr) 
		{
			int cnt = 0;
			int swap = 0;
			int left = 1;
			int right = arr.Length - 1;
			var start = DateTime.Now;
			while (left<=right) 
			{
				for (int i = right; i >= left; i--,cnt++)
				{
					if (arr[i-1]<arr[i]) 
					{
						int temp = arr[i];
						arr[i] = arr[i - 1];
						arr[i - 1] = temp;
					}

				}
				swap++;
				left++;
				for (int i = left; i <= right; i++,cnt++)
				{
					if (arr[i-1]<arr[i]) 
					{
						int temp = arr[i];
						arr[i] = arr[i - 1];
						arr[i - 1] = temp;
					}
				}
				swap++;
				right--;
			}
			var end = DateTime.Now;
			TimeSpan interval = end - start;
			Console.WriteLine("время сортировки:{0}; количество сравнений:{1}; количество обменов:{2}", interval, cnt, swap);
			return arr;
		}

		static int[] Shell(int[] arr) 
		{
			int cnt = 0;
			int swap = 0;
			var start = DateTime.Now;
			int step = arr.Length / 2;
			while (step > 0)
			{
				int i, j;
				for (i = step; i < arr.Length; i++,cnt++)
				{
					int value = arr[i];
					for (j = i - step; (j >= 0) && (arr[j] < value); j -= step) 
					{
						arr[j + step] = arr[j];
					}
					arr[j + step] = value;
					swap++;
				}
				step /= 2;
			}
			var end = DateTime.Now;
			TimeSpan interval = end - start;
			Console.WriteLine("время сортировки:{0}; количество сравнений:{1}; количество обменов:{2}", interval, cnt, swap);
			return arr;
		}

		static void Check(string path)
		{
			Console.WriteLine("=====================================");
			using (var textReader = new StreamReader(path))
			{
				bool passOrFaild = true;
				string line;
				while ((line = textReader.ReadLine())!=null) 
				{
					line = textReader.ReadLine();
					if (line != null)
					{
						string[] nums = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						for (int i = 0; i < nums.Length - 1; i++)
						{
							if (Convert.ToInt32(nums[i]) < Convert.ToInt32(nums[i++]))
							{
								passOrFaild = false;
								break;
							}
						}
					}

				}
				if (passOrFaild) 
				{
					Console.WriteLine("Сортировка всех функций прошла успешно");
				}
				else
				{
					Console.WriteLine("Сортировка функции прошла неправильно/неудачно");
				}

			}
			Console.WriteLine("=====================================");
		}
	}
}
