using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace sharp.ScreenCapturer.MailSender
{
    public class MailSender
    {
        private static string mailTo = "yegoryan.narek@gmail.com";
        private static string mailFrom = "esiminch";
        private SmtpClient client;
        private string path = Environment.SpecialFolder.MyDocuments.ToString() + "\\picture";
        public MailSender()
        {
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.Credentials = new NetworkCredential("", "");
            client.EnableSsl = true;
        }

        public void SendMail(Image img)
        {
            LinkedResource resource = new LinkedResource(path,
                 MediaTypeNames.Image.Jpeg);
            img.Save(path, ImageFormat.Jpeg);
            string htmlBody = "<html><body><h1>Picture</h1><br><img src=\"here\"></body></html>";
            htmlBody.Replace("here", path);
            resource.ContentId = new Guid().ToString();
            MailMessage mail = new MailMessage(mailFrom, mailTo);
            mail.Subject = string.Format("");
            mail.IsBodyHtml = true;

        }


    }
}