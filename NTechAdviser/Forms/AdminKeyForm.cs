using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace NTechAdviser.Forms
{
    public partial class AdminKeyForm : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(AddNewUserForm));
        public AdminKeyForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utilities utils = new Utilities();
            if (ApplicationContext.UserName != null && ApplicationContext.UserType != 1)
            {
                if (textBox1.Text == ApplicationContext.AdminKeyForUpdate)
                {
                    log.Info("Can continue check. - Yes.");
                    ApplicationContext.CanContinue = true;
                }
                else
                {
                    log.Info("Invalid Key. Data will not be saved. Please refresh this page again to see the old data.");
                    MessageBox.Show("Invalid Key. Data will not be saved. Please refresh this page again to see the old data.", "Unlock key check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ApplicationContext.CanContinue = false;
                }
            }
        }
    }
}
