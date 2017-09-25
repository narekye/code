using sharp.webApiSession.BLL.Repository;
using sharp.webApiSession.Controllers.Core;
using System.Web.Http;

namespace sharp.webApiSession.Controllers
{

    public class DefaultController : BaseApiController
    {
        public DefaultController(IAdminRepository repository) : base(repository) { }

        [HttpGet]
        public IHttpActionResult DoWork()
        {
            var result = AdminRepository.DoWork();
            return Ok(result);
        }
    }
}
