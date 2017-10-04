using System;
using System.Threading;

namespace sharp.ScreenCapturer.Job
{
    public class Worker
    {
        private ScreenCapturer Capturer;
        private MailSender.MailSender sender;
        private bool enabled = true;
        public double Time { get; set; }
        public Worker()
        {
            Capturer = new ScreenCapturer();
            sender = new MailSender.MailSender();
        }

        public void Run()
        {
            while (enabled)
            {
                var image = Capturer.CaptureScreen();
                sender.SendMail(image);
                Thread.Sleep(TimeSpan.FromHours(Time));
            }
        }

        public void StopService()
        {
            enabled = false;
        }
    }
}
