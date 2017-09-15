namespace Creational.Builder
{
    public class Computer
    {
        public string Hdd { get; set; }
        public string Ram { get; set; }
        public bool GraphicsCardEnabled { get; set; }
        public bool BluetoothEnabled { get; set; }
        public static ComputerBuilder ComputerBuild { get; set; }
        public Computer(ComputerBuilder builder)
        {
            Hdd = builder.Hdd;
            Ram = builder.Ram;
            GraphicsCardEnabled = builder.GraphicsCardEnabled;
            BluetoothEnabled = builder.BluetoothEnabled;
        }
    }
}
