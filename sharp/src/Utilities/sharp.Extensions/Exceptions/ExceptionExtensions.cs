using System;

namespace sharp.Extensions.Exceptions
{
    public static class ExceptionExtensions
    {
        public static string GetMessageFromException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex.Message;
        }
    }
}
