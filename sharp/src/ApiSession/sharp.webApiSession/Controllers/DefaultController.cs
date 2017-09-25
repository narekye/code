using sharp.webApiSession.BLL.Models;
using sharp.webApiSession.BLL.Repository;
using sharp.webApiSession.Controllers.Core;
using System;
using System.Web;
using System.Web.Http;

namespace sharp.webApiSession.Controllers
{

    public class DefaultController : BaseApiController
    {
        // its a bad practice to use session in REST APIs, but for testing stuff its all done))
        public DefaultController(IAdminRepository repository) : base(repository) { }

        [HttpGet]
        public IHttpActionResult DoWork()
        {
            var result = AdminRepository.DoWork();
            var model = new SessionModel()
            {
                Token = Guid.NewGuid().ToString()
            };

            if (HttpContext.Current.Session["Some"] == null)
            {
                HttpContext.Current.Session["Some"] = model;
            }

            return Ok(HttpContext.Current.Session["Some"] as SessionModel);
        }

        public IHttpActionResult GetA()
        {
            return Ok(HttpContext.Current.Session["Some"] as SessionModel);
        }
    }
}
