using sharp.AuthorizationServer.Api.Entities;
using sharp.AuthorizationServer.Api.Models;
using sharp.AuthorizationServer.Api.Store;
using System.Web.Http;

namespace sharp.AuthorizationServer.Api.Controllers
{
    [RoutePrefix("api/audience")]
    public class AudienceController : ApiController
    {
        [Route("")]
        public IHttpActionResult Post(AudienceModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Audience aud = AudiencesStore.AddAudience(model.Name);
            return Ok(aud);
        }
    }
}
