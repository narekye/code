using System;

namespace Creational.Prototype
{
    class Program
    {
        static void Main()
        {
            IEmployee obj = new Employee();
            obj.AddData();
            var next = obj.Clone();
            Console.WriteLine(obj == next);
        }
    }
}
