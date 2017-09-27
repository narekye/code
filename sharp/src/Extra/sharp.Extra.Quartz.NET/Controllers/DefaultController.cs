using System.Web.Http;

namespace sharp.Extra.Quartz.NET.Controllers
{
    public class DefaultController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(new[] { "val1", "val2" });
        }
    }
}
