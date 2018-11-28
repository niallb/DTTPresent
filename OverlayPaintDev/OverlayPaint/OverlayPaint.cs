using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OverlayPaint
{
    public partial class OverlayPaintArea : UserControl
    {
        public enum penType { none, softpen, marker, highlighter, airbrush, brush, spray, eraser };

        private const int  MAXPRESSURE = 750;

        //private bool needsRefresh;

        private bool isZoomed = false;
        private Rectangle zoomRect;

        internal OverlayPaintControls ctrls;
        private bool ctrlsEnabled = true;

        [Serializable]
        public class Layer
        {
            public Bitmap image;
            public string name;
            public bool visible;
            public bool selected { get; internal set; }

            public Layer(int width, int height)
            {
                image = new Bitmap(width, height);
                visible = true;
                name = "";
            }
        }

        private Bitmap zoomedBackgroundImage;
        private Bitmap background;

         //# really should initialise background if needed.
        public Bitmap Image { get { return background; } set{ background = value;} }

        public Bitmap PenImg
        {
            get
            {
                if ((penImages != null) && (penImages.Count > 0))
                    return penImages[0];
                else
                    return null;
            }
        }

        

        [DllImport("user32.dll")]
        private static extern uint GetMessageExtraInfo();

        private List<Bitmap> penImages;
        private penType type;
        private List<Layer> layers;
        private int activeLayer
        {
            get
            {
                int n = 0;
                foreach(Layer l in layers)
                {
                    if (l.selected)
                        return n;
                    n++;
                }
                layers[0].selected = true;
                return 0;
            }
        }
        private Bitmap activeLayerImg;
        private int layerNumbering;
        public bool drawing { get; private set; }
        public bool tabletActive { get; private set; }
        private PointF cp;
        public int penSize {get; private set;}

        private TabletLaunch tl;
        
        private bool pointerVis;
        public Point pointerPos;

        private int magfactor; // How extra big to make the image

        public EventHandler onLayersChanged;

        public OverlayPaintArea()
        {
            magfactor = 1;
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent; 
            Reinitialise();

            penImages = new List<Bitmap>();
            penImages.Add(getPenImage(3, 3, Color.DarkBlue, penType.softpen, 1.0));
            tabletActive = false;
         }

        public void Reinitialise()
        {
            layers = new List<Layer>();
            Layer l1 = new Layer(this.Width * magfactor, this.Height * magfactor);
            layerNumbering = 1;
            l1.name = "layer" + layerNumbering.ToString();
            layers.Add(l1);
            setActiveLayer(0);
            if (onLayersChanged != null)
            {
                onLayersChanged(this, null);
            }
            Invalidate();
        }

        public List<Layer> Layers 
        { 
            get { return layers; } 
            set 
            { 
                layers = value;
                setActiveLayer(activeLayer);
                if (onLayersChanged != null)
                {
                    onLayersChanged(this, null);
                }
                OverlayPaint_Resize(this, null);
                Invalidate(); 
            } 
        }

        public Layer AddLayer()
        {
            Layer ln = new Layer(this.Width * magfactor, this.Height * magfactor);
            layerNumbering++;
            ln.name = "layer" + layerNumbering.ToString();
            layers.Add(ln);
            setActiveLayer(layers.Count - 1);
            if (onLayersChanged != null)
            {
                onLayersChanged(this, null);
            }
            return ln;
        }

        public void ClearLayer()
        {
            if (layers.Count > 0)
            {
                int targ = activeLayer;
                layers[targ].image = new Bitmap(this.Width * magfactor, this.Height * magfactor);
                Invalidate();
                if (onLayersChanged != null)
                {
                    onLayersChanged(this, null);
                }
            }
        }

        public void deleteLayer()
        {
            if (layers.Count > 0)
            {
                int targ = activeLayer;
                layers.RemoveAt(targ);
                Invalidate();
                if (onLayersChanged != null)
                {
                    onLayersChanged(this, null);
                }
            }
        }

        public bool setActiveLayer(int idx)
        {
            if (idx < layers.Count)
            {
                layers[activeLayer].selected = false;
                layers[idx].selected = true;
                activeLayerImg = layers[idx].image;
                if (onLayersChanged != null)
                {
                    onLayersChanged(this, null);
                }
                return true;
            }
            else
                return false;
        }

        public void setLayerVisible(int layerIdx, bool visible)
        {
            layers[layerIdx].visible = visible;
            Invalidate();
        }
        
        public void GrabBackground()
        {
            background = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            Graphics g2 = Graphics.FromImage(background);
            Point tr = PointToScreen(new Point(0,0));
            Rectangle cr = this.Bounds;
            g2.CopyFromScreen(tr.X, tr.Y, 0, 0, new Size(this.ClientRectangle.Width, this.ClientRectangle.Height));
            Invalidate();
        }

        public void ClearBackground(bool maintainColours)
        {
            
            if((maintainColours)&&(background != null))
            {
                Bitmap nbackground = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
                Graphics g2 = Graphics.FromImage(nbackground);
                g2.FillRectangle(Brushes.Transparent, this.ClientRectangle);
                for (int x = 0; x < this.ClientRectangle.Width; x++)
                {
                    for (int y = 0; y < this.ClientRectangle.Height; y++)
                    {
                        if(layers[0].image.GetPixel(x,y).A != 0)
                        {
                            nbackground.SetPixel(x, y, background.GetPixel(x, y));
                        }
                    }
                }
                background = nbackground;
            }
            else
                background = null;
        }

        public bool startWintabInput(TextBox textBox1)
        {
            if (!WintabDN.CWintabInfo.IsWintabAvailable())
                return false;
            if (tl == null)
            {
                tl = new TabletLaunch(this, textBox1);
            }
            //textBox1.Text = "";
            Screen screen = Screen.FromControl(this); 
            tl.InitDataCapture(screen, 10000, 10000, true);
            this.Cursor = Cursors.Cross;
            tabletActive = true;

            return true;
        }

        public bool startWintabInput()
        {
            if (!WintabDN.CWintabInfo.IsWintabAvailable())
                return false;
            if (tl == null)
            {
                tl = new TabletLaunch(this);
            }
            //textBox1.Text = "";
            Screen screen = Screen.FromControl(this); 
            tl.InitDataCapture(screen, 10000, 10000, true);
            this.Cursor = Cursors.Cross;
            tabletActive = true;

            return true;
        }

        public void stopWintabInput(bool leaveActive=false)
        {
            tl.CloseCurrentContext();
            tl = null;
            if(!leaveActive)
                tabletActive = false;
        }

        public void setPen(int size, Color color, penType type)
        {
            drawing = false;
            penSize = size*magfactor;
            penImages = new List<Bitmap>();
            double mult = 1;
            while ((int)(size * mult) >= 0.2)
            {
                if(type == penType.softpen)
                    penImages.Add(getPenImage(penSize + 2, penSize * (float)mult, color, type, mult));
                else
                    penImages.Add(getPenImage(penSize, penSize, color, type, mult));
                //penImages.Add(getPenImage(penSize + 2, (int)(penSize * mult), color, type, 1.0));
                mult -= 0.02;
            }
            this.type = type;
            if (type == penType.highlighter)
            {
                for (int n = 0; n < penImages.Count; n++)
                {
                    int size2 = penImages[n].Width;
                    int fade = size / 4;
                    if (fade == 0)
                        fade = 1;
                    for (int x = 0; x < size2; x++)
                    {
                        for (int y = 0; y < size2; y++)
                        {
                            Color c = penImages[n].GetPixel(x, y);
                            penImages[n].SetPixel(x, y, Color.FromArgb(c.A / fade, c));
                        }
                    }
                }
            }

            /*//Temporary pen test
            startDrawing(10, 10, 5);
            for(int n = 6; n<= Width -6 ; n++)
            {
                DrawTo(n, 10, (512 * n / Width));
            }
            endDrawing();
            Graphics g = Graphics.FromImage(activeLayerImg);
            for(int n = 0; n< penImages.Count; n++)
            {
                g.DrawImage(penImages[n], 10 + (Width / penImages.Count) * n, 20);
                g.DrawImage(penImages[n], 10 + (Width / penImages.Count) * n, 20);
                g.DrawImage(penImages[n], 10 + (Width / penImages.Count) * n, 20);
            }
            //End temp pen test */
        }

 /*       public void startTabletCapture()
        {
            //Here temporally
            if (CWintabInfo.IsWintabAvailable())
            {
                InitDataCapture(200, 200, false);
            }
        }*/

        public Bitmap getPenImage(int imgsize, float pensize, Color color, penType type, double pressureMultiplier)
        {
            if (pressureMultiplier > 1.0)
                pressureMultiplier = 1.0;
            if (pensize > imgsize)
                pensize = imgsize;
            float offset = ((float)imgsize - pensize) / 2;
            Bitmap rawPen;
            switch (type)
            {
                case penType.softpen:
                    rawPen = new Bitmap(Properties.Resources.softpen);
                    break;
                case penType.airbrush:
                    rawPen = new Bitmap(Properties.Resources.airbrush);
                    break;
                case penType.brush:
                    rawPen = new Bitmap(Properties.Resources.brush);
                    break;
                case penType.highlighter:
                    rawPen = new Bitmap(Properties.Resources.highlighter);
                    break;
                case penType.marker:
                    rawPen = new Bitmap(Properties.Resources.marker);
                    break;
                case penType.spray:
                    rawPen = new Bitmap(Properties.Resources.spray);
                    break;
                default: // includes eraser 
                    rawPen = new Bitmap(Properties.Resources.softpen);
                    break;
            }
            /*for (int x = 0; x < rawPen.Width; x++)
            {
                for (int y = 0; y < rawPen.Height; y++)
                {
                    Color c = rawPen.GetPixel(x, y);
                    int newalpha = (int)((double)c.R * pressureMultiplier);
                    rawPen.SetPixel(x, y, Color.FromArgb(newalpha, color));
                }
            }*/

            Bitmap pen = new Bitmap(imgsize, imgsize);
            Graphics g = Graphics.FromImage(pen);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //g.DrawImage(rawPen, 0, 0, imgsize, imgsize);
            g.DrawImage(rawPen, new RectangleF(offset, offset, pensize, pensize));
            if (type == penType.softpen)
            {
                for (int x = 0; x < imgsize; x++)
                {
                    for (int y = 0; y < imgsize; y++)
                    {
                        Color c = pen.GetPixel(x, y);
                        int newalpha = (int)((double)c.R * pressureMultiplier / 3);
                        pen.SetPixel(x, y, Color.FromArgb(newalpha, color));
                    }
                }
            }
            else
            {
                for (int x = 0; x < imgsize; x++)
                {
                    for (int y = 0; y < imgsize; y++)
                    {
                        Color c = pen.GetPixel(x, y);
                        int newalpha = (int)((double)c.A * pressureMultiplier / 3);
                        pen.SetPixel(x, y, Color.FromArgb(newalpha, color));
                    }
                }
            }
            return pen;
        }

        public void cancelZoom()
        {
            isZoomed = false;
        }

        public bool Zoom(Rectangle zoomTo)
        {
            if (background == null)
            {
                GrabBackground();
            }
            else
            {
                if (BackgroundImage != null)
                {
                    zoomedBackgroundImage = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
                    Graphics g2 = Graphics.FromImage(zoomedBackgroundImage);
                    g2.DrawImage(BackgroundImage, new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
                }
                else
                {
                    zoomedBackgroundImage = null;
                }
            }
            zoomRect = zoomTo;
            isZoomed = true;
            return true;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            if((isZoomed)&&(zoomedBackgroundImage != null))
            {
                e.Graphics.DrawImage(zoomedBackgroundImage, new Rectangle(0, 0, Width, Height), zoomRect, GraphicsUnit.Pixel);
            }
            if (background != null)
            {
                if(isZoomed)
                    e.Graphics.DrawImage(background, new Rectangle(0, 0, Width, Height), zoomRect, GraphicsUnit.Pixel);
                else
                    e.Graphics.DrawImage(background, 0, 0, Width, Height);
            }
            foreach (Layer l in layers)
            {
                if (l.visible)
                {
                    if (isZoomed)
                        e.Graphics.DrawImage(l.image, new Rectangle(0, 0, Width, Height), zoomRect, GraphicsUnit.Pixel);
                    else
                        e.Graphics.DrawImage(l.image, 0, 0, Width, Height);
                }
            }
            if(pointerVis)
            {
                e.Graphics.DrawImage(PenImg, pointerPos);
            }
        }

        public void showPointer(int X, int Y)
        {
            Point pointerNewPos = new Point(X - penSize / 2, Y - penSize / 2);
            Rectangle invRect;
            if(pointerVis)
            {
                invRect = Rectangle.Union(new Rectangle(pointerPos, PenImg.Size), new Rectangle(pointerNewPos, PenImg.Size));
            }
            else
            {
                invRect = new Rectangle(pointerNewPos, PenImg.Size);
                pointerVis = true;
            }           
            pointerPos = pointerNewPos;
            Invalidate(invRect);
        }

        public void hidePointer()
        {
            if (pointerVis)
            {
                pointerVis = false;
                Invalidate(new Rectangle(pointerPos, PenImg.Size));
            }
        }

        private void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            uint extra = GetMessageExtraInfo();
            if (extra != 0)
            {
                uint id = (extra & 0x0000FFFF);
            }
            if ((tl != null) && (!tl.capturing))
            {
                startDrawing(e.X, e.Y, 220);
            }
        }

        private void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ((tl != null)&&(!tl.capturing))
            {
                if (drawing)
                {
                    DrawTo(e.X, e.Y, 220);
                }
                hidePointer(); // You probably arent wanting to use mouse and pen at the same time
            }
        }

        private void OnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ((tl != null) && (!tl.capturing))
            {
                endDrawing();
            }
        }

        public void startDrawing(float sx, float sy, int pressure)
        {
            float x = sx * magfactor;
            float y = sy * magfactor;

            if (isZoomed)
            {
                x = (x * ((float)zoomRect.Width / Width)) + zoomRect.X;
                y = (y * ((float)zoomRect.Height / Height)) + zoomRect.Y;
            }

            if (layers[activeLayer].visible)
            {
                drawing = true;
                cp = new PointF(x, y);
                //# This is the proof of concept for using a bitmap with alpha as a pen nib...
                //Bitmap pb = new Bitmap(1, 1);
                //pb.SetPixel(0, 0, Color.FromArgb(10, 255, 0, 0));

                if (pressure > MAXPRESSURE)
                    pressure = MAXPRESSURE;
                int penIdx = (int)((((float)MAXPRESSURE - pressure) * penImages.Count) / MAXPRESSURE);
                Bitmap PenImg = penImages[penIdx];
                int penSize = PenImg.Width;

                Graphics g = Graphics.FromImage(activeLayerImg);
                //g.DrawImage(pb, 5, 5, 20, 20);
                switch (type)
                {
                    case penType.eraser:
                        erase((int)x, (int)y);
                        break;
                    case penType.highlighter:
                        highlight((int)x, (int)y, pressure);
                        break;
                    default:
                        g.DrawImage(PenImg, x - (float)penSize / 2, y - (float)penSize / 2);
                        break;
                }
               // Invalidate();
            }
        }

        private void erase(int eX, int eY)
        {
            int xs = eX - penSize / 2;
            int ys = eY - penSize / 2;
            for (int x = 0; x < penSize; x++)
            {
                for (int y = 0; y < penSize; y++)
                {

                    if ((x + xs >= 0) && (x + xs < Width) && (y + ys >= 0) && (y + ys < Height))
                    {
                        Color c1 = PenImg.GetPixel(x, y);
                        Color c2 = activeLayerImg.GetPixel(x + xs, y + ys);
                        int na = c2.A - c1.A;
                        na = na < 0 ? 0 : na;
                        c2 = Color.FromArgb(na, c2);
                        activeLayerImg.SetPixel(x + xs, y + ys, c2);
                    }
                }

            }

        }

        private void highlight(int eX, int eY, int pressure)
        {
            if (pressure > 255)
                pressure = 255;
            int penIdx = (int)(((255.0 - pressure) * penImages.Count) / 256);
            Bitmap PenImg = penImages[penIdx];
            //int penSize = PenImg.Width;

            Bitmap hlb = (Bitmap)PenImg.Clone();
            Graphics g = Graphics.FromImage(hlb);
            int xs = eX - hlb.Width / 2;
            int ys = eY - hlb.Height / 2;
            g.DrawImage(activeLayerImg, xs * -1, ys * -1);
            Graphics g2 = Graphics.FromImage(activeLayerImg);
            g2.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            g2.DrawImage(hlb, xs, ys);
        }

        public void DrawTo(float sx, float sy, int pressure)
        {
            float x = sx * magfactor;
            float y = sy * magfactor;


            if (isZoomed)
            {
                x = (x * ((float)zoomRect.Width / Width)) + zoomRect.X;
                y = (y * ((float)zoomRect.Height / Height)) + zoomRect.Y;
            }

            //# This article points the way, but is way over the top compaired to what's needed.
            //#https://social.msdn.microsoft.com/Forums/vstudio/en-US/4adbfffd-bb50-4761-b4f1-c7c13b628f4d/combine-bitmap-and-a-mask-into-one-bitmap-that-uses-alpa-to-control-the-transparency?forum=vbgeneral
            //# The way to do this might be to create a png of the current nib/brush and draw it once for each pixel that should be drawn on.
            //# It can then have varied transparency, and could have a pattern as well.
            //# I'll have to think a bit about how to deal with pen pressure - maybe generate bitmaps with different alpha levels for a few increments of pressure.
            //# Plan is to generate the drawing bitmap each time the pen colour, type, size or transparency is altered.
            if (drawing)
            {
                if (pressure > MAXPRESSURE)
                    pressure = MAXPRESSURE;
                int penIdx = (int)((((float)MAXPRESSURE - pressure) * penImages.Count) / MAXPRESSURE);
                Bitmap PenImg = penImages[penIdx];
                int penSize = PenImg.Width;

                PointF ncp = new PointF(x, y);
                float xmag = ncp.X > cp.X ? ncp.X - cp.X : cp.X - ncp.X;
                float ymag = ncp.Y > cp.Y ? ncp.Y - cp.Y : cp.Y - ncp.Y;
                float maxmag = ymag > xmag ? ymag : xmag;
                float yinc = (ncp.Y - cp.Y) / maxmag;
                float xinc = (ncp.X - cp.X) / maxmag;
                Graphics g = Graphics.FromImage(activeLayerImg);
                for (float n = 0.2f; n <= maxmag; n += 0.2f )
                {
                    switch (type)
                    {
                        case penType.eraser:
                            erase((int)((xinc * n) + cp.X), (int)((yinc * n) + cp.Y));
                            break;
                        case penType.highlighter:
                            highlight((int)((xinc * n) + cp.X), (int)((yinc * n) + cp.Y), pressure);
                            break;
                        default:
                            g.DrawImage(PenImg, (xinc * n) + cp.X - (float)penSize / 2, (yinc * n) + cp.Y - (float)penSize / 2);
                            break;
                    }
                }
                Rectangle oldArea = new Rectangle(new Point((int)cp.X, (int)cp.Y), PenImg.Size);
                Rectangle newArea = new Rectangle(new Point((int)ncp.X, (int)ncp.Y), PenImg.Size);
                Rectangle inv = Rectangle.Union(oldArea, newArea);
                inv.Inflate(2,2);
                cp = ncp;
                if(isZoomed)
                {
                    inv.X = (int)(inv.X * ((float)zoomRect.Width / Width)) + zoomRect.X;
                    inv.Y = (int)(inv.Y * ((float)zoomRect.Width / Width)) + zoomRect.Y;
                    inv.Width = (int)(inv.Width * ((float)zoomRect.Width / Width));
                    inv.Height = (int)(inv.Height * ((float)zoomRect.Width / Width));
                }
                Invalidate(inv);
                //Update();
            }
        }

        public void endDrawing()
        {
            drawing = false;
            Invalidate();
        }

        private void OverlayPaint_Resize(object sender, EventArgs e)
        {
            if ((this.Width > 0) && (this.Height > 0))
            {
                for (int n = 0; n < layers.Count; n++)
                {
                    Bitmap b = new Bitmap(layers[n].image, new Size(this.Width * magfactor, this.Height * magfactor));
                    layers[n].image = b;
                }
                activeLayerImg = layers[activeLayer].image;
                if (tl != null)
                    tl.zpNeedsInit = true;
            }
        }

        private void OverlayPaintArea_Leave(object sender, EventArgs e)
        {
            if (tabletActive)
            {
         //       stopWintabInput(true);
            }
        }

        private void OverlayPaintArea_Enter(object sender, EventArgs e)
        {
            if (tabletActive)
            {
         //       startWintabInput(null);
            }
        }

        private void OverlayPaintArea_VisibleChanged(object sender, EventArgs e)
        {
            if(ctrls != null)
            {
                if(Visible)
                {
                    ctrls.Enabled = ctrlsEnabled;
                    //if(tabletActive)
                    //    startWintabInput();
                }
                else
                {
                    ctrlsEnabled = ctrls.Enabled;
                    ctrls.Enabled = false;
                    //if(tabletActive)
                    //    stopWintabInput(true);                    
                }
            }
        }

        private void OverlayPaintArea_Move(object sender, EventArgs e)
        {
            //stopWintabInput();
           // startWintabInput();        
        }

/*        private void timer1_Tick(object sender, EventArgs e)
        {
            if(needsRefresh)
            {
                Invalidate();
                needsRefresh = false;
            }
        }
        */
         
/*        public bool startTabletCapture()
        {
            if (CWintabInfo.IsWintabAvailable())
            {
                if (!tabletActive)
                {
                    InitDataCapture(10000, 10000, false);
                    tabletActive = true;
                }
                else
                {
                    CloseCurrentContext();
                    tabletActive = false;
                }
            }
            return tabletActive;
        }*/

    }
}
