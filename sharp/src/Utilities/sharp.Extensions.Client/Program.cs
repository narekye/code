using Newtonsoft.Json;
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

            string json = "{\"name\":\"John\", \"car\":null}";
            var obj = JsonConvert.DeserializeObject<EsimINch>(json);
            Console.WriteLine();


        }
    }

    class EsimINch
    {
        public string anun { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        public string car { get; set; }

    }
}

