using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp.ISTC.Sample2
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> values = new List<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine("Before change: {0}", string.Join(", ", values));

            ChangeValues(values);

            Console.WriteLine("After change: {0}", string.Join(", ", values));

            Console.Read();
        }

        static void ChangeValues(IEnumerable<int> values)
        {
            var intValues = values as List<int>;

            intValues.AddRange(Enumerable.Range(10, 10));
        }
    }
}
