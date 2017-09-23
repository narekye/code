using System.Web.Http;

namespace sharp.webApiSession.Controllers
{

    public class DefaultController : ApiController
    {
        public DefaultController()
        {

        }


        public IHttpActionResult Get()
        {
            return Ok(new object());
        }
    }
}
