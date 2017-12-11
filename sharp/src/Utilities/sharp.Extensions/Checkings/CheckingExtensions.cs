using System;

namespace sharp.Extensions.Checkings
{
    public static class CheckingExtensions
    {
        public static void ThrowIfNull<T>(this T obj, Exception exception = null)
        {
            if (obj == null) throw exception.IsNull() ? new NullReferenceException() : exception;
        }

        public static bool IsNull<T>(this T obj) where T : class
        {
            return ReferenceEquals(obj, null);
        }

        public static bool IsNotNull<T>(this T obj) where T : class
        {
            return !IsNull(obj);
        }
    }
}