using Microsoft.Owin;
using Owin;
using sharp.Extra.Quartz.NET.Jobs;
using System.Web.Http;

[assembly: OwinStartup(typeof(sharp.Extra.Quartz.NET.Startup.Startup))]

namespace sharp.Extra.Quartz.NET.Startup
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage("/");
            var config = new HttpConfiguration();
            Configure(config);
            app.UseWebApi(config);
            EmailScheduler.Start();
        }

        private void Configure(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("default",
                "api/{controller}/{action}",
                new { action = RouteParameter.Optional });
        }
    }
}
