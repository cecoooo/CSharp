using System;
using System.Collections;
using System.Dynamic;
using ImplementingLinkedList;

// Name of the class
public class CustomDoublyLinkedList
{
	// Create inner class Node
	// Node is a member of the collection
	private class Node
	{
		// it keeps the given value, next and previous element
		public int value;
		public Node next = null;
		public Node previous = null;
		public Node(int value)
		{
			this.value = value;
		}
	}

	// define properties of the class
	// head - first node
	private Node head;
	//tail = last node
	private Node tail;
	// count - number of Nodes in the collection
	private int count;
	public int Count
	{
		get { return count; }
		private set { count = value; }
	}

    // AddFirst(int element) method changes the head of the collection
    public void AddFirst(int element)
	{
		// if there are no still elements in the LinkedList, the new element is both head and tail 
		if (this.count == 0)
		{
			this.head = this.tail = new Node(element);
		}
		// if the LinkedList has already any elements, then:
		else
		{
			// create a new node
			Node newHead = new Node(element);
			// newHead now has next node the current head
			newHead.next = this.head;
			// current head has as previous node the newHead
			this.head.previous = newHead;
			// now newHead is current head
			this.head = newHead;
		}
		this.count++;
	}
    // AddLast(int element) method changes the tail of the collection
    public void AddLast(int element)
	{
        // if there are no still elements in the LinkedList, the new element is both head and tail 
        if (this.count == 0)
			this.head = this.tail = new Node(element);
        // if the LinkedList has already any elements, then:
        else
        {
            // create a new node
            Node newTail = new Node(element);
            // newTail now has next node the current tail
            newTail.previous = this.tail;
            // current tail has as previous node the newTail
            this.tail.next = newTail;
            // now newTail is current tail
            this.tail = newTail;
		}
		this.count++;
	}

	// this method removes the current head and returns its value
	public int RemoveFirst()
	{
		// if there are no elements in the collection then we can remove nothing and return exception
		if (this.count == 0)
			throw new Exception("You cannot remove elements from empty collection.");
		// keep the value into a variable
		int first = this.head.value;
		// remove current head
		this.head.next.previous = null;
		// new head is the next element
		this.head = this.head.next;
		// update the counter
		this.count--;
		return first;
	}
	public int RemoveLast()
	{
        // if there are no elements in the collection then we can remove nothing and return exception
        if (this.count == 0)
			throw new Exception("You cannot remove elements from empty collection.");
        // keep the value into a variable
        int last = this.tail.value;
        // remove current tail
        this.tail.previous.next = null;
        // new tail is the previous element
        this.tail = this.tail.next;
		this.count--;
		return last;
	}

	// this method transforms every single element's value by given function
	public void ForEach(Func<int, int> func) 
	{
		// start from the head
		Node node = this.head;
		for (int i = 0; i < this.count; i++)
		{
			// change the value of the node
			node.value = func(node.value);
			// get the next node
			node = node.next;
		}
	}

	// returns array with the values of the nodes
	public int[] ToArray() 
	{
		// allocate memory for the array
		int[] arr = new int[this.count];
		// start with the head
		Node node = this.head;
		for (int i = 0; i < this.count; i++)
		{
			// get the values
			arr[i] = node.value;
			// get the next node
			node = node.next;
		}
		// return the array
		return arr;
	}
}