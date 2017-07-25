using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Newtonsoft.Json.Serialization;
using Owin;
using sharp.IocContainer.Autofac.Utilities;

[assembly: OwinStartup(typeof(sharp.IocContainer.Autofac.Startup))]

namespace sharp.IocContainer.Autofac
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage("/");
            var config = new HttpConfiguration();
            app.UseCors(CorsOptions.AllowAll);
            ConfigureWebApi(config);
            app.UseWebApi(config);
            AutoFacConfig.Configure();
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("default", "api/{controller}/{action}", new { action = RouteParameter.Optional });

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
