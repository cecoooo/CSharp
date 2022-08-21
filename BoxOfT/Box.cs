using System;
using BoxOfT;

public class Box<T>
{
    private T[] data;
    private int capacity;
    public Box() :
        this(4)
    {

    }
    public Box(int capacity)
    {
        this.capacity = capacity;
        this.data = new T[capacity];
    }
    public int Count { get; private set; }
    public void Add(T element) 
    {
        if (Count == this.data.Length) this.Resize();
        this.data[Count] = element;
        Count++;
    }
    public void Remove() 
    {
        var newData = new T[Count-1];
        for (int i = 0; i < newData.Length; i++)
        {
            newData[i] = this.data[i];
        }
        this.data = newData;
        Count--;
    }
    private void Resize() 
    {
        var newData = new T[this.data.Length * 2];
        for (int i = 0; i < this.data.Length; i++)
            newData[i] = this.data[i];
        this.data = newData;
    }
}