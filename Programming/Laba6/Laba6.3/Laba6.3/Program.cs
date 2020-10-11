using System;
using System.IO;

namespace Laba6
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string pathOriginalFile = @"C:\Users\user\Documents\Projects\ЛАБАРАТОРНАЯ 6\Laba6.3\Laba6.3\text.txt";
			string pathEditFile = @"C:\Users\user\Documents\Projects\ЛАБАРАТОРНАЯ 6\Laba6.3\Laba6.3\text1.txt";
			int cntOfEmptyLines = 0;
			using (var readfromText = new StreamReader(pathOriginalFile))
			{
				var writeToSecondFile = new System.IO.StreamWriter(pathEditFile, false);
				while (readfromText.Peek()>-1) 
				{
					string line = readfromText.ReadLine();
					if (line != "")
					{
						writeToSecondFile.WriteLine(line + " «(c)Student»");
					}
					else
					{
						writeToSecondFile.WriteLine(line);
						cntOfEmptyLines++;
					}
				}
				writeToSecondFile.Close();
			}
			Console.Write(cntOfEmptyLines);
			Console.ReadKey();
		}
	}
}
