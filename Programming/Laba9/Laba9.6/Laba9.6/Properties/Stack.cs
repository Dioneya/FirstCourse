using System;
namespace Laba9
{
	class Stack<T>
	{
		class StackItem<T>
		{
			public T Data { get; private set; } 
			public StackItem<T> Next { get; set; } 

			public StackItem(T item)
			{
				this.Data = item;
			}
		}

		public void PrintAll() //Вывод стэка
		{
			while (current != null)
			{
				Console.Write(current.Data+" ");
				current = current.Next;
			}
			current = first;
		}

		public void Add(T item) 
		{
			StackItem<T> I = new StackItem<T>(item);

			if (first == null)
			{
				I.Next = null;
			}
			else
			{
				I.Next = first;

			}
			first = I;
			current = I;
		}

		private StackItem<T> first;
		private StackItem<T> current;
	}
}
