using PostSharp.Aspects;
using System;

namespace AspectsClient
{
    [Serializable]
    public class LoggingAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("{0}.{1}: Enter",
                                    args.Method.DeclaringType.FullName, args.Method.Name);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            Console.WriteLine("{0}.{1}: Success",
                                    args.Method.DeclaringType.FullName, args.Method.Name);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine("{0}.{1}: Exception {2}",
                                    args.Method.DeclaringType.FullName, args.Method.Name,
                                    args.Exception.Message);
        }
    }
}
