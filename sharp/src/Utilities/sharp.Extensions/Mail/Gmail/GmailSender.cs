namespace sharp.Extensions.Mail.Gmail
{
    using Checkings;
    using System.Linq;

    public class GmailSender
    {
        private readonly System.Net.Mail.MailMessage message;
        private readonly System.Net.Mail.SmtpClient client;

        #region Constructors
        /// <summary>
        /// Initializes an empty mail
        /// </summary>
        public GmailSender()
        {
            client = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            message = new System.Net.Mail.MailMessage
            {
                IsBodyHtml = false
            };
        }

        /// <summary>
        /// Initializes an GmailSender class instance on which is setted mail address from and setted mail address to.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        ///<returns>New instance of class GmailSender</returns>
        public GmailSender(System.Net.Mail.MailAddress from, System.Net.Mail.MailAddress to) : this()
        {
            message.From = from;
            message.To.Add(to);
        }

        public GmailSender(string from, string to) : this(new System.Net.Mail.MailAddress(from), new
            System.Net.Mail.MailAddress(to))
        { }
        #endregion
        /// <summary>
        /// Adds the list of mail addresses to mailing list.
        /// </summary>
        /// <param name="addresses"></param>
        /// <returns></returns>
        public GmailSender AddToMailingList(System.Collections.Generic.IEnumerable<System.Net.Mail.MailAddress> addresses)
        {
            foreach (var mailAddress in addresses)
            {
                message.To.Add(mailAddress);
            }
            return this;
        }

        public GmailSender AddToMailingList(System.Collections.Generic.IEnumerable<string> addresses)
        {
            var listMailAddresses = new System.Collections.Generic.List<System.Net.Mail.MailAddress>();

            foreach (var address in addresses)
                listMailAddresses.Add(new System.Net.Mail.MailAddress(address));
            return AddToMailingList(listMailAddresses);
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        public void Send()
        {
            if (!message.To.Any())
                throw new System.Exception("Mail message to is not set.");
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
                throw new System.Security.Authentication.InvalidCredentialException();
            client.Credentials = new System.Net.NetworkCredential(username, password);
            return this;
        }

        /// <summary>
        /// Set credentials for the SMTP client.
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        public GmailSender SetCredentials(System.Net.NetworkCredential credential)
        {
            if (credential.IsNull())
                throw new System.Security.Authentication.InvalidCredentialException();
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
