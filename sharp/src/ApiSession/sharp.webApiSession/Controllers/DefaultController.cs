using sharp.webApiSession.BLL.Repository;
using sharp.webApiSession.Controllers.Core;
using System.Web.Http;

namespace sharp.webApiSession.Controllers
{

    public class DefaultController : BaseApiController
    {
        // its a bad practice to use session in REST APIs, but for testing stuff its all done))
        public DefaultController(IAdminRepository repository) : base(repository) { }

        [HttpGet]
        public IHttpActionResult Get()
        {

            return Ok();
        }
    }
}
