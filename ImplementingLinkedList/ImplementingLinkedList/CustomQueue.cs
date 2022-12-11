using System;
using System.Collections.Generic;
using System.Text;
using ImplementingLinkedList;

public class CustomQueue
{
    private const int initialSize = 4;

    private int[] data;
    private int count;

    public int Count { get { return count; } }

    public CustomQueue() 
    {
        this.count = 0;
        this.data = new int[initialSize];
    }

    public void Enqueue(int element) 
    {
        if (this.count == this.data.Length)
        {
            int[] arr = new int[this.count * 2];
            for (int i = 0; i < this.count; i++)
            {
                arr[i] = this.data[i];
            }
            this.data = arr;
        }
        this.data[this.count] = element;
        this.count++;
    }

    public int Dequeue() 
    {
        if (this.count == 0)
            throw new ArgumentException("Collection is still empty.");
        int[] arr = new int[this.count-1];
        int res = this.data[0];
        int c = 0;
        for (int i = 1; i < this.count; i++)
        {
            arr[c] = this.data[i];
            c++;
        }
        this.data = arr;
        this.count--;
        return res;
    }

    public int Peek() 
    {
        if (this.count == 0)
            throw new ArgumentException("Collection is still empty.");
        return this.data[0];
    }

    public void Clear() 
    {
        this.data = new int[initialSize];
        this.count = 0;
    }

    public void ForEach(Action<int> action) 
    {
        for (int i = 0; i < this.count; i++)
        {
            action(this.data[i]);
        }
    }
}