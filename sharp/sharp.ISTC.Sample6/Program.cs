using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp.ISTC.Sample6
{

    class Parent
    {
        static Parent()
        {
            Console.WriteLine("Parent static ctor called");
        }

        public Parent()
        {
            Console.WriteLine("Parent ctor called");
        }
    }

    class Child : Parent
    {
        //public int Child { get; set; }

            public int this[int a, int b]
        {
            get {
                int[] arr = new int[10];

                return 0; }
        }

        static Child()
        {
            Console.WriteLine("Child static ctor called");
        }

        public Child()
        {
            Console.WriteLine("Child ctor called");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var child = new Child();
            Console.ReadKey();

            int value = 2;

            Console.WriteLine(value++ + ++value);

            Console.ReadKey();
        }
    }
}
