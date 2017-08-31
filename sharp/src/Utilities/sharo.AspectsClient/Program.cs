using System;

namespace AspectsClient
{
    class Program
    {
        static void Main()
        {
            var aspect = new LoggingUsingAspect(); // loggs all errors
            aspect.FindByID(new Guid());
        }
    }
}
