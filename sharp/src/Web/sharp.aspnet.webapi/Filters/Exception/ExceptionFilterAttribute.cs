using sharp.aspnet.webapi.Models.Response;
using sharp.Extensions.Checkings;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace sharp.aspnet.webapi.Filters.Exception
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public bool AllowMultiple => true;

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            // Line for exception logger
            if (actionExecutedContext.Exception.IsNull())
            {
                return null;
            }
            return Task.FromResult(ErrorResponse.Create(actionExecutedContext.Exception));
        }
    }
}