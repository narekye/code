using System;

namespace sharp.ISTC.Sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 5;

            Console.WriteLine($"Current value: {value}");

            ChangeValue(value);

            Console.WriteLine($"Value after change: {value}");

            Console.Read();
        }

        static void ChangeValue(int valueToBeChanged)
        {
            valueToBeChanged = 10;
        }
    }
}
