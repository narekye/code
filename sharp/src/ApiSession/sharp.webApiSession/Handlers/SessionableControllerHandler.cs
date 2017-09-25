using System.Net.Http;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace sharp.webApiSession.Handlers
{
    public class SessionableControllerHandler : HttpControllerHandler, IRequiresSessionState
    {
        public SessionableControllerHandler(RouteData routeData) : base(routeData)
        {
        }

        public SessionableControllerHandler(RouteData routeData, HttpMessageHandler handler) : base(routeData, handler)
        {
        }
    }
}