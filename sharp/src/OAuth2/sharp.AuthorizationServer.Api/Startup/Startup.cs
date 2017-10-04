using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using sharp.AuthorizationServer.Api.JWT;
using sharp.AuthorizationServer.Api.Providers;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(sharp.AuthorizationServer.Api.Startup.Startup))]

namespace sharp.AuthorizationServer.Api.Startup
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage("/");
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            ConfigureOAuth(app);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth2/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat("http://localhost:56051/")
            };

            app.UseOAuthAuthorizationServer(options);
        }
    }
}
