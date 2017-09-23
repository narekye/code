namespace sharp.IocContainer.Console
{
    class MailSender : IMailSender
    {
        public void Send(string message)
        {
            System.Console.WriteLine($"Mail sended with message: - {message}");
        }
    }
}
