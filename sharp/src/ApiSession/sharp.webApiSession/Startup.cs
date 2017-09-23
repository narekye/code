using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(sharp.webApiSession.Startup))]

namespace sharp.webApiSession
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage("/");
            var config = new HttpConfiguration();
            ConfigureWebApi(config);
            app.UseWebApi(config);
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
               name: "default",
               routeTemplate: "api/{controller}/{action}",
               defaults: new { action = RouteParameter.Optional }
            );
        }
    }
}
