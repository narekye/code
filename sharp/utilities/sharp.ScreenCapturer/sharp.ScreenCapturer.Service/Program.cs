using System.ServiceProcess;

namespace sharp.ScreenCapturer.Service
{
    static class Program
    {
        static void Main()
        {
            var ServicesToRun = new ServiceBase[]
            {
                new CapturerService()
            };

            ServiceBase.Run(ServicesToRun);
        }
    }
}
