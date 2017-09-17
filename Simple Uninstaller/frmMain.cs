using System;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Etier.IconHelper;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections.Generic;

namespace SimpleUninstaller
{
    public partial class frmMain : Form
    {
        // api import
        [DllImport("shlwapi.dll", EntryPoint = "PathParseIconLocationA")]
        private extern static int PathParseIconLocation(StringBuilder pszIconFile);

        [DllImport("shlwapi.dll", EntryPoint = "PathUnquoteSpacesA")]
        private extern static void PathUnquoteSpaces(StringBuilder lpsz);

        [DllImport("shlwapi.dll", EntryPoint = "PathRemoveArgsA")]
        private extern static void PathRemoveArgs(StringBuilder pszPath);
        
        [DllImport("shlwapi.dll", EntryPoint = "PathSearchAndQualifyA")]
        private extern static bool PathSearchAndQualify(string pcszPath, StringBuilder pszFullyQualifiedPath, int cchFullyQualifiedPath);

        [DllImport("shlwapi.dll", EntryPoint = "PathRemoveBackslashA")]
        private extern static void PathRemoveBackslash(StringBuilder lpszPath);

        // global variable
        private string strUninstallRegistryLocation;
        private IniFile iniSettings = new IniFile("Settings.ini");

        // global const
        const int ColumnMaxCount = 9;
        const int ColumnMinWidth = 24;

        public frmMain()
        {
            InitializeComponent();

            // set global variable
            if (Environment.Is64BitOperatingSystem)
                strUninstallRegistryLocation = @"Software\" + "Wow6432Node" + @"\Microsoft\Windows\CurrentVersion\Uninstall";
            else
                strUninstallRegistryLocation = @"Software\" + @"Microsoft\Windows\CurrentVersion\Uninstall";

            // set window text
            this.Text = Application.ProductName + " " +
                        "v" + Application.ProductVersion + " " + 
                        "(" + (Environment.Is64BitProcess ? "x64" : "x86") + ") - " +
                        "[" + Environment.MachineName + @"\" + Environment.UserName + "]";

            //ShowConsoleWindow();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // clear controls by ini setting
            if (tsmiSaveWindowLocation.Checked = iniSettings.Read("IsSaveWindowLocation", "WindowInformation", false))
            {
                this.Location = new Point(
                    iniSettings.Read("X", "WindowInformation", this.Location.X), 
                    iniSettings.Read("Y", "WindowInformation", this.Location.Y)
                    );
                this.Size = new Size(
                    iniSettings.Read("Width", "WindowInformation", this.MinimumSize.Width),
                    iniSettings.Read("Height", "WindowInformation", this.MinimumSize.Height)
                    );
            }
            this.TopMost = tsmiAlwaysOnTop.Checked = iniSettings.Read("AlwaysOnTop", "WindowInformation", false);

            tsmiViewSystemComponent.Checked = iniSettings.Read("SystemComponent", "SoftwareVisible", false);
            
            SetColumnHeaders();

            lblState.Text = "Readying..";
        }
        
        private void lvApp_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // lock listview
            ListViewUtil.LockUpdate(lvApp);

            // clear column name
            foreach (ColumnHeader Column in lvApp.Columns)
            {
                Column.Text = Column.Text.Replace(" ∨", "").Replace(" ∧", "");
            }
            
            string strColumnName = lvApp.Columns[e.Column].Text;
            string strSortType = "";

            lblState.Text = "Sorting...";

            if (lvApp.Sorting == SortOrder.Ascending || lvApp.Sorting == SortOrder.None)
            {
                strSortType = "descending";
                lvApp.ListViewItemSorter = new ListViewItemComparer(e.Column, lvApp.Columns[e.Column].Text, SortOrder.Descending);
                lvApp.Sorting = SortOrder.Descending;
                lvApp.Columns[e.Column].Text += " ∨";
            }
            else if(lvApp.Sorting == SortOrder.Descending)
            {
                strSortType = "ascending";
                lvApp.ListViewItemSorter = new ListViewItemComparer(e.Column, lvApp.Columns[e.Column].Text, SortOrder.Ascending);
                lvApp.Sorting = SortOrder.Ascending;
                lvApp.Columns[e.Column].Text += " ∧";
            }
            lvApp.Sort();

