using Quartz;
using System.Net;
using System.Net.Mail;

namespace sharp.Extra.Quartz.NET.Jobs
{
    public class EmailSender : IJob
    {
        private static MailAddress fromAddress = new MailAddress("from@gmail.com", "Its a job");
        private static MailAddress toAddress = new MailAddress("to@gmail.com", "To me");
        private const string password = "password";
        private const string subject = "Subject";
        private const string body = "<h1>Hello from job</h1>";

        public void Execute(IJobExecutionContext context)
        {
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })

            using (SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, password)
            })
            {
                client.Send(message);
            }
        }
    }
}