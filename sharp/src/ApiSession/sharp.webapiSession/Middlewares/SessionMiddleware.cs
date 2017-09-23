using System.Threading.Tasks;
using Microsoft.Owin;
using sharp.webapiSession.Models;

namespace sharp.webapiSession.Middlewares
{
    public class SessionMiddleware : OwinMiddleware
    {
        public SessionMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            var token = context.Request.Headers[Resources.Constants.Authentication];
            SessionInfoModel model = new SessionInfoModel
            {
                Name = token
            };
            await this.Next.Invoke(context);
        }
    }
}