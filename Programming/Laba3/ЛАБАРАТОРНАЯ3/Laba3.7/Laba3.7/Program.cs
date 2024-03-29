using System;

namespace Laba3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
			Console.Write(fib(n));
            Console.ReadKey();
        }
       public static int fib(int term, int val = 1, int prev = 0)
		{
			if (term == 0)
			{
				return prev;
			}
			if (term == 1)
			{
				return val;
			}
			return fib(term - 1, val + prev, val);
		}
    }
}
