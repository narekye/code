using sharp.aspnet.webapi.Models.Response;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace sharp.aspnet.webapi.Core
{
    public class BaseApiController : ApiController
    {
        public string Session { get; set; } // You can change it
        protected virtual HttpResponseMessage Create200Response<T>(T data = null) where T : class
        {
            HttpResponseMessage message;
            if (data == null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
                return message;
            }
            var response = SuccessResponse<T>.Success(data);
            message = Request.CreateResponse(HttpStatusCode.OK, response);
            return message;
        }

        public virtual HttpResponseMessage Create200Response()
        {
            var message = Request.CreateResponse(HttpStatusCode.OK);
            return message;
        }


        public virtual HttpResponseMessage Create201Response()
        {
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        public virtual HttpResponseMessage Create202Response()
        {
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        public virtual HttpResponseMessage Create400Response()
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public virtual HttpResponseMessage Create404Response()
        {
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public virtual HttpResponseMessage Create502Response()
        {
            return Request.CreateResponse(HttpStatusCode.BadGateway);
        }

        public virtual HttpResponseMessage CreateHtmlResponse(string html)
        {
            var response = new HttpResponseMessage { Content = new StringContent(html) };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}