using System;

namespace Laba1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int sec = Convert.ToInt32(Console.ReadLine());
			int min = sec / 60;
			int hour = min / 60;

			min = min - hour * 60; 

			sec = sec - (min*60 + hour*3600);

			Console.WriteLine("Часов - "+hour + " Минуты - "+min+" Секунд - "+sec );
			Console.ReadKey();
		}
	}
}
