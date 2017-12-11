namespace sharp.Extensions.ExportFiles
{
    using Checkings;
    using Constants;
    using System.Linq;

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
        /// <returns>Awaitable task.</returns>
        public static async System.Threading.Tasks.Task ToCsv<T>(this T source, string path = null, FileExtensionEnum fileType = FileExtensionEnum.Csv) where T : class
        {
            source.ThrowIfNull();
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            if (!string.IsNullOrEmpty(path))
                builder.Append(path).Append(fileType);
            else
            {
                builder.Clear()
                    .Append(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop)).Append('/')
                    .Append(System.DateTime.Now.ToShortDateString().Replace('/', '-')).Append('.');
                builder.Append(fileType);
            }

            var propertiesInfo = source.GetType().GetProperties().Select(x => x.Name);
            var objects = propertiesInfo as System.Collections.Generic.IList<string> ?? propertiesInfo.ToList();
            objects.ThrowIfNull();

            using (System.IO.FileStream stream = System.IO.File.Create(builder.ToString()))
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

                byte[] text = new System.Text.UTF8Encoding(true).GetBytes(builder + System.Environment.NewLine);
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
                text = new System.Text.UTF8Encoding(true).GetBytes(builder.ToString());
                await stream.WriteAsync(text, 0, builder.Length);
            }
        }

        public static void ToCsv<T>(this System.Collections.Generic.IEnumerable<T> source, string fileName = null, string path = null)
        {

        }
        public static void ToXlxs<T>(this T @object) { }
        public static void ToXlxs<T>(this System.Collections.Generic.IEnumerable<T> source) { }

        public static void ToPdfFile<T>(this System.Collections.Generic.IEnumerable<T> source, string path = null) where T : class
        {
            source.ThrowIfNull();
            iTextSharp.text.Document document = new iTextSharp.text.Document();

            if (string.IsNullOrWhiteSpace(path))
                path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);

            path += $"\\{System.DateTime.Now.ToShortDateString().Replace('/', '-')}_table.pdf";
            iTextSharp.text.pdf.PdfWriter.GetInstance(document, new System.IO.FileStream(path, System.IO.FileMode.Create));
            document.Open();
            iTextSharp.text.pdf.BaseFont baseFont = iTextSharp.text.pdf.BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf",
                iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE);
            var propertyInfoArray = typeof(T).GetProperties().ToList();
            var properties = propertyInfoArray.Select(x => x.Name).ToList();

            properties.ThrowIfNull(new System.Exception("Properties count is 0."));

            iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(properties.Count);
            iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase($"Database table writed at - {System.DateTime.Now.Date}", font))
            {
                Colspan = properties.Count,
                HorizontalAlignment = 1,
                Border = 0
            };
            table.AddCell(cell);
            foreach (string item in properties)
            {
                cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(item, font));
                cell.BackgroundColor = iTextSharp.text.BaseColor.GREEN;
                table.AddCell(cell);
            }
            var listOfObjects = source.ToList();
            foreach (var item in listOfObjects)
            {
                foreach (System.Reflection.PropertyInfo propertyInfo in propertyInfoArray)
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = item?.GetType().GetProperty(propertyName)?.GetValue(item, null);
                    if (propertyValue is System.Collections.IEnumerable && !(propertyValue is string))
                    {
                        cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Collection", font));
                        font.Color = iTextSharp.text.BaseColor.RED;
                    }
                    else
                    {
                        bool isNull = propertyValue.IsNull();
                        string text = isNull ? "Empty" : propertyValue?.ToString();
                        cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase($"{text}", font));
                        font.Color = iTextSharp.text.BaseColor.BLACK;
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    }
                    table.AddCell(cell);
                    font.Color = iTextSharp.text.BaseColor.BLACK;
                }
            }
            bool added = document.Add(table);

            if (!added)
                throw new System.Exception("Table wasn't added to document. Please verify your object.");

            document.Close();
        }
    }
}
