using System;
using System.Collections.Generic;
using System.Linq;

namespace sharp.ISTC.Sample3
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> values = new List<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine("Before change: {0}", string.Join(", ", values));

            ChangeValues(values);

            Console.WriteLine("After change: {0}", string.Join(", ", values));

            Console.ReadLine();

            ChangeValues(ref values);

            Console.WriteLine("After change: {0}", string.Join(", ", values));

            Console.Read();
        }

        static void ChangeValues(ref IEnumerable<int> values)
        {
            values = new List<int>(Enumerable.Range(100, 10));
        }

        static void ChangeValues(IEnumerable<int> values)
        {
            values = new List<int>(Enumerable.Range(200, 10));
        }
    }
}
