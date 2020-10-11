using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
namespace Laba6
{
	public class DoublyNode<DoubleList>
	{
		public DoublyNode(DoubleList data)
		{
			Data = data;
		}
		public DoubleList Data { get; set; }
		public DoublyNode<DoubleList> Previous { get; set; }
		public DoublyNode<DoubleList> Next { get; set; }
	}
}