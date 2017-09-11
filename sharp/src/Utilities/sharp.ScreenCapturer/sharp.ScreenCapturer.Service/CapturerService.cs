using System.ServiceProcess;

namespace sharp.ScreenCapturer.Service
{
    public partial class CapturerService : ServiceBase
    {

        public CapturerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
