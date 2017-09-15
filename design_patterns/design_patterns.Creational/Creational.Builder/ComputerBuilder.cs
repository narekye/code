namespace Creational.Builder
{
    public class ComputerBuilder
    {
        public string Hdd { get; set; }
        public string Ram { get; set; }
        public bool GraphicsCardEnabled { get; set; }
        public bool BluetoothEnabled { get; set; }
        public ComputerBuilder(string hdd, string ram)
        {
            Hdd = hdd;
            Ram = ram;
        }
        public ComputerBuilder SetGrapicsCardEnabled()
        {
            GraphicsCardEnabled = true;
            return this;
        }

        public ComputerBuilder SetBluetoothEnabled()
        {
            BluetoothEnabled = true;
            return this;
        }

        public Computer Build()
        {
            return new Computer(this);
        }
    }
}
