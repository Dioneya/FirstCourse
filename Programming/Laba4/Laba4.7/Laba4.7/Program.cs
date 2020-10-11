using System;

namespace Laba4
{
	class MainClass
	{
		public static string ConverterToString(char number1, char number2) 
		{
			string converter = Convert.ToString(number1) + Convert.ToString(number2);
			return converter;
		}

		public static void Main(string[] args)
		{
			string[] musicOfPlayList = new string[10];
			musicOfPlayList[0] = "Gentle Giant – Free Hand [06:15]";
			musicOfPlayList[1] = "Supertramp – Child Of Vision [07:27]";
			musicOfPlayList[2] = "Camel – Lawrence [10:46]";
			musicOfPlayList[3] = "Yes – Don’t Kill The Whale [03:55]";
			musicOfPlayList[4] = "10CC – Notell Hotel [04:58]";
			musicOfPlayList[5] = "Nektar – King Of Twilight [04:16]";
			musicOfPlayList[6] = "The Flower Kings – Monsters & Men [21:19]";
			musicOfPlayList[7] = "Focus – Le Clochard [01:59]";
			musicOfPlayList[8] = "Pendragon – Fallen Dream And Angel [05:23]";
			musicOfPlayList[9] = "Kaipa – Remains Of The Day [08:02]";

			Console.WriteLine("====Список плейлиста====");
			foreach (string music in musicOfPlayList) 
			{
				Console.WriteLine(music);
			}
			Console.WriteLine("========================");

			int[] durationOfMusic = new int [musicOfPlayList.Length];
			int sum = 0;
			for (int i = 0; i < musicOfPlayList.Length; i++) 
			{
				int indexOfNumberMin = musicOfPlayList[i].IndexOf('[')+1;
				string music = musicOfPlayList[i];
				durationOfMusic[i] = int.Parse(ConverterToString(music[indexOfNumberMin], music[indexOfNumberMin + 1])) * 60;
				int indexOfNumberSec = musicOfPlayList[i].IndexOf(':')+1;
				durationOfMusic[i] += int.Parse(ConverterToString(music[indexOfNumberSec],music[indexOfNumberSec + 1]));
				sum += durationOfMusic[i];
				//Тест на определение времени в секундах каждой песни: Console.WriteLine(durationOfMusic[i]);
			}
			Console.WriteLine("Сумма равна: "+sum/3600+"h "+(sum/60-(sum/3600*60))+"min "+(sum-(sum/60*60))+"sec ");
			//Нахождение мин и макс
			int indexOfMinDurationMusic = 0; int indexOfMaxDurationMusic = 0;
			for (int i = 1; i < musicOfPlayList.Length; i++) 
			{
				if (durationOfMusic[indexOfMinDurationMusic]>durationOfMusic[i]) 
				{
					indexOfMinDurationMusic = i;
				}

				if (durationOfMusic[indexOfMaxDurationMusic]<durationOfMusic[i]) 
				{
					indexOfMaxDurationMusic = i;
				}
			}
			Console.WriteLine("Самая короткая песня: "+musicOfPlayList[indexOfMinDurationMusic]);
			Console.WriteLine("Самая длинная песня: " + musicOfPlayList[indexOfMaxDurationMusic]);
			//Нахождение мин разницы в песнях
			string music1="";
			string music2="";
			for (int i = 0, differance=100; i < musicOfPlayList.Length; i++) 
			{
				for (int j = 0; j < musicOfPlayList.Length; j++) 
				{
					if (i == j)
					{
						continue;
					}
					else 
					{
						if (Math.Abs(durationOfMusic[i] - durationOfMusic[j]) < differance) 
						{
							differance = Math.Abs(durationOfMusic[i] - durationOfMusic[j]);
							music1 = musicOfPlayList[i];
							music2 = musicOfPlayList[j];
						}
					}
				}
			}
			Console.WriteLine("Песни с минимальной разницой: "+music1+"; "+music2);
			Console.ReadKey();
		}
	}
}
