﻿using System;
using System.IO;
namespace Laba6
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string pathDatFile =@"C:\Users\user\Documents\Projects\ЛАБАРАТОРНАЯ 6\Laba6.1\lab.dat";
			string pathDirectoty = @"E:\Lab6_Temp";

			var directory = new DirectoryInfo(pathDirectoty);
			if (!directory.Exists) 
			{
				directory.Create();
			}
			var fileLabDat = new FileInfo(pathDatFile);
			fileLabDat.CopyTo(@"E:\Lab6_Temp\lab.dat", true);
			var fileRead = new BinaryReader(new FileStream(@"E:\Lab6_Temp\lab.dat", FileMode.Open));
			var fileWrite = new BinaryWriter(new FileStream(@"E:\Lab6_Temp\lab_backup.dat", FileMode.OpenOrCreate));
			while (fileRead.PeekChar() > -1) 
			{
				byte line = fileRead.ReadByte();
				fileWrite.Write(line);
			}
			fileWrite.Close();
			fileRead.Close();
			Console.WriteLine("размер: {0} ; время последнего изменения: {1} ; время последнего доступа: {2}",fileLabDat.Length, fileLabDat.LastWriteTime, fileLabDat.LastAccessTime);
			Console.ReadKey();

		}
	}
}
