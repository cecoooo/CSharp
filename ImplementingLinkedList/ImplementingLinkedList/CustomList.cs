using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using ImplementingLinkedList;

public class CustomList
{
    private const int initialValue = 2;

    private int[] data;
    private int count = 0;
    public int Count 
    {
        get { return count; }
    }

    public CustomList() 
    {
        this.data = new int[initialValue];
    }

    public int this[int index] 
    {
        get 
        {
            if(index < 0 || index >= this.Count)
                throw new IndexOutOfRangeException("Index was outside the bound of the collection."); 
            return data[index];
        }
        set
        {
            if (index < 0 || index >= this.Count)
                throw new IndexOutOfRangeException("Index was outside the bound of the collection.");
            data[index] = value;
        }
    }

    public void Add(int element) 
    {
        if (this.Count == this.data.Length) 
        {
            int[] arr = new int[this.Count*2];
            for (int i = 0; i < this.Count; i++)
                arr[i] = this.data[i];
            this.data = arr;
        }
        this.data[this.count] = element;
        this.count++;
    }

    public int RemoveAt(int index)
    {
        if (index >= this.count || index<0)
            throw new IndexOutOfRangeException("Index was outside the bound of the collection.");
        int[] arr = new int[this.count-1];
        int res = 0;
        int c = 0;
        for (int i = 0; i < this.count; i++)
        {
            if (i == index)
            {
                res = this.data[i];
                continue;
            }
            arr[c] = this.data[i];
            c++;
        }
        this.data = arr;
        this.count--;
        return res;
    }

    public bool Contains(int element) 
    {
        bool isThere = false;
        for (int i = 0; i < this.count; i++)
        {
            if (this.data[i] == element)
                isThere = true;
        }
        return isThere;
    }

    public void Swap(int firstIndex, int secondIndex) 
    {
        if(firstIndex < 0 || secondIndex < 0 || firstIndex >= this.count || secondIndex >= this.count)
            throw new IndexOutOfRangeException("Index was outside the bound of the collection.");
        int temp = this.data[firstIndex];
        this.data[firstIndex] = this.data[secondIndex];
        this.data[secondIndex] = temp;
    }
}