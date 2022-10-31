using System;
using LinkedList;

public class OwnCollection
{
    private int[] data;
    private int capacity;
    
    public OwnCollection()
        : this(4)
    {

    }

    public OwnCollection(int capacity)
    {
        this.capacity = capacity;
        this.data = new int[capacity];
    }
    public int Count { get; private set; }
    public int this[int index]
    {
        get
        {
            this.ValidateIndex(index);
            return this.data[index];
        }
        set 
        {
            this.ValidateIndex(index);
            this.data[index] = value;
        }
    }

    public void Add(int num) 
    {
        if (this.Count == this.data.Length) this.Resize();
        this.data[Count] = num;
        Count++;
    }

    public void RemoveAt(int idx) 
    {
        ValidateIndex(idx);
        var newData = new int[this.data.Length-1];
        int c = 0;
        for (int i = 0; i < this.data.Length; i++)
        {
            if (i == idx) continue;
            newData[c] = this.data[i];
            c++;
        }
        this.data = newData;
        this.Count--;
    }

    public void InsertAt(int pos, int num) 
    {
        this.ValidateIndex(pos);
        var newData = new int[this.data.Length+1];
        int c = 0;
        for (int i = 0; i < newData.Length; i++)
        {
            if (i == pos)
            {
                newData[i] = num;
                continue;
            }
            newData[i] = this.data[c];
            c++;
        }
        this.Count++;
        this.data = newData;
    }
    private void ValidateIndex(int idx) 
    {
        if (idx >=0 && idx < this.Count)
        {
            return;
        }
        throw new IndexOutOfRangeException($"Index is outside the bound of the Collection." +
            $"\nCollection Count: {this.Count} (zero based). Given index: {idx}");
    }
    private void Resize() 
    { 
        int newCapacity = this.data.Length*2;
        var newData = new int[newCapacity];
        for (int i = 0; i < this.data.Length; i++)
        {
            newData[i] = this.data[i];
        }
        this.data = newData;
    }
}