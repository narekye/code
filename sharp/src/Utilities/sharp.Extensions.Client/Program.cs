using sharp.Extensions.QR;
using System;
using System.Threading;

namespace sharp.Extensions.Client
{
    class Program
    {
        [STAThread]
        private static void Main()
        {
            QrCode.GenerateBarCode("otpauth://totp/UserName?secret=secret&issuer=issuer");
            Console.WriteLine("Completed !");
            Thread.Sleep(2500);
        }
    }
}
