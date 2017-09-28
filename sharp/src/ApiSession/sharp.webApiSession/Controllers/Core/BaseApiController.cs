using Ninject;
using sharp.webApiSession.BLL.Repository;
using System.Web.Http;

namespace sharp.webApiSession.Controllers.Core
{
    public class BaseApiController : ApiController
    {
        [Inject]
        public virtual IAdminRepository AdminRepository { get; }
        public BaseApiController(IAdminRepository repository)
        {
            AdminRepository = repository;
        }
    }
}