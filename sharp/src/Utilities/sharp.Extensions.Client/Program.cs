using sharp.Extensions.ExportFiles;
using System;

namespace sharp.Extensions.Client
{
    class Program
    {
        [STAThread]
        private static void Main()
        {
            //QrCode.GenerateBarCode("otpauth://totp/UserName?secret=secret&issuer=issuer");
            Console.WriteLine("Completed !");
            // Thread.Sleep(2500);

            PlayersEntities context = new PlayersEntities();

            context.Players.ToPdfFile();
        }
    }
}

