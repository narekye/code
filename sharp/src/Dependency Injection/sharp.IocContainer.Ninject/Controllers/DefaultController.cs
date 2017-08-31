using System.Web.Http;
using Ninject;
using sharp.IocContainer.Ninject.Entity;
using sharp.IocContainer.Ninject.Repository;

namespace sharp.IocContainer.Ninject.Controllers
{
    public class DefaultController : ApiController
    {
        private IRepository repo;

        public DefaultController()
        {
            IKernel ninjectkernel = new StandardKernel();
            ninjectkernel.Bind<IRepository>().To<CrmRepository>().WithConstructorArgument("db", new CrmEntities());
            repo = ninjectkernel.Get<IRepository>();
        }

        // Get api/default
        public IHttpActionResult GetAllData()
        {
            var result = repo.GetContacts();
            return Ok(result);
        }
    }
}
