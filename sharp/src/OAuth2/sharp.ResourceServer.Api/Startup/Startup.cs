using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System.Collections.Generic;
using System.Web.Http;

[assembly: OwinStartup(typeof(sharp.ResourceServer.Api.Startup.Startup))]

namespace sharp.ResourceServer.Api.Startup
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var issuer = "http://localhost:56051/";
            var audience = "099153c2625149bc8ecb3e85e03f0022";
            var secret = TextEncodings.Base64Url.Decode("IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw");
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions()
            {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { audience },
                IssuerSecurityTokenProviders = new List<IIssuerSecurityTokenProvider>()
                {
                    new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                }

            });
        }
    }
}

