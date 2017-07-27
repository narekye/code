using System;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(sharp.signalr.notifications.Startup))]

namespace sharp.signalr.notifications
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var config = new HttpConfiguration();
            ConfigureWebApi(config);
            
            app.MapSignalR();
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("default",
                "api/{controller}/{action}",
                new
                {
                    action = RouteParameter.Optional
                }
            );
        }
    }
}
