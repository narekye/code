using System;

namespace sharp.Extensions.Checkings
{
    public static class CheckingExtensions
    {
        public static void ThrowIfArgumentIsNull<T>(this T obj, string parameterName = null) where T : class
        {
            if (obj == null) throw new ArgumentNullException("Not allowed to be null");
        }

        private static bool IsNull<T>(this T obj) where T : class
        {
            return ReferenceEquals(obj, null);
        }
    }
}
