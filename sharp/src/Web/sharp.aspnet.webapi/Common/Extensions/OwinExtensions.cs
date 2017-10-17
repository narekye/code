using Microsoft.Owin;
using Newtonsoft.Json.Linq;
using sharp.aspnet.webapi.Middlewares;

namespace sharp.aspnet.webapi.Common.Extensions
{
    public static class OwinExtensions
    {
        public static JToken GetRequestJsonBody(this IOwinContext context)
        {
            JToken body = null;

            if (RequestContentMiddleware.RequestJsonBody.TryGetValue(context.Request, out body))
            {
                return body;
            }
            return null;
        }
    }
}