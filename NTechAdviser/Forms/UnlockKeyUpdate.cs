using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace NTechAdviser.Forms
{
    public partial class UnlockKeyUpdate : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(SearchForm));
        public UnlockKeyUpdate()
        {
            InitializeComponent();
        }

        private void formUnlockKey_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateKey_Click(object sender, EventArgs e)
        {
            try
            {
                if (ApplicationContext.UserName != null && ApplicationContext.UserType == 1)
                {
                    Utilities utils = new Utilities();
                    string encryptedKey = txtPassword.Text;
                    utils.AddUnlockKeyData(encryptedKey);
                    MessageBox.Show("New key updated.");
                }
                else
                {
                    MessageBox.Show("This feature is only for administrators.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during unlock key update. Please check log for more details.", "Unlock Key Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Error during unlock key update.", ex);
            }
        }
    }
}
