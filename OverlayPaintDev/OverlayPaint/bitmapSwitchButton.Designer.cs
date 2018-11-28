namespace OverlayPaint
{
    partial class bitmapSwitchButton
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
            this.SuspendLayout();
            // 
            // bitmapSwitchButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MaximumSize = new System.Drawing.Size(24, 24);
            this.MinimumSize = new System.Drawing.Size(24, 24);
            this.Name = "bitmapSwitchButton";
            this.Size = new System.Drawing.Size(24, 24);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.bitmapSwitchButton_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bitmapSwitchButton_MouseClick);
            this.MouseEnter += new System.EventHandler(this.bitmapSwitchButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.bitmapSwitchButton_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
