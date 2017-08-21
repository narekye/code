using System;

namespace CurrencyApi.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser();
            var data = parser.GetAvailableCurrencies().Result;
            Console.WriteLine(data);
            Console.Read();
        }
    }
}
