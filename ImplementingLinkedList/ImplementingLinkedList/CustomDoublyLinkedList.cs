using System;
using System.Collections;
using ImplementingLinkedList;
public class CustomDoublyLinkedList
{
	private class Node
	{
		public int value;
		public Node next = null;
		public Node previous = null;
		public Node(int value)
		{
			this.value = value;
		}
	}

	private Node head;
	private Node tail;
	private int count;
	public int Count
	{
		get { return count; }
		set { count = value; }
	}

	public void AddFirst(int element)
	{
		if (this.count == 0)
		{
			this.head = this.tail = new Node(element);
		}
		else
		{
			Node newHead = new Node(element);
			newHead.next = this.head;
			this.head.previous = newHead;
			this.head = newHead;
		}
		this.count++;
	}
	public void AddLast(int element)
	{
		if (this.count == 0)
			this.head = this.tail = new Node(element);
		else
		{
			Node newTail = new Node(element);
			newTail.previous = this.tail;
			this.tail.next = newTail;
			this.tail = newTail;
		}
		this.count++;
	}

	public int RemoveFirst()
	{
		if (this.count == 0)
			throw new Exception("You cannot remove elements from empty collection.");
		int first = this.head.value;
		this.head.next.previous = null;
		this.head = this.head.next;
		this.count--;
		return first;
	}
	public int RemoveLast()
	{
		if (this.count == 0)
			throw new Exception("You cannot remove elements from empty collection.");
		int last = this.tail.value;
		this.tail.previous.next = null;
		this.tail = this.tail.next;
		this.count--;
		return last;
	}

	public void ForEach(Func<int, int> func) 
	{
		Node node = this.head;
		for (int i = 0; i < this.count; i++)
		{
			node.value = func(node.value);
			node = node.next;
		}
	}

	public int[] ToArray() 
	{
		int[] arr = new int[this.count];
		Node node = this.head;
		for (int i = 0; i < this.count; i++)
		{
			arr[i] = node.value;
			node = node.next;
		}
		return arr;
	}
}