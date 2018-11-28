namespace OverlayPaint
{
    partial class OverlayPaintControls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverlayPaintControls));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colourBtn = new System.Windows.Forms.Button();
            this.sizeSelect = new System.Windows.Forms.NumericUpDown();
            this.typeSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.layersPanel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddLayerB = new System.Windows.Forms.ToolStripButton();
            this.moveLayerUpB = new System.Windows.Forms.ToolStripButton();
            this.moveLayerDnB = new System.Windows.Forms.ToolStripButton();
            this.clearLayerB = new System.Windows.Forms.ToolStripButton();
            this.delLayerB = new System.Windows.Forms.ToolStripButton();
            this.eraserBtn = new OverlayPaint.bitmapSwitchButton();
            this.pen7Btn = new OverlayPaint.bitmapSwitchButton();
            this.pen6Btn = new OverlayPaint.bitmapSwitchButton();
            this.pen5Btn = new OverlayPaint.bitmapSwitchButton();
            this.pen1Btn = new OverlayPaint.bitmapSwitchButton();
            this.pen4Btn = new OverlayPaint.bitmapSwitchButton();
            this.pen3Btn = new OverlayPaint.bitmapSwitchButton();
            this.pen2Btn = new OverlayPaint.bitmapSwitchButton();
            ((System.ComponentModel.ISupportInitialize)(this.sizeSelect)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colourBtn
            // 
            this.colourBtn.BackColor = System.Drawing.Color.Maroon;
            this.colourBtn.Location = new System.Drawing.Point(45, 116);
            this.colourBtn.Name = "colourBtn";
            this.colourBtn.Size = new System.Drawing.Size(40, 23);
            this.colourBtn.TabIndex = 0;
            this.colourBtn.UseVisualStyleBackColor = false;
            this.colourBtn.Click += new System.EventHandler(this.colourBtn_Click);
            // 
            // sizeSelect
            // 
            this.sizeSelect.Location = new System.Drawing.Point(45, 67);
            this.sizeSelect.Name = "sizeSelect";
            this.sizeSelect.Size = new System.Drawing.Size(40, 20);
            this.sizeSelect.TabIndex = 11;
            this.sizeSelect.ValueChanged += new System.EventHandler(this.sizeSelect_ValueChanged);
            // 
            // typeSelect
            // 
            this.typeSelect.FormattingEnabled = true;
            this.typeSelect.Items.AddRange(new object[] {
            "Pen",
            "Marker",
            "Highlight",
            "Airbrush",
            "Brush",
            "Spray",
            "Eraser"});
            this.typeSelect.Location = new System.Drawing.Point(45, 91);
            this.typeSelect.Name = "typeSelect";
            this.typeSelect.Size = new System.Drawing.Size(67, 21);
            this.typeSelect.TabIndex = 12;
            this.typeSelect.SelectedIndexChanged += new System.EventHandler(this.typeSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Colour";
            // 
            // layersPanel
            // 
            this.layersPanel.AutoScroll = true;
            this.layersPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.layersPanel.Location = new System.Drawing.Point(3, 169);
            this.layersPanel.Name = "layersPanel";
            this.layersPanel.Size = new System.Drawing.Size(112, 111);
            this.layersPanel.TabIndex = 16;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddLayerB,
            this.moveLayerUpB,
            this.moveLayerDnB,
            this.clearLayerB,
            this.delLayerB});
            this.toolStrip1.Location = new System.Drawing.Point(3, 141);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(149, 25);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddLayerB
            // 
            this.AddLayerB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddLayerB.Image = ((System.Drawing.Image)(resources.GetObject("AddLayerB.Image")));
            this.AddLayerB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddLayerB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddLayerB.Name = "AddLayerB";
            this.AddLayerB.Size = new System.Drawing.Size(23, 22);
            this.AddLayerB.Text = "Add a layer";
            this.AddLayerB.Click += new System.EventHandler(this.AddLayerBtn_Click);
            // 
            // moveLayerUpB
            // 
            this.moveLayerUpB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveLayerUpB.Image = ((System.Drawing.Image)(resources.GetObject("moveLayerUpB.Image")));
            this.moveLayerUpB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.moveLayerUpB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveLayerUpB.Name = "moveLayerUpB";
            this.moveLayerUpB.Size = new System.Drawing.Size(23, 22);
            this.moveLayerUpB.Text = "Move layer up";
            // 
            // moveLayerDnB
            // 
            this.moveLayerDnB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveLayerDnB.Image = ((System.Drawing.Image)(resources.GetObject("moveLayerDnB.Image")));
            this.moveLayerDnB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.moveLayerDnB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveLayerDnB.Name = "moveLayerDnB";
            this.moveLayerDnB.Size = new System.Drawing.Size(23, 22);
            this.moveLayerDnB.Text = "Move layer down";
            // 
            // clearLayerB
            // 
            this.clearLayerB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearLayerB.Image = ((System.Drawing.Image)(resources.GetObject("clearLayerB.Image")));
            this.clearLayerB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clearLayerB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearLayerB.Name = "clearLayerB";
            this.clearLayerB.Size = new System.Drawing.Size(23, 22);
            this.clearLayerB.Text = "Clear layer";
            this.clearLayerB.Click += new System.EventHandler(this.clearLayerB_Click);
            // 
            // delLayerB
            // 
            this.delLayerB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.delLayerB.Image = ((System.Drawing.Image)(resources.GetObject("delLayerB.Image")));
            this.delLayerB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.delLayerB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delLayerB.Name = "delLayerB";
            this.delLayerB.Size = new System.Drawing.Size(23, 22);
            this.delLayerB.Text = "Delete layer";
            this.delLayerB.Click += new System.EventHandler(this.delLayerB_Click);
            // 
            // eraserBtn
            // 
            this.eraserBtn.data = null;
            //this.eraserBtn.enabled = true;
            this.eraserBtn.Image = null;
            this.eraserBtn.Location = new System.Drawing.Point(88, 34);
            this.eraserBtn.MaximumSize = new System.Drawing.Size(24, 24);
            this.eraserBtn.MinimumSize = new System.Drawing.Size(24, 24);
            this.eraserBtn.Name = "eraserBtn";
            this.eraserBtn.selected = false;
            this.eraserBtn.Size = new System.Drawing.Size(24, 24);
            this.eraserBtn.TabIndex = 10;
            // 
            // pen7Btn
            // 
            this.pen7Btn.data = null;
            //this.pen7Btn.enabled = true;
            this.pen7Btn.Image = null;
            this.pen7Btn.Location = new System.Drawing.Point(61, 34);
            this.pen7Btn.MaximumSize = new System.Drawing.Size(24, 24);
            this.pen7Btn.MinimumSize = new System.Drawing.Size(24, 24);
            this.pen7Btn.Name = "pen7Btn";
            this.pen7Btn.selected = false;
            this.pen7Btn.Size = new System.Drawing.Size(24, 24);
            this.pen7Btn.TabIndex = 9;
            // 
            // pen6Btn
            // 
            this.pen6Btn.data = null;
           // this.pen6Btn.enabled = true;
            this.pen6Btn.Image = null;
            this.pen6Btn.Location = new System.Drawing.Point(34, 34);
            this.pen6Btn.MaximumSize = new System.Drawing.Size(24, 24);
            this.pen6Btn.MinimumSize = new System.Drawing.Size(24, 24);
            this.pen6Btn.Name = "pen6Btn";
            this.pen6Btn.selected = false;
            this.pen6Btn.Size = new System.Drawing.Size(24, 24);
            this.pen6Btn.TabIndex = 8;
            // 
            // pen5Btn
            // 
            this.pen5Btn.data = null;
            //this.pen5Btn.enabled = true;
            this.pen5Btn.Image = null;
            this.pen5Btn.Location = new System.Drawing.Point(7, 34);
            this.pen5Btn.MaximumSize = new System.Drawing.Size(24, 24);
            this.pen5Btn.MinimumSize = new System.Drawing.Size(24, 24);
            this.pen5Btn.Name = "pen5Btn";
            this.pen5Btn.selected = false;
            this.pen5Btn.Size = new System.Drawing.Size(24, 24);
            this.pen5Btn.TabIndex = 7;
            // 
            // pen1Btn
            // 
            this.pen1Btn.data = null;
            //this.pen1Btn.enabled = true;
            this.pen1Btn.Image = null;
            this.pen1Btn.Location = new System.Drawing.Point(7, 3);
            this.pen1Btn.MaximumSize = new System.Drawing.Size(24, 24);
            this.pen1Btn.MinimumSize = new System.Drawing.Size(24, 24);
            this.pen1Btn.Name = "pen1Btn";
            this.pen1Btn.selected = false;
            this.pen1Btn.Size = new System.Drawing.Size(24, 24);
            this.pen1Btn.TabIndex = 6;
            // 
            // pen4Btn
            // 
            this.pen4Btn.data = null;
            //this.pen4Btn.enabled = true;
            this.pen4Btn.Image = null;
            this.pen4Btn.Location = new System.Drawing.Point(88, 3);
            this.pen4Btn.MaximumSize = new System.Drawing.Size(24, 24);
            this.pen4Btn.MinimumSize = new System.Drawing.Size(24, 24);
            this.pen4Btn.Name = "pen4Btn";
            this.pen4Btn.selected = false;
            this.pen4Btn.Size = new System.Drawing.Size(24, 24);
            this.pen4Btn.TabIndex = 5;
            // 
            // pen3Btn
            // 
            this.pen3Btn.data = null;
            //this.pen3Btn.enabled = true;
            this.pen3Btn.Image = null;
            this.pen3Btn.Location = new System.Drawing.Point(61, 3);
            this.pen3Btn.MaximumSize = new System.Drawing.Size(24, 24);
            this.pen3Btn.MinimumSize = new System.Drawing.Size(24, 24);
            this.pen3Btn.Name = "pen3Btn";
            this.pen3Btn.selected = false;
            this.pen3Btn.Size = new System.Drawing.Size(24, 24);
            this.pen3Btn.TabIndex = 4;
            // 
            // pen2Btn
            // 
            this.pen2Btn.data = null;
            //this.pen2Btn.enabled = true;
            this.pen2Btn.Image = null;
            this.pen2Btn.Location = new System.Drawing.Point(34, 3);
            this.pen2Btn.MaximumSize = new System.Drawing.Size(24, 24);
            this.pen2Btn.MinimumSize = new System.Drawing.Size(24, 24);
            this.pen2Btn.Name = "pen2Btn";
            this.pen2Btn.selected = false;
            this.pen2Btn.Size = new System.Drawing.Size(24, 24);
            this.pen2Btn.TabIndex = 3;
            // 
            // OverlayPaintControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.layersPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeSelect);
            this.Controls.Add(this.sizeSelect);
            this.Controls.Add(this.eraserBtn);
            this.Controls.Add(this.pen7Btn);
            this.Controls.Add(this.pen6Btn);
            this.Controls.Add(this.pen5Btn);
            this.Controls.Add(this.pen1Btn);
            this.Controls.Add(this.pen4Btn);
            this.Controls.Add(this.pen3Btn);
            this.Controls.Add(this.pen2Btn);
            this.Controls.Add(this.colourBtn);
            this.MinimumSize = new System.Drawing.Size(110, 2);
            this.Name = "OverlayPaintControls";
            this.Size = new System.Drawing.Size(118, 287);
            ((System.ComponentModel.ISupportInitialize)(this.sizeSelect)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button colourBtn;
        private bitmapSwitchButton pen2Btn;
        private bitmapSwitchButton pen3Btn;
        private bitmapSwitchButton pen4Btn;
        private bitmapSwitchButton pen1Btn;
        private bitmapSwitchButton pen5Btn;
        private bitmapSwitchButton pen6Btn;
        private bitmapSwitchButton pen7Btn;
        private bitmapSwitchButton eraserBtn;
        private System.Windows.Forms.NumericUpDown sizeSelect;
        private System.Windows.Forms.ComboBox typeSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel layersPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddLayerB;
        private System.Windows.Forms.ToolStripButton moveLayerUpB;
        private System.Windows.Forms.ToolStripButton moveLayerDnB;
        private System.Windows.Forms.ToolStripButton clearLayerB;
        private System.Windows.Forms.ToolStripButton delLayerB;
    }
}
