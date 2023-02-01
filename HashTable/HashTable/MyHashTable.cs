using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using HashTable;

public class MyHashTable
{
    private string[] data;
	private int count;

	public int Count
	{
		get { return count; }
		private set { count = value; }
	}

	public MyHashTable(int length) 
	{
		this.data = new string[length];
		this.count = 0;
	}

	public void Add(string key, string value) 
	{
		this.data[Hashing(key)] = value;
		count++;
	}

	public string GetValue(string key) 
	{
		return this.data[Hashing(key)];
	}

	public void DeleteValue(string key) 
	{
		this.data[Hashing(key)] = null;
	}

	public string PrintMyHashTable() 
	{
		string res = string.Empty;
		for (int i = 0; i < this.data.Length; i++)
		{
			res += $"[{i}] -> {this.data[i]}\n";
		}
		return res;
	}

	private int Hashing(string element) 
	{
		return element.Length % this.data.Length;
	}
}