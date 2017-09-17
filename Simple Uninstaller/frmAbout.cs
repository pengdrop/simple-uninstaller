using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SimpleUninstaller
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();

            lblName.Text = Application.ProductName;

            lblVersion.Text = "v" + Application.ProductVersion + " " +
            "(" + (Environment.Is64BitProcess ? "x64" : "x86") + ")";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lnkWebsite.Text);
        }
    }
}
