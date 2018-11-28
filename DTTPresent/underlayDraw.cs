using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopTeacherTools
{
    //enum position {full, left, right, top, bottom};

    class underlayDraw
    {
        private int decadesAcross;
        private bool logAcross;
        private int decadesDown;
        private bool logDown;
        private int minBorder;
        private float[] logPoints = {-1.0f, 0.0f, 0.3010f, 0.4771f, 0.6021f, 0.6990f, 0.7782f, 0.8451f, 0.9031f, 0.9542f };
        private cls_underlayDefinition.underlayPosition pos;

        public underlayDraw(int decadesAcross, bool logAcross, int decadesDown, bool logDown)
        {
            this.decadesAcross = decadesAcross;
            this.logAcross = logAcross;
            this.decadesDown = decadesDown;
            this.logDown = logDown;
            minBorder = 20;
            pos = cls_underlayDefinition.underlayPosition.full;
        }

        public underlayDraw(cls_underlayDefinition def) : this(1 ,false, 1,false)
        {
            if (def != null)
            {
                this.decadesAcross = def.M_decadesAcross;
                this.logAcross = def.M_logAcross;
                this.decadesDown = def.M_decadesDown;
                this.logDown = def.M_logDown;
                minBorder = 20;
                pos = def.M_position;
            }
        }

        public void DrawUnderlayPaper(Image image, Color lineColour)
        {
            Graphics g = Graphics.FromImage(image);
            Pen gpPen = new Pen(lineColour);
            Pen gpPenFaint = new Pen(Color.FromArgb(64, lineColour));

            int maxWidth = image.Width - minBorder * 2;
            int maxHeight = image.Height - minBorder * 2;
            if ((pos == cls_underlayDefinition.underlayPosition.left) || (pos == cls_underlayDefinition.underlayPosition.right))
                maxWidth = maxWidth / 2;
            if ((pos == cls_underlayDefinition.underlayPosition.top) || (pos == cls_underlayDefinition.underlayPosition.bottom))
                maxHeight = maxHeight / 2;

            float decWidth = maxWidth / decadesAcross;
            float decHeight;
            if (decadesDown == 0)
            {
                decHeight = decWidth;
                decadesDown = (int)Math.Floor((double)maxHeight / decHeight);
            }
            else
                decHeight = maxHeight / decadesDown;

            // if(forceSquare)
            if(decHeight != decWidth)
            {
                decHeight = decHeight < decWidth ? decHeight : decWidth;
                decWidth = decHeight;
            }
            int graphWidth = decadesAcross * (int)decWidth;
            int graphHeight = decadesDown * (int)decHeight;

            int graphX = (image.Width - graphWidth) / 2;
            if (pos == cls_underlayDefinition.underlayPosition.left)
                graphX -= (image.Width / 2 - minBorder) / 2;//(image.Width / 2) - (((image.Width / 2 - minBorder) / 2) + minBorder);
            else if (pos == cls_underlayDefinition.underlayPosition.right)
                graphX += (image.Width / 2 - minBorder) / 2;
            int graphY = (image.Height - graphHeight) / 2;
            if (pos == cls_underlayDefinition.underlayPosition.top)
                graphY -= (image.Height / 2 - minBorder) / 2;
            if (pos == cls_underlayDefinition.underlayPosition.bottom)
                graphY += (image.Height / 2 - minBorder) / 2;


            g.DrawRectangle(gpPen, graphX, graphY, graphWidth, graphHeight);

            float unitWidth = decWidth / 10;
            for (int dec = 0; dec < decadesAcross; dec++)
            {
                float x = graphX + dec * decWidth;
                g.DrawLine(gpPen, x, graphY, x, graphHeight + graphY);
                if (logAcross)
                {
                    for (int unit = 2; unit < 10; unit++)
                    {
                        g.DrawLine(gpPenFaint, x + logPoints[unit] * decWidth, graphY, x + logPoints[unit] * decWidth, graphHeight + graphY);
                    }
                }
                else
                {
                    for (int unit = 1; unit < 10; unit++)
                    {
                        g.DrawLine(gpPenFaint, x + unit * unitWidth, graphY, x + unit * unitWidth, graphHeight + graphY);
                    }
                }
            }
            float unitHeight = decHeight / 10;
            for (int dec = 0; dec < decadesDown; dec++)
            {
                float y = (graphY + graphHeight) - dec * decHeight;
                g.DrawLine(gpPen, graphX, y, graphX + graphWidth, y);
                if (logDown)
                {
                    for (int unit = 2; unit < 10; unit++)
                    {
                        g.DrawLine(gpPenFaint, graphX, y - logPoints[unit] * decHeight, graphX + graphWidth, y - logPoints[unit] * decHeight);
                    }
                }
                else
                {
                    for (int unit = 1; unit < 10; unit++)
                    {
                        g.DrawLine(gpPenFaint, graphX, y - unit * unitHeight, graphX + graphWidth, y - unit * unitHeight);
                    }
                }
            }
        }   
    }
}
