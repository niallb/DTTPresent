using DesktopTeacherTools;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Snippets;
using OverlayPaint;
using WintabDN;
using NBZipPackage;
using System.Runtime.InteropServices;
using System.Threading;
using DTPMagnify;
using ScreenSelector;
using System.Reflection;

namespace DTTPresent
{
    public partial class mainForm : Form
    {
        private ToolForm toolForm = null;

        private OverlayPaintArea overlayPaintArea1;

        /// <summary>
        /// From DTPMagnify
        projection theProjection;
        Bitmap selMagAreaBackimg;
        private int zoomx, zoomy, zoomdx, zoomdy;
        private bool zooming = false;
        private bool isZoomed = false;
        private projection.Info projInfo = new projection.Info();

        /// </summary>

        private cls_DTTPresentation thePresentation;
        private Dictionary<string, cls_page> pageLookup;
        enum pageType { board, web, slide, application, animation, transparent, info }
        private Dictionary<Type, pageType> pageTypeLookup;
        private List<Control> pageParts;
        private cls_page curPage;
        private string curPath;
        private ZipPackage package;
        private IntPtr embeddedHandle;
        private bool _inPresentationMode;
        private Screen captureScreen = null;
        private bool InPresentationMode
        {
            set
            {
                if (value)
                {
                    modeIndicator.Text = "Presentation mode";
                    modeIndicator.BackColor = Color.PaleGreen;
                }
                else
                {
                    modeIndicator.Text = "Preparation mode";
                    modeIndicator.BackColor = Color.White;
                }
                _inPresentationMode = value;
            }
            get
            {
                return _inPresentationMode;
            }
        }
        //private string curTempDir;

        private Dictionary<string, cls_underlayDefinition> defaultUnderlays;
        private Dictionary<string, cls_penSet> defaultPenSets;
        chalkBoardProperties boardProps;

