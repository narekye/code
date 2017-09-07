using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace sharp.ScreenCapturer.Job
{
    public class ScreenCapture
    {
        public Image CaptureScreen()
        {
            return CaptureWindow(User32.GetDesktopWindow());
        }

        public Image CaptureWindow(IntPtr handle)
        {
            var hdcSrc = User32.GetWindowDC(handle);
            var windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            var width = windowRect.right - windowRect.left;
            var height = windowRect.bottom - windowRect.top;
            var hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
            var hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
            var hOld = GDI32.SelectObject(hdcDest, hBitmap);
            GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
            GDI32.SelectObject(hdcDest, hOld);
            GDI32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);
            Image img = Image.FromHbitmap(hBitmap);
            GDI32.DeleteObject(hBitmap);
            return img;
        }

        public void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format)
        {
            var img = CaptureWindow(handle);
            img.Save(filename, format);
        }

        public void CaptureScreenToFile(string filename, ImageFormat format)
        {
            var img = CaptureScreen();
            img.Save(filename, format);
        }

        private class GDI32
        {
            public const int SRCCOPY = 0x00CC0020;

            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                int nWidth, int nHeight, IntPtr hObjectSource,
                int nXSrc, int nYSrc, int dwRop);

            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                int nHeight);

            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);

            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);

            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }

        private class User32
        {
            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();

            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);

            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);

            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public readonly int left;
                public readonly int top;
                public readonly int right;
                public readonly int bottom;
            }
        }
    }
}