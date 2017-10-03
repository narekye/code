using System;

namespace sharp.Extensions.Checkings
{
    public static class CheckingExtensions
    {
        public static void ThrowIfNull<T>(this T obj, string parameterName = null)
        {
            if (obj == null) throw new ArgumentNullException(Constants.Exceptions.ArgumentCannotBeNull);
        }

        public static bool IsNull<T>(this T obj) where T : class
        {
            return ReferenceEquals(obj, null);
        }
    }
}
