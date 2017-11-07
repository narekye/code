using sharp.Extensions.Checkings;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Authentication;

namespace sharp.Extensions.Mail.Gmail
{
    public class GmailSender
    {
        private MailMessage message;
        private SmtpClient client;
        /// <summary>
        /// Initializes an empty mail
        /// </summary>
        public GmailSender()
        {
            client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            message = new MailMessage
            {
                IsBodyHtml = false
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public GmailSender(MailAddress to) : this()
        {
            message.To.Add(to);
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        public void Send()
        {
            if (!message.To.Any())
                throw new Exception("Mail message to is not set.");
            client.Send(message);
        }
        /// <summary>
        /// Sets the flag [IsBodyHtml] of  mail message.
        /// </summary>
        /// <param name="isBodyHtml"></param>
        /// <returns>Same instance on which set [IsBodyHtml] flag.</returns>
        public GmailSender SetBodyHtml(bool isBodyHtml = false)
        {
            message.IsBodyHtml = isBodyHtml;
            return this;
        }
        /// <summary>
        /// Sets the body of message as processed on argument of function.
        /// </summary>
        /// <param name="body"></param>
        /// <returns>Same instance on which set body.</returns>
        public GmailSender SetBodyString(string body)
        {
            message.Body = body;
            return this;
        }
        /// <summary>
        /// Set credentials for the SMTP client.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public GmailSender SetCredentials(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new InvalidCredentialException();
            client.Credentials = new NetworkCredential(username, password);
            return this;
        }

        /// <summary>
        /// Set credentials for the SMTP client.
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        public GmailSender SetCredentials(NetworkCredential credential)
        {
            if (credential.IsNull())
                throw new InvalidCredentialException();
            client.Credentials = credential;
            return this;
        }
        /// <summary>
        /// Sets the subject of message.
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public GmailSender SetSubject(string subject)
        {
            if (subject.IsNull())
                subject = "Empty subject";
            message.Subject = subject;
            return this;
        }
    }
}
