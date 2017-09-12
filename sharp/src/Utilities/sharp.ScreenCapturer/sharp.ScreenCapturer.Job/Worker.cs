namespace sharp.ScreenCapturer.Job
{
    public class Worker
    {
        private ScreenCapturer Capturer;
        private MailSender.MailSender sender;

        public Worker()
        {
            Capturer = new ScreenCapturer();
            sender = new MailSender.MailSender();
        }

        public void CaptureSendScreenShoot()
        {
            var image = Capturer.CaptureScreen();
            sender.SendMail(image);
        }
    }
}
