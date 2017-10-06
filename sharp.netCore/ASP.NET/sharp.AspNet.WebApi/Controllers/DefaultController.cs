using Microsoft.AspNetCore.Mvc;

namespace sharp.AspNet.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DefaultController : Controller
    {
        [HttpGet, Route("")]
        public IActionResult Get()
        {
            var headers = HttpContext.Request.Headers;
            return Ok(new[] { "value1", "value2" });
        }
    }
}