namespace OverlayPaint
{
    partial class LayerCtrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layerNameLbl = new System.Windows.Forms.Label();
            this.visibleBtn = new OverlayPaint.bitmapSwitchButton();
            this.SuspendLayout();
            // 
            // layerNameLbl
            // 
            this.layerNameLbl.AutoSize = true;
            this.layerNameLbl.Location = new System.Drawing.Point(27, 4);
            this.layerNameLbl.Name = "layerNameLbl";
            this.layerNameLbl.Size = new System.Drawing.Size(33, 13);
            this.layerNameLbl.TabIndex = 2;
            this.layerNameLbl.Text = "name";
            this.layerNameLbl.Click += new System.EventHandler(this.layerNameLbl_Click);
            // 
            // visibleBtn
            // 
            this.visibleBtn.data = null;
            //this.visibleBtn.enabled = true;
            this.visibleBtn.Image = null;
            this.visibleBtn.Location = new System.Drawing.Point(0, 0);
            this.visibleBtn.MaximumSize = new System.Drawing.Size(24, 24);
            this.visibleBtn.MinimumSize = new System.Drawing.Size(24, 24);
            this.visibleBtn.Name = "visibleBtn";
            this.visibleBtn.selected = false;
            this.visibleBtn.Size = new System.Drawing.Size(24, 24);
            this.visibleBtn.TabIndex = 0;
            this.visibleBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.visibleBtn_MouseClick);
            // 
            // LayerCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layerNameLbl);
            this.Controls.Add(this.visibleBtn);
            this.Name = "LayerCtrl";
            this.Size = new System.Drawing.Size(110, 26);
            this.EnabledChanged += new System.EventHandler(this.LayerCtrl_EnabledChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LayerCtrl_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private bitmapSwitchButton visibleBtn;
        private System.Windows.Forms.Label layerNameLbl;

    }
}
