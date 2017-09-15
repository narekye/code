using System;

namespace Creational.Builder
{
    class Program
    {
        static void Main()
        {
            var builder = Computer.ComputerBuild = new ComputerBuilder("", "").SetBluetoothEnabled()
                .SetGrapicsCardEnabled();

            var computer = builder.Build(); // builder

            Console.WriteLine(computer.Hdd);
            Console.WriteLine(computer.Ram);
        }
    }
}
