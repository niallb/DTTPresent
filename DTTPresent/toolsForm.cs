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
    public partial class ToolForm : Form
    {
        mainForm parent;

        public ToolForm(mainForm parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void ToolForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.HasChildren)
            {
                parent.switchControlPanelLocation();
            }
        }

        private void ToolForm_KeyDown(object sender, KeyEventArgs e)
        {
            parent.processKey(e);
        }
    }
}
