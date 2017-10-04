using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using sharp.AuthorizationServer.Api.Entities;
using sharp.AuthorizationServer.Api.Store;
using System;
using System.IdentityModel.Tokens;
using Thinktecture.IdentityModel.Tokens;

namespace sharp.AuthorizationServer.Api.JWT
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private const string AudiencePropertyKey = "audience";
        private readonly string _issuer = string.Empty;

        public CustomJwtFormat(string issuer)
        {
            _issuer = issuer;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentException(nameof(data));
            }
            string audienceId = data.Properties.Dictionary.ContainsKey(AudiencePropertyKey)
                ? data.Properties.Dictionary[AudiencePropertyKey]
                : null;

            if (string.IsNullOrWhiteSpace(audienceId))
                throw new InvalidOperationException("AuthenticationTicket.Properties does not include audience");

            Audience audience = AudiencesStore.FindAudience(audienceId);

            string symmetricKeyAsBase64 = audience.Base64Secret;

            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);

            var signingKey = new HmacSigningCredentials(keyByteArray);

            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;

            var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime,
                expires.Value.UtcDateTime, signingKey);

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);

            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}