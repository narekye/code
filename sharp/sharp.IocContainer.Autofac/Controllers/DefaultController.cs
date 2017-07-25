using System.Web.Http;
using sharp.IocContainer.Autofac.Repository;

namespace sharp.IocContainer.Autofac.Controllers
{
    public class DefaultController : ApiController
    {
        private IRepository repo;

        public IHttpActionResult GetAllContacts()
        {
            return Ok(repo.GetContacts());
        }
    }
}
