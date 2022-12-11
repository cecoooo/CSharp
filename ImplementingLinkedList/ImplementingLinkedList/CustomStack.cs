using System;
using System.Collections.Generic;
using System.Text;
using ImplementingLinkedList;

public class CustomStack
{
    private int initialSize = 4;
    private int[] data;
    private int count;

    public int Count 
    {
        get { return count; }
        private set { count = value; }
    }

    public CustomStack() 
    {
        this.Count = 0;
        this.data = new int[initialSize];
    }

    public void Push(int element) 
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

    public int Pop() 
    {
        if (this.count == 0)
            throw new ArgumentException("Collection is still empty.");
        int[] arr = new int[this.count-1];
        for (int i = 0; i < this.count-1; i++)
        {
            arr[i] = this.data[i];
        }
        int res = this.data[this.count-1];
        this.data = arr;
        this.count--;
        return res;
    }

    public int Peek()
    {
        if (this.count == 0)
            throw new ArgumentException("Collection is still empty.");
        return this.data[this.count - 1];
    }

    public void ForEach(Action<int> action) 
    {
        for (int i = 0; i < this.count; i++)
        {
            action(this.data[i]);
        }
    }
}