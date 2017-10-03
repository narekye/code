using sharp.Extensions.ExportFiles;
using System;
using System.Diagnostics;

namespace sharp.Extensions.Client
{
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

        }
    }
}

