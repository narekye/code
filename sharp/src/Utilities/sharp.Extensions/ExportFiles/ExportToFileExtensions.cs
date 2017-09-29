using iTextSharp.text;
using iTextSharp.text.pdf;
using sharp.Extensions.Checkings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;

namespace sharp.Extensions.ExportFiles
{
    public static class ExportToFileExtensions
    {
        public static void ToCsv<T>(this T @object) { }
        public static void ToCsv<T>(this IEnumerable<T> source) { }
        public static void ToXlxs<T>(this T @object) { }
        public static void ToXlxs<T>(this IEnumerable<T> source) { }

        public static void ToPdfFile<T>(this DbSet<T> source, string path = null) where T : class, new()
        {
            Document document = new Document();
            if (string.IsNullOrWhiteSpace(path))
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            path += $"\\{System.DateTime.Now.ToShortDateString().Replace('/', '-')}_table.pdf";
            PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
            document.Open();
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font font = new Font(baseFont, Font.DEFAULTSIZE);
            var propertyInfoArray = typeof(T).GetProperties().ToList();
            var properties = propertyInfoArray.Select(x => x.Name).ToList();
            if (properties == null)
                throw new Exception("Properties count is 0.");
            PdfPTable table = new PdfPTable(properties.Count);
            PdfPCell cell = new PdfPCell(new Phrase($"Database table writed at - {System.DateTime.Now.Date}", font));
            cell.Colspan = properties.Count;
            cell.HorizontalAlignment = 1;
            cell.Border = 0;
            table.AddCell(cell);
            foreach (string item in properties)
            {
                cell = new PdfPCell(new Phrase(item, font));
                cell.BackgroundColor = BaseColor.GREEN;
                table.AddCell(cell);
            }
            var listOfObjects = source.ToList();
            foreach (var item in listOfObjects)
            {
                foreach (PropertyInfo propertyInfo in propertyInfoArray)
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = item?.GetType().GetProperty(propertyName)?.GetValue(item, null);
                    if (propertyValue is IEnumerable && !(propertyValue is string))
                    {
                        cell = new PdfPCell(new Phrase("Collection", font));

                        font.Color = BaseColor.RED;
                    }
                    else
                    {
                        bool isNull = propertyValue.IsNull();
                        string text = isNull ? "Empty" : propertyValue?.ToString();
                        cell = new PdfPCell(new Phrase($"{text}", font));
                        font.Color = BaseColor.BLACK;
                        cell.BackgroundColor = BaseColor.WHITE;
                    }
                    table.AddCell(cell);
                    font.Color = BaseColor.BLACK;
                }
            }
            document.Add(table);
            document.Close();
        }
    }
}
