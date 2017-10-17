using Microsoft.Owin;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace sharp.aspnet.webapi.Middlewares
{
    public class RequestContentMiddleware : OwinMiddleware
    {
        public RequestContentMiddleware(OwinMiddleware next) : base(next) { }

        public static readonly ConditionalWeakTable<IOwinRequest, JToken> RequestJsonBody = new ConditionalWeakTable<IOwinRequest, JToken>();

        public override async Task Invoke(IOwinContext context)
        {
            bool bodyIsJson = context.Request.ContentType?.Contains("appliaction/json") ?? false;
            if (bodyIsJson && (context.Request.Method == HttpMethod.Post.Method || context.Request.Method == HttpMethod.Put.Method))
            {
                var json = await Common.Utils.CommonUtils.GetRequestBodyFromRequestStream(context.Request);
                var body = JToken.Parse(json);
                RequestJsonBody.Add(context.Request, body);
            }
            await Next.Invoke(context);
            if (bodyIsJson)
                RequestJsonBody.Remove(context.Request);
        }
    }
}