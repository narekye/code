using iTextSharp.text;
using iTextSharp.text.pdf;
using sharp.Extensions.Checkings;
using sharp.Extensions.Constants;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace sharp.Extensions.ExportFiles
{
    public static class ExportToFileExtensions
    {
        /// <summary>
        /// T is a object.
        /// By default file will be saved on local machine desktop.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="path"></param>
        /// <param name="fileType"></param>
        public static async Task ToCsv<T>(this T source, string path = null, FileExtensionEnum fileType = FileExtensionEnum.Csv)
        {
            source.ThrowIfNull();
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(path))
            {
                builder.Append(path);
                builder.Append(fileType);
            }
            else
            {
                builder.Clear()
                    .Append(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)).Append('/')
                    .Append(System.DateTime.Now.ToShortDateString().Replace('/', '-')).Append('.');
                builder.Append(fileType);
            }

            var propertiesInfo = source.GetType().GetProperties().Select(x => x.Name);
            var objects = propertiesInfo as IList<string> ?? propertiesInfo.ToList();
            objects.ThrowIfNull();

            using (FileStream stream = File.Create(builder.ToString()))
            {
                // Property name write.
                builder.Clear();
                foreach (var s in objects)
                {
                    if (s == objects.LastOrDefault())
                    {
                        builder.Append(s);
                        continue;
                    }
                    builder.Append(s).Append(',');
                }

                byte[] text = new UTF8Encoding(true).GetBytes(builder + Environment.NewLine);
                await stream.WriteAsync(text, 0, text.Length);

                // Property value write.
                builder.Clear();
                foreach (var s in objects)
                {
                    var value = source.GetType().GetProperty(s)?.GetValue(source, null);
                    if (s == objects.LastOrDefault())
                    {
                        builder.Append(value);
                        continue;
                    }
                    builder.Append(value).Append(',');

                }
                text = new UTF8Encoding(true).GetBytes(builder.ToString());
                await stream.WriteAsync(text, 0, builder.Length);
            }
        }

        public static async Task ToCsv<T>(this IEnumerable<T> source) { }
        public static void ToXlxs<T>(this T @object) { }
        public static void ToXlxs<T>(this IEnumerable<T> source) { }

        public static void ToPdfFile<T>(this IEnumerable<T> source, string path = null) where T : class
        {
            source.ThrowIfNull();
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
            PdfPCell cell = new PdfPCell(new Phrase($"Database table writed at - {System.DateTime.Now.Date}", font))
            {
                Colspan = properties.Count,
                HorizontalAlignment = 1,
                Border = 0
            };
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
