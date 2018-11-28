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
    public partial class browserSlideProperties : Form
    {
        public browserSlideProperties()
        {
            InitializeComponent();
        }

        public string Title
        {
            set { title.Text = value; }
            get { return title.Text; }
        }

        public string Url
        {
            set { url.Text = value; }
            get { return url.Text; }
        }

        public void addPenSetOption(string name)
        {
            penSetSelect.Items.Add(name);
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


    }
}
