using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OverlayPaint;

namespace OverlayPaintDev
{
    public partial class Form1 : Form
    {
        OverlayPaintArea overlayPaint1;


        public Form1()
        {
            InitializeComponent();
            overlayPaint1 = new OverlayPaintArea();
            overlayPaint1.Dock = DockStyle.Fill;
            this.Controls.Add(overlayPaint1);

            overlayPaintControls1.Attach(overlayPaint1);
            //TransparencyKey = Color.FromArgb(127, 127, 127);
            //overlayPaint1.textBox1 = textBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BackColor == TransparencyKey)
            {
                BackColor = Color.Wheat;
                overlayPaint1.ClearBackground(true);
            }
            else
                BackColor = TransparencyKey;
        }  

        private void button2_Click(object sender, EventArgs e)
        {
            if (!overlayPaint1.tabletActive)
            {
                if(overlayPaint1.startWintabInput(textBox1))
                    button2.Text = "Stop";
            }
            else
            {
                overlayPaint1.stopWintabInput();
                button2.Text = "Tablet";
            }
            //overlayPaint1.GrabBackground();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            //overlayPaint1.Dispose();
        }

        private void InitTestBtn_Click(object sender, EventArgs e)
        {
            overlayPaintControls1.selectPenByIdx(1);
        }

        private void InitTestBtn_MouseClick(object sender, MouseEventArgs e)
        {
          //  overlayPaint1.Reinitialise();
        }

        List<OverlayPaintArea.Layer> swapLayers;
        private void SwapBtn_Click(object sender, EventArgs e)
        {
            List<OverlayPaintArea.Layer> tmp = overlayPaint1.Layers;
            if (swapLayers != null)
            {
                overlayPaint1.Layers = swapLayers;
            }
            else
                overlayPaint1.Reinitialise();
            swapLayers = tmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (overlayPaintControls1.Enabled)
                overlayPaintControls1.Enabled = false;
            else
                overlayPaintControls1.Enabled = true;
        }
    }
}
