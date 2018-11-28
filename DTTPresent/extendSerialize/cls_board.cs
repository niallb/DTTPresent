using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopTeacherTools
{
    partial class cls_board
    {
        public Image background;


        partial void loadBinaryData(string binaryPath)
        {
            loadPageBinaryData(binaryPath);
            if (File.Exists(binaryPath + "\\" + M_uniqueID + "\\background.png"))
            {
                background = Image.FromFile(binaryPath + "\\" + M_uniqueID + "\\background.png");
            }
        }

        partial void saveBinaryData(string binaryPath)
        {
            savePageBinaryData(binaryPath);
            if (background != null)
            {
                //background.RawFormat.
                background.Save(binaryPath + "\\" + M_uniqueID + "\\background.png", ImageFormat.Png);
            }
        }
    }
}
