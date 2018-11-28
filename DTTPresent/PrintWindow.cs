using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DTTPresent
{

    // https://www.daniweb.com/programming/software-development/threads/260393/get-bitmap-of-hidden-window

    class PrintWindowContainer
    {
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        public static System.Drawing.Bitmap CaptureWindow(IntPtr hWnd)
        {
            System.Drawing.Rectangle rctForm = System.Drawing.Rectangle.Empty;
            using (System.Drawing.Graphics grfx = System.Drawing.Graphics.FromHdc(GetWindowDC(hWnd)))
            {
                rctForm = System.Drawing.Rectangle.Round(grfx.VisibleClipBounds);
            }
            System.Drawing.Bitmap pImage = new System.Drawing.Bitmap(rctForm.Width, rctForm.Height);
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(pImage);
            IntPtr hDC = graphics.GetHdc();
            //paint control onto graphics using provided options        
            try
            {
                PrintWindow(hWnd, hDC, (uint)0);
            }
            finally
            {
                graphics.ReleaseHdc(hDC);
            }
            return pImage;
        }
    }
}
