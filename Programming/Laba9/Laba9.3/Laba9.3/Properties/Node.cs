﻿using System;
namespace Laba9
{
	public class Node<T>
	{
		public Node(T data)
		{
			Data = data;
		}
		public T Data { get; set; }
		public Node<T> Next { get; set; }
	}
}
