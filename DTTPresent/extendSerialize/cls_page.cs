using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OverlayPaint;

using System.Windows.Forms;
using System.Drawing.Imaging;


namespace DesktopTeacherTools
{
    public partial class cls_page
    {
        public Bitmap thumb;
        public List<OverlayPaintArea.Layer> tmpLayers;

        internal void savePageBinaryData(string binaryPath)
        {
            if(!Directory.Exists(binaryPath + "\\" + M_uniqueID))
            {
                Directory.CreateDirectory(binaryPath + "\\" + M_uniqueID);
            }
            string tpath = binaryPath + "\\" + M_uniqueID + "\\thumbnail.png";
            thumb.Save(tpath, ImageFormat.Png);
            //MessageBox.Show("Saving binary data for " + M_uniqueID + "\r\nto "+binaryPath);
        }

        internal void loadPageBinaryData(string binaryPath)
        {
            if (File.Exists(binaryPath + "\\" + M_uniqueID + "\\thumbnail.png"))
            {
                using (FileStream fs = new FileStream(binaryPath + "\\" + M_uniqueID + "\\thumbnail.png", FileMode.Open, FileAccess.Read))
                {
                    thumb = (Bitmap)Image.FromStream(fs);
                }
            }
            //MessageBox.Show("Loading binary data for " + M_uniqueID + "\r\nfrom " + binaryPath);
        }

    }
}
