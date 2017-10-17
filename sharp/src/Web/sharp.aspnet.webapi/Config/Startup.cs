using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using sharp.aspnet.webapi.Middlewares;
using System.Web.Http;

[assembly: OwinStartup(typeof(sharp.aspnet.webapi.Config.Startup))]

namespace sharp.aspnet.webapi.Config
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            Configure(config);
            app.Use<RequestContentMiddleware>();
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private void Configure(HttpConfiguration config)
        {
            config.EnableCors();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("default", "api/{controller}/{id}", new { id = RouteParameter.Optional });
        }
    }
}
