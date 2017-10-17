using Newtonsoft.Json.Linq;
using sharp.aspnet.webapi.Common.Extensions;
using sharp.aspnet.webapi.Core;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace sharp.aspnet.webapi.Attributes
{
    public class DefaultAuthorizeAttribute : AuthorizeAttribute
    {
        private const string Token = "Token";
        private static readonly ConcurrentDictionary<string, string> Sessions = new ConcurrentDictionary<string, string>();

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            try
            {
                var owin = actionContext.Request.GetOwinContext();
                var requestData = owin.GetRequestJsonBody();

                if (requestData[Token] == null) return false;

                var token = requestData[Token].Value<string>();

                var session = GetSession(token);

                var controller = actionContext.ControllerContext.Controller as BaseApiController;

                if (controller == null || session == null)
                    return false;

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
            if (controller != null)
                actionContext.Response = actionContext.Request.CreateResponse(controller.Create400Response());
            else
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        private string GetSession(string token)
        {
            if (string.IsNullOrEmpty(token)) return null;
            string session;
            if (Sessions.TryGetValue(token, out session))
            {
                // if expired time
                Sessions.TryRemove(session, out session);
            }
            return session;
        }
    }
}