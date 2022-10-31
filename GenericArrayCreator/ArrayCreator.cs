using System;
using GenericArrayCreator;

public class ArrayCreator
{
    public static T[] Create<T>(int len, T item) 
    {
        var arr = new T[len];
        for (int i = 0; i < arr.Length; i++) 
        {
            arr[i] = item;
        }
        return arr;
    }
}

