using sharp.Extensions.Mail.Gmail;
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

            GmailSender sender = new GmailSender();
            sender.SetBodyHtml(true).SetSubject("").SetBodyString("").SetCredentials("", "").Send();
            Console.Read();
        }
    }
}
