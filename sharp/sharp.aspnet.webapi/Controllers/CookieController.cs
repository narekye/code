using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using sharp.aspnet.webapi.Core;
using sharp.aspnet.webapi.Filters.Exception;
using sharp.aspnet.webapi.Models;

namespace sharp.aspnet.webapi.Controllers
{
    [ActionException]
    public class CookieController : BaseApiController
    {
        private static string cookieName = "key";
        private static string cookieValue = "value";
        public HttpResponseMessage GetData()
        {
            CookieHeaderValue cookie = new CookieHeaderValue(cookieName, cookieValue) { Expires = DateTimeOffset.Now.AddHours(1) };
            HttpResponseMessage response = Create200(new SuccessModel<object>
            {
                Data = null,
                Error = null
            });
            response.Headers.AddCookies(new[] { cookie });
            return response;
        }

        public HttpResponseMessage GetCookie([FromUri]string key)
        {
            CookieHeaderValue cookie = Request.Headers.GetCookies(cookieName).FirstOrDefault();
            if (cookie != null) return Create200(new SuccessModel<string>
            {
                Data = cookie[cookieName].Value,
                Error = null
            });
            return null;
        }
    }
}
