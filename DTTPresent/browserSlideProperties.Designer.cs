namespace DTTPresent
{
    partial class browserSlideProperties
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
            this.button1 = new System.Windows.Forms.Button();
            this.penSetSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.url = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.showControls = new System.Windows.Forms.CheckBox();
            this.refresh = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(334, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Define";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // penSetSelect
            // 
            this.penSetSelect.FormattingEnabled = true;
            this.penSetSelect.Location = new System.Drawing.Point(71, 67);
            this.penSetSelect.Name = "penSetSelect";
            this.penSetSelect.Size = new System.Drawing.Size(257, 21);
            this.penSetSelect.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Pen set";
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(234, 129);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 37;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(315, 129);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 38;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(71, 12);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(318, 20);
            this.title.TabIndex = 28;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(13, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(55, 13);
            this.titleLabel.TabIndex = 32;
            this.titleLabel.Text = "Page Title";
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(72, 38);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(318, 20);
            this.url.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "URL";
            // 
            // showControls
            // 
            this.showControls.AutoSize = true;
            this.showControls.Location = new System.Drawing.Point(72, 95);
            this.showControls.Name = "showControls";
            this.showControls.Size = new System.Drawing.Size(133, 17);
            this.showControls.TabIndex = 44;
            this.showControls.Text = "Show browser controls";
            this.showControls.UseVisualStyleBackColor = true;
            // 
            // refresh
            // 
            this.refresh.AutoSize = true;
            this.refresh.Location = new System.Drawing.Point(234, 95);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(94, 17);
            this.refresh.TabIndex = 45;
            this.refresh.Text = "Always refresh";
            this.refresh.UseVisualStyleBackColor = true;
            // 
            // browserSlideProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 164);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.showControls);
            this.Controls.Add(this.url);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.penSetSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.title);
            this.Controls.Add(this.titleLabel);
            this.Name = "browserSlideProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "browserSlideProperties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox penSetSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox showControls;
        private System.Windows.Forms.CheckBox refresh;
    }
}