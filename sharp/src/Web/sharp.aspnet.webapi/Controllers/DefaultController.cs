using sharp.aspnet.webapi.Core;
using sharp.aspnet.webapi.Filters.Exception;
using System.Web.Http;

namespace sharp.aspnet.webapi.Controllers
{
    [ExceptionFilter]
    // [DefaultAuthorize]
    public class DefaultController : BaseApiController
    {
        // an empty controller
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
