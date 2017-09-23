using Microsoft.Owin;
using Owin;
using sharp.webapiSession;

[assembly: OwinStartup(typeof(Startup))]

namespace sharp.webapiSession
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
