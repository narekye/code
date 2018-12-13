using System;

namespace sharp.ISTC.Sample6
{

    class ClassA
    {
        static ClassA()
        {
            Console.WriteLine("Parent static ctor called");
        }

        public ClassA()
        {
            Console.WriteLine("Parent ctor called");
        }
    }

    class ClassB : ClassA
    {
        static ClassB()
        {
            Console.WriteLine("Child static ctor called");
        }

        public ClassB()
        {
            Console.WriteLine("Child ctor called");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var child = new ClassB();
            Console.ReadKey();

            int value = 2;

            Console.WriteLine(value++ + ++value);

            Console.ReadKey();
        }
    }
}
