using Newtonsoft.Json.Linq;
using sharp.aspnet.webapi.Common.Extensions;
using sharp.aspnet.webapi.Core;
using sharp.Extensions.Checkings;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace sharp.aspnet.webapi.Attributes
{
    public class DefaultAuthorizeAttribute : AuthorizeAttribute
    {
        private static readonly ConcurrentDictionary<string, string> Sessions = new ConcurrentDictionary<string, string>();

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            try
            {
                var owin = actionContext.Request.GetOwinContext();
                var requestData = owin.GetRequestJsonBody();

                if (requestData[Extensions.Constants.Constants.Token].IsNull()) return false;

                var token = requestData[Extensions.Constants.Constants.Token].Value<string>();

                var session = GetSession(token);

                var controller = actionContext.ControllerContext.Controller as BaseApiController;

                if (session.IsNull())
                    return false;

                if (controller.IsNotNull() && session.IsNotNull())
                    controller.Session = session;
                return true;
            }
            catch
            {
                // Paste here your logger function to log an error if it is so neccessary;
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var controller = actionContext.ControllerContext.Controller as BaseApiController;
            actionContext.Response = !controller.IsNull()
                ? actionContext.Request.CreateResponse(controller.Unauthorized())
                : actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }

        private string GetSession(string token)
        {
            if (string.IsNullOrEmpty(token)) return null;
            string session;
            if (Sessions.TryGetValue(token, out session))
            {
                // if expired time
                if (false)
                    Sessions.TryRemove(session, out session);
            }
            return session;
        }
    }
}