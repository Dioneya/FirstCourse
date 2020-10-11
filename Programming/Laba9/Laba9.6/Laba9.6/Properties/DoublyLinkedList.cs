using System.Collections.Generic;
using System.Collections;
using System;


namespace Laba9
{
	public class DoublyLinkedList<DoubleList> : IEnumerable<DoubleList>  // двусвязный список
	{
		DoublyNode<DoubleList> head; // головной/первый элемент
		DoublyNode<DoubleList> tail; // последний/хвостовой элемент
		int count;  // количество элементов в списке

		// добавление элемента
		public void Add(DoubleList data)
		{
			var node = new DoublyNode<DoubleList>(data);

			if (head == null)
				head = node;
			else
			{
				tail.Next = node;
				node.Previous = tail;
			}
			tail = node;
			count++;
		}
		public void AddFirst(DoubleList data)
		{
			var node = new DoublyNode<DoubleList>(data);
			DoublyNode<DoubleList> temp = head;
			node.Next = temp;
			head = node;
			if (count == 0)
				tail = head;
			else
				temp.Previous = node;
			count++;
		}
		// удаление
		public bool Remove(DoubleList data)
		{
			DoublyNode<DoubleList> current = head;

			// поиск удаляемого узла
			while (current != null)
			{
				if (current.Data.Equals(data))
				{
					break;
				}
				current = current.Next;
			}
			if (current != null)
			{
				// если узел не последний
				if (current.Next != null)
				{
					current.Next.Previous = current.Previous;
				}
				else
				{
					// если последний, переустанавливаем tail
					tail = current.Previous;
				}

				// если узел не первый
				if (current.Previous != null)
				{
					current.Previous.Next = current.Next;
				}
				else
				{
					// если первый, переустанавливаем head
					head = current.Next;
				}
				count--;
				return true;
			}
			return false;
		}

		public int Count { get { return count; } }
		public bool IsEmpty { get { return count == 0; } }

		public void Clear()
		{
			head = null;
			tail = null;
			count = 0;
		}

		public bool Contains(DoubleList data)
		{
			DoublyNode<DoubleList> current = head;
			while (current != null)
			{
				if (current.Data.Equals(data))
					return true;
				current = current.Next;
			}
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this).GetEnumerator();
		}

		IEnumerator<DoubleList> IEnumerable<DoubleList>.GetEnumerator()
		{
			DoublyNode<DoubleList> current = head;
			while (current != null)
			{
				yield return current.Data;
				current = current.Next;
			}
		}

		public IEnumerable<DoubleList> BackEnumerator()
		{
			DoublyNode<DoubleList> current = tail;
			while (current != null)
			{
				yield return current.Data;
				current = current.Previous;
			}
		}

		public DoublyNode<DoubleList> SearchElement(int index)
		{
			//присваиваю первый или последний член списка
			DoublyNode<DoubleList> Prev = tail;
			DoublyNode<DoubleList> Next = head;

			//Проверка на недопустимый индекс / проход с начала / конца списка.
			if (index > count || index < 0)
			{
				throw new IndexOutOfRangeException();
			}
			else if (index < ((count + 1) / 2))
			{
				if (index == 0)
				{
					return head;
				}

				for (; index != 0; index--)
				{
					Next = Next.Next;
				}

				return Next;
			}
			else
			{
				for (; index < count; index++)
				{
					Prev = Prev.Previous;
				}

				return Prev;
			}
		}

		public DoubleList AddToPosition(DoubleList elem, int index)
		{
			DoublyNode<DoubleList> Last = tail;
			DoublyNode<DoubleList> Next = SearchElement(index);

			if (index == 0)
			{
				head = new DoublyNode<DoubleList>(elem);
				head.Next = Next;
				Next.Previous = head;
				return default(DoubleList);
			}

			DoublyNode<DoubleList> Prev = SearchElement(index - 1);
			var NewElement = new DoublyNode<DoubleList>(elem);


			Prev.Next = NewElement;
			NewElement.Previous = Prev;
			Next.Previous = NewElement;
			NewElement.Next = Next;

			count++;

			tail = Last;

			return default(DoubleList);
		}


	}
}
