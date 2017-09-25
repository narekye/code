using System.Web;
using System.Web.Routing;

namespace sharp.webApiSession.Handlers
{
    public class SessionStateRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new SessionableControllerHandler(requestContext.RouteData);
        }
    }
}