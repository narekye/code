using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace sharp.aspnet.webapi.Filters.Exception
{
    public class ActionExceptionAttribute : Attribute, IExceptionFilter
    {
        public bool AllowMultiple => true;

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            // Line for exception logger
            if (actionExecutedContext.Exception != null)
            {
                return null;
            }
            return Task.FromResult(new object());
        }
    }
}