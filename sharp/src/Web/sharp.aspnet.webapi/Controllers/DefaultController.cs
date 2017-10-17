using sharp.aspnet.webapi.Attributes;
using sharp.aspnet.webapi.Core;
using sharp.aspnet.webapi.Filters.Exception;

namespace sharp.aspnet.webapi.Controllers
{
    [ActionException]
    [DefaultAuthorize]
    public class DefaultController : BaseApiController
    {
        // an empty controller
    }
}
