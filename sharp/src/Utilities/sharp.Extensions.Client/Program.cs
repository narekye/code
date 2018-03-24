using sharp.Extensions.ExportFiles;
using System;
using System.Collections.Generic;

namespace sharp.Extensions.Client
{
    class Program
    {
        [STAThread]
        private static void Main()
        {
            var s = System.IO.File.ReadAllLines("NewFolder/TextFile1.txt");

            byte b = 100;
            b = unchecked((byte)(b + 200));
        }
    }
}
