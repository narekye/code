using Microsoft.Owin.Security.DataHandler.Encoder;
using sharp.AuthorizationServer.Api.Entities;
using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;

namespace sharp.AuthorizationServer.Api.Store
{
    public static class AudiencesStore
    {
        public static ConcurrentDictionary<string, Audience> AudiencesList = new ConcurrentDictionary<string, Audience>();

        static AudiencesStore()
        {
            var audience = new Audience()
            {
                ClientId = "099153c2625149bc8ecb3e85e03f0022",
                Base64Secret = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw",
                Name = "ResourceServer.Api 1"

            };
            AudiencesList.TryAdd("099153c2625149bc8ecb3e85e03f0022", audience);
        }

        public static Audience AddAudience(string name)
        {
            var clientId = Guid.NewGuid().ToString("N");
            var key = new byte[32];
            RNGCryptoServiceProvider.Create().GetBytes(key);
            var base64Secret = TextEncodings.Base64Url.Encode(key);
            var audience = new Audience()
            {
                ClientId = clientId,
                Base64Secret = base64Secret,
                Name = name
            };
            AudiencesList.TryAdd(clientId, audience);
            return audience;
        }

        public static Audience FindAudience(string clientId)
        {
            Audience aud = null;
            if (AudiencesList.TryGetValue(clientId, out aud))
            {
                return aud;
            }
            return null;
        }
    }
}