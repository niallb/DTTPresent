namespace DTTPresent
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.controlPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.slideDnBtn = new System.Windows.Forms.Button();
            this.magnifyTestBtn = new System.Windows.Forms.Button();
            this.slideUpBtn = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.modeIndicator = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.slideFromScreen = new System.Windows.Forms.ToolStripButton();
            this.slideFromMonitor = new System.Windows.Forms.ToolStripButton();
            this.resetOverlay = new System.Windows.Forms.Button();
            this.overlayPaintControls1 = new OverlayPaint.OverlayPaintControls();
            this.pageTree = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reopenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackWhiteBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embeddedApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparentViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embedApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displaywebPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.splitUnsplitDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startFromFirstSlideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startFromCurrentSlideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnToPreparationModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testProjectorPresentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pen1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pen2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.selMagAreaPicturebox = new System.Windows.Forms.PictureBox();
            this.bowserControlStrip = new System.Windows.Forms.ToolStrip();
            this.UTLEdt = new System.Windows.Forms.ToolStripTextBox();
            this.URLGoBtn = new System.Windows.Forms.ToolStripButton();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.backgroundImage = new System.Windows.Forms.PictureBox();
            this.thumbnailTimer = new System.Windows.Forms.Timer(this.components);
            this.grabAppTimer = new System.Windows.Forms.Timer(this.components);
            this.projectionTimer = new System.Windows.Forms.Timer(this.components);
            this.experimentBtn = new System.Windows.Forms.Button();
            this.controlPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selMagAreaPicturebox)).BeginInit();
            this.bowserControlStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).BeginInit();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.controlPanel.Controls.Add(this.groupBox1);
            this.controlPanel.Controls.Add(this.modeIndicator);
            this.controlPanel.Controls.Add(this.toolStrip1);
            this.controlPanel.Controls.Add(this.resetOverlay);
            this.controlPanel.Controls.Add(this.overlayPaintControls1);
            this.controlPanel.Controls.Add(this.pageTree);
            this.controlPanel.Controls.Add(this.menuStrip1);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(306, 569);
            this.controlPanel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.experimentBtn);
            this.groupBox1.Controls.Add(this.slideDnBtn);
            this.groupBox1.Controls.Add(this.magnifyTestBtn);
            this.groupBox1.Controls.Add(this.slideUpBtn);
            this.groupBox1.Controls.Add(this.testBtn);
            this.groupBox1.Location = new System.Drawing.Point(171, 429);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 128);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Experiments";
            // 
            // slideDnBtn
            // 
            this.slideDnBtn.Location = new System.Drawing.Point(6, 19);
            this.slideDnBtn.Name = "slideDnBtn";
            this.slideDnBtn.Size = new System.Drawing.Size(47, 23);
            this.slideDnBtn.TabIndex = 8;
            this.slideDnBtn.Text = "Down";
            this.slideDnBtn.UseVisualStyleBackColor = true;
            this.slideDnBtn.Click += new System.EventHandler(this.slideDnBtn_Click);
            // 
            // magnifyTestBtn
            // 
            this.magnifyTestBtn.Location = new System.Drawing.Point(5, 71);
            this.magnifyTestBtn.Name = "magnifyTestBtn";
            this.magnifyTestBtn.Size = new System.Drawing.Size(109, 23);
            this.magnifyTestBtn.TabIndex = 7;
            this.magnifyTestBtn.Text = "Test Magnify";
            this.magnifyTestBtn.UseVisualStyleBackColor = true;
            this.magnifyTestBtn.Click += new System.EventHandler(this.magnifyTestBtn_Click);
            // 
            // slideUpBtn
            // 
            this.slideUpBtn.Location = new System.Drawing.Point(59, 19);
            this.slideUpBtn.Name = "slideUpBtn";
            this.slideUpBtn.Size = new System.Drawing.Size(47, 23);
            this.slideUpBtn.TabIndex = 9;
            this.slideUpBtn.Text = "Up";
            this.slideUpBtn.UseVisualStyleBackColor = true;
            this.slideUpBtn.Click += new System.EventHandler(this.slideUpBtn_Click);
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(5, 48);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(109, 23);
            this.testBtn.TabIndex = 2;
            this.testBtn.Text = "Draw over this";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // modeIndicator
            // 
            this.modeIndicator.BackColor = System.Drawing.Color.White;
            this.modeIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeIndicator.Location = new System.Drawing.Point(173, 56);
            this.modeIndicator.Name = "modeIndicator";
            this.modeIndicator.Size = new System.Drawing.Size(121, 22);
            this.modeIndicator.TabIndex = 6;
            this.modeIndicator.Text = "Preparation mode";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slideFromScreen,
            this.slideFromMonitor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(306, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // slideFromScreen
            // 
            this.slideFromScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.slideFromScreen.Image = ((System.Drawing.Image)(resources.GetObject("slideFromScreen.Image")));
            this.slideFromScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.slideFromScreen.Name = "slideFromScreen";
            this.slideFromScreen.Size = new System.Drawing.Size(23, 22);
            this.slideFromScreen.Text = "Capture Current display to new slide";
            this.slideFromScreen.Click += new System.EventHandler(this.slideFromScreen_Click);
            // 
            // slideFromMonitor
            // 
            this.slideFromMonitor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.slideFromMonitor.Image = ((System.Drawing.Image)(resources.GetObject("slideFromMonitor.Image")));
            this.slideFromMonitor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.slideFromMonitor.Name = "slideFromMonitor";
            this.slideFromMonitor.Size = new System.Drawing.Size(23, 22);
            this.slideFromMonitor.Text = "Capture other monitor";
            this.slideFromMonitor.ToolTipText = "Capture another monitor as new slide";
            this.slideFromMonitor.Click += new System.EventHandler(this.slideFromMonitor_Click);
            this.slideFromMonitor.MouseEnter += new System.EventHandler(this.slideFromMonitor_MouseEnter);
            // 
            // resetOverlay
            // 
            this.resetOverlay.Location = new System.Drawing.Point(171, 370);
            this.resetOverlay.Name = "resetOverlay";
            this.resetOverlay.Size = new System.Drawing.Size(124, 23);
            this.resetOverlay.TabIndex = 4;
            this.resetOverlay.Text = "Reset drawing";
            this.resetOverlay.UseVisualStyleBackColor = true;
            this.resetOverlay.Click += new System.EventHandler(this.resetOverlay_Click);
            // 
            // overlayPaintControls1
            // 
            this.overlayPaintControls1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.overlayPaintControls1.Location = new System.Drawing.Point(171, 81);
            this.overlayPaintControls1.MinimumSize = new System.Drawing.Size(110, 2);
            this.overlayPaintControls1.Name = "overlayPaintControls1";
            this.overlayPaintControls1.Size = new System.Drawing.Size(124, 283);
            this.overlayPaintControls1.TabIndex = 3;
            // 
            // pageTree
            // 
            this.pageTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pageTree.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.pageTree.ItemHeight = 62;
            this.pageTree.Location = new System.Drawing.Point(3, 55);
            this.pageTree.Name = "pageTree";
            this.pageTree.Size = new System.Drawing.Size(162, 511);
            this.pageTree.TabIndex = 1;
            this.pageTree.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.pageTree_DrawNode);
            this.pageTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.pageTree_AfterSelect);
            this.pageTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.pageTree_NodeMouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.presentToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(306, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.reopenToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // reopenToolStripMenuItem
            // 
            this.reopenToolStripMenuItem.Name = "reopenToolStripMenuItem";
            this.reopenToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.reopenToolStripMenuItem.Text = "&Reopen";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackWhiteBoardToolStripMenuItem,
            this.slideToolStripMenuItem,
            this.animationToolStripMenuItem,
            this.webBrowserToolStripMenuItem,
            this.embeddedApplicationToolStripMenuItem,
            this.transparentViewToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // blackWhiteBoardToolStripMenuItem
            // 
            this.blackWhiteBoardToolStripMenuItem.Name = "blackWhiteBoardToolStripMenuItem";
            this.blackWhiteBoardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.blackWhiteBoardToolStripMenuItem.Size = new System.Drawing.Size(315, 22);
            this.blackWhiteBoardToolStripMenuItem.Text = "Insert new &ChalkBoard";
            this.blackWhiteBoardToolStripMenuItem.Click += new System.EventHandler(this.blackWhiteBoardToolStripMenuItem_Click);
            // 
            // slideToolStripMenuItem
            // 
            this.slideToolStripMenuItem.Enabled = false;
            this.slideToolStripMenuItem.Name = "slideToolStripMenuItem";
            this.slideToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.slideToolStripMenuItem.Size = new System.Drawing.Size(315, 22);
            this.slideToolStripMenuItem.Text = "Insert new &Slide";
            // 
            // animationToolStripMenuItem
            // 
            this.animationToolStripMenuItem.Enabled = false;
            this.animationToolStripMenuItem.Name = "animationToolStripMenuItem";
            this.animationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.A)));
            this.animationToolStripMenuItem.Size = new System.Drawing.Size(315, 22);
            this.animationToolStripMenuItem.Text = "Insert new &Animation";
            // 
            // webBrowserToolStripMenuItem
            // 
            this.webBrowserToolStripMenuItem.Name = "webBrowserToolStripMenuItem";
            this.webBrowserToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.W)));
            this.webBrowserToolStripMenuItem.Size = new System.Drawing.Size(315, 22);
            this.webBrowserToolStripMenuItem.Text = "Insert new &Web browser";
            this.webBrowserToolStripMenuItem.Click += new System.EventHandler(this.webBrowserToolStripMenuItem_Click);
            // 
            // embeddedApplicationToolStripMenuItem
            // 
            this.embeddedApplicationToolStripMenuItem.Name = "embeddedApplicationToolStripMenuItem";
            this.embeddedApplicationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.E)));
            this.embeddedApplicationToolStripMenuItem.Size = new System.Drawing.Size(315, 22);
            this.embeddedApplicationToolStripMenuItem.Text = "Insert new &Embedded Application";
            this.embeddedApplicationToolStripMenuItem.Click += new System.EventHandler(this.embedApplicationToolStripMenuItem_Click);
            // 
            // transparentViewToolStripMenuItem
            // 
            this.transparentViewToolStripMenuItem.Enabled = false;
            this.transparentViewToolStripMenuItem.Name = "transparentViewToolStripMenuItem";
            this.transparentViewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.T)));
            this.transparentViewToolStripMenuItem.Size = new System.Drawing.Size(315, 22);
            this.transparentViewToolStripMenuItem.Text = "Insert new &Transparent view";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.embedApplicationToolStripMenuItem,
            this.releaseApplicationToolStripMenuItem,
            this.displaywebPageToolStripMenuItem,
            this.toolStripMenuItem1,
            this.splitUnsplitDisplayToolStripMenuItem,
            this.fullScreenToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // embedApplicationToolStripMenuItem
            // 
            this.embedApplicationToolStripMenuItem.Name = "embedApplicationToolStripMenuItem";
            this.embedApplicationToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.embedApplicationToolStripMenuItem.Text = "&Embed application...";
            this.embedApplicationToolStripMenuItem.Click += new System.EventHandler(this.embedApplicationToolStripMenuItem_Click);
            // 
            // releaseApplicationToolStripMenuItem
            // 
            this.releaseApplicationToolStripMenuItem.Enabled = false;
            this.releaseApplicationToolStripMenuItem.Name = "releaseApplicationToolStripMenuItem";
            this.releaseApplicationToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.releaseApplicationToolStripMenuItem.Text = "&Release application";
            this.releaseApplicationToolStripMenuItem.Click += new System.EventHandler(this.releaseApplicationToolStripMenuItem_Click);
            // 
            // displaywebPageToolStripMenuItem
            // 
            this.displaywebPageToolStripMenuItem.Name = "displaywebPageToolStripMenuItem";
            this.displaywebPageToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.displaywebPageToolStripMenuItem.Text = "Display &web page ...";
            this.displaywebPageToolStripMenuItem.Click += new System.EventHandler(this.displaywebPageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 6);
            // 
            // splitUnsplitDisplayToolStripMenuItem
            // 
            this.splitUnsplitDisplayToolStripMenuItem.Name = "splitUnsplitDisplayToolStripMenuItem";
            this.splitUnsplitDisplayToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.splitUnsplitDisplayToolStripMenuItem.Text = "&Split/Unsplit Display";
            this.splitUnsplitDisplayToolStripMenuItem.Click += new System.EventHandler(this.splitUnsplitDisplayToolStripMenuItem_Click);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.fullScreenToolStripMenuItem.Text = "&Full screen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // presentToolStripMenuItem
            // 
            this.presentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startFromFirstSlideToolStripMenuItem,
            this.startFromCurrentSlideToolStripMenuItem,
            this.returnToPreparationModeToolStripMenuItem,
            this.testProjectorPresentationToolStripMenuItem,
            this.penSelectionToolStripMenuItem});
            this.presentToolStripMenuItem.Name = "presentToolStripMenuItem";
            this.presentToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.presentToolStripMenuItem.Text = "&Present";
            // 
            // startFromFirstSlideToolStripMenuItem
            // 
            this.startFromFirstSlideToolStripMenuItem.Name = "startFromFirstSlideToolStripMenuItem";
            this.startFromFirstSlideToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.startFromFirstSlideToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.startFromFirstSlideToolStripMenuItem.Text = "Start from &first slide";
            this.startFromFirstSlideToolStripMenuItem.Click += new System.EventHandler(this.startFromFirstSlideToolStripMenuItem_Click);
            // 
            // startFromCurrentSlideToolStripMenuItem
            // 
            this.startFromCurrentSlideToolStripMenuItem.Name = "startFromCurrentSlideToolStripMenuItem";
            this.startFromCurrentSlideToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
            this.startFromCurrentSlideToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.startFromCurrentSlideToolStripMenuItem.Text = "Start from c&urrent slide";
            this.startFromCurrentSlideToolStripMenuItem.Click += new System.EventHandler(this.startFromCurrentSlideToolStripMenuItem_Click);
            // 
            // returnToPreparationModeToolStripMenuItem
            // 
            this.returnToPreparationModeToolStripMenuItem.Name = "returnToPreparationModeToolStripMenuItem";
            this.returnToPreparationModeToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.returnToPreparationModeToolStripMenuItem.Text = "&Return to preparation mode";
            this.returnToPreparationModeToolStripMenuItem.Click += new System.EventHandler(this.returnToPreparationModeToolStripMenuItem_Click);
            // 
            // testProjectorPresentationToolStripMenuItem
            // 
            this.testProjectorPresentationToolStripMenuItem.Name = "testProjectorPresentationToolStripMenuItem";
            this.testProjectorPresentationToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.testProjectorPresentationToolStripMenuItem.Text = "Test projector presentation";
            this.testProjectorPresentationToolStripMenuItem.Click += new System.EventHandler(this.testProjectorPresentationToolStripMenuItem_Click);
            // 
            // penSelectionToolStripMenuItem
            // 
            this.penSelectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pen1ToolStripMenuItem,
            this.pen2ToolStripMenuItem});
            this.penSelectionToolStripMenuItem.Name = "penSelectionToolStripMenuItem";
            this.penSelectionToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.penSelectionToolStripMenuItem.Text = "&Pen selection";
            // 
            // pen1ToolStripMenuItem
            // 
            this.pen1ToolStripMenuItem.Name = "pen1ToolStripMenuItem";
            this.pen1ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.pen1ToolStripMenuItem.Text = "Pen &1";
            this.pen1ToolStripMenuItem.Click += new System.EventHandler(this.pen1ToolStripMenuItem_Click);
            // 
            // pen2ToolStripMenuItem
            // 
            this.pen2ToolStripMenuItem.Name = "pen2ToolStripMenuItem";
            this.pen2ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.pen2ToolStripMenuItem.Text = "Pen &2";
            this.pen2ToolStripMenuItem.Click += new System.EventHandler(this.pen2ToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.selMagAreaPicturebox);
            this.mainPanel.Controls.Add(this.bowserControlStrip);
            this.mainPanel.Controls.Add(this.webBrowser);
            this.mainPanel.Controls.Add(this.backgroundImage);
            this.mainPanel.Location = new System.Drawing.Point(309, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(879, 569);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.Move += new System.EventHandler(this.mainPanel_Resize);
            this.mainPanel.Resize += new System.EventHandler(this.mainPanel_Resize);
            // 
            // selMagAreaPicturebox
            // 
            this.selMagAreaPicturebox.Location = new System.Drawing.Point(620, 120);
            this.selMagAreaPicturebox.Name = "selMagAreaPicturebox";
            this.selMagAreaPicturebox.Size = new System.Drawing.Size(100, 50);
            this.selMagAreaPicturebox.TabIndex = 6;
            this.selMagAreaPicturebox.TabStop = false;
            this.selMagAreaPicturebox.Visible = false;
            this.selMagAreaPicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.selMagAreaPicturebox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.selMagAreaPicturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // bowserControlStrip
            // 
            this.bowserControlStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UTLEdt,
            this.URLGoBtn});
            this.bowserControlStrip.Location = new System.Drawing.Point(0, 0);
            this.bowserControlStrip.Name = "bowserControlStrip";
            this.bowserControlStrip.Size = new System.Drawing.Size(879, 25);
            this.bowserControlStrip.TabIndex = 5;
            this.bowserControlStrip.Text = "toolStrip1";
            // 
            // UTLEdt
            // 
            this.UTLEdt.Name = "UTLEdt";
            this.UTLEdt.Size = new System.Drawing.Size(400, 25);
            // 
            // URLGoBtn
            // 
            this.URLGoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.URLGoBtn.Image = ((System.Drawing.Image)(resources.GetObject("URLGoBtn.Image")));
            this.URLGoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.URLGoBtn.Name = "URLGoBtn";
            this.URLGoBtn.Size = new System.Drawing.Size(23, 22);
            this.URLGoBtn.Text = "toolStripButton1";
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(98, 248);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(384, 253);
            this.webBrowser.TabIndex = 4;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_Navigated);
            // 
            // backgroundImage
            // 
            this.backgroundImage.BackColor = System.Drawing.Color.Transparent;
            this.backgroundImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backgroundImage.Location = new System.Drawing.Point(98, 100);
            this.backgroundImage.Name = "backgroundImage";
            this.backgroundImage.Size = new System.Drawing.Size(100, 50);
            this.backgroundImage.TabIndex = 3;
            this.backgroundImage.TabStop = false;
            this.backgroundImage.Visible = false;
            // 
            // thumbnailTimer
            // 
            this.thumbnailTimer.Interval = 500;
            this.thumbnailTimer.Tick += new System.EventHandler(this.thumbnailTimer_Tick);
            // 
            // grabAppTimer
            // 
            this.grabAppTimer.Tick += new System.EventHandler(this.grabAppTimer_Tick);
            // 
            // projectionTimer
            // 
            this.projectionTimer.Interval = 330;
            this.projectionTimer.Tick += new System.EventHandler(this.projectionTimer_Tick);
            // 
            // experimentBtn
            // 
            this.experimentBtn.Location = new System.Drawing.Point(6, 101);
            this.experimentBtn.Name = "experimentBtn";
            this.experimentBtn.Size = new System.Drawing.Size(75, 23);
            this.experimentBtn.TabIndex = 10;
            this.experimentBtn.Text = "Experiment";
            this.experimentBtn.UseVisualStyleBackColor = true;
            this.experimentBtn.Click += new System.EventHandler(this.experimentBtn_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 569);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.controlPanel);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.Text = "DTTPresent";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selMagAreaPicturebox)).EndInit();
            this.bowserControlStrip.ResumeLayout(false);
            this.bowserControlStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.TreeView pageTree;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStrip bowserControlStrip;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.PictureBox backgroundImage;
        private System.Windows.Forms.ToolStripTextBox UTLEdt;
        private System.Windows.Forms.ToolStripButton URLGoBtn;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reopenToolStripMenuItem;
        private OverlayPaint.OverlayPaintControls overlayPaintControls1;
        private System.Windows.Forms.ToolStripMenuItem slideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackWhiteBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embeddedApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparentViewToolStripMenuItem;
        private System.Windows.Forms.Timer thumbnailTimer;
        private System.Windows.Forms.Button resetOverlay;
        private System.Windows.Forms.ToolStripMenuItem presentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embedApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displaywebPageToolStripMenuItem;
        private System.Windows.Forms.Timer grabAppTimer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem startFromFirstSlideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startFromCurrentSlideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnToPreparationModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton slideFromScreen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem splitUnsplitDisplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.Label modeIndicator;
        private System.Windows.Forms.ToolStripButton slideFromMonitor;
        private System.Windows.Forms.ToolStripMenuItem testProjectorPresentationToolStripMenuItem;
        private System.Windows.Forms.Timer projectionTimer;
        private System.Windows.Forms.Button magnifyTestBtn;
        private System.Windows.Forms.PictureBox selMagAreaPicturebox;
        private System.Windows.Forms.Button slideUpBtn;
        private System.Windows.Forms.Button slideDnBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem penSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pen1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pen2ToolStripMenuItem;
        private System.Windows.Forms.Button experimentBtn;
    }
}

