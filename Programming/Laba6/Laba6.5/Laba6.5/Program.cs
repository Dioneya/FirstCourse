using System;
using System.IO;
using System.Drawing;
namespace Laba6
{
	class MainClass
	{
		public static void Main(string[] args)
		{
            string nameOfImage = Console.ReadLine();
			string path = @"C:\Users\user\Documents\Projects\ЛАБАРАТОРНАЯ6\Laba6.5\"+nameOfImage;
			//var image = new Bitmap(path);
			//Console.WriteLine("{0} {1} {2} {3} {4}",image.Size, image.Width, image.Height, image.VerticalResolution, image.HorizontalResolution);
			var image = new BinaryReader(new FileStream(path,FileMode.Open));
			char[] code = image.ReadChars(2);
			int size = image.ReadInt32();
			image.ReadBytes(8);
			int sizeZag = image.ReadInt32();
			int width = image.ReadInt32();
			int height = image.ReadInt32();
			short plane = image.ReadInt16();
			short byteByPixel = image.ReadInt16();
			int compression = image.ReadInt32();
			string compressionName = "";
			switch(compression)
			{
				case (0):
					compressionName = "BI_RGB";
					break;
				case (1):
					compressionName = "BI_RLE8";
					break;
				case (2):
					compressionName = "BI_RLE4";
					break;	
			}
			int compressionSize = image.ReadInt32();
			int horizontalResolustion = image.ReadInt32();
			int verticalResolution = image.ReadInt32();
			int numOfColors = image.ReadInt32();
			int numOfImportantColors = image.ReadInt32();
			int[] palitra = new int [numOfColors];
			if (numOfColors > 0) 
			{
				for (int i = 0; i < palitra.Length; i++) 
				{
					palitra[i] = image.ReadInt32();
				}
			}
			image.Close();
			Console.WriteLine("Символ: {0}{1}\nРазмер: {2}\nРазмер Заголовка: {3}\nШирина: {4}\nВысота: {5}\nЧисло плоскостей: {6}\nБит/пиксель: {7}\nТип Сжатия: {8}\nРазмер сжатого изображения: {9}\nГоризонтальное разрешение: {10}\nВертикальное разрешение: {11}\nКоличество используемых цветов: {12}\nКоличество важных цветов: {13}",code[0],code[1],size,sizeZag,width,height,plane,byteByPixel,compressionName,compressionSize,horizontalResolustion,verticalResolution,numOfColors,numOfColors);
			Console.WriteLine("Карта цветов:");
			foreach (int color in palitra) 
			{
				Console.Write(color+";");
			}
			Console.ReadKey();
		}
	}
}
