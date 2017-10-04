using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using sharp.AuthorizationServer.Api.Store;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace sharp.AuthorizationServer.Api.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                context.SetError(Constants.Constants.InvalidClientId, Constants.Constants.ClientIdIsNotSet);
            }

            var audience = AudiencesStore.FindAudience(context.ClientId);

            if (audience == null)
            {
                context.SetError(Constants.Constants.InvalidClientId, $"{Constants.Constants.InvalidClientId} '{context.ClientId}'");
                return Task.FromResult<object>(null);
            }
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //Dummy check here, you need to do your DB checks against memebrship system http://bit.ly/SPAAuthCode
            if (context.UserName != context.Password)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect");
                //return;
                return Task.FromResult<object>(null);
            }

            var identity = new ClaimsIdentity("JWT");

            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Manager"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Supervisor"));

            var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                {
                    "audience", context.ClientId ?? string.Empty
                }
            });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }
    }
}