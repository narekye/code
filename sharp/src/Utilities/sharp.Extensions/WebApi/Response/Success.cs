using sharp.Extensions.Checkings;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace sharp.Extensions.WebApi.Response
{
    public class Success<T> : IHttpActionResult
    {
        public T Data
        {
            set
            {
                value.ThrowIfNull();
                Data = value;
            }
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
