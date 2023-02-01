using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyHashTable hashTable = new MyHashTable(10);
            Console.WriteLine(hashTable.Count);
            hashTable.Add("Micho", "Kosio");
            hashTable.Add("icho", "Losio");
            hashTable.Add("Mic", "Mosio");
            hashTable.Add("Micdho", "Nosio");
            hashTable.Add("Micddho", "Posio");
            Console.WriteLine(hashTable.Count);
            Console.WriteLine(hashTable.GetValue("Micho"));
            hashTable.DeleteValue("icho");
            Console.WriteLine(hashTable.PrintMyHashTable());
        }
    }
}