            lblState.Text = "Sorted in " + strSortType + " order by " + strColumnName.ToLower() + ".";

            // unlock listview
            ListViewUtil.UnlockUpdate(lvApp);
        }

        private void RefreshInstalledList()
        {
            if (txtSearchKeyword.ForeColor == Color.Black)
            {
                RefreshAppListView(txtSearchKeyword.Text);
            }
            else
            {
                RefreshAppListView();
            }
        }

        private void RefreshAppListView(string strKeyword = "")
        {
            lblState.Text = "Scanning...";

            // backup sort type at before
            SortOrder soTemp = lvApp.Sorting;
            lvApp.Sorting = SortOrder.None;

            // lock listview
            ListViewUtil.LockUpdate(lvApp);

            // clear controls
            Global.siMain.Clear();
            lvApp.Items.Clear();
            imglstAppSmall.Images.Clear();
            picAppIcon.Image = null;
            lblDisplayName.Text = "";
            lblPublisher.Text = "";

            bool isOdd = false;

            // get registrys
            foreach (string strUninstallSubkey in Registry.LocalMachine.OpenSubKey(strUninstallRegistryLocation).GetSubKeyNames())
            {
                // write struct
                SoftwareInformation siTemp = new SoftwareInformation();

                // `Registry Location`
                siTemp.strRegistryLocation = strUninstallRegistryLocation + @"\" + strUninstallSubkey;

                // get registry sub key
                RegistryKey regkeyTemp = Registry.LocalMachine.OpenSubKey(siTemp.strRegistryLocation);
                if (regkeyTemp == null) continue;

                // System Component
                try
                {
                    siTemp.isSystemComponent = ((Int32)regkeyTemp.GetValue("SystemComponent") == 1);
                }
                catch
                {
                    siTemp.isSystemComponent = false;
                }
                if (!tsmiViewSystemComponent.Checked && siTemp.isSystemComponent) continue;

                // `Name`
                siTemp.strDisplayName = (string)regkeyTemp.GetValue("DisplayName");
                if (siTemp.strDisplayName == null) continue;

                // icon
                siTemp.strDisplayIcon = (string)regkeyTemp.GetValue("DisplayIcon");
                {
                    StringBuilder sbTemp = new StringBuilder(siTemp.strDisplayIcon);
                    PathParseIconLocation(sbTemp);
                    siTemp.strDisplayIcon = sbTemp.ToString();
                }

                // `Publisher`
                siTemp.strPublisher = (string)regkeyTemp.GetValue("Publisher");

                // `Version`
                siTemp.strDisplayVersion = (string)regkeyTemp.GetValue("DisplayVersion");

                // `Installed Time`
                siTemp.dtLastWriteTime = RegQuery.lastWriteTime(@"HKEY_LOCAL_MACHINE\" + siTemp.strRegistryLocation);
                string strLastWriteTime = siTemp.dtLastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");

                // filepath of uninstaller
                siTemp.strUninstallString = (string)regkeyTemp.GetValue("UninstallString");
                /*
                // get realpath
                StringBuilder sbQuote = new StringBuilder(siTemp.strUninstallString);
                if (!File.Exists(siTemp.strUninstallString))
                    PathRemoveArgs(sbQuote);
                PathUnquoteSpaces(sbQuote);
                StringBuilder sbUninstallString = new StringBuilder(260);
                PathSearchAndQualify(sbQuote.ToString(), sbUninstallString, 260);
                strUninstallString = sbUninstallString.ToString();
                */

                // `Help Link`
                siTemp.strHelpLink = (string)regkeyTemp.GetValue("HelpLink");

                // `Support Link`
                siTemp.strSupportLink = (string)regkeyTemp.GetValue("URLInfoAbout");

                // `File Location`
                siTemp.strFileLocation = (string)regkeyTemp.GetValue("InstallLocation");
                if (siTemp.strFileLocation == null)
                {
                    if (siTemp.strDisplayIcon != null)
                        siTemp.strFileLocation = FileUtil.DirName(siTemp.strDisplayIcon);
                }
                else
                {
                    StringBuilder sbTemp = new StringBuilder(siTemp.strFileLocation);
                    PathRemoveBackslash(sbTemp);
                    PathUnquoteSpaces(sbTemp);
                    siTemp.strFileLocation = sbTemp.ToString();
                }


                // `Size`
                siTemp.lngFileLocationSize = FileUtil.GetDirSize(siTemp.strFileLocation);
                string strFileLocationSize = siTemp.lngFileLocationSize != -1 ? FileUtil.ConvertHumanReadableFileSize(siTemp.lngFileLocationSize) : null;

                // search filter
                if(!(   (siTemp.strDisplayName != null    && StringUtil.InStr(siTemp.strDisplayName, strKeyword) ) ||
                        (siTemp.strPublisher != null      && StringUtil.InStr(siTemp.strPublisher, strKeyword) ) ||
                        (siTemp.strDisplayVersion != null && StringUtil.InStr(siTemp.strDisplayVersion, strKeyword) ) ||
                        (strLastWriteTime != null        && StringUtil.InStr(strLastWriteTime, strKeyword) ) ||
                        (strFileLocationSize != null  && StringUtil.InStr(strFileLocationSize, strKeyword) )  ))
                {
                    continue;
                }
                
                // large icon for preview
                Icon icoTempLarge = IconReader.GetFileIcon(siTemp.strDisplayIcon, IconReader.IconSize.Large, false);
                siTemp.imgLargeIcon = icoTempLarge.ToBitmap();
                
                // add listview item
                ListViewItem lviTemp = new ListViewItem();
                lviTemp.Text = siTemp.strDisplayName;

                // set small icon
                Icon icoTempSmall = IconReader.GetFileIcon(siTemp.strDisplayIcon, IconReader.IconSize.Small, false);
                imglstAppSmall.Images.Add(icoTempSmall);
                lviTemp.ImageIndex = imglstAppSmall.Images.Count - 1;

                // set subitems
                if (tsmiViewPublisher.Checked)
                    lviTemp.SubItems.Add(siTemp.strPublisher);
                if (tsmiViewVersion.Checked)
                    lviTemp.SubItems.Add(siTemp.strDisplayVersion);
                if (tsmiViewInstallTime.Checked)
                    lviTemp.SubItems.Add(strLastWriteTime);
                if (tsmiViewSize.Checked)
                    lviTemp.SubItems.Add(strFileLocationSize);
                if (tsmiViewHelpLink.Checked)
                    lviTemp.SubItems.Add(siTemp.strHelpLink);
                if (tsmiViewSupportLink.Checked)
                    lviTemp.SubItems.Add(siTemp.strSupportLink);
                if (tsmiViewFileLocation.Checked)
                    lviTemp.SubItems.Add(siTemp.strFileLocation);
                if (tsmiViewRegistryLocation.Checked)
                    lviTemp.SubItems.Add(@"HKEY_LOCAL_MACHINE\" + siTemp.strRegistryLocation);

                // set backcolor
                if (isOdd = !isOdd)
                    lviTemp.BackColor = MyColor.Odd;
                else
                    lviTemp.BackColor = MyColor.Even;
                
                // set forecolor
                if (!FileUtil.IsDir(siTemp.strFileLocation))
                    lviTemp.ForeColor = MyColor.Danger;

                // add struct
                Global.siMain.Add(siTemp);

                // for access to struct by listview item
                ListViewUtil.SetSoftwareInformationIndexOfList(lviTemp, Global.siMain.Count - 1);
                
                lvApp.Items.Add(lviTemp);
                lblInstallCount.Text = "Installations : " + lvApp.Items.Count.ToString();
            }

            // sort
            lblState.Text = "Sorting...";
            lvApp.Sorting = soTemp;
            if (lvApp.Sorting == SortOrder.Ascending) // asc
            {
                for (int i = 0; i < lvApp.Columns.Count; i++)
                {
                    if (lvApp.Columns[i].Text.Contains(" ∧"))
                    {
                        lvApp.ListViewItemSorter = new ListViewItemComparer(i, lvApp.Columns[i].Text.Replace(" ∨", "").Replace(" ∧", ""), SortOrder.Ascending);
                        lvApp.Sorting = SortOrder.Ascending;
                        lvApp.Sort();
                        break;
                    }
                }
            }
            else if (lvApp.Sorting == SortOrder.Descending) // desc
            {
                for (int i = 0; i < lvApp.Columns.Count; i++)
                {
                    if (lvApp.Columns[i].Text.Contains(" ∨"))
                    {
                        lvApp.ListViewItemSorter = new ListViewItemComparer(i, lvApp.Columns[i].Text.Replace(" ∨", "").Replace(" ∧", ""), SortOrder.Descending);
                        lvApp.Sorting = SortOrder.Descending;
                        lvApp.Sort();
                        break;
                    }
                }
            }

            // unlock listview
            ListViewUtil.UnlockUpdate(lvApp);
        }

        private void txtSearchKeyword_GotFocus(object sender, EventArgs e)
        {
            if (txtSearchKeyword.ForeColor == Color.Gray)
            {
                txtSearchKeyword.Text = "";
                txtSearchKeyword.ForeColor = Color.Black;
            }
        }

        private void txtSearchKeyword_LostFocus(object sender, EventArgs e)
        {
            if (txtSearchKeyword.Text == "")
            {
                txtSearchKeyword.ForeColor = Color.Gray;
                txtSearchKeyword.Text = "Search Softwares..";
            }
            else
            {
                txtSearchKeyword.AutoCompleteCustomSource.Add(txtSearchKeyword.Text);
            }
        }

        private void txtSearchKeyword_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchKeyword.ForeColor == Color.Black)
            {
                RefreshAppListView(txtSearchKeyword.Text);
                lblState.Text = "Completed to search.";
            }
        }

        private void lvApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvApp.SelectedItems.Count < 1) return;

            SoftwareInformation siTemp = ListViewUtil.GetSoftwareInformationOfList(lvApp.SelectedItems[0], Global.siMain);
            
            picAppIcon.Image = siTemp.imgLargeIcon;

            lblDisplayName.Text = siTemp.strDisplayName;
            lblPublisher.Text = siTemp.strPublisher;

            lblState.Text = "Selected " + lvApp.SelectedItems.Count.ToString() + " item" + (lvApp.SelectedItems.Count > 1 ? "s" : "") + ".";
            
        }
        
        private void mnuUninstall_Click(object sender, EventArgs e)
        {
            UninstallSelectedItems();
        }

        private void UninstallSelectedItems()
        {
            if (lvApp.SelectedItems.Count < 1) return;

            foreach (ListViewItem lviTemp in lvApp.SelectedItems)
            {
                try
                {
                    SoftwareInformation siTemp = ListViewUtil.GetSoftwareInformationOfList(lviTemp, Global.siMain);

                    lblState.Text = "Uninstalling " + siTemp.strDisplayName + "..";

                    /*
                    int PID = Interaction.Shell(siTemp.strUninstallString, AppWinStyle.NormalFocus);
                    if(PID > 0)
                    {
                        Process proc = Process.GetProcessById(PID);
                        if (proc.HasExited) MessageBox.Show("asd");
                        proc.EnableRaisingEvents = true;
                        proc.Exited += new EventHandler(Process_Exited);
                        // 이벤트 등록하기도 전에 이미 종료됨
                    }*/

                    Process proc = new Process();
                    proc.StartInfo.FileName = siTemp.strUninstallString;
                    proc.EnableRaisingEvents = true;
                    proc.Exited += new EventHandler(Process_Exited);
                    proc.Start();

                    //Console.WriteLine("시작 : " + proc.ProcessName);
                }
                catch
                {
                    lblState.Text = "Failed to uninstall.";
                }
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            Process procMe = (Process)sender;
            //Console.WriteLine("종료 : " + procMe.ProcessName);

            var procChildren = ProcUtil.GetChildProcesses(procMe.Id);
            if(procChildren.Count > 0)
            {
                foreach (Process procChild in procChildren)
                {
                    procChild.EnableRaisingEvents = true;
                    procChild.Exited += new EventHandler(Process_Exited);
                    //Console.WriteLine("자식 : " + procChild.ProcessName);
                }
            }
            else
            {
                RefreshInstalledList();
                lblState.Text = "Completed to uninstall.";
            }
        }

        // ######################################################################################

        public static void ShowConsoleWindow()
        {
            var handle = GetConsoleWindow();
            if (handle == IntPtr.Zero)
                AllocConsole();
            else
                ShowWindow(handle, SW_SHOW);
        }

        public static void HideConsoleWindow()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        // ######################################################################################

        private void trayicoMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (this.Visible)
                {
                    this.Hide();
                    tsmiOpen.Visible = true;
                    tsmiHide.Visible = false;
                }
                else
                {
                    this.Show();
                    tsmiOpen.Visible = false;
                    tsmiHide.Visible = true;
                }
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshInstalledList();
            lblState.Text = "Completed to refresh.";
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiViewSystemComponent_Click(object sender, EventArgs e)
        {
            iniSettings.Write("SystemComponent", !tsmiViewSystemComponent.Checked, "SoftwareVisible");
            tsmiViewSystemComponent.Checked = iniSettings.Read("SystemComponent", "SoftwareVisible", false);

            RefreshInstalledList();
            lblState.Text = "Completed to refresh.";
        }

        private void tsmiAlwaysOnTop_Click(object sender, EventArgs e)
        {
            iniSettings.Write("AlwaysOnTop", !tsmiAlwaysOnTop.Checked, "WindowInformation");
            this.TopMost = tsmiAlwaysOnTop.Checked = iniSettings.Read("AlwaysOnTop", "WindowInformation", false);
        }
        
        private void mnuCopy_Click(object sender, EventArgs e)
        {
            if (lvApp.SelectedItems.Count < 1) return;

            string EofString = lvApp.SelectedItems.Count > 1 ? "\r\n" : "";
            int LoopCount = 0;
            string strCopyData = "";
            foreach (ListViewItem lviTemp in lvApp.SelectedItems)
            {
                for (int DisplayIndex = 0; DisplayIndex < lvApp.Columns.Count; DisplayIndex++)
                {
                    int RealIndex = ListViewUtil.GetIndexByDisplayIndex(lvApp, DisplayIndex);
                    if (RealIndex < 0) continue;

                    strCopyData += lviTemp.SubItems[RealIndex].Text + 
                        (DisplayIndex == lvApp.Columns.Count - 1 ?
                        (LoopCount++ == lvApp.SelectedItems.Count - 1 ? "" : EofString) : 
                        ",\t");
                }
            }

            try
            {
                Clipboard.Clear();
                Clipboard.SetText(strCopyData);

                lblState.Text = "Completed to copy.";
            }
            catch
            {
                lblState.Text = "Failed to copy.";
            }
        }
        
        private void SetColumnHeaders()
        {
            // lock listview
            ListViewUtil.LockUpdate(lvApp);

            ColumnHeaderUtil.Add(
                "Name",
                iniSettings.Read("Name", "ColumnHeaderWidth", 240),
                true,
                iniSettings.Read("Name", "ColumnHeaderDisplayIndex", -1),
                tsmiViewName
                );
            ColumnHeaderUtil.Add(
                "Publisher",
                iniSettings.Read("Publisher", "ColumnHeaderWidth", 200),
                iniSettings.Read("Publisher", "ColumnHeaderVisible", true),
                iniSettings.Read("Publisher", "ColumnHeaderDisplayIndex", -1),
                tsmiViewPublisher
                );
            ColumnHeaderUtil.Add(
                "Version",
                iniSettings.Read("Version", "ColumnHeaderWidth", 80),
                iniSettings.Read("Version", "ColumnHeaderVisible", true),
                iniSettings.Read("Version", "ColumnHeaderDisplayIndex", -1),
                tsmiViewVersion
                );
            ColumnHeaderUtil.Add(
                "Install Time",
                iniSettings.Read("InstallTime", "ColumnHeaderWidth", 140),
                iniSettings.Read("InstallTime", "ColumnHeaderVisible", true),
                iniSettings.Read("InstallTime", "ColumnHeaderDisplayIndex", -1),
                tsmiViewInstallTime
                );
            ColumnHeaderUtil.Add(
                "Size",
                iniSettings.Read("Size", "ColumnHeaderWidth", 80),
                iniSettings.Read("Size", "ColumnHeaderVisible", true),
                iniSettings.Read("Size", "ColumnHeaderDisplayIndex", -1),
                tsmiViewSize
                );
            ColumnHeaderUtil.Add(
                "Help Link",
                iniSettings.Read("HelpLink", "ColumnHeaderWidth", 120),
                iniSettings.Read("HelpLink", "ColumnHeaderVisible", false),
                iniSettings.Read("HelpLink", "ColumnHeaderDisplayIndex", -1),
                tsmiViewHelpLink
                );
            ColumnHeaderUtil.Add(
                "Support Link",
                iniSettings.Read("SupportLink", "ColumnHeaderWidth", 120),
                iniSettings.Read("SupportLink", "ColumnHeaderVisible", false),
                iniSettings.Read("SupportLink", "ColumnHeaderDisplayIndex", -1),
                tsmiViewSupportLink
                );
            ColumnHeaderUtil.Add(
                "File Location",
                iniSettings.Read("FileLocation", "ColumnHeaderWidth", 200),
                iniSettings.Read("FileLocation", "ColumnHeaderVisible", false),
                iniSettings.Read("FileLocation", "ColumnHeaderDisplayIndex", -1),
                tsmiViewFileLocation
                );
            ColumnHeaderUtil.Add(
                "Registry Location",
                iniSettings.Read("RegistryLocation", "ColumnHeaderWidth", 200),
                iniSettings.Read("RegistryLocation", "ColumnHeaderVisible", false),
                iniSettings.Read("RegistryLocation", "ColumnHeaderDisplayIndex", -1),
                tsmiViewRegistryLocation
                );
            ColumnHeaderUtil.Create(lvApp);

            // =======================================================================================

            //lvApp.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            // unlock listview
            ListViewUtil.UnlockUpdate(lvApp);

            RefreshInstalledList();
        }

        private void tsbUninstall_Click(object sender, EventArgs e)
        {
            UninstallSelectedItems();
        }

        private void tsmiViewPublisher_Click(object sender, EventArgs e)
        {
            iniSettings.Write("Publisher", !tsmiViewPublisher.Checked, "ColumnHeaderVisible");
            SetColumnHeaders();
        }

        private void tsmiViewVersion_Click(object sender, EventArgs e)
        {
            iniSettings.Write("Version", !tsmiViewVersion.Checked, "ColumnHeaderVisible");
            SetColumnHeaders();
        }

        private void tsmiViewInstallTime_Click(object sender, EventArgs e)
        {
            iniSettings.Write("InstallTime", !tsmiViewInstallTime.Checked, "ColumnHeaderVisible");
            SetColumnHeaders();
        }

        private void tsmiViewSize_Click(object sender, EventArgs e)
        {
            iniSettings.Write("Size", !tsmiViewSize.Checked, "ColumnHeaderVisible");
            SetColumnHeaders();
        }

        private void tsmiViewHelpLink_Click(object sender, EventArgs e)
        {
            iniSettings.Write("HelpLink", !tsmiViewHelpLink.Checked, "ColumnHeaderVisible");
            SetColumnHeaders();
        }

        private void tsmiViewSupportLink_Click(object sender, EventArgs e)
        {
            iniSettings.Write("SupportLink", !tsmiViewSupportLink.Checked, "ColumnHeaderVisible");
            SetColumnHeaders();
        }

        private void tsmiViewFileLocation_Click(object sender, EventArgs e)
        {
            iniSettings.Write("FileLocation", !tsmiViewFileLocation.Checked, "ColumnHeaderVisible");
            SetColumnHeaders();
        }

        private void tsmiViewRegistryLocation_Click(object sender, EventArgs e)
        {
            iniSettings.Write("RegistryLocation", !tsmiViewRegistryLocation.Checked, "ColumnHeaderVisible");
            SetColumnHeaders();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            this.Show();
            tsmiOpen.Visible = false;
            tsmiHide.Visible = true;
        }

        private void tsmiHide_Click(object sender, EventArgs e)
        {
            this.Hide();
            tsmiOpen.Visible = true;
            tsmiHide.Visible = false;
        }

        private void lvApp_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            // if locked listview
            if (ListViewUtil.IsLockedUpdate(lvApp)) return;

            iniSettings.Write(lvApp.Columns[e.ColumnIndex].Text.Replace(" ", "").Replace("∧", "").Replace("∨", ""), lvApp.Columns[e.ColumnIndex].Width, "ColumnHeaderWidth");
        }

        private void tsmiSaveWindowLocation_Click(object sender, EventArgs e)
        {
            iniSettings.Write("IsSaveWindowLocation", !tsmiSaveWindowLocation.Checked, "WindowInformation");
            tsmiSaveWindowLocation.Checked = iniSettings.Read("IsSaveWindowLocation", "WindowInformation", false);

            if (tsmiSaveWindowLocation.Checked)
            {
                iniSettings.Write("X", this.Location.X, "WindowInformation");
                iniSettings.Write("Y", this.Location.Y, "WindowInformation");
                iniSettings.Write("Width", this.Width, "WindowInformation");
                iniSettings.Write("Height", this.Height, "WindowInformation");
            }
        }

        private void frmMain_Move(object sender, EventArgs e)
        {
            if (tsmiSaveWindowLocation.Checked && this.WindowState == FormWindowState.Normal)
            {
                iniSettings.Write("X", this.Location.X, "WindowInformation");
                iniSettings.Write("Y", this.Location.Y, "WindowInformation");
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (tsmiSaveWindowLocation.Checked && this.WindowState == FormWindowState.Normal)
            {
                iniSettings.Write("Width", this.Width, "WindowInformation");
                iniSettings.Write("Height", this.Height, "WindowInformation");
            }
        }

        private void lvApp_ColumnReordered(object sender, ColumnReorderedEventArgs e)
        {
            // if locked listview
            if (ListViewUtil.IsLockedUpdate(lvApp)) return;
            
            List<int> IndexOrderList = new List<int>();
            
            if(e.OldDisplayIndex < e.NewDisplayIndex)
            {
                for (int i = 0; i < e.OldDisplayIndex; i++)
                    IndexOrderList.Add(ListViewUtil.GetIndexByDisplayIndex(lvApp, i));

                for (int i = e.OldDisplayIndex + 1; i <= e.NewDisplayIndex; i++)
                    IndexOrderList.Add(ListViewUtil.GetIndexByDisplayIndex(lvApp, i));

                IndexOrderList.Add(e.Header.Index);

                for (int i = e.NewDisplayIndex + 1; i < lvApp.Columns.Count; i++)
                    IndexOrderList.Add(ListViewUtil.GetIndexByDisplayIndex(lvApp, i));
            }
            else if (e.OldDisplayIndex > e.NewDisplayIndex)
            {
                for (int i = 0; i < e.NewDisplayIndex; i++)
                    IndexOrderList.Add(ListViewUtil.GetIndexByDisplayIndex(lvApp, i));

                IndexOrderList.Add(e.Header.Index);

                for (int i = e.NewDisplayIndex; i < e.OldDisplayIndex; i++)
                    IndexOrderList.Add(ListViewUtil.GetIndexByDisplayIndex(lvApp, i));

                for (int i = e.OldDisplayIndex + 1; i < lvApp.Columns.Count; i++)
                    IndexOrderList.Add(ListViewUtil.GetIndexByDisplayIndex(lvApp, i));
            }

            for (int i = 0; i < IndexOrderList.Count; i++)
            {
                iniSettings.Write(
                    lvApp.Columns[IndexOrderList[i]].Text.Replace(" ", "").Replace("∧", "").Replace("∨", ""),
                    i.ToString(), 
                    "ColumnHeaderDisplayIndex");
            }
        }

        private void lvApp_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            // if locked listview
            if (ListViewUtil.IsLockedUpdate(lvApp)) return;

            // min width
            if(e.NewWidth < ColumnMinWidth)
            {
                e.Cancel = true;
                e.NewWidth = lvApp.Columns[e.ColumnIndex].Width;
            }
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            
        }

        private void tsmiAllSelect_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem lviTemp in lvApp.Items)
            {
                lviTemp.Selected = true;
            }
        }

        private void lvApp_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                cmsApp.Show(MousePosition.X, MousePosition.Y);
            }
            else
            {
                ListViewHitTestInfo info = lvApp.HitTest(e.X, e.Y);
                if (info == null || info.Item == null)
                    return;

                ListViewItem.ListViewSubItem subItem = info.Item.GetSubItemAt(e.X, e.Y);
                if (subItem == null)
                    return;

                try
                {
                    if (subItem.Text.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase) ||
                        subItem.Text.StartsWith("https://", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Process.Start(subItem.Text);
                    }
                    else if (subItem.Text.StartsWith("HKEY_", StringComparison.CurrentCultureIgnoreCase) && StringUtil.InStr(subItem.Text, "\\"))
                    {
                        RegistryKey regkeyTemp = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Applets\Regedit", true);
                        regkeyTemp.SetValue("Lastkey", subItem.Text.Replace(@"HKEY_LOCAL_MACHINE\", @"HKLM\"), RegistryValueKind.String);
                        regkeyTemp.Close();

                        Process.Start("regedit.exe");
                    }
                    else if (StringUtil.InStr(subItem.Text, "\\"))
                    {
                        Process.Start("explorer.exe", subItem.Text);
                    }
                }
                catch
                {

                }
            }
        }

        private void lvApp_Click(object sender, EventArgs e)
        {
        }

        private void lvApp_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            frmAbout Form = new frmAbout();
            Form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void lvApp_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
        }

        private void lvApp_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = lvApp.HitTest(e.X, e.Y);
            if (info == null || info.Item == null)
                return;

            ListViewItem.ListViewSubItem subItem = info.Item.GetSubItemAt(e.X, e.Y);
            if (subItem == null)
                return;

            if (subItem.Text.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase) ||
                subItem.Text.StartsWith("https://", StringComparison.CurrentCultureIgnoreCase))
            {
                Cursor = Cursors.Hand;
            }
            else if (subItem.Text.StartsWith("HKEY_", StringComparison.CurrentCultureIgnoreCase) && StringUtil.InStr(subItem.Text, "\\"))
            {
                Cursor = Cursors.Hand;
            }
            else if (StringUtil.InStr(subItem.Text, "\\"))
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void tsmiOpenFile_Click(object sender, EventArgs e)
        {
            if (lvApp.SelectedItems.Count < 1) return;

            foreach (ListViewItem lviTemp in lvApp.SelectedItems)
            {
                SoftwareInformation siTemp = ListViewUtil.GetSoftwareInformationOfList(lviTemp, Global.siMain);

                Process.Start("explorer.exe", siTemp.strFileLocation);
            }
        }

        private void tsmiOpenReg_Click(object sender, EventArgs e)
        {
            if (lvApp.SelectedItems.Count < 1) return;

            foreach (ListViewItem lviTemp in lvApp.SelectedItems)
            {
                SoftwareInformation siTemp = ListViewUtil.GetSoftwareInformationOfList(lviTemp, Global.siMain);

                RegistryKey regkeyTemp = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Applets\Regedit", true);
                regkeyTemp.SetValue("Lastkey", @"HKLM\" + siTemp.strRegistryLocation, RegistryValueKind.String);
                regkeyTemp.Close();

                Process.Start("regedit.exe");
            }
        }
    }


}
