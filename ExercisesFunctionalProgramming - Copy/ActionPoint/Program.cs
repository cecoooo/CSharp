using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Example
{
    internal class Program
    {
        public delegate bool CheckForLessThanZeroNumber(int num);
        public delegate int Number(string num);
        public delegate int NumberInt(int n);
        static void Main(string[] args)
        {
            CheckForLessThanZeroNumber isLess = new CheckForLessThanZeroNumber(isLessThanZero);
            CheckForLessThanZeroNumber isHigher = new CheckForLessThanZeroNumber(isHigherThanZero);
            var getNum = new Number(GetNumber);
            var getNum2 = new Number(GetNumber);
            var arr = new NumberInt(Add);
            arr = new NumberInt(Num);
            Console.WriteLine(arr(3));
            Console.WriteLine(arr(3));
            if (isLess(-5))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
            if (isLess(5))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
            bool isBigger = isHigher(1);

            if (isBigger)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
            Func<int, int, int> add = (a, b) => a+b;
            Action<int> print = x => Console.WriteLine(x);
            Console.WriteLine(
                String.Join("\n", 
                Console.ReadLine().
                Split(" ").
                Select(GetNumber).
                ToArray().
                Select(add)));
        }
        static bool isLessThanZero(int num)
        {
            if (num < 0)
                return true;
            else
                return false;
        }
        static bool isHigherThanZero(int num)
        {
            if (num > 0)
                return true;
            else
                return false;
        }
        static int GetNumber(string digit)
        {
            int number = 0;
            for (int i = 0; i < digit.Length; i++)
            {
                int n = digit[i] - '0';
                number += n;
                number *= 10;
            }
            return number / 10;
        }
        static int Add(int n) 
        {
            return n + 10;
        }
        static int Num(int n)
        {
            return n;
        }
    }
}


