using System;

namespace AspectsClient
{
    class LoggingUsingAspect
    {
        [Logging]
        public void FindByID(Guid id)
        {
            throw new Exception();
        }

        [Logging]
        public void CalculatePayroll()
        {

        }
    }
}
