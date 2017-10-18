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
        [NonAction]
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
        [NonAction]
        public virtual HttpResponseMessage Created()
        {
            return Request.CreateResponse(HttpStatusCode.Created);
        }
        [NonAction]
        public virtual HttpResponseMessage Accepted()
        {
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
        [NonAction]
        public new virtual HttpResponseMessage BadRequest()
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        [NonAction]
        public new virtual HttpResponseMessage NotFound()
        {
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
        [NonAction]
        public virtual HttpResponseMessage BadGateway()
        {
            return Request.CreateResponse(HttpStatusCode.BadGateway);
        }
        [NonAction]
        public virtual HttpResponseMessage Unauthorized()
        {
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
        [NonAction]
        public virtual HttpResponseMessage CreateHtmlResponse(string html)
        {
            var response = new HttpResponseMessage();
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(Extensions.Constants.ContentType.Html);
            if (string.IsNullOrEmpty(html))
                html = Extensions.Constants.HTML.Empty;
            response.Content = new StringContent(html);
            return response;
        }
    }
}