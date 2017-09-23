using sharp.webApiSession.BLL;
using sharp.webApiSession.Controllers.Core;
using System.Web.Http;

namespace sharp.webApiSession.Controllers
{

    public class DefaultController : BaseApiController
    {
        private readonly ICalculator _calculator;
        public DefaultController(ICalculator calculator)
        {
            _calculator = calculator;
        }


        public IHttpActionResult Get()
        {
            return Ok(_calculator.Add(3, 3));
        }
    }
}
