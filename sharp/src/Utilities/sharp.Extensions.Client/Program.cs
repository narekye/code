using sharp.Extensions.Common;
using System;

namespace sharp.Extensions.Client
{
    class Program
    {
        [STAThread]
        private static void Main()
        {
            var pass = "poghos";
            byte[] arr = pass.Compress();
            var tt = arr.Decompress();
            Console.WriteLine(tt);
        }
    }
}
