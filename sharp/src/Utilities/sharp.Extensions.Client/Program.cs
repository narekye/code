using sharp.Extensions.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace sharp.Extensions.Client
{
    class Program
    {
        public async Task CompleteWork()
        {
            await Task.WhenAll(Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Thread.Sleep(1000);
                }
            }));
        }

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
