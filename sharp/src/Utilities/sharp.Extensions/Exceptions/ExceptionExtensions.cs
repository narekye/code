namespace sharp.Extensions.Exceptions
{
    public static class ExceptionExtensions
    {
        public static string GetMessageFromException(System.Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex.Message;
        }
    }
}
