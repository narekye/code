using sharp.Extensions.ExportFiles;
using sharp.Extensions.Xml;
using System;
using System.Diagnostics;

namespace sharp.Extensions.Client
{
    public class FF
    {
        public int I { get; set; }
    }
    class Program
    {
        [STAThread]
        private static void Main()
        {
            var obj = new { Name = "alice", Age = 148, Country = "uae" };
            Stopwatch watch = new Stopwatch();
            watch.Start();
            obj.ToCsv().GetAwaiter().GetResult();
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
            Console.Read();

            Console.WriteLine(new string('-', 30));
            var k = new FF() { I = 4 }.XmlSerialize();
            Console.WriteLine(k);
        }


    }
}

