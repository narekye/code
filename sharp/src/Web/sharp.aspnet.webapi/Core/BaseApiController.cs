using sharp.aspnet.webapi.Models.Response;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace sharp.aspnet.webapi.Core
{
    public class BaseApiController : ApiController
    {
        public string Session { get; set; } // You can change type of session
        protected new virtual HttpResponseMessage Ok<T>(T data = null) where T : class
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

        public virtual HttpResponseMessage Created()
        {
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        public virtual HttpResponseMessage Accepted()
        {
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        public new virtual HttpResponseMessage BadRequest()
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public new virtual HttpResponseMessage NotFound()
        {
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public virtual HttpResponseMessage BadGateway()
        {
            return Request.CreateResponse(HttpStatusCode.BadGateway);
        }

        public virtual HttpResponseMessage Unauthorized()
        {
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
        public virtual HttpResponseMessage CreateHtmlResponse(string html)
        {
            var response = new HttpResponseMessage { Content = new StringContent(html) };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}