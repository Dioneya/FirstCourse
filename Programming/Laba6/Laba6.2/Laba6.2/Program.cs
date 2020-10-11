using System;
using System.IO;
namespace Laba6
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string path = @"C:\Users\user\Documents\Projects\ЛАБАРАТОРНАЯ 6\Laba6.2\Laba6.2\lab.dat";
			int repeat = 0;
			var writeToFirstFile = new BinaryWriter(new FileStream(path, FileMode.OpenOrCreate));
			while (repeat<4) 
			{
				repeat++;
				int M = 0;
				bool errorM = false;
				try
				{
					
					do 
					{
						Console.Write("Введите число 'M' от 0 до 5:");
						M = Convert.ToInt32(Console.ReadLine());
						if (M > 5 || M < 0)
						{
							errorM = true;
							Console.WriteLine("Введите верное значение");
						}
						else
						{
							errorM = false;
						}
					}
					while (errorM) ;

				}
				catch 
				{
					Console.WriteLine("Введите верное значение");
					errorM = true;
				}
				int N = 0;
				bool errorN = false;
				try
				{

					do
					{
						Console.Write("Введите число 'N' от 0 до 5:");
						N = Convert.ToInt32(Console.ReadLine());
						if (N > 5 || N < 0)
						{
							errorN = true;
							Console.WriteLine("Введите верное значение");
						}
						else
						{
							errorN = false;
						}
					}
					while (errorN);

				}
				catch
				{
					Console.WriteLine("Введите верное значение");
					errorN = true;
				}
				double pow = Math.Pow(M,N);

				writeToFirstFile.Write(M);
				writeToFirstFile.Write(N);
				writeToFirstFile.Write(pow);
			}
			writeToFirstFile.Close();
			WriterToSecondFileFrom(path);

		}
		public static void WriterToSecondFileFrom(string path) 
		{
			var readFromFirstFile = new BinaryReader(new FileStream(path, FileMode.Open));
			var writeToSecondFile = new BinaryWriter(new FileStream(@"C:\Users\user\Documents\Projects\ЛАБАРАТОРНАЯ 6\Laba6.2\Laba6.2\lab1.dat", FileMode.OpenOrCreate));
			while (readFromFirstFile.PeekChar() > -1)
			{
				double pow = readFromFirstFile.ReadDouble();
				writeToSecondFile.Write(pow);
			}
			writeToSecondFile.Close();
			readFromFirstFile.Close();
			var readFromSecondFile = new BinaryReader(new FileStream(@"C:\Users\user\Documents\Projects\ЛАБАРАТОРНАЯ 6\Laba6.2\Laba6.2\lab1.dat", FileMode.Open));
			while (readFromSecondFile.PeekChar() > -1)
			{
				double number = readFromSecondFile.ReadDouble();
				Console.WriteLine(number);

			}
			readFromSecondFile.Close();
			Console.ReadKey();
		}
	}
}
