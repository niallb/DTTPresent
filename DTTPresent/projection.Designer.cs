namespace DTPMagnify
{
    partial class projection
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
            this.components = new System.ComponentModel.Container();
            this.thePic = new System.Windows.Forms.PictureBox();
            this.projectionTimer = new System.Windows.Forms.Timer(this.components);
            this.worker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.thePic)).BeginInit();
            this.SuspendLayout();
            // 
            // thePic
            // 
            this.thePic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thePic.Location = new System.Drawing.Point(0, 0);
            this.thePic.Name = "thePic";
            this.thePic.Size = new System.Drawing.Size(284, 262);
            this.thePic.TabIndex = 0;
            this.thePic.TabStop = false;
            // 
            // projectionTimer
            // 
            this.projectionTimer.Interval = 130;
            this.projectionTimer.Tick += new System.EventHandler(this.projectionTimer_Tick);
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            // 
            // projection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.thePic);
            this.Name = "projection";
            this.Text = "projection";
            ((System.ComponentModel.ISupportInitialize)(this.thePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox thePic;
        private System.Windows.Forms.Timer projectionTimer;
        private System.ComponentModel.BackgroundWorker worker;
    }
}