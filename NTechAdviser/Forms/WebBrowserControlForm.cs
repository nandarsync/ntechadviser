using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NTechAdviser.Forms
{
    public partial class WebBrowserControlForm : Form
    {
        public WebBrowserControlForm()
        {
            InitializeComponent();
        }

        string htmlContent = string.Empty;
        public WebBrowserControlForm(string htmlContent)
        {
            InitializeComponent();

            this.htmlContent = htmlContent;
        }

        private void WebBrowserControlForm_Load(object sender, EventArgs e)
        {
            this.webBrowser1.DocumentText = htmlContent;
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pageSetupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.ShowPageSetupDialog();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.webBrowser1.ShowPrintPreviewDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.webBrowser1.ShowPrintDialog();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.ShowPrintDialog();
        }
    }
}
