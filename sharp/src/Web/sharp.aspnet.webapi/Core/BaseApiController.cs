using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using sharp.aspnet.webapi.Models;

namespace sharp.aspnet.webapi.Core
{
    public class BaseApiController : ApiController
    {
        protected virtual HttpResponseMessage Create200Response<T>(T data = null) where T : class
        {
            HttpResponseMessage message;
            if (data == null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
                return message;
            }
            var response = SuccessModel<T>.Success(data);
            message = Request.CreateResponse(HttpStatusCode.OK, response);
            return message;
        }

        protected virtual HttpResponseMessage Create200Response()
        {
            HttpResponseMessage message;
            message = Request.CreateResponse(HttpStatusCode.OK);
            return message;
        }


        protected virtual HttpResponseMessage Create201Response()
        {
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        protected virtual HttpResponseMessage Create202Response()
        {
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        protected virtual HttpResponseMessage Create400Response()
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        protected virtual HttpResponseMessage Create404Response()
        {
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        protected virtual HttpResponseMessage Create502Response()
        {
            return Request.CreateResponse(HttpStatusCode.BadGateway);
        }

        protected virtual HttpResponseMessage CreateHtmlResponse(string html)
        {
            var response = new HttpResponseMessage { Content = new StringContent(html) };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}