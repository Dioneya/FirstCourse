using System;
using System.Linq;

namespace Laba1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			/*
			int first = number / 1000;
			int second = number/100%10; 
			int third = number/10%10;
			int last = number%10;
			*/

			int number = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine((number / 1000) * (number / 100 % 10) * (number / 10 % 10) * (number % 10));
			Console.ReadKey();











			/*
			string number = Console.ReadLine(); //ввод числа 
			char[] numbers = number.ToCharArray(); //разбиваем строку на чары
			string[] arr = new string[numbers.Length];//присваиваем массиву строки, массивы чаров
			arr[0] = Convert.ToString(numbers[0]); //превращаем значения чаров в строку
			arr[1] = Convert.ToString(numbers[1]);
			arr[2] = Convert.ToString(numbers[2]);
			arr[3] = Convert.ToString(numbers[3]);
			int[] chiffre = new int[4]; //создаём интовый массив
			chiffre[0] = Convert.ToInt32(arr[0]); //переводим символ в число 
			chiffre[1] = Convert.ToInt32(arr[1]);
			chiffre[2] = Convert.ToInt32(arr[2]);
			chiffre[3] = Convert.ToInt32(arr[3]);


			int multiply = chiffre[0]*chiffre[1]*chiffre[2]*chiffre[3]; //умножаем числа 
			Console.WriteLine(multiply);
			Console.ReadKey();
			*/

		}
	}
}
