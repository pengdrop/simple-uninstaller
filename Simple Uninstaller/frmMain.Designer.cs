namespace SimpleUninstaller
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.imglstAppSmall = new System.Windows.Forms.ImageList(this.components);
            this.cmsApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiUninstall = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiListViewSepa1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenReg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiListViewSepa2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiProp = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.cmsAppShortcut = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAllSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.lvApp = new System.Windows.Forms.ListView();
            this.panTop = new System.Windows.Forms.Panel();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbUninstall = new System.Windows.Forms.ToolStripButton();
            this.tsbSepa1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOptions = new System.Windows.Forms.ToolStripButton();
            this.tsbView = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiViewName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewPublisher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewInstallTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewSize = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewHelpLink = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewSupportLink = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewFileLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewRegistryLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsViewSepa1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiViewSystemComponent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsViewSepa2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAlwaysOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveWindowLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSepa2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbHelp = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.panSearch = new System.Windows.Forms.Panel();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.txtSearchKeyword = new System.Windows.Forms.TextBox();
            this.panBottom = new System.Windows.Forms.Panel();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.picAppIcon = new System.Windows.Forms.PictureBox();
            this.trayicoMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHide = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTraySepa1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.lblState = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblInstallCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.imgColIcon = new System.Windows.Forms.ImageList(this.components);
            this.cmsApp.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.cmsAppShortcut.SuspendLayout();
            this.panTop.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.panSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            this.panBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAppIcon)).BeginInit();
            this.cmsTray.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // imglstAppSmall
            // 
            this.imglstAppSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imglstAppSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imglstAppSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmsApp
            // 
            this.cmsApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUninstall,
            this.tsmiCopy,
            this.tsmiListViewSepa1,
            this.tsmiOpenFile,
            this.tsmiOpenReg,
            this.tsmiListViewSepa2,
            this.tsmiProp});
            this.cmsApp.Name = "cmsApp";
            this.cmsApp.Size = new System.Drawing.Size(207, 148);
            // 
            // tsmiUninstall
            // 
            this.tsmiUninstall.Image = ((System.Drawing.Image)(resources.GetObject("tsmiUninstall.Image")));
            this.tsmiUninstall.Name = "tsmiUninstall";
            this.tsmiUninstall.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmiUninstall.Size = new System.Drawing.Size(206, 22);
            this.tsmiUninstall.Text = "Uninstall";
            this.tsmiUninstall.Click += new System.EventHandler(this.mnuUninstall_Click);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsmiCopy.Image")));
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmiCopy.Size = new System.Drawing.Size(206, 22);
            this.tsmiCopy.Text = "Copy";
            this.tsmiCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // tsmiListViewSepa1
            // 
            this.tsmiListViewSepa1.Name = "tsmiListViewSepa1";
            this.tsmiListViewSepa1.Size = new System.Drawing.Size(203, 6);
            // 
            // tsmiOpenFile
            // 
            this.tsmiOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("tsmiOpenFile.Image")));
            this.tsmiOpenFile.Name = "tsmiOpenFile";
            this.tsmiOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tsmiOpenFile.Size = new System.Drawing.Size(206, 22);
            this.tsmiOpenFile.Text = "Open to file";
            this.tsmiOpenFile.Click += new System.EventHandler(this.tsmiOpenFile_Click);
            // 
            // tsmiOpenReg
            // 
            this.tsmiOpenReg.Image = ((System.Drawing.Image)(resources.GetObject("tsmiOpenReg.Image")));
            this.tsmiOpenReg.Name = "tsmiOpenReg";
            this.tsmiOpenReg.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiOpenReg.Size = new System.Drawing.Size(206, 22);
            this.tsmiOpenReg.Text = "Open to registry";
            this.tsmiOpenReg.Click += new System.EventHandler(this.tsmiOpenReg_Click);
            // 
            // tsmiListViewSepa2
            // 
            this.tsmiListViewSepa2.Name = "tsmiListViewSepa2";
            this.tsmiListViewSepa2.Size = new System.Drawing.Size(203, 6);
            this.tsmiListViewSepa2.Visible = false;
            // 
            // tsmiProp
            // 
            this.tsmiProp.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsmiProp.Image = ((System.Drawing.Image)(resources.GetObject("tsmiProp.Image")));
            this.tsmiProp.Name = "tsmiProp";
            this.tsmiProp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.tsmiProp.Size = new System.Drawing.Size(206, 22);
            this.tsmiProp.Text = "Properties";
            this.tsmiProp.Visible = false;
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ContextMenuStrip = this.cmsAppShortcut;
            this.tlpMain.Controls.Add(this.lvApp, 0, 1);
            this.tlpMain.Controls.Add(this.panTop, 0, 0);
            this.tlpMain.Controls.Add(this.panBottom, 0, 2);
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0, 0, 0, 22);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpMain.Size = new System.Drawing.Size(775, 390);
            this.tlpMain.TabIndex = 18;
            // 
            // cmsAppShortcut
            // 
            this.cmsAppShortcut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAllSelect});
            this.cmsAppShortcut.Name = "cmsApp";
            this.cmsAppShortcut.Size = new System.Drawing.Size(110, 26);
            // 
            // tsmiAllSelect
            // 
            this.tsmiAllSelect.Name = "tsmiAllSelect";
            this.tsmiAllSelect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsmiAllSelect.Size = new System.Drawing.Size(109, 22);
            this.tsmiAllSelect.Visible = false;
            this.tsmiAllSelect.Click += new System.EventHandler(this.tsmiAllSelect_Click);
            // 
            // lvApp
            // 
            this.lvApp.AllowColumnReorder = true;
            this.lvApp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvApp.FullRowSelect = true;
            this.lvApp.Location = new System.Drawing.Point(12, 40);
            this.lvApp.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lvApp.Name = "lvApp";
            this.lvApp.Size = new System.Drawing.Size(751, 294);
            this.lvApp.SmallImageList = this.imglstAppSmall;
            this.lvApp.TabIndex = 26;
            this.lvApp.UseCompatibleStateImageBehavior = false;
            this.lvApp.View = System.Windows.Forms.View.Details;
            this.lvApp.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvApp_ColumnClick);
            this.lvApp.ColumnReordered += new System.Windows.Forms.ColumnReorderedEventHandler(this.lvApp_ColumnReordered);
            this.lvApp.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvApp_ColumnWidthChanged);
            this.lvApp.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvApp_ColumnWidthChanging);
            this.lvApp.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.lvApp_ItemMouseHover);
            this.lvApp.SelectedIndexChanged += new System.EventHandler(this.lvApp_SelectedIndexChanged);
            this.lvApp.Click += new System.EventHandler(this.lvApp_Click);
            this.lvApp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvApp_MouseClick);
            this.lvApp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvApp_MouseDown);
            this.lvApp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvApp_MouseMove);
            // 
            // panTop
            // 
            this.panTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTop.BackColor = System.Drawing.SystemColors.Control;
            this.panTop.Controls.Add(this.tsMain);
            this.panTop.Controls.Add(this.panSearch);
            this.panTop.Location = new System.Drawing.Point(12, 9);
            this.panTop.Margin = new System.Windows.Forms.Padding(12, 9, 12, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(751, 24);
            this.panTop.TabIndex = 32;
            // 
            // tsMain
            // 
            this.tsMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsMain.AutoSize = false;
            this.tsMain.BackColor = System.Drawing.SystemColors.Control;
            this.tsMain.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMain.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefresh,
            this.tsbUninstall,
            this.tsbSepa1,
            this.tsbOptions,
            this.tsbView,
            this.tsbSepa2,
            this.tsbHelp,
            this.tsbExit});
            this.tsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Padding = new System.Windows.Forms.Padding(0);
            this.tsMain.ShowItemToolTips = false;
            this.tsMain.Size = new System.Drawing.Size(519, 24);
            this.tsMain.TabIndex = 33;
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.AutoToolTip = false;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsbRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(66, 20);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbUninstall
            // 
            this.tsbUninstall.AutoToolTip = false;
            this.tsbUninstall.Image = ((System.Drawing.Image)(resources.GetObject("tsbUninstall.Image")));
            this.tsbUninstall.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsbUninstall.Name = "tsbUninstall";
            this.tsbUninstall.Size = new System.Drawing.Size(73, 20);
            this.tsbUninstall.Text = "Uninstall";
            this.tsbUninstall.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbUninstall.Click += new System.EventHandler(this.tsbUninstall_Click);
            // 
            // tsbSepa1
            // 
            this.tsbSepa1.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.tsbSepa1.Name = "tsbSepa1";
            this.tsbSepa1.Size = new System.Drawing.Size(6, 23);
            // 
            // tsbOptions
            // 
            this.tsbOptions.AutoToolTip = false;
            this.tsbOptions.Image = ((System.Drawing.Image)(resources.GetObject("tsbOptions.Image")));
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(69, 20);
            this.tsbOptions.Text = "Options";
            this.tsbOptions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbOptions.Visible = false;
            // 
            // tsbView
            // 
            this.tsbView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewName,
            this.tsmiViewPublisher,
            this.tsmiViewVersion,
            this.tsmiViewInstallTime,
            this.tsmiViewSize,
            this.tsmiViewHelpLink,
            this.tsmiViewSupportLink,
            this.tsmiViewFileLocation,
            this.tsmiViewRegistryLocation,
            this.tsViewSepa1,
            this.tsmiViewSystemComponent,
            this.tsViewSepa2,
            this.tsmiAlwaysOnTop,
            this.tsmiSaveWindowLocation});
            this.tsbView.Image = ((System.Drawing.Image)(resources.GetObject("tsbView.Image")));
            this.tsbView.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsbView.Name = "tsbView";
            this.tsbView.Size = new System.Drawing.Size(62, 20);
            this.tsbView.Text = "View";
            this.tsbView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbView.Click += new System.EventHandler(this.tsbView_Click);
            // 
            // tsmiViewName
            // 
            this.tsmiViewName.Checked = true;
            this.tsmiViewName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiViewName.Enabled = false;
            this.tsmiViewName.Name = "tsmiViewName";
            this.tsmiViewName.Size = new System.Drawing.Size(192, 22);
            this.tsmiViewName.Text = "Name";
            // 
            // tsmiViewPublisher
            // 
            this.tsmiViewPublisher.Name = "tsmiViewPublisher";
            this.tsmiViewPublisher.Size = new System.Drawing.Size(192, 22);
            this.tsmiViewPublisher.Text = "Publisher";
            this.tsmiViewPublisher.Click += new System.EventHandler(this.tsmiViewPublisher_Click);
            // 
            // tsmiViewVersion
            // 
            this.tsmiViewVersion.Name = "tsmiViewVersion";
            this.tsmiViewVersion.Size = new System.Drawing.Size(192, 22);
            this.tsmiViewVersion.Text = "Version";
            this.tsmiViewVersion.Click += new System.EventHandler(this.tsmiViewVersion_Click);
            // 
            // tsmiViewInstallTime
            // 
            this.tsmiViewInstallTime.Name = "tsmiViewInstallTime";
            this.tsmiViewInstallTime.Size = new System.Drawing.Size(192, 22);
            this.tsmiViewInstallTime.Text = "Install Time";
            this.tsmiViewInstallTime.Click += new System.EventHandler(this.tsmiViewInstallTime_Click);
            // 
            // tsmiViewSize
            // 
            this.tsmiViewSize.Name = "tsmiViewSize";
            this.tsmiViewSize.Size = new System.Drawing.Size(192, 22);
            this.tsmiViewSize.Text = "Size";
            this.tsmiViewSize.Click += new System.EventHandler(this.tsmiViewSize_Click);
            // 
            // tsmiViewHelpLink
            // 
            this.tsmiViewHelpLink.Name = "tsmiViewHelpLink";
            this.tsmiViewHelpLink.Size = new System.Drawing.Size(192, 22);
            this.tsmiViewHelpLink.Text = "Help Link";
            this.tsmiViewHelpLink.Click += new System.EventHandler(this.tsmiViewHelpLink_Click);
            // 
            // tsmiViewSupportLink
            // 
            this.tsmiViewSupportLink.Name = "tsmiViewSupportLink";
            this.tsmiViewSupportLink.Size = new System.Drawing.Size(192, 22);
            this.tsmiViewSupportLink.Text = "Support Link";
            this.tsmiViewSupportLink.Click += new System.EventHandler(this.tsmiViewSupportLink_Click);
            // 
            // tsmiViewFileLocation
            // 
            this.tsmiViewFileLocation.Name = "tsmiViewFileLocation";
            this.tsmiViewFileLocation.Size = new System.Drawing.Size(192, 22);
            this.tsmiViewFileLocation.Text = "File Location";
            this.tsmiViewFileLocation.Click += new System.EventHandler(this.tsmiViewFileLocation_Click);
            // 
            // tsmiViewRegistryLocation
            // 
            this.tsmiViewRegistryLocation.Name = "tsmiViewRegistryLocation";
            this.tsmiViewRegistryLocation.Size = new System.Drawing.Size(192, 22);
            this.tsmiViewRegistryLocation.Text = "Registry Location";
            this.tsmiViewRegistryLocation.Click += new System.EventHandler(this.tsmiViewRegistryLocation_Click);
            // 
            // tsViewSepa1
            // 
            this.tsViewSepa1.Name = "tsViewSepa1";
            this.tsViewSepa1.Size = new System.Drawing.Size(189, 6);
            // 
            // tsmiViewSystemComponent
            // 
            this.tsmiViewSystemComponent.Name = "tsmiViewSystemComponent";
            this.tsmiViewSystemComponent.Size = new System.Drawing.Size(192, 22);
            this.tsmiViewSystemComponent.Text = "System Component";
            this.tsmiViewSystemComponent.Click += new System.EventHandler(this.tsmiViewSystemComponent_Click);
            // 
            // tsViewSepa2
            // 
            this.tsViewSepa2.Name = "tsViewSepa2";
            this.tsViewSepa2.Size = new System.Drawing.Size(189, 6);
            // 
            // tsmiAlwaysOnTop
            // 
            this.tsmiAlwaysOnTop.Name = "tsmiAlwaysOnTop";
            this.tsmiAlwaysOnTop.Size = new System.Drawing.Size(192, 22);
            this.tsmiAlwaysOnTop.Text = "Always on top";
            this.tsmiAlwaysOnTop.Click += new System.EventHandler(this.tsmiAlwaysOnTop_Click);
            // 
            // tsmiSaveWindowLocation
            // 
            this.tsmiSaveWindowLocation.Name = "tsmiSaveWindowLocation";
            this.tsmiSaveWindowLocation.Size = new System.Drawing.Size(192, 22);
            this.tsmiSaveWindowLocation.Text = "Save window location";
            this.tsmiSaveWindowLocation.Click += new System.EventHandler(this.tsmiSaveWindowLocation_Click);
            // 
            // tsbSepa2
            // 
            this.tsbSepa2.Margin = new System.Windows.Forms.Padding(2, 0, 4, 0);
            this.tsbSepa2.Name = "tsbSepa2";
            this.tsbSepa2.Size = new System.Drawing.Size(6, 23);
            // 
            // tsbHelp
            // 
            this.tsbHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCheckForUpdates,
            this.tsmiAbout});
            this.tsbHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsbHelp.Image")));
            this.tsbHelp.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsbHelp.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tsbHelp.Name = "tsbHelp";
            this.tsbHelp.Size = new System.Drawing.Size(61, 20);
            this.tsbHelp.Text = "Help";
            // 
            // tsmiCheckForUpdates
            // 
            this.tsmiCheckForUpdates.Image = ((System.Drawing.Image)(resources.GetObject("tsmiCheckForUpdates.Image")));
            this.tsmiCheckForUpdates.Name = "tsmiCheckForUpdates";
            this.tsmiCheckForUpdates.Size = new System.Drawing.Size(172, 22);
            this.tsmiCheckForUpdates.Text = "Check for updates";
            this.tsmiCheckForUpdates.Visible = false;
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAbout.Image")));
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(172, 22);
            this.tsmiAbout.Text = "About";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.AutoToolTip = false;
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(46, 20);
            this.tsbExit.Text = "Exit";
            this.tsbExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // panSearch
            // 
            this.panSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panSearch.Controls.Add(this.picSearch);
            this.panSearch.Controls.Add(this.txtSearchKeyword);
            this.panSearch.Location = new System.Drawing.Point(524, 0);
            this.panSearch.Margin = new System.Windows.Forms.Padding(0);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(227, 23);
            this.panSearch.TabIndex = 32;
            // 
            // picSearch
            // 
            this.picSearch.BackColor = System.Drawing.Color.Transparent;
            this.picSearch.Image = ((System.Drawing.Image)(resources.GetObject("picSearch.Image")));
            this.picSearch.Location = new System.Drawing.Point(0, 0);
            this.picSearch.Margin = new System.Windows.Forms.Padding(0);
            this.picSearch.Name = "picSearch";
            this.picSearch.Padding = new System.Windows.Forms.Padding(3);
            this.picSearch.Size = new System.Drawing.Size(23, 23);
            this.picSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSearch.TabIndex = 21;
            this.picSearch.TabStop = false;
            // 
            // txtSearchKeyword
            // 
            this.txtSearchKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtSearchKeyword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearchKeyword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearchKeyword.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSearchKeyword.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchKeyword.Location = new System.Drawing.Point(25, 0);
            this.txtSearchKeyword.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.txtSearchKeyword.Name = "txtSearchKeyword";
            this.txtSearchKeyword.Size = new System.Drawing.Size(202, 23);
            this.txtSearchKeyword.TabIndex = 18;
            this.txtSearchKeyword.Text = "Search Softwares";
            this.txtSearchKeyword.TextChanged += new System.EventHandler(this.txtSearchKeyword_TextChanged);
            this.txtSearchKeyword.GotFocus += new System.EventHandler(this.txtSearchKeyword_GotFocus);
            this.txtSearchKeyword.LostFocus += new System.EventHandler(this.txtSearchKeyword_LostFocus);
            // 
            // panBottom
            // 
            this.panBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBottom.Controls.Add(this.lblPublisher);
            this.panBottom.Controls.Add(this.lblDisplayName);
            this.panBottom.Controls.Add(this.picAppIcon);
            this.panBottom.Location = new System.Drawing.Point(12, 346);
            this.panBottom.Margin = new System.Windows.Forms.Padding(12);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(751, 32);
            this.panBottom.TabIndex = 43;
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.BackColor = System.Drawing.Color.Transparent;
            this.lblPublisher.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPublisher.Location = new System.Drawing.Point(42, 17);
            this.lblPublisher.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblPublisher.MinimumSize = new System.Drawing.Size(250, 15);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(250, 15);
            this.lblPublisher.TabIndex = 30;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.BackColor = System.Drawing.Color.Transparent;
            this.lblDisplayName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDisplayName.Location = new System.Drawing.Point(42, 0);
            this.lblDisplayName.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblDisplayName.MinimumSize = new System.Drawing.Size(250, 15);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(250, 15);
            this.lblDisplayName.TabIndex = 29;
            // 
            // picAppIcon
            // 
            this.picAppIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picAppIcon.Location = new System.Drawing.Point(0, 0);
            this.picAppIcon.Margin = new System.Windows.Forms.Padding(0);
            this.picAppIcon.Name = "picAppIcon";
            this.picAppIcon.Size = new System.Drawing.Size(32, 32);
            this.picAppIcon.TabIndex = 28;
            this.picAppIcon.TabStop = false;
            // 
            // trayicoMain
            // 
            this.trayicoMain.ContextMenuStrip = this.cmsTray;
            this.trayicoMain.Icon = ((System.Drawing.Icon)(resources.GetObject("trayicoMain.Icon")));
            this.trayicoMain.Text = "Simple Uninstaller";
            this.trayicoMain.Visible = true;
            this.trayicoMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayicoMain_MouseDoubleClick);
            // 
            // cmsTray
            // 
            this.cmsTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.tsmiHide,
            this.tsTraySepa1,
            this.tsmiExit});
            this.cmsTray.Name = "cmsTray";
            this.cmsTray.Size = new System.Drawing.Size(104, 76);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsmiOpen.Image")));
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(103, 22);
            this.tsmiOpen.Text = "Open";
            this.tsmiOpen.Visible = false;
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiHide
            // 
            this.tsmiHide.Image = ((System.Drawing.Image)(resources.GetObject("tsmiHide.Image")));
            this.tsmiHide.Name = "tsmiHide";
            this.tsmiHide.Size = new System.Drawing.Size(103, 22);
            this.tsmiHide.Text = "Hide";
            this.tsmiHide.Click += new System.EventHandler(this.tsmiHide_Click);
            // 
            // tsTraySepa1
            // 
            this.tsTraySepa1.Name = "tsTraySepa1";
            this.tsTraySepa1.Size = new System.Drawing.Size(100, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Image = ((System.Drawing.Image)(resources.GetObject("tsmiExit.Image")));
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(103, 22);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblState,
            this.lblInstallCount});
            this.ssMain.Location = new System.Drawing.Point(0, 389);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(775, 22);
            this.ssMain.TabIndex = 19;
            // 
            // lblState
            // 
            this.lblState.AutoSize = false;
            this.lblState.Image = ((System.Drawing.Image)(resources.GetObject("lblState.Image")));
            this.lblState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblState.Margin = new System.Windows.Forms.Padding(3, 3, 0, 2);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(300, 17);
            this.lblState.Text = "Readying..";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInstallCount
            // 
            this.lblInstallCount.AutoSize = false;
            this.lblInstallCount.Image = ((System.Drawing.Image)(resources.GetObject("lblInstallCount.Image")));
            this.lblInstallCount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInstallCount.Name = "lblInstallCount";
            this.lblInstallCount.Size = new System.Drawing.Size(150, 17);
            this.lblInstallCount.Text = "Installations : 0";
            this.lblInstallCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInstallCount.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // imgColIcon
            // 
            this.imgColIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgColIcon.ImageStream")));
            this.imgColIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imgColIcon.Images.SetKeyName(0, "if_application_4970.png");
            this.imgColIcon.Images.SetKeyName(1, "if_Company_132680.png");
            this.imgColIcon.Images.SetKeyName(2, "if_edit-number_45989.png");
            this.imgColIcon.Images.SetKeyName(3, "if_clock_16162.png");
            this.imgColIcon.Images.SetKeyName(4, "if_Copy_1493280.png");
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 411);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(791, 450);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Move += new System.EventHandler(this.frmMain_Move);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.cmsApp.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.cmsAppShortcut.ResumeLayout(false);
            this.panTop.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.panSearch.ResumeLayout(false);
            this.panSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            this.panBottom.ResumeLayout(false);
            this.panBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAppIcon)).EndInit();
            this.cmsTray.ResumeLayout(false);
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imglstAppSmall;
        private System.Windows.Forms.ContextMenuStrip cmsApp;
        private System.Windows.Forms.ToolStripMenuItem tsmiUninstall;
        private System.Windows.Forms.ToolStripSeparator tsmiListViewSepa1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenReg;
        private System.Windows.Forms.ToolStripMenuItem tsmiProp;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.ListView lvApp;
        private System.Windows.Forms.NotifyIcon trayicoMain;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.Panel panSearch;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.TextBox txtSearchKeyword;
        private System.Windows.Forms.Panel panBottom;
        private System.Windows.Forms.PictureBox picAppIcon;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel lblState;
        private System.Windows.Forms.ToolStripStatusLabel lblInstallCount;
        private System.Windows.Forms.ToolStripButton tsbOptions;
        private System.Windows.Forms.ToolStripSeparator tsbSepa1;
        private System.Windows.Forms.ToolStripButton tsbUninstall;
        private System.Windows.Forms.ToolStripSeparator tsbSepa2;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripDropDownButton tsbView;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewPublisher;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewVersion;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewInstallTime;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewSize;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewFileLocation;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewRegistryLocation;
        private System.Windows.Forms.ToolStripSeparator tsViewSepa1;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewSystemComponent;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewName;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewHelpLink;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewSupportLink;
        private System.Windows.Forms.ToolStripSeparator tsViewSepa2;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlwaysOnTop;
        private System.Windows.Forms.ContextMenuStrip cmsTray;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripSeparator tsTraySepa1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiHide;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveWindowLocation;
        private System.Windows.Forms.ImageList imgColIcon;
        private System.Windows.Forms.ToolStripDropDownButton tsbHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiCheckForUpdates;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ContextMenuStrip cmsAppShortcut;
        private System.Windows.Forms.ToolStripMenuItem tsmiAllSelect;
        private System.Windows.Forms.ToolStripSeparator tsmiListViewSepa2;
    }
}

