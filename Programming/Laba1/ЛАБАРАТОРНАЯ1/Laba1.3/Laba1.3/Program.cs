using System;

namespace Laba1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Введите часы от 0-11");
			ushort userHours = Convert.ToUInt16(Console.ReadLine());
			Console.WriteLine("Введите минуты от 0-59");
			ushort userMin = Convert.ToUInt16(Console.ReadLine());
			Console.WriteLine("Введите секунды от 0-59");
			ushort userSec = Convert.ToUInt16(Console.ReadLine());

			int hour = 30*userHours;
			double min = 0.5*userMin;
			double sec =0.0083*userSec;

			double angle = hour+min+sec;

			Console.WriteLine("Угол = "+angle);
			Console.ReadKey();

		}
	}
}
