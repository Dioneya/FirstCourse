using System;
using System.Collections.Generic;
namespace Laba9
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Enter expression");
			string expression = Console.ReadLine();
			var brackets = new Stack<char>();
			bool isBreaked = false;
			for (int i = 0; i < expression.Length; i++) 
			{
				if (expression[i] == '(')
				{
					brackets.Push(expression[i]);
				}
				else if (expression[i] == ')') 
				{
					if (brackets.Count > 0)
					{
						brackets.Pop();
					}
					else 
					{
						Console.WriteLine("Выражение не верно");
						isBreaked = true;
						break;
					}
				}
			}
			if (brackets.Count > 0 && !isBreaked)
			{
				Console.WriteLine("Выражение не верно");
			}
			else if(!isBreaked)
			{
				Console.WriteLine("Выражение верно");
			}
			Console.ReadKey();
		}
	}
}
