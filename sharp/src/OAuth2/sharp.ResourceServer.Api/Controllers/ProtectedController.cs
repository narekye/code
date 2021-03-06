﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace sharp.ResourceServer.Api.Controllers
{
    [Authorize, RoutePrefix("api/protected")]
    public class ProtectedController : ApiController
    {
        [Route("")]
        public IEnumerable<object> Get()
        {
            var identity = User.Identity as ClaimsIdentity;
            return identity.Claims.Select(c => new { c.Type, c.Value });
        }
    }
}