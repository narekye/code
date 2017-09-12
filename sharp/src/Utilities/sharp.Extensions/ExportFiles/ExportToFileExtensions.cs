using System.Collections.Generic;

namespace sharp.Extensions.ExportFiles
{
    public static class ExportToFileExtensions
    {
        public static void ToCsv<T>(this T @object) { }
        public static void ToCsv<T>(this IEnumerable<T> source) { }
        public static void ToXlxs<T>(this T @object) { }
        public static void ToXlxs<T>(this IEnumerable<T> source) { }
    }
}
