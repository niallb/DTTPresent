namespace OverlayPaint
{
    partial class OverlayPaintArea
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
            // OverlayPaintArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "OverlayPaintArea";
            this.Size = new System.Drawing.Size(381, 238);
            this.VisibleChanged += new System.EventHandler(this.OverlayPaintArea_VisibleChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.Enter += new System.EventHandler(this.OverlayPaintArea_Enter);
            this.Leave += new System.EventHandler(this.OverlayPaintArea_Leave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.Move += new System.EventHandler(this.OverlayPaintArea_Move);
            this.Resize += new System.EventHandler(this.OverlayPaint_Resize);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
