                                                                                                        using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OverlayPaint
{
    public partial class bitmapSwitchButton : UserControl
    {
        public event EventHandler<EventArgs<int, bool>> SelectionChanged; 
        //public bool enabled { get; set; }
        public Object data { get; set; }
        private bool _selected;
        private bool mouseOver;
        private Bitmap image;
        public Bitmap nselImg;
        public Bitmap Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                Invalidate();
            }
        }

        public bool selected
        {
            get
            {
                return _selected;
            }
            set
            {
                if(value)
                {
                    foreach(bitmapSwitchButton b in group)
                    {
                        if (b != this)
                        {
                            b.selected = false;
                        }
                    }
                }
                _selected = value;
                Invalidate();
            }
        }

        public int index
        {
            get
            {
                return group.IndexOf(this);
            }
        }

        internal List<bitmapSwitchButton> group;

        public bitmapSwitchButton() : this (null) {}

        public bitmapSwitchButton(bitmapSwitchButton primary)
        {
            InitializeComponent();
            if (primary == null)
                group = new List<bitmapSwitchButton>();
            else
                group = primary.group;
            group.Add(this);
            Enabled = true;
            selected = false;
        }

        public void addToGroup(bitmapSwitchButton primary)
        {
            group.Remove(this);
            group = primary.group;
            foreach(bitmapSwitchButton bt in group)
            {
                if((bt!=this)&&(bt.selected))
                {
                    this.selected = false;
                }
            }
            group.Add(this);
        }

        public bitmapSwitchButton getSelected()
        {
            foreach(bitmapSwitchButton b in group)
            {
                if (b.selected)
                    return b;
            }
            return null;
        }

        private void bitmapSwitchButton_Paint(object sender, PaintEventArgs e)
        {
            if(Enabled)
            {
                if (selected)
                {
                    e.Graphics.FillRectangle(SystemBrushes.Highlight, 0, 0, 23, 23);
                    e.Graphics.DrawLine(Pens.Black, 1, 1, 1, 22);
                    e.Graphics.DrawLine(Pens.Black, 1, 1, 22, 1);
                    e.Graphics.DrawLine(Pens.White, 1, 22, 22, 22);
                    e.Graphics.DrawLine(Pens.White, 22, 1, 22, 22);
                }
                else
                { 
                    e.Graphics.FillRectangle(SystemBrushes.ButtonFace, 0, 0, 23, 23);
                    e.Graphics.DrawLine(Pens.White, 1, 1, 1, 22);
                    e.Graphics.DrawLine(Pens.White, 1, 1, 22, 1);
                    e.Graphics.DrawLine(Pens.DarkGray, 1, 22, 22, 22);
                    e.Graphics.DrawLine(Pens.DarkGray, 22, 1, 22, 22);
                }
                if(mouseOver)
                    e.Graphics.DrawRectangle(Pens.Black, 0, 0, 23, 23);
                else if(selected)
                    e.Graphics.DrawRectangle(Pens.White, 0, 0, 23, 23);
                if((!selected)&&(nselImg != null))
                    e.Graphics.DrawImage(nselImg, 4, 4);
                else if (image != null)
                    e.Graphics.DrawImage(image, 4, 4);
            }
            else
            {
                if (selected)
                {
                    e.Graphics.DrawLine(Pens.DarkGray, 1, 1, 1, 22);
                    e.Graphics.DrawLine(Pens.DarkGray, 1, 1, 22, 1);
                    e.Graphics.DrawLine(Pens.White, 1, 22, 22, 22);
                    e.Graphics.DrawLine(Pens.White, 22, 1, 22, 22);
                }
                else
                {
                    e.Graphics.DrawLine(Pens.DarkGray, 1, 22, 22, 22);
                    e.Graphics.DrawLine(Pens.DarkGray, 22, 1, 22, 22);
                }
                if ((!selected) && (nselImg != null))
                    ControlPaint.DrawImageDisabled(e.Graphics, nselImg, 4, 4, Color.LightGray);
                else if (image != null)
                    ControlPaint.DrawImageDisabled(e.Graphics, image, 4, 4, Color.LightGray);
            }

       }

        private void bitmapSwitchButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (!selected)
                selected = true;
            else if (group.Count == 1)
                selected = false;
            if (SelectionChanged != null)
            {
                SelectionChanged(this, new EventArgs<int, bool>(group.IndexOf(this), selected));
            }
            if ((group.IndexOf(this)!=0)&&(group[0].SelectionChanged != null))
                group[0].SelectionChanged(this, new EventArgs<int, bool>(group.IndexOf(this), selected));
            
            Invalidate();
        }

        private void bitmapSwitchButton_MouseEnter(object sender, EventArgs e)
        {
            mouseOver = true;
            Invalidate();
        }

        private void bitmapSwitchButton_MouseLeave(object sender, EventArgs e)
        {
            mouseOver = false;
            Invalidate();
        }
    }
}
