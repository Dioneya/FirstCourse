using System;
namespace Laba9
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
