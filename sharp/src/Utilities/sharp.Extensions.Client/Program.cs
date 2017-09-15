using sharp.Extensions.QR;
using System;

namespace sharp.Extensions.Client
{
    class Program
    {
        static void Main()
        {
            QrCode.GenerateBarCode("Some text", 500, 500);
            Console.Read();
        }
    }
}
