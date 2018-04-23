using System;
using System.Drawing;
using ZXing;
using ZXing.QrCode;

namespace sharp.Extensions.QR
{
    using Extensions.Checkings;

    public class QrCode
    {
        public static void GenerateBarCode(string text, int width = 250, int height = 250)
        {
            text.ThrowIfNull(new ArgumentException("Text cannot be null or empty."));

            var options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = width,
                Height = height
            };

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = options
            };



            var result = new Bitmap(writer.Write(text));
            string date = System.DateTime.Now.ToShortDateString();
            result.Save(date.Replace('/', '-') + ".jpeg");
        }
    }
}
