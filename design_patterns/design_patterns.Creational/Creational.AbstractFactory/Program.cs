using System;
using Creational.AbstractFactory.AbstractFactory;

namespace Creational.AbstractFactory
{
    class Program
    {
        static void Main()
        {
            var factory = new ConcreteFactory();
            var client = new Client.Client(factory);
            client.DoWork();
            // delay 
            Console.Read();
        }
    }
}
