using Microsoft.Owin;
using Ninject.Web.Common;
using Ninject.Web.WebApi;
using Owin;
using sharp.webApiSession.Handlers;
using sharp.webApiSession.Middlewares;
using System.Web.Http;
using System.Web.Routing;

[assembly: OwinStartup(typeof(sharp.webApiSession.Startup))]

namespace sharp.webApiSession
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<SessionMiddleware>();
            app.UseWelcomePage("/");
            var config = new HttpConfiguration();
            ConfigureWebApi(config);
            app.UseWebApi(config);
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.DependencyResolver = new NinjectDependencyResolver(new Bootstrapper().Kernel);
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
               name: "default",
               routeTemplate: "api/{controller}/{action}",
               defaults: new { action = RouteParameter.Optional }
            );
            RouteTable.Routes.MapHttpRoute(
                name: "default",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = RouteParameter.Optional }).RouteHandler = new SessionStateRouteHandler();
        }
    }
}
