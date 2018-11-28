namespace OverlayPaintDev
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.InitTestBtn = new System.Windows.Forms.Button();
            this.overlayPaintControls1 = new OverlayPaint.OverlayPaintControls();
            this.overlayPaintArea1 = new OverlayPaint.OverlayPaintArea();
            this.SwapBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 357);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Tablet";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 457);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(105, 140);
            this.textBox1.TabIndex = 4;
            // 
            // InitTestBtn
            // 
            this.InitTestBtn.Location = new System.Drawing.Point(13, 399);
            this.InitTestBtn.Name = "InitTestBtn";
            this.InitTestBtn.Size = new System.Drawing.Size(75, 23);
            this.InitTestBtn.TabIndex = 5;
            this.InitTestBtn.Text = "Initialise";
            this.InitTestBtn.UseVisualStyleBackColor = true;
            this.InitTestBtn.Click += new System.EventHandler(this.InitTestBtn_Click);
            this.InitTestBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.InitTestBtn_MouseClick);
            // 
            // overlayPaintControls1
            // 
            this.overlayPaintControls1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.overlayPaintControls1.Location = new System.Drawing.Point(4, 13);
            this.overlayPaintControls1.MinimumSize = new System.Drawing.Size(110, 2);
            this.overlayPaintControls1.Name = "overlayPaintControls1";
            this.overlayPaintControls1.Size = new System.Drawing.Size(120, 277);
            this.overlayPaintControls1.TabIndex = 6;
            // 
            // overlayPaintArea1
            // 
            this.overlayPaintArea1.BackColor = System.Drawing.Color.Transparent;
            this.overlayPaintArea1.Image = null;
            this.overlayPaintArea1.Layers = ((System.Collections.Generic.List<OverlayPaint.OverlayPaintArea.Layer>)(resources.GetObject("overlayPaintArea1.Layers")));
            this.overlayPaintArea1.Location = new System.Drawing.Point(0, 0);
            this.overlayPaintArea1.Name = "overlayPaintArea1";
            this.overlayPaintArea1.Size = new System.Drawing.Size(381, 238);
            this.overlayPaintArea1.TabIndex = 0;
            // 
            // SwapBtn
            // 
            this.SwapBtn.Location = new System.Drawing.Point(13, 428);
            this.SwapBtn.Name = "SwapBtn";
            this.SwapBtn.Size = new System.Drawing.Size(75, 23);
            this.SwapBtn.TabIndex = 7;
            this.SwapBtn.Text = "Swap";
            this.SwapBtn.UseVisualStyleBackColor = true;
            this.SwapBtn.Click += new System.EventHandler(this.SwapBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 604);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "EnableCtrls";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1139, 723);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.SwapBtn);
            this.Controls.Add(this.overlayPaintControls1);
            this.Controls.Add(this.InitTestBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

                   

        //private OverlayPaint.OverlayPaintArea overlayPaint1;
        //private OverlayPaint.OverlayPaintControls overlayPaintControls1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button InitTestBtn;
        private OverlayPaint.OverlayPaintControls overlayPaintControls1;
        private OverlayPaint.OverlayPaintArea overlayPaintArea1;
        private System.Windows.Forms.Button SwapBtn;
        private System.Windows.Forms.Button button3;
    }
}

