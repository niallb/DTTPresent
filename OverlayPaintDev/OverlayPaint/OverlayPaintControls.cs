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
    public partial class OverlayPaintControls : UserControl
    {
        class penInfo
        {
            internal penInfo(int s, Color c, OverlayPaintArea.penType t)
            {
                size = s;
                color = c;
                type = t;
            }

            internal int size;
            internal Color color;
            internal OverlayPaintArea.penType type;
            //internal int alpha; // not used yet.
        }


        private OverlayPaintArea surface;
        private bool switchingPen;

        public EventHandler OnPenUpdated;

        public OverlayPaintControls()
        {
            InitializeComponent();
            pen2Btn.addToGroup(pen1Btn);
            pen3Btn.addToGroup(pen1Btn);
            pen4Btn.addToGroup(pen1Btn);
            pen5Btn.addToGroup(pen1Btn);
            pen6Btn.addToGroup(pen1Btn);
            pen7Btn.addToGroup(pen1Btn);
            eraserBtn.addToGroup(pen1Btn);
            pen1Btn.data = new penInfo(3, Color.Black, OverlayPaintArea.penType.softpen);
            pen2Btn.data = new penInfo(3, Color.Red, OverlayPaintArea.penType.softpen);
            pen3Btn.data = new penInfo(3, Color.Green, OverlayPaintArea.penType.softpen);
            pen4Btn.data = new penInfo(3, Color.Blue, OverlayPaintArea.penType.softpen);
            pen5Btn.data = new penInfo(14, Color.Yellow, OverlayPaintArea.penType.highlighter);
            pen6Btn.data = new penInfo(14, Color.PaleGreen, OverlayPaintArea.penType.highlighter);
            pen7Btn.data = new penInfo(8, Color.BlueViolet, OverlayPaintArea.penType.marker);
            eraserBtn.Image = Properties.Resources.eraser;
            eraserBtn.data = new penInfo(14, Color.Black, OverlayPaintArea.penType.eraser);
            pen1Btn.SelectionChanged += pen1Btn_SelectionChanged;
            pen1Btn.selected = true;
            pen1Btn_SelectionChanged(pen1Btn, null);
            switchingPen = false;
        }

        private bool settingPenInfo = false; // to block onPenUpdated wnen it's jut a set change

        public void SetPenBtnInfo(int index, int size, Color colour, OverlayPaintArea.penType type)
        {
            penInfo tmpInfo = new penInfo(size, colour, type);
            Bitmap tmpImg = penImageFromInfo(tmpInfo);
            bool isSel = false;
            switch(index)
            {
                case 1:
                    pen1Btn.data = tmpInfo;
                    pen1Btn.Image = tmpImg;
                    if(pen1Btn.getSelected() == pen1Btn)
                        isSel = true;
                    break;
                case 2:
                    pen2Btn.data = tmpInfo;
                    pen2Btn.Image = tmpImg;
                    if(pen1Btn.getSelected() == pen2Btn)
                        isSel = true;
                    break;
                case 3:
                    pen3Btn.data = tmpInfo;
                    pen3Btn.Image = tmpImg;
                    if(pen1Btn.getSelected() == pen3Btn)
                        isSel = true;
                    break;
                case 4:
                    pen4Btn.data = tmpInfo;
                    pen4Btn.Image = tmpImg;
                    if(pen1Btn.getSelected() == pen4Btn)
                        isSel = true;
                    break;
                case 5:
                    pen5Btn.data = tmpInfo;
                    pen5Btn.Image = tmpImg;
                    if(pen1Btn.getSelected() == pen5Btn)
                        isSel = true;
                    break;
                case 6:
                    pen6Btn.data = tmpInfo;
                    pen6Btn.Image = tmpImg;
                    if(pen1Btn.getSelected() == pen6Btn)
                        isSel = true;
                    break;
                case 7:
                    pen7Btn.data = tmpInfo;
                    pen7Btn.Image = tmpImg;
                    if(pen1Btn.getSelected() == pen7Btn)
                        isSel = true;
                    break;
            }
            if((surface != null)&&(isSel))
            {                
                this.surface.setPen(size, colour, type);
                settingPenInfo = true;
                colourBtn.BackColor = colour;
                typeSelect.SelectedIndex = (int)type - 1;
                sizeSelect.Value = size;
                settingPenInfo = false;
            }
        }

        public bool getPenBtnInfo(int index, out int size, out Color colour, out OverlayPaintArea.penType type)
        {
            // some basic default values.
            size = 2;
            colour = Color.Black;
            type = OverlayPaintArea.penType.softpen;
            penInfo tmpInfo;
            switch(index)
            {
                case 1:
                    tmpInfo = (penInfo)pen1Btn.data;
                    break;
                case 2:
                    tmpInfo = (penInfo)pen2Btn.data;
                    break;
                case 3:
                    tmpInfo = (penInfo)pen3Btn.data;
                    break;
                case 4:
                    tmpInfo = (penInfo)pen4Btn.data;
                    break;
                case 5:
                    tmpInfo = (penInfo)pen5Btn.data;
                    break;
                case 6:
                    tmpInfo = (penInfo)pen6Btn.data;
                    break;
                case 7:
                    tmpInfo = (penInfo)pen7Btn.data;
                    break;
                default:
                    return false;
            }
            if(tmpInfo == null)
                return false;
            size = tmpInfo.size;
            colour = tmpInfo.color;
            type = tmpInfo.type;
            return true;
        }

        public void Attach(OverlayPaintArea surface)
        {
            if (this.surface != null)
                this.surface.ctrls = null;
            this.surface = surface;
            this.surface.ctrls = this;
            pen1Btn.Image = penImageFromInfo((penInfo)pen1Btn.data);
            pen2Btn.Image = penImageFromInfo((penInfo)pen2Btn.data);
            pen3Btn.Image = penImageFromInfo((penInfo)pen3Btn.data);
            pen4Btn.Image = penImageFromInfo((penInfo)pen4Btn.data);
            pen5Btn.Image = penImageFromInfo((penInfo)pen5Btn.data);
            pen6Btn.Image = penImageFromInfo((penInfo)pen6Btn.data);
            pen7Btn.Image = penImageFromInfo((penInfo)pen7Btn.data);
            penInfo p = (penInfo)pen1Btn.data;
            this.surface.setPen(p.size, p.color, p.type);
            onLayersChanged(null, null);
            surface.onLayersChanged = new EventHandler(onLayersChanged);
            //updateCurrentPenImage();
        }

        void onLayersChanged(object sender, EventArgs e)
        {
            layersPanel.Controls.Clear();
            int n = 0;
            if (this.surface.Layers != null)
            {
                foreach (OverlayPaintArea.Layer l in this.surface.Layers)
                {
                    LayerCtrl b = new LayerCtrl(this);
                    b.layerIdx = n;
                    n++;
                    b.Dock = DockStyle.Top;
                    b.Text = l.name;
                    b.isVisible = l.visible;
                    if (l.selected)
                        b.BackColor = Color.Aquamarine;
                    layersPanel.Controls.Add(b);
                }
            }
        }

        public void setLayerVisible(int layerIdx, bool visible)
        {
            if(surface != null)
            {
                surface.setLayerVisible(layerIdx, visible);
            }
        }

        public void setActiveLayer(int layerIdx)
        {
            if (surface != null)
            {
                surface.setActiveLayer(layerIdx);
            }
        }

        private Bitmap penImageFromInfo(penInfo p)
        {
            if (surface != null)
            {
                return getPenImage(surface.getPenImage(p.size, p.size, p.color, p.type, 1.0));
            }
            else
            {
                return new Bitmap(16, 16);
            }
        }

        public void updateCurrentPenImage()
        {
            bitmapSwitchButton cb = pen1Btn.getSelected();
            if ((cb != null) && (cb != eraserBtn) && (cb != pen7Btn))
            {
                cb.Image = getPenImage(surface.PenImg);
            }
        }

        public Bitmap getPenImage(Bitmap pen)
        {
            Bitmap penImg = new Bitmap(16, 16);
            if (surface != null)
            {
                Graphics g = Graphics.FromImage(penImg);
                float xp = (16 - surface.penSize) / 2;
                float yp = (16 - surface.penSize) / 2;
                g.FillRectangle(Brushes.White, 0, 0, 15, 15);
                g.DrawImage(pen, xp - 2, yp + 2);
                g.DrawImage(pen, xp - 1, yp + 1);
                g.DrawImage(pen, xp, yp);
                g.DrawImage(pen, xp + 1, yp - 1);
                g.DrawImage(pen, xp + 2, yp - 2);
                g.DrawImage(pen, xp - 2, yp + 2);
                g.DrawImage(pen, xp - 1, yp + 1);
                g.DrawImage(pen, xp, yp);
                g.DrawImage(pen, xp + 1, yp - 1);
                g.DrawImage(pen, xp + 2, yp - 2);
            }
            return penImg;
        }

        private void colourBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (this.surface != null)
                {
                    colourBtn.BackColor = colorDialog1.Color;
                    bitmapSwitchButton cb = pen1Btn.getSelected();
                    cb.data = new penInfo((int)sizeSelect.Value, colorDialog1.Color, (OverlayPaintArea.penType)(typeSelect.SelectedIndex + 1));
                    this.surface.setPen((int)sizeSelect.Value, colorDialog1.Color, (OverlayPaintArea.penType)(typeSelect.SelectedIndex + 1));
                    updateCurrentPenImage();
                    if ((OnPenUpdated != null) && (!settingPenInfo))
                    {
                        OnPenUpdated(sender, e);
                    }
                }
            }
        }

        public void selectPenByIdx(int idx)
        {
            switch(idx)
            {
                case 0:
                    pen1Btn_SelectionChanged(pen1Btn, null);
                    break;
                case 1:
                    pen1Btn_SelectionChanged(pen2Btn, null);                    
                    break;
                case 2:
                    pen1Btn_SelectionChanged(pen3Btn, null);
                    break;
                case 3:
                    pen1Btn_SelectionChanged(pen4Btn, null);
                    break;
                case 4:
                    pen1Btn_SelectionChanged(pen5Btn, null);
                    break;
                case 5:
                    pen1Btn_SelectionChanged(pen6Btn, null);
                    break;
                case 6:
                    pen1Btn_SelectionChanged(pen7Btn, null);
                    break;
                case 7:
                    pen1Btn_SelectionChanged(eraserBtn, null);
                    break;
            }
        }

        private void pen1Btn_SelectionChanged(object sender, EventArgs<int, bool> e)
        {
            if (((bitmapSwitchButton)sender).data != null)
            {
                switchingPen = true;
                ((bitmapSwitchButton)sender).selected = true;
                penInfo p = (penInfo)((bitmapSwitchButton)sender).data;
                colourBtn.BackColor = p.color;
                typeSelect.SelectedIndex = (int)p.type-1;
                sizeSelect.Value = p.size;
                if (this.surface != null)
                {
                    this.surface.setPen(p.size, p.color, p.type);
                    updateCurrentPenImage();
                }
                switchingPen = false;
            }
        }

        private void typeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!switchingPen) && (sender == typeSelect) && (this.surface != null))
            {
                bitmapSwitchButton cb = pen1Btn.getSelected();
                cb.data = new penInfo((int)sizeSelect.Value, colourBtn.BackColor, (OverlayPaintArea.penType)(typeSelect.SelectedIndex + 1));
                this.surface.setPen((int)sizeSelect.Value, colourBtn.BackColor, (OverlayPaintArea.penType)(typeSelect.SelectedIndex + 1));
                updateCurrentPenImage();
                if ((OnPenUpdated != null) && (!settingPenInfo))
                {
                    OnPenUpdated(sender, e);
                }
            }
        }

        private void sizeSelect_ValueChanged(object sender, EventArgs e)
        {
            if ((!switchingPen) && (this.surface != null))
            {
                bitmapSwitchButton cb = pen1Btn.getSelected();
                cb.data = new penInfo((int)sizeSelect.Value, colourBtn.BackColor, (OverlayPaintArea.penType)(typeSelect.SelectedIndex + 1));
                this.surface.setPen((int)sizeSelect.Value, colourBtn.BackColor, (OverlayPaintArea.penType)(typeSelect.SelectedIndex + 1));
                updateCurrentPenImage();
                if ((OnPenUpdated != null) && (!settingPenInfo))
                {
                    OnPenUpdated(sender, e);
                }
            }
        }

        private void AddLayerBtn_Click(object sender, EventArgs e)
        {
            OverlayPaintArea.Layer l;
            if (surface != null)
            {
                l = surface.AddLayer();                
            }
        }

        private void clearLayerB_Click(object sender, EventArgs e)
        {
            if (surface != null)
            {
                surface.ClearLayer();
            }
        }

        private void delLayerB_Click(object sender, EventArgs e)
        {
            if (surface != null)
            {
                surface.deleteLayer();
            }
        }
    }
}