        public mainForm()
        {
            WebBrowserHelper.FixBrowserVersion();
            embeddedHandle = IntPtr.Zero;
            overlayPaintArea1 = new OverlayPaintArea();
            overlayPaintArea1.Dock = DockStyle.Fill;
            this.Controls.Add(overlayPaintArea1);

            //overlayPaintControls1.Attach(overlayPaintArea1);
            InitializeComponent();
            pageTypeLookup = new Dictionary<Type, pageType>();
            pageTypeLookup[typeof(cls_board)] = pageType.board;
            pageTypeLookup[typeof(cls_web)] = pageType.web;
            pageTypeLookup[typeof(cls_slide)] = pageType.slide;
            pageTypeLookup[typeof(cls_application)] = pageType.application;
            pageTypeLookup[typeof(cls_info)] = pageType.info;
            //newToolStripMenuItem_Click(null, null);
            mainPanel.Left = controlPanel.Width;
            mainPanel.Width = ClientRectangle.Width - controlPanel.Width;
            InitialiseNewDoc();

            //     if(Properties.Settings.Default.recentFiles != null)
            //    {
            //        openFile(Properties.Settings.Default.recentFiles[0]);
            //    }
            defaultUnderlays = new Dictionary<string, cls_underlayDefinition>();
            defaultUnderlays.Add("None", null);
            defaultUnderlays.Add("5x3_Decades_Square", new cls_underlayDefinition(5, false, 3, false, cls_underlayDefinition.underlayPosition.full));
            defaultUnderlays.Add("4x5_Decades_Square_on_right", new cls_underlayDefinition(4, false, 5, false, cls_underlayDefinition.underlayPosition.right));
            defaultUnderlays.Add("5x3_Decades_Log", new cls_underlayDefinition(5, true, 3, true, cls_underlayDefinition.underlayPosition.full));
            defaultUnderlays.Add("3x2_Decades_Square", new cls_underlayDefinition(3, false, 2, false, cls_underlayDefinition.underlayPosition.full));
            defaultUnderlays.Add("3x2_Decades_Log", new cls_underlayDefinition(3, true, 2, true, cls_underlayDefinition.underlayPosition.full));
            defaultUnderlays.Add("5x3_Decades_LogLin", new cls_underlayDefinition(5, true, 3, false, cls_underlayDefinition.underlayPosition.full));
            defaultUnderlays.Add("5x3_Decades_LinLog", new cls_underlayDefinition(5, false, 3, true, cls_underlayDefinition.underlayPosition.full));

            defaultPenSets = new Dictionary<string, cls_penSet>();
            cls_penSet tmpPenSet = new cls_penSet();
            tmpPenSet.M_name = "Default pens for light backgrounds";
            tmpPenSet.M_id = "Default_pens_for_light_backgrounds";
            tmpPenSet.Add_penDefinition(new cls_penDefinition(3, Color.Black, cls_penDefinition.penmasks.softpen));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(3, Color.Red, cls_penDefinition.penmasks.softpen));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(3, Color.Green, cls_penDefinition.penmasks.softpen));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(3, Color.Blue, cls_penDefinition.penmasks.softpen));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(10, Color.Yellow, cls_penDefinition.penmasks.highlighter));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(10, Color.Pink, cls_penDefinition.penmasks.highlighter));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(10, Color.Purple, cls_penDefinition.penmasks.marker));
            defaultPenSets.Add(tmpPenSet.M_id, tmpPenSet);
            tmpPenSet = new cls_penSet();
            tmpPenSet.M_name = "Default pens for dark backgrounds";
            tmpPenSet.M_id = "Default_pens_for_dark_backgrounds";
            tmpPenSet.Add_penDefinition(new cls_penDefinition(3, Color.White, cls_penDefinition.penmasks.softpen));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(3, Color.Red, cls_penDefinition.penmasks.softpen));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(3, Color.LightGreen, cls_penDefinition.penmasks.softpen));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(3, Color.LightBlue, cls_penDefinition.penmasks.softpen));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(10, Color.DarkOrange, cls_penDefinition.penmasks.highlighter));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(10, Color.DarkCyan, cls_penDefinition.penmasks.highlighter));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(10, Color.Pink, cls_penDefinition.penmasks.marker));
            defaultPenSets.Add(tmpPenSet.M_id, tmpPenSet);
            tmpPenSet = new cls_penSet();
            tmpPenSet.M_name = "Default larger pens for light backgrounds";
            tmpPenSet.M_id = "Default_larger_pens_for_light_backgrounds";
            tmpPenSet.Add_penDefinition(new cls_penDefinition(8, Color.Black, cls_penDefinition.penmasks.softpen));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(8, Color.Red, cls_penDefinition.penmasks.softpen));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(8, Color.Green, cls_penDefinition.penmasks.softpen));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(8, Color.Blue, cls_penDefinition.penmasks.softpen));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(18, Color.Yellow, cls_penDefinition.penmasks.highlighter));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(18, Color.Pink, cls_penDefinition.penmasks.highlighter));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(18, Color.Purple, cls_penDefinition.penmasks.marker));
            defaultPenSets.Add(tmpPenSet.M_id, tmpPenSet);
            tmpPenSet = new cls_penSet();
            tmpPenSet.M_name = "Default larger pens for dark backgrounds";
            tmpPenSet.M_id = "Default_larger_pens_for_dark_backgrounds";
            tmpPenSet.Add_penDefinition(new cls_penDefinition(8, Color.White, cls_penDefinition.penmasks.softpen));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(8, Color.Red, cls_penDefinition.penmasks.softpen));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(8, Color.LightGreen, cls_penDefinition.penmasks.softpen));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(8, Color.LightBlue, cls_penDefinition.penmasks.softpen));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(18, Color.DarkOrange, cls_penDefinition.penmasks.highlighter));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(18, Color.DarkCyan, cls_penDefinition.penmasks.highlighter));
            tmpPenSet.Add_penDefinition(new cls_penDefinition(18, Color.Pink, cls_penDefinition.penmasks.marker));
            defaultPenSets.Add(tmpPenSet.M_id, tmpPenSet);

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            mainPanel, new object[] { true }); 
        }

        #region initialisation

        private void InitialisePageParts()
        {
            pageParts = new List<Control>();
            pageParts.Add(webBrowser);
            pageParts.Add(backgroundImage);
            pageParts.Add(bowserControlStrip);
            overlayPaintArea1.Dock = DockStyle.Fill;
            overlayPaintArea1.startWintabInput();
            overlayPaintControls1.Attach(overlayPaintArea1);
            overlayPaintControls1.OnPenUpdated = new EventHandler(onPenUpdated);
            overlayPaintArea1.Visible = false;
            overlayPaintControls1.Enabled = false;
            foreach (Control part in pageParts)
            {
                part.Visible = false;
            }
        }

        private void InitialiseNewDoc()
        {
            pageLookup = new Dictionary<string, cls_page>();
            thePresentation = new cls_DTTPresentation();
            curPath = null;
            package = new ZipPackage();
            InitialisePageParts();
            pageTree.Nodes.Clear();
            switchToPage(cls_info.Instance);
        }

        #endregion
        #region filemenu

        private void updateRecentFilesList(string mostRecent, int limit)
        {
            StringCollection rfl;
            if (Properties.Settings.Default.recentFiles == null)
                rfl = new StringCollection();
            else
                rfl = Properties.Settings.Default.recentFiles;
            int index = rfl.IndexOf(mostRecent);
            if (index > 0)
            {
                rfl.RemoveAt(index);
            }
            if (index != 0)
            {
                rfl.Insert(0, mostRecent);
            }
            while (rfl.Count > limit)
            {
                rfl.RemoveAt(limit);
            }
            Properties.Settings.Default.recentFiles = rfl;
            Properties.Settings.Default.Save();
        }

        private void updateRecentFilesMenu(ToolStripMenuItem recentFiles)
        {
            recentFiles.DropDownItems.Clear();
            StringCollection rfl;
            if (Properties.Settings.Default.recentFiles == null)
                rfl = new StringCollection();
            else
                rfl = Properties.Settings.Default.recentFiles;
            if (rfl.Count == 0)
            {
                reopenToolStripMenuItem.Enabled = false;
            }
            else
            {
                reopenToolStripMenuItem.Enabled = true;
                reopenToolStripMenuItem.DropDown.Enabled = true;
                foreach (string fn in rfl)
                {
                    string nm = fn.Substring(fn.LastIndexOf(Path.DirectorySeparatorChar) + 1);
                    ToolStripItem m = new ToolStripMenuItem(nm, null, recentFileMenuItem_Click, fn);
                    recentFiles.DropDownItems.Add(m);
                }
            }
        }

        private void recentFileMenuItem_Click(object sender, EventArgs e)
        {
            string fn = ((ToolStripMenuItem)sender).Name;
            openFile(fn);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateRecentFilesMenu(reopenToolStripMenuItem);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitialiseNewDoc();
        }

        private void openFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                InitialiseNewDoc();
                package = new ZipPackage(fileName);
                curPath = fileName;
                DTTPresentation_parser parser = new DTTPresentation_parser();
                thePresentation = parser.parseIn(File.ReadAllText(package.tmpDir + "\\slides.xml"), package.tmpDir);
                updateRecentFilesList(fileName, 6);
                foreach (cls_page pa in thePresentation.M_page)
                {
                    pageLookup[pa.M_uniqueID] = pa;
                    pageTree.Nodes.Add(pa.M_uniqueID, pa.M_title);
                }
            }
            if (thePresentation.M_page.Count > 0)
            {
                pageTree.SelectedNode = pageTree.Nodes[0];
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "DTT files (*.dtt)|*.dtt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFile(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curPath != null)
            {
                File.WriteAllText(package.tmpDir + "\\slides.xml", thePresentation.toXML(true, package.tmpDir));
                package.SaveAs(curPath);
            }
            else
                saveAsToolStripMenuItem_Click(sender, e);
            //File.WriteAllText(curTempDir + Path.DirectorySeparatorChar + "slides.xml", thePresentation.toXML(true));
            // ZipFile.CreateFromDirectory(curTempDir, curPath);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filter = "DTT files (*.dtt)|*.dtt|All files (*.*)|*.*";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = filter;
            saveFileDialog1.FilterIndex = 1;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fshortname = saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.LastIndexOf(Path.DirectorySeparatorChar) + 1);
                //TabCtrl.updateSelectedTabName(fshortname);
                curPath = saveFileDialog1.FileName;
                saveToolStripMenuItem_Click(sender, e);
                updateRecentFilesList(curPath, 6);
            }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            //setMainPanelSize(1280, 720);
            //switchControlPanelLocation();
            //mainPanel.BackColor = Color.Transparent;
            //BackColor = TransparencyKey;
            if (curPage.GetType() != typeof(cls_board))
            {
                if (!overlayPaintArea1.Visible)
                {
                    overlayPaintArea1.GrabBackground();
                    overlayPaintArea1.Visible = true;
                    magnifyTestBtn.Enabled = true;
                    testBtn.BackColor = Color.PaleVioletRed;

                }
                else
                {
                    resetZoom();
                    overlayPaintArea1.Visible = false;
                    magnifyTestBtn.Enabled = false;
                    testBtn.BackColor = SystemColors.ButtonFace;
                }
            }

        }

        public void switchControlPanelLocation()
        {
            if (toolForm == null)
            {
                toolForm = new ToolForm(this);
                toolForm.Show();
                toolForm.TopLevel = true;
                toolForm.TopMost = true;
                toolForm.ClientSize = new Size(controlPanel.Width, controlPanel.Height);
                controlPanel.Parent = toolForm;
                //toolStrip1.Top = 0;
                ClientSize = new Size(ClientSize.Width - controlPanel.Width, ClientSize.Height);
                mainPanel.Left = 0;
                mainPanel.Width = ClientRectangle.Width;
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                controlPanel.Parent = this;
                toolForm.Hide();
                toolForm.Dispose();
                toolForm = null;
                mainPanel.Left = controlPanel.Width;
                mainPanel.Width = ClientRectangle.Width - controlPanel.Width;
                ClientSize = new Size(ClientSize.Width + controlPanel.Width, ClientSize.Height);
            }
        }

        private void setMainPanelSize(int mpwidth, int mpheight)
        {
            mainPanel.Width = mpwidth;
            mainPanel.Height = mpheight;
            if (mainPanel.Parent == this)
            {
                Width = mainPanel.Width + controlPanel.Width;
                Height = mainPanel.Height;
            }
        }

        private void blackWhiteBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (boardProps == null)
            {
                boardProps = new chalkBoardProperties();
                foreach (KeyValuePair<String, cls_underlayDefinition> kvp in defaultUnderlays)
                {
                    boardProps.addUnderlayOption(kvp.Key);
                }
                foreach (KeyValuePair<String, cls_penSet> kvp in defaultPenSets)
                {
                    boardProps.addPenSetOption(kvp.Key);
                }
                boardProps.underlayChoice = "None";
                boardProps.penSetIndex = 0;
            }
            boardProps.Title = "Slide " + (thePresentation.M_page.Count + 1).ToString();
            if (boardProps.ShowDialog(toolForm) == System.Windows.Forms.DialogResult.OK)
            {
                cls_board nb = new cls_board();
                nb.M_title = boardProps.Title;
                nb.M_boardColour = System.Drawing.ColorTranslator.ToHtml(boardProps.boardColour);
                nb.M_lineColour = System.Drawing.ColorTranslator.ToHtml(boardProps.lineColour);
                nb.M_uniqueID = SHA1Util.SHA1HashStringForUTF8String(nb.M_title + DateTime.Now.ToString());
                if (!boardProps.underlayChoice.Equals("None"))
                {
                    string key = boardProps.underlayChoice;
                    if (!thePresentation.M_underlayDefinition.ContainsKey(key))
                    {
                        thePresentation.M_underlayDefinition.Add(key, defaultUnderlays[boardProps.underlayChoice]);
                        thePresentation.M_underlayDefinition[key].M_id = key;
                    }
                    nb.M_underlayID = key;
                }
                else
                    nb.M_underlayID = null;
                nb.M_penSetID = boardProps.penSetChoice;
                if (!thePresentation.M_penSet.ContainsKey(nb.M_penSetID))
                {
                    thePresentation.M_penSet.Add(nb.M_penSetID, defaultPenSets[nb.M_penSetID]);
                }
                if ((boardProps.Background.Length > 0) && (File.Exists(boardProps.Background)))
                {
                    nb.background = Image.FromFile(boardProps.Background);
                }
                InsertPage(nb);                
            }
        }

        private void InsertPage(cls_page np, int atidx=-1)
        {
            pageLookup[np.M_uniqueID] = np;
            int insertidx = atidx;
            if ((curPage != null)&&(insertidx == -1))
            {
                insertidx = thePresentation.M_page.IndexOf(curPage)+1;
            }

            if (insertidx >= 0)
            {
                thePresentation.M_page.Insert(insertidx, np);
                pageTree.SelectedNode = pageTree.Nodes.Insert(insertidx, np.M_uniqueID, np.M_title);
            }
            else
            {
                thePresentation.M_page.Add(np);
                pageTree.SelectedNode = pageTree.Nodes.Add(np.M_uniqueID, np.M_title);
            }
            thumbnailTimer.Start();
        }

        private cls_page RemoveCurPage()
        {
            cls_page removed = curPage;
            if (removed != null)
            {
                thePresentation.M_page.Remove(curPage);
                pageTree.Nodes.Remove(pageTree.SelectedNode);
                pageLookup[removed.M_uniqueID] = null;
            }
            return removed;
        }

        private void webBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            browserSlideProperties props = new browserSlideProperties();
            foreach (KeyValuePair<String, cls_penSet> kvp in defaultPenSets)
            {
                props.addPenSetOption(kvp.Key);
            }
            props.penSetIndex = 0;
            props.Title = "Slide " + (thePresentation.M_page.Count + 1).ToString();
            if (props.ShowDialog(toolForm) == System.Windows.Forms.DialogResult.OK)
            {
                cls_web nw = new cls_web();
                nw.M_title = props.Title;
                nw.M_url = props.Url;
                nw.M_uniqueID = SHA1Util.SHA1HashStringForUTF8String(nw.M_title + DateTime.Now.ToString());
                nw.M_penSetID = props.penSetChoice;
                if (!thePresentation.M_penSet.ContainsKey(nw.M_penSetID))
                {
                    thePresentation.M_penSet.Add(nw.M_penSetID, defaultPenSets[nw.M_penSetID]);
                }
                InsertPage(nw);
            }
        }


        Font tagFont = new Font("Helvetica", 8, FontStyle.Bold);


        private void pageTree_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            // Draw the background and node text for a selected node.
            Rectangle bounds = e.Node.Bounds;
            bounds.Width = pageTree.Width - bounds.X - 5;

            e.Graphics.FillRectangle(Brushes.White, bounds);
            bounds.Inflate(0, -2);
            if (e.Node == pageTree.SelectedNode)
            {
                e.Graphics.DrawRectangle(Pens.Red, bounds);
            }
            else
            {
                e.Graphics.DrawRectangle(Pens.Gray, bounds);
            }
            if (pageLookup[e.Node.Name].thumb != null)
            {
                e.Graphics.DrawImage(pageLookup[e.Node.Name].thumb, bounds.X + 10, bounds.Y + 5);
            }
            Font nodeFont = e.Node.NodeFont;
            if (nodeFont == null) nodeFont = ((TreeView)sender).Font;

            // Draw the node text.
            e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.Black, Rectangle.Inflate(bounds, -2, -2));


        }

        private void pageTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            displayPage(pageLookup[e.Node.Name]);
        }

        private void updateCurPageThumbnail()
        {
            if (curPage != null)
            {
                Bitmap thumb;
                if (curPage.GetType() == typeof(cls_board))
                {
                    thumb = PrintWindowContainer.CaptureWindow(overlayPaintArea1.Handle);
                }
                else
                {
                    thumb = new Bitmap(mainPanel.Width, mainPanel.Height);
                    Graphics g2 = Graphics.FromImage(thumb);
                    Point tr = mainPanel.PointToScreen(new Point(0, 0));
                    g2.CopyFromScreen(tr.X, tr.Y, 0, 0, mainPanel.Size);
                }
                curPage.thumb = new Bitmap(thumb, new Size(80, 50));
                pageTree.Invalidate();
            }
        }

        private void switchToPage(cls_page toPage)
        {
            //updateCurPageThumbnail();
            TreeNode[] nds = pageTree.Nodes.Find(toPage.M_uniqueID, true);
            if ((nds.Length == 1) && (pageTree.SelectedNode != nds[0]))
            {
                pageTree.SelectedNode = nds[0];
                // No need to call displayPage as pageTree_AfterSelect will do it
            }
            else
            {
                pageTree.SelectedNode = null;
                displayPage(toPage);
            }

        }

        private void displayPage(cls_page toPage)
        {
            resetZoom();
            foreach (Control part in pageParts)
            {
                part.Visible = false;
            }
            overlayPaintArea1.Visible = false;
            if (curPage != null)
            {
                curPage.tmpLayers = overlayPaintArea1.Layers;
            }
            curPage = toPage;
            if (curPage.tmpLayers != null)
            {
                overlayPaintArea1.Layers = curPage.tmpLayers;
            }
            else
            {
                overlayPaintArea1.Reinitialise();
            }
            magnifyTestBtn.Enabled = false;
            switch (pageTypeLookup[curPage.GetType()])
            {
                case pageType.board:
                    cls_board tmpboard = (cls_board)curPage;
                    /*backgroundImage.Visible = true;
                    backgroundImage.BackColor = Color.FromName(tmpboard.M_boardColour);
                    backgroundImage.Dock = DockStyle.Fill;
                    backgroundImage.Image = new Bitmap(backgroundImage.Width, backgroundImage.Height);
                    Color lineColour = Color.FromName(tmpboard.M_lineColour);
                    cls_underlayDefinition ul = new cls_underlayDefinition(5, false, 3, false);
                    ul.DrawUnderlayPaper(backgroundImage.Image, lineColour);
                    Invalidate(); /*/
                    overlayPaintArea1.Visible = true;
                    overlayPaintArea1.BackColor = System.Drawing.ColorTranslator.FromHtml(tmpboard.M_boardColour);
                    overlayPaintArea1.Dock = DockStyle.Fill;
                    overlayPaintArea1.Image = new Bitmap(overlayPaintArea1.Width, overlayPaintArea1.Height);
                    Color lineColour = System.Drawing.ColorTranslator.FromHtml(tmpboard.M_lineColour);
                    if (tmpboard.M_underlayID != null)
                    {
                        cls_underlayDefinition ul = thePresentation.M_underlayDefinition[tmpboard.M_underlayID];
                        if (ul != null)
                        {
                            underlayDraw ud = new underlayDraw(ul);
                            ud.DrawUnderlayPaper(overlayPaintArea1.Image, lineColour);
                        }
                    }
                    Invalidate();
                    overlayPaintArea1.BackgroundImage = tmpboard.background;
                    overlayPaintArea1.BackgroundImageLayout = ImageLayout.Stretch;
                    //overlayPaintArea1.Image = (Bitmap)tmpboard.background;

                    //overlayPaintArea1.BackColor = Color.FromName(tmpboard.M_boardColour);
                    //overlayPaintArea1.BackgroundImage = backgroundImage.Image;
                    //overlayPaintArea1.Dock = DockStyle.Fill;
                    // overlayPaintArea1.Visible = true;
                    magnifyTestBtn.Enabled = true;
                    break;
                case pageType.web:
                    cls_web tmpweb = (cls_web)curPage;
                    webBrowser.Visible = true;
                    webBrowser.Dock = DockStyle.Fill;
                    webBrowser.Navigate(tmpweb.M_url);
                    break;
                case pageType.info:
                    webBrowser.Visible = true;
                    webBrowser.Dock = DockStyle.Fill;
                    webBrowser.Navigate(cls_info.Instance.infoURL);
                    break;
                default:
                    MessageBox.Show("I don't know how to display a " + curPage.GetType().ToString() + "  yet.");
                    break;
            }
            if (curPage.M_penSetID != null)
            {
                setPenSet(curPage.M_penSetID);
            }
            // Form1_Move(null, null);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            package.Close(false);
            if (embeddedHandle != IntPtr.Zero)
            {
                SetParent(embeddedHandle, IntPtr.Zero);
            }
        }

        private void pageTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            pageTree.SelectedNode = e.Node;
        }

        private void thumbnailTimer_Tick(object sender, EventArgs e)
        {
            thumbnailTimer.Stop();
            updateCurPageThumbnail();
        }

        private void resetOverlay_Click(object sender, EventArgs e)
        {
            overlayPaintArea1.Reinitialise();
            Invalidate();
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("User32", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndParent);

        private void embedApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchToPage(cls_info.Instance);
            if (MessageBox.Show("Click OK then click on the application window that you wish to capture images from.", "Embed an application", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                grabAppTimer.Start();

            }
        }

        private void grabAppTimer_Tick(object sender, EventArgs e)
        {
            const int nChars = 256;
            if (embeddedHandle != IntPtr.Zero)
            {
                SetParent(embeddedHandle, IntPtr.Zero);
                embeddedHandle = IntPtr.Zero;
            }

            StringBuilder Buff = new StringBuilder(nChars);
            if ((GetForegroundWindow() != this.Handle) && ((toolForm == null) || (GetForegroundWindow() != toolForm.Handle)))
            {
                embeddedHandle = GetForegroundWindow();

                if (GetWindowText(embeddedHandle, Buff, nChars) > 0)
                {
                    Text = Buff.ToString();
                    grabAppTimer.Stop();
                    SetParent(embeddedHandle, mainPanel.Handle);
                    SetWindowPos(embeddedHandle, new IntPtr(0), 0, 0, mainPanel.Width, mainPanel.Height, 0x0040);
                }
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            releaseApplicationToolStripMenuItem.Enabled = (embeddedHandle != IntPtr.Zero);
        }

        private void releaseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (embeddedHandle != IntPtr.Zero)
            {
                SetParent(embeddedHandle, IntPtr.Zero);
            }
        }

        private void startFromFirstSlideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thePresentation.M_page.Count > 0)
            {
                InPresentationMode = true;
                switchToPage(thePresentation.M_page[0]);
            }
        }

        private void startFromCurrentSlideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thePresentation.M_page.Count > 0)
            {
                InPresentationMode = true;
                if (curPage == null)
                {
                    switchToPage(thePresentation.M_page[0]);
                }
            }
        }

        private void returnToPreparationModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InPresentationMode = false;
        }

        private void slideFromScreen_Click(object sender, EventArgs e)
        {
            cls_board nb = new cls_board();
            nb.M_title = "Slide " + (thePresentation.M_page.Count + 1).ToString();
            nb.M_boardColour = System.Drawing.ColorTranslator.ToHtml(Color.White);
            nb.M_lineColour = System.Drawing.ColorTranslator.ToHtml(Color.PaleTurquoise);
            Bitmap capture = new Bitmap(mainPanel.Width, mainPanel.Height);
            Graphics g2 = Graphics.FromImage(capture);
            Point tr = mainPanel.PointToScreen(new Point(0, 0));
            g2.CopyFromScreen(tr.X, tr.Y, 0, 0, mainPanel.Size);
            nb.background = capture;
            nb.thumb = new Bitmap(capture, new Size(80, 50));
            nb.M_uniqueID = SHA1Util.SHA1HashStringForUTF8String(nb.M_title + DateTime.Now.ToString());
            InsertPage(nb);
        }

        private void slideFromMonitor_Click(object sender, EventArgs e)
        {
            if(captureScreen == null)
            {
                SelectScreen sc = new SelectScreen();
                sc.Prompt = "Select which screen will be captured to slides.";
                if (sc.ShowDialog() == DialogResult.OK)
                    captureScreen = sc.SelectedScreen;
                else
                    return;
            }
            cls_board nb = new cls_board();
            nb.M_title = "Slide " + (thePresentation.M_page.Count + 1).ToString();
            nb.M_boardColour = System.Drawing.ColorTranslator.ToHtml(Color.White);
            nb.M_lineColour = System.Drawing.ColorTranslator.ToHtml(Color.PaleTurquoise);
            int scount = Screen.AllScreens.Length;
            Bitmap capture = new Bitmap(captureScreen.WorkingArea.Width, captureScreen.WorkingArea.Height);
            Graphics g2 = Graphics.FromImage(capture);
            g2.CopyFromScreen(captureScreen.WorkingArea.X, captureScreen.WorkingArea.Y, 0, 0, captureScreen.WorkingArea.Size);
            nb.background = capture;
            nb.thumb = new Bitmap(capture, new Size(80, 50));
            nb.M_uniqueID = SHA1Util.SHA1HashStringForUTF8String(nb.M_title + DateTime.Now.ToString());
            InsertPage(nb);            
        }


        private void displaywebPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            browserSlideProperties props = new browserSlideProperties();
            props.Title = "View a web site";
            if (props.ShowDialog(toolForm) == System.Windows.Forms.DialogResult.OK)
            {
                pageTree.SelectedNode = null;
                cls_web tmpPage = new cls_web();
                tmpPage.M_url = props.Url;
                displayPage(tmpPage);
            }
        }

        private void resetZoom()
        {
            projInfo.pos = mainPanel.PointToScreen(new Point(0, 0));
            projInfo.sz = new Size(mainPanel.Width, mainPanel.Height);
            isZoomed = false;
            magnifyTestBtn.BackColor = Color.LightGray;
            overlayPaintArea1.cancelZoom();
            Invalidate();
        }

        private void mainPanel_Resize(object sender, EventArgs e)
        {
            overlayPaintArea1.Invalidate();
            resetZoom();
        }

        private void splitUnsplitDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchControlPanelLocation();
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolForm != null)
            {
                if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.Sizable)
                {
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            processKey(e);
        }

        public void processKey(KeyEventArgs e)
        {
            //MessageBox.Show("KeyDown\r\n" + e.KeyCode.ToString());
            int cidx = thePresentation.M_page.IndexOf(curPage);
            switch (e.KeyCode)
            {
                case Keys.Next:
                    if ((cidx != -1) && (cidx < thePresentation.M_page.Count - 1))
                    {
                        switchToPage(thePresentation.M_page[cidx + 1]);
                    }
                    break;
                case Keys.PageUp:
                    if ((cidx != -1) && (cidx > 0))
                    {
                        switchToPage(thePresentation.M_page[cidx - 1]);
                    }
                    break;
                case Keys.D1:
                    overlayPaintControls1.selectPenByIdx(0);
                    break;
                case Keys.D2:
                    overlayPaintControls1.selectPenByIdx(1);
                    break;
                case Keys.D3:
                    overlayPaintControls1.selectPenByIdx(2);
                    break;
                case Keys.D4:
                    overlayPaintControls1.selectPenByIdx(3);
                    break;
                case Keys.D5:
                    overlayPaintControls1.selectPenByIdx(4);
                    break;
                case Keys.D6:
                    overlayPaintControls1.selectPenByIdx(5);
                    break;
                case Keys.D7:
                    overlayPaintControls1.selectPenByIdx(6);
                    break;
                case Keys.D8:
                    overlayPaintControls1.selectPenByIdx(7);
                    break;
                case Keys.Z:
                    if(e.Alt)
                    {
                        if(magnifyTestBtn.Enabled)
                            magnifyTestBtn_Click(null, null);
                    }
                    break;

            }
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            overlayPaintArea1.stopWintabInput();
            overlayPaintArea1.startWintabInput();
            //overlayPaintArea1.Reinitialise();
        }

        private void webBrowser_Navigated(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            thumbnailTimer.Start();
            //updateCurPageThumbnail();
        }

        private cls_penSet pensetFromCtrls()
        {
            cls_penSet ps = new cls_penSet();
            for (int n = 1; n <= 7; n++)
            {
                ps.Add_penDefinition(penDefFromPenBtn(n));
            }
            return ps;
        }

        private cls_penDefinition penDefFromPenBtn(int idx)
        {
            cls_penDefinition pd = new cls_penDefinition();
            int size;
            Color colour;
            OverlayPaintArea.penType type;

            if (overlayPaintControls1.getPenBtnInfo(idx, out size, out colour, out type))
            {
                pd.M_size = size;
                pd.M_R = colour.R;
                pd.M_G = colour.G;
                pd.M_B = colour.B;
                pd.M_A = colour.A;
                pd.M_mask = (cls_penDefinition.penmasks)Enum.Parse(typeof(cls_penDefinition.penmasks), type.ToString());
                return pd;
            }
            else
                return null;
        }

        private void onPenUpdated(object sender, EventArgs e)
        {
            if ((curPage != null) && (InPresentationMode == false))
            {
                cls_penSet ps = pensetFromCtrls();
                ps.M_name = curPage.M_title + " pen set.";
                ps.M_id = curPage.M_uniqueID;
                curPage.M_penSetID = curPage.M_uniqueID;
                thePresentation.M_penSet[curPage.M_uniqueID] = ps;
            }
        }



        private void setPenSet(string id)
        {
            if ((thePresentation.M_penSet != null) && (thePresentation.M_penSet.ContainsKey(id)))
            {
                setPenSet(thePresentation.M_penSet[id]);
            }
            else
            {
                if ((defaultPenSets != null) && (defaultPenSets.ContainsKey(id)))
                {
                    setPenSet(defaultPenSets[id]);
                }
            }
        }

        private void setPenSet(cls_penSet penset)
        {
            int max = penset.M_penDefinition.Count < 7 ? penset.M_penDefinition.Count : 7;
            for (int n = 0; n < max; n++)
            {
                cls_penDefinition pd = penset.M_penDefinition[n];
                OverlayPaintArea.penType pt = (OverlayPaintArea.penType)Enum.Parse(typeof(OverlayPaintArea.penType), pd.M_mask.ToString());
                overlayPaintControls1.SetPenBtnInfo(n + 1, pd.M_size, Color.FromArgb(pd.M_A, pd.M_R, pd.M_G, pd.M_B), pt);
            }
        }

        private void projectionTimer_Tick(object sender, EventArgs e)
        {
            
/*            if (theProjection != null)
            {
                if (backimg != null)
                    backimg.Dispose();
                if (isZoomed)
                {
                    backimg = new Bitmap(zoomdx, zoomdy);
                    Graphics g2 = Graphics.FromImage(backimg);
                    Point tr = mainPanel.PointToScreen(new Point(zoomx, zoomy));
                    g2.CopyFromScreen(tr.X, tr.Y, 0, 0, new Size(zoomdx, zoomdy));
                    Point cpos = mainPanel.PointToClient(Cursor.Position);
                    g2.DrawEllipse(Pens.Red, cpos.X - 5 - zoomx, cpos.Y - 5 - zoomy, 10, 10);

                }
                else
                {
                    backimg = new Bitmap(mainPanel.ClientRectangle.Width, mainPanel.ClientRectangle.Height);
                    Graphics g2 = Graphics.FromImage(backimg);
                    Point tr = mainPanel.PointToScreen(new Point(0, 0));
                    g2.CopyFromScreen(tr.X, tr.Y, 0, 0, new Size(mainPanel.ClientRectangle.Width, mainPanel.ClientRectangle.Height));
                    Point cpos = mainPanel.PointToClient(Cursor.Position);
                    g2.DrawEllipse(Pens.Red, cpos.X - 5, cpos.Y - 5, 10, 10);
                }
                theProjection.setPic(backimg);
            }*/
        }

        private void testProjectorPresentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetZoom();           
            if (theProjection == null)
            {
                theProjection = new projection(projInfo);
                theProjection.Show();
                theProjection.TopLevel = true;
                theProjection.TopMost = true;
                int screenCount = Screen.AllScreens.Length;
                //MessageBox.Show(screenCount.ToString());
                if (screenCount >= 2)
                {
                    int projScreen;
                    Screen thisScreen = Screen.FromControl(this);
                    if ((Screen.AllScreens.Length > 1) && (Screen.AllScreens[0].WorkingArea.Location == thisScreen.WorkingArea.Location))
                        projScreen = 1;
                    else
                        projScreen = 0;
                    //projScreen = Screen.AllScreens[0].Bounds == thisScreen.Bounds ? 1 : 0;
                    // MessageBox.Show(projScreen.ToString());
                    theProjection.WindowState = FormWindowState.Normal;
                    theProjection.Top = Screen.AllScreens[projScreen].Bounds.Top + 10;
                    theProjection.Left = Screen.AllScreens[projScreen].Bounds.Left + 10;

                    theProjection.FormBorderStyle = FormBorderStyle.None;
                    theProjection.WindowState = FormWindowState.Maximized;
                }
                this.Focus();
                projectionTimer.Start();
            }
            else
            {
                projectionTimer.Stop();
                theProjection.Hide();
                theProjection.Dispose();
                theProjection = null;

            }
            
        }

        private bool olpVis;

        private void magnifyTestBtn_Click(object sender, EventArgs e)
        {
            if (selMagAreaPicturebox.Visible)
            {
                isZoomed = false;
                zooming = false;
                selMagAreaPicturebox.Hide();
                overlayPaintArea1.Visible = olpVis;
                magnifyTestBtn.BackColor = Color.LightGray;
            }
            else
            {
                if (isZoomed)
                {
                    resetZoom();
                }
                else
                {
                    //projectionTimer.Stop();
                    if (selMagAreaBackimg != null)
                        selMagAreaBackimg.Dispose();
                    selMagAreaBackimg = new Bitmap(mainPanel.ClientRectangle.Width, mainPanel.ClientRectangle.Height);
                    Graphics g2 = Graphics.FromImage(selMagAreaBackimg);
                    Point tr = mainPanel.PointToScreen(new Point(0, 0));
                    g2.CopyFromScreen(tr.X, tr.Y, 0, 0, new Size(mainPanel.ClientRectangle.Width, mainPanel.ClientRectangle.Height));
                    selMagAreaPicturebox.Image = selMagAreaBackimg;
                    //setActiveWindow(pictureBox1);
                    selMagAreaPicturebox.Show();
                    olpVis = overlayPaintArea1.Visible;
                    overlayPaintArea1.Visible = false;
                    selMagAreaPicturebox.Dock = DockStyle.Fill;
                    magnifyTestBtn.BackColor = Color.OrangeRed;
                }
            }
        }

        private void SelectDraw(int X, int Y, int dX, int dY)
        {
            if (selMagAreaBackimg != null)
            {
                if (dX < 0)
                {
                    X += dX;
                    dX *= -1;
                }
                if (dY < 0)
                {
                    Y += dY;
                    dY *= -1;
                }
                Bitmap offscreenBitMap = new Bitmap(selMagAreaPicturebox.Width, selMagAreaPicturebox.Height);
                Graphics offscreenGraphics = Graphics.FromImage(offscreenBitMap);
                offscreenGraphics.DrawImage(selMagAreaBackimg, 0, 0);
                offscreenGraphics.DrawRectangle(Pens.Red, X, Y, dX, dY);

                offscreenGraphics.Dispose();
                selMagAreaPicturebox.Image = offscreenBitMap;
                //offscreenBitMap.Dispose();
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            zoomx = e.X;
            zoomy = e.Y;
            zoomdx = 0;
            zoomdy = 0;
            SelectDraw(zoomx, zoomy, zoomdx, zoomdy);
            zooming = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (zooming)
            {
                zoomdx = e.X - zoomx;
                zoomdy = e.Y - zoomy;
                double ratioX = Convert.ToDouble(Math.Abs(zoomdx)) / selMagAreaPicturebox.Width;
                double ratioY = Convert.ToDouble(Math.Abs(zoomdy)) / selMagAreaPicturebox.Height;
                if (ratioY > ratioX)
                    zoomdx = Convert.ToInt32(selMagAreaPicturebox.Width * ratioY);
                else
                    zoomdy = Convert.ToInt32(selMagAreaPicturebox.Height * ratioX);
                SelectDraw(zoomx, zoomy, zoomdx, zoomdy);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            zooming = false;
            selMagAreaPicturebox.Hide();
            overlayPaintArea1.Visible = olpVis;
            projInfo.pos = mainPanel.PointToScreen(new Point(zoomx, zoomy));
            projInfo.sz = new Size(zoomdx, zoomdy);

            isZoomed = true;
            overlayPaintArea1.Zoom(new Rectangle(zoomx, zoomy, zoomdx, zoomdy));
            magnifyTestBtn.BackColor = Color.PaleGreen;
       }

        private void slideUpBtn_Click(object sender, EventArgs e)
        {
            int idx = thePresentation.M_page.IndexOf(curPage);
            if (idx > 0)
            {
                cls_page cp = RemoveCurPage();
                InsertPage(cp, idx-1);
            }
        }

        private void slideDnBtn_Click(object sender, EventArgs e)
        {
            int idx = thePresentation.M_page.IndexOf(curPage);
            if(idx < thePresentation.M_page.Count - 1)
            {
                cls_page cp = RemoveCurPage();
                InsertPage(cp);
            }
        }

        private void slideFromMonitor_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void pen1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            overlayPaintControls1.selectPenByIdx(0);
        }

        private void pen2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            overlayPaintControls1.selectPenByIdx(1);
        }

        private void experimentBtn_Click(object sender, EventArgs e)
        {
            if(embeddedHandle != IntPtr.Zero)
            {
                if (experimentBtn.BackColor != Color.BlueViolet)
                {
                    SetWindowPos(embeddedHandle, new IntPtr(0), 0, 0, mainPanel.Width, mainPanel.Height, 0x0080);
                    experimentBtn.BackColor = Color.BlueViolet;
                }
                else
                {
                    SetWindowPos(embeddedHandle, new IntPtr(0), 0, 0, mainPanel.Width, mainPanel.Height, 0x0040);
                    experimentBtn.BackColor = SystemColors.ButtonFace;
                }
            }               
        }


    }
}
