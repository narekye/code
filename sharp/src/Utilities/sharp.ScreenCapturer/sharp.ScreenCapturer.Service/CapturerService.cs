using sharp.ScreenCapturer.Job;
using System;
using System.ServiceProcess;
using System.Threading;

namespace sharp.ScreenCapturer.Service
{
    public partial class CapturerService : ServiceBase
    {
        private Worker worker;
        public CapturerService()
        {
            InitializeComponent();
            ServiceName = "Hah hah, your screen will be captured))";
            CanStop = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            worker = new Worker { Time = 0.5 };
            Thread workerThread = new Thread(worker.Run);
            workerThread.Start();
        }

        protected override void OnStop()
        {
            worker.StopService();
            GC.SuppressFinalize(worker);
        }
    }
}
