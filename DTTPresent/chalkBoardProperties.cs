using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DTTPresent
{
    public partial class chalkBoardProperties : Form
    {
        public chalkBoardProperties()
        {
            InitializeComponent();
        }

        public string Title
        {
            set { title.Text = value; }
            get { return title.Text; }
        }

        public string Background
        {
            set { imgSel.Text = value; }
            get { return imgSel.Text; }
        }

        public Color boardColour
        {
            set { setButtonColour(BgColourBtn, value); }
            get { return BgColourBtn.BackColor; }
        }

        public Color lineColour
        {
            set { setButtonColour(LineColourBtn, value); }
            get { return LineColourBtn.BackColor; }
        }

        private void ColourBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = ((Button)sender).BackColor;
            DialogResult r = cd.ShowDialog();
            if (r == DialogResult.OK)
            {
                setButtonColour((Button)sender, cd.Color);
            }
        }

        public string underlayChoice
        {
            get { return underlaySelect.Text; }
            set { underlaySelect.SelectedIndex = underlaySelect.FindString(value); }
        }

        public string penSetChoice
        {
            get { return penSetSelect.Text; }
            set { penSetSelect.SelectedIndex = penSetSelect.FindString(value); }
        }

        public int penSetIndex
        {
            get { return penSetSelect.SelectedIndex; }
            set { penSetSelect.SelectedIndex = value; }
        }

        public void addUnderlayOption(string name)
        {
            underlaySelect.Items.Add(name);
        }

        public void addPenSetOption(string name)
        {
            penSetSelect.Items.Add(name);
        }

        private void setButtonColour(Button b, Color c)
        {
            b.BackColor = c;
            if (c.R + c.G + c.B < 384)
                b.ForeColor = Color.White;
            else
                b.ForeColor = Color.Black;
        }

        private void findImgBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Image files|*.png; *.jpeg; *.gif; *.jpg; *.bmp|All files (*.*)|*.*";
            //openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imgSel.Text = openFileDialog1.FileName;
            }

        }


    }
}
