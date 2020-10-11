using System;

namespace Laba1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("система уравнения имеет следующий вид:");
			Console.WriteLine("a1*x + b1*y + c1*z = d1");
			Console.WriteLine("a2*x + b2*y + c2*z = d2");
			Console.WriteLine("a3*x + b3*y + c3*z = d3");



			Console.WriteLine("Введите значение a1");
			int a1 = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Введите значение b1");
			int b1 = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Введите значение с1");
			int c1 = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Введите значение a2");
			int a2 = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Введите значение b2");
			int b2 = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Введите значение с2");
			int c2 = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Введите значение a3");
			int a3 = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Введите значение b3");
			int b3 = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Введите значение с3");
			int c3 = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Введите значение d1");
			int d1 = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Введите значение d2");
			int d2 = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Введите значение d3");
			int d3 = Convert.ToInt32(Console.ReadLine());


			int A = a1 * b2 * c3 + c1 * a2 * b3 + b1 * c2 * a3; //подсчёт определитель основной матрицы 

			if (A == 0)
			{
				Console.WriteLine("Определитель основной матрицы равняется 0 - нет решения");
			}

			else 
			{
				double x = (double)(d1 * b2 * c3 + c1 * d2 * b3 + b1 * c2 * d3) / 3;
				double y = (double)(a1 * d2 * c3 + c1 * a2 * d3 + d1 * c2 * a3) / 3;
				double z = (double)(a1 * b2 * d3 + d1 * a2 * b3 + b1 * d2 * a3) / 3;
				Console.WriteLine("определитель основной матрицы = " + A + " x = " + x + " y = " + y + " z = " + z);
			}

			Console.ReadKey();

		}
	}
}
