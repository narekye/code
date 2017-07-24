using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Newtonsoft.Json.Serialization;

[assembly: OwinStartup(typeof(sharp.IocContainer.Ninject.Startup))]

namespace sharp.IocContainer.Ninject
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage("/");
            app.UseCors(CorsOptions.AllowAll);
            var config = new HttpConfiguration();
            ConfigureWebApi(config);
            app.UseWebApi(config);
        }

        public void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Routes.MapHttpRoute(
                "default",
                "api/{controller}/{action}",
                new
                {
                    action = RouteParameter.Optional
                }
            );
        }
    }
}
