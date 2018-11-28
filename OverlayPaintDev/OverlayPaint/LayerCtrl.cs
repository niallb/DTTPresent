using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverlayPaint
{
    public partial class LayerCtrl : UserControl
    {
        private OverlayPaintControls owner;

        public LayerCtrl(OverlayPaintControls owner)
        {
            InitializeComponent();
            visibleBtn.Image = Properties.Resources.visible;
            visibleBtn.nselImg = Properties.Resources.hidden;
            this.owner = owner;
        }

        public override string Text
        {
            get { return layerNameLbl.Text; }
            set { layerNameLbl.Text = value; }
        }

        public int layerIdx;

        public bool isVisible
        {
            get { return visibleBtn.selected; }
            set
            {
                if(value == true)
                {
                    visibleBtn.selected = true;
                }
                else
                {
                    visibleBtn.selected = false;
                }
            }
        }

        private void LayerCtrl_MouseClick(object sender, MouseEventArgs e)
        {
            owner.setActiveLayer(layerIdx);
        }

        private void visibleBtn_MouseClick(object sender, MouseEventArgs e)
        {
            owner.setLayerVisible(layerIdx, visibleBtn.selected);
        }

        private void layerNameLbl_Click(object sender, EventArgs e)
        {
            LayerCtrl_MouseClick(sender, null);
        }

        private void LayerCtrl_EnabledChanged(object sender, EventArgs e)
        {
            if(!Enabled)
            {
                if (BackColor == Color.Aquamarine)
                    BackColor = Color.Gray;
                if (visibleBtn.selected)
                    visibleBtn.BackColor = Color.LightGray;
            }
            else
            {
                if (BackColor == Color.Gray)
                    BackColor = Color.Aquamarine;
                if (visibleBtn.selected)
                    visibleBtn.BackColor = Color.LightGray;
            }
        }
    }
}
