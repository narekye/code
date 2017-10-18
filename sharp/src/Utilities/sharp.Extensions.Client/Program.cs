using System;
namespace sharp.Extensions.Client
{
    class Program
    {
        [STAThread]
        private static void Main()
        {
            string token = Common.Common.GenerateToken();
            Console.WriteLine(token);
            Console.Read();
        }
    }
}
