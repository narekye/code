using System.Drawing;
using System.Drawing.Imaging;

namespace sharp.ScreenCapturer.Job
{
    public class ScreenShootSaver
    {
        public static void SaveImage(string path, Image img)
        {
            img.Save("temp.png", ImageFormat.Png);
        }
    }
}
