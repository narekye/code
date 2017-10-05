using System.ComponentModel;
using System.ServiceProcess;

namespace sharp.ScreenCapturer.Service
{
    [RunInstaller(true)]
    public partial class CapturerServiceInstaller : System.Configuration.Install.Installer
    {
        ServiceInstaller _capturerServiceInstaller;
        ServiceProcessInstaller processInstaller;
        public CapturerServiceInstaller()
        {
            InitializeComponent();
            processInstaller = new ServiceProcessInstaller();
            processInstaller.Account = ServiceAccount.LocalSystem;
            _capturerServiceInstaller.StartType = ServiceStartMode.Manual;
            _capturerServiceInstaller.ServiceName = "Service";
            Installers.Add(processInstaller);
            Installers.Add(_capturerServiceInstaller);
        }
    }
}
