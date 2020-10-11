using System;
using System.Linq;
using System.IO;
namespace Laba10
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int cnt = 0;
			int swap = 0;

			string path = @"C:\Users\Никита\Documents\Project\ЛАБАРАТОРНАЯ 10\Laba10.1\sorted.dat";

			int[] arr = new int[100];
			var rnd = new Random();
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = rnd.Next(0, 1000);
			}

			//делаем отсортированный массив по убыванию
			var arrSorted = (int[])arr.Clone();
			arrSorted = MergeSort(arrSorted, 0, arr.Length-1, ref cnt, ref swap);

			//противоположный массив убыванию т.е. по возрастанию
			int[] arrInvers = new int[arr.Length];
			for (int i = arr.Length - 1, j = 0; i > -1; i--, j++)
			{
				arrInvers[i] = arrSorted[j];
			}

			var resetOfFile= new StreamWriter(path, false);
			resetOfFile.Close();

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Сортировка - Слиянием несортированного массива");
			Console.ResetColor();
			var mergeArr = (int[])arr.Clone();
			Log(MergeSort(mergeArr, 0, arr.Length - 1, ref cnt, ref swap),ref cnt, ref swap, path);

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Сортировка - Слиянием по убыванию");
			Console.ResetColor();
			var mergeArrSorted = (int[])arrSorted.Clone();
			Log(MergeSort(mergeArrSorted, 0, arr.Length - 1, ref cnt, ref swap), ref cnt, ref swap, path);

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Сортировка - Слиянием по возрастанию");
			Console.ResetColor();
			var mergeArrInvers = (int[])arrInvers.Clone();
			Log(MergeSort(mergeArrInvers, 0, arr.Length - 1, ref cnt, ref swap), ref cnt, ref swap, path);



			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine("Сортировка - Приамидальная несортированного массива");
			Console.ResetColor();
			Log(PyramidSort(arr, 0, arr.Length - 1, ref cnt, ref swap), ref cnt, ref swap, path);

			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine("Сортировка - Приамидальная по убыванию");
			Console.ResetColor();
			Log(PyramidSort(arrSorted, 0, arr.Length - 1, ref cnt, ref swap), ref cnt, ref swap, path);

			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine("Сортировка - Приамидальная по возрастанию");
			Console.ResetColor();
			Log(PyramidSort(arrInvers, 0, arr.Length - 1, ref cnt, ref swap), ref cnt, ref swap, path);



			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine("Сортировка - Слиянием несортированного массива");
			Console.ResetColor();
			var quickArr = (int[])arr.Clone();
			Log(QuickSort(quickArr, 0, arr.Length - 1, ref cnt, ref swap), ref cnt, ref swap, path);

			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine("Сортировка - Слиянием по убыванию");
			Console.ResetColor();
			var quickArrSorted = (int[])arrSorted.Clone();
			Log(QuickSort(quickArrSorted, 0, arr.Length - 1, ref cnt, ref swap), ref cnt, ref swap, path);

			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine("Сортировка - Слиянием по возрастанию");
			Console.ResetColor();
			var quickArrInvers = (int[])arrInvers.Clone();
			Log(QuickSort(quickArrInvers, 0, arr.Length - 1, ref cnt, ref swap), ref cnt, ref swap, path);


			Check(path);
			Console.ReadKey();
		}

		static void Log(int[] arr, ref int cnt, ref int swap, string path) 
		{
			var start = DateTime.Now;

			WriteInFile(arr, path);

			var end = DateTime.Now;
			TimeSpan interval = end - start;
			Console.WriteLine("время сортировки:{0}; количество сравнений:{1}; количество обменов:{2}", interval, cnt, swap);
			cnt = 0; swap = 0;
			Console.WriteLine();
		}

		static void WriteInFile(int[] arr, string path) 
		{
			using (var streamWriter = new StreamWriter(path, true, System.Text.Encoding.Default))
			{
				foreach (int selection in arr)
				{
					streamWriter.Write(selection + " ");
				}
				streamWriter.WriteLine();
			}
		}
		//============================================================//
		static int[] MergeSort(int[] arr, int left, int right, ref int cnt, ref int swap) 
		{
			if (right<=left) 
			{
				return arr;
			}

			int mid = (left + right) / 2;
			MergeSort(arr, left, mid, ref cnt, ref swap);
			MergeSort(arr, mid+1, right, ref cnt, ref swap);
			Merge(arr, left, mid, right, ref cnt, ref swap);

			return arr;
		}

		static void Merge(int[] arr, int left, int mid, int right, ref int cnt, ref int swap) 
		{
			int[] temp = new int[right - left + 1];

			int i = left, j = mid + 1;
			int k = 0;

			for (k = 0; k < temp.Length; k++) 
			{
				cnt++;
				if (i > mid) 
				{
					temp[k] = arr[j++];
				}
				else if (j > right)
				{
					temp[k] = arr[i++];
				}
				else
				{
					cnt++;
					if (arr[i] > arr[j]) //изменяем условие чтобы сортировало по убыванию
					{
						temp[k] = arr[i++];
					}
					else 
					{
						temp[k] = arr[j++];
					}
				}
			}
			//Копируем временный массив в изначальный
			k = 0;
			i = left;
			while (k < temp.Length && i <= right) 
			{
				swap++;
				arr[i++] = temp[k++];
			}
		}
		//=======================================================================================//

		static void Swap(ref int a, ref int b)
		{
			int temp = a;
			a = b;
			b = temp;
		}

		public static int[] PyramidSort(int[] tempArr, int left, int right, ref int cnt, ref int swap)
		{
			var arr = (int[])tempArr.Clone();
			int N = right - left + 1;

			for (int i = right; i >= left; i--) 
			{
				Heapify(arr, i, N, ref cnt, ref swap);
			}

			while (N > 0) 
			{
				swap++;
				Swap(ref arr[left], ref arr[N - 1]);
				Heapify(arr, left, --N, ref cnt, ref swap);
			}
			return arr;
		}

		public static void Heapify(int[] arr, int i, int N, ref int cnt, ref int swap) 
		{
			while (2 * i + 1 < N)
			{
				int k = 2 * i + 1;
				cnt++;
				if (2*i + 2 < N && arr[2*i + 2] <= arr[k]) // меняем >= на <=, чтобы сортировало по убыванию
				{
					k = 2 * i + 2;
				}
				cnt++;
				if (arr[i] > arr[k]) //меняем это условие для сортировки убывания 
				{
					swap++;
					Swap(ref arr[i], ref arr[k]);
					i = k;
				}
				else
					break;
			}
		}

		//=====================================================================================//

		public static int[] QuickSort(int[] arr, int left, int right, ref int cnt, ref int swap) 
		{
			if (right<=left) 
			{
				return arr;
			}

			int partition = Partition(arr, left, right, ref cnt, ref swap);
			QuickSort(arr, left, partition - 1, ref cnt, ref swap);
			QuickSort(arr, partition + 1, right,ref cnt, ref swap);

			return arr;
		}

		public static int Partition(int[] arr, int left, int right, ref int cnt, ref int swap) 
		{
			int pivot = arr[right];
			int i = left - 1, j = right;
			while (i < j) 
			{
				while (arr[++i] > pivot); //Изменили знаки в этих двух while, чтобы получилось по убыванию
				while (arr[--j] < pivot)
				{
					cnt++;
					if (j == left)
						break;
				}	
				cnt++;
				if (i < j)
				{
					swap++;
					Swap(ref arr[i], ref arr[j]);
				}
				else 
				{
					break;
				}
			}
			swap++;
			Swap(ref arr[i], ref arr[right]);
			return i;
		}


		//=====================================================================================//
		static void Check(string path)
		{
			using (var textReader = new StreamReader(path))
			{
				bool passOrFaild = true;
				string line;
				while ((line = textReader.ReadLine()) != null)
				{
					line = textReader.ReadLine();
					if (line != null)
					{
						string[] nums = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						for (int i = 0; i < nums.Length - 1; i++)
						{
							if (Convert.ToInt32(nums[i]) < Convert.ToInt32(nums[++i]))
							{
								passOrFaild = false;
								break;
							}
						}
					}

				}
				if (passOrFaild)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("=====================================");
					Console.WriteLine("Сортировка всех функций прошла успешно");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("=====================================");
					Console.WriteLine("Сортировка функции прошла неправильно/неудачно");
				}

			}
			Console.WriteLine("=====================================");
		}
	}
}
