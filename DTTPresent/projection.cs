using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTPMagnify
{
    public partial class projection : Form
    {
        public class Info
        {
            public Point pos;
            public Size sz;
            public Point cursorPos;
        }

        Bitmap s, backimg;
        Info info;

        public projection(Info theInfo)
        {
            info = theInfo;
            InitializeComponent();
            projectionTimer.Start();
        }

        public void setPic(Bitmap p)
        {
            if (s != null)
                s.Dispose();
            //s = new Bitmap(p, thePic.Size);


            s = new Bitmap(thePic.Width, thePic.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (var gr = Graphics.FromImage(s))
            {
                gr.DrawImage(p, new Rectangle(Point.Empty, s.Size));
            }
            if (thePic.Image != null) thePic.Image.Dispose();
            thePic.Image = s;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void projectionTimer_Tick(object sender, EventArgs e)
        {            
            if(!worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
  /*          if (info != null)
            {
                if (backimg != null)
                    backimg.Dispose();
                backimg = new Bitmap(info.sz.Width, info.sz.Height);
                Graphics g2 = Graphics.FromImage(backimg);
                g2.CopyFromScreen(info.pos.X, info.pos.Y, 0, 0, info.sz);
                //g2.DrawEllipse(Pens.Red, cpos.X - 5 - zoomx, cpos.Y - 5 - zoomy, 10, 10);
 
                setPic(backimg);
            }*/

        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (info != null)
            {
                if (backimg != null)
                    backimg.Dispose();
                backimg = new Bitmap(info.sz.Width, info.sz.Height);
                Graphics g2 = Graphics.FromImage(backimg);
                g2.CopyFromScreen(info.pos.X, info.pos.Y, 0, 0, info.sz);
                //g2.DrawEllipse(Pens.Red, cpos.X - 5 - zoomx, cpos.Y - 5 - zoomy, 10, 10);

                setPic(backimg);
            }

        }

    }
}
