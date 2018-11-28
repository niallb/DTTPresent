namespace DTTPresent
{
    partial class chalkBoardProperties
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
            this.title = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.underlaySelect = new System.Windows.Forms.ComboBox();
            this.underlaySettingsBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.verticalScrollChk = new System.Windows.Forms.CheckBox();
            this.BgColourBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.penSetSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.LineColourBtn = new System.Windows.Forms.Button();
            this.findImgBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.imgSel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(72, 12);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(318, 20);
            this.title.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(14, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(55, 13);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "Page Title";
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(235, 157);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 10;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(316, 157);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // underlaySelect
            // 
            this.underlaySelect.FormattingEnabled = true;
            this.underlaySelect.Location = new System.Drawing.Point(103, 125);
            this.underlaySelect.Name = "underlaySelect";
            this.underlaySelect.Size = new System.Drawing.Size(226, 21);
            this.underlaySelect.TabIndex = 8;
            // 
            // underlaySettingsBtn
            // 
            this.underlaySettingsBtn.Location = new System.Drawing.Point(335, 123);
            this.underlaySettingsBtn.Name = "underlaySettingsBtn";
            this.underlaySettingsBtn.Size = new System.Drawing.Size(53, 23);
            this.underlaySettingsBtn.TabIndex = 9;
            this.underlaySettingsBtn.Text = "Define";
            this.underlaySettingsBtn.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Lines layout";
            // 
            // verticalScrollChk
            // 
            this.verticalScrollChk.AutoSize = true;
            this.verticalScrollChk.Location = new System.Drawing.Point(259, 43);
            this.verticalScrollChk.Name = "verticalScrollChk";
            this.verticalScrollChk.Size = new System.Drawing.Size(129, 17);
            this.verticalScrollChk.TabIndex = 4;
            this.verticalScrollChk.Text = "Vertical scroll enabled";
            this.verticalScrollChk.UseVisualStyleBackColor = true;
            // 
            // BgColourBtn
            // 
            this.BgColourBtn.BackColor = System.Drawing.Color.White;
            this.BgColourBtn.Location = new System.Drawing.Point(103, 38);
            this.BgColourBtn.Name = "BgColourBtn";
            this.BgColourBtn.Size = new System.Drawing.Size(75, 23);
            this.BgColourBtn.TabIndex = 2;
            this.BgColourBtn.Text = "Background";
            this.BgColourBtn.UseVisualStyleBackColor = false;
            this.BgColourBtn.Click += new System.EventHandler(this.ColourBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Colour";
            // 
            // penSetSelect
            // 
            this.penSetSelect.FormattingEnabled = true;
            this.penSetSelect.Location = new System.Drawing.Point(103, 95);
            this.penSetSelect.Name = "penSetSelect";
            this.penSetSelect.Size = new System.Drawing.Size(226, 21);
            this.penSetSelect.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Pen set";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Define";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LineColourBtn
            // 
            this.LineColourBtn.BackColor = System.Drawing.Color.DarkTurquoise;
            this.LineColourBtn.Location = new System.Drawing.Point(178, 38);
            this.LineColourBtn.Name = "LineColourBtn";
            this.LineColourBtn.Size = new System.Drawing.Size(75, 23);
            this.LineColourBtn.TabIndex = 3;
            this.LineColourBtn.Text = "Lines";
            this.LineColourBtn.UseVisualStyleBackColor = false;
            this.LineColourBtn.Click += new System.EventHandler(this.ColourBtn_Click);
            // 
            // findImgBtn
            // 
            this.findImgBtn.Location = new System.Drawing.Point(335, 66);
            this.findImgBtn.Name = "findImgBtn";
            this.findImgBtn.Size = new System.Drawing.Size(53, 23);
            this.findImgBtn.TabIndex = 29;
            this.findImgBtn.Text = "Select";
            this.findImgBtn.UseVisualStyleBackColor = true;
            this.findImgBtn.Click += new System.EventHandler(this.findImgBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Background";
            // 
            // imgSel
            // 
            this.imgSel.Location = new System.Drawing.Point(103, 68);
            this.imgSel.Name = "imgSel";
            this.imgSel.Size = new System.Drawing.Size(226, 20);
            this.imgSel.TabIndex = 31;
            // 
            // chalkBoardProperties
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(402, 190);
            this.Controls.Add(this.imgSel);
            this.Controls.Add(this.findImgBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LineColourBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.penSetSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.underlaySelect);
            this.Controls.Add(this.underlaySettingsBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.verticalScrollChk);
            this.Controls.Add(this.BgColourBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.title);
            this.Controls.Add(this.titleLabel);
            this.Name = "chalkBoardProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ComboBox underlaySelect;
        private System.Windows.Forms.Button underlaySettingsBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox verticalScrollChk;
        private System.Windows.Forms.Button BgColourBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox penSetSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button LineColourBtn;
        private System.Windows.Forms.Button findImgBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox imgSel;
    }
}