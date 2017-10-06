using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sharp.AspNet.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Default")]
    public class DefaultController : Controller
    {
        [HttpGet, Route("")]
        public IActionResult Get()
        {
            var headers = this.HttpContext.Request.Headers;
            return Ok(new[] { "value1", "value2" });
        }
    }
}