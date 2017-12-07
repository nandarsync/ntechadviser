using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NTechAdviser.Forms;
using log4net;
using System.Reflection;
using System.Configuration;

namespace NTechAdviser
{
    public partial class AdviserMain : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(AdviserMain));
        public AdviserMain()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockAddForm addDataForm = new StockAddForm();
            addDataForm.Show();
        }

        private void searchDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm();
            search.Show();
        }

        private void debitViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PendingDebitUpdate pendingDebitUpdate = new PendingDebitUpdate();
            pendingDebitUpdate.Show();
        }

        private void AdviserMain_Load(object sender, EventArgs e)
        {
            //WaitForm waitform = new WaitForm();
            //waitform.Show();

            menuStripMainForm.Enabled = false;

            panelLogin.Visible = true;
            panelLogin.Show();
            panelLogOut.Visible = false;
            panelLogOut.Hide();

            Utilities utils = new Utilities();
            utils.UpdateCacheData();

            //this.lblCompanyName.Text = ConfigurationManager.AppSettings["CompanyName"];
            ApplicationContext.AdminKeyForUpdate = utils.GetUnlockKeyData();
            ApplicationContext.CanContinue = false;

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["AvoidableColumnsForAccountsSearch"]))
                ApplicationContext.AvoidableColumnsForAccountsSearch = ConfigurationManager.AppSettings["AvoidableColumnsForAccountsSearch"].Split(',').ToList();

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["AvoidableColumnsForCreDebSearch"]))
                ApplicationContext.AvoidableColumnsForCreDebSearch = ConfigurationManager.AppSettings["AvoidableColumnsForCreDebSearch"].Split(',').ToList();

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["AvoidableColumnsForStocksSearch"]))
                ApplicationContext.AvoidableColumnsForStocksSearch = ConfigurationManager.AppSettings["AvoidableColumnsForStocksSearch"].Split(',').ToList();

            log.Info("AdviserMain started.");
            //waitform.Close();
        }

        private void stockDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockForm stockDetails = new StockForm();
            stockDetails.Show();
        }

        private void stockSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockSearchForm stockSearchForm = new StockSearchForm();
            stockSearchForm.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void userLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void adminEditKeyChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ApplicationContext.UserType == 1)
            {
                UnlockKeyUpdate unlockKeyForm = new UnlockKeyUpdate();
                unlockKeyForm.ShowDialog();
                if (unlockKeyForm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    //nothing.
                }
            }
            else
            {
                MessageBox.Show("Please login as an administrator to use this option. Only administrators can change this.", "UnlockKey Edit Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewUserForm add = new AddNewUserForm();
            add.ShowDialog();
            if (add.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                //Do nothing.
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet.", "Not implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void userLoginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void loginToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Utilities utils = new Utilities();
                UserInfo userInfo = utils.GetUserDetails(txtUserName.Text);
                if (userInfo != null)
                {
                    if (userInfo.Password != txtPassword.Text)
                    {
                        MessageBox.Show("Password mismatch.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!string.IsNullOrEmpty(userInfo.UserException))
                    {
                        MessageBox.Show(this, "User not found. Please enter valid username and password.", "User Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        ApplicationContext.UserName = userInfo.UserName;
                        ApplicationContext.UserType = userInfo.UserType;
                        ApplicationContext.AdminKeyForUpdate = utils.GetUnlockKeyData();
                        ApplicationContext.IsLoggedIn = true;
                        MessageBox.Show("User logged in successfully.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblUserName.Text = ApplicationContext.UserName;
                        lblUserType.Text = (ApplicationContext.UserType == 0) ? "Non Admin" : "Admin";

                        panelLogOut.Visible = true;
                        panelLogOut.Show();

                        panelLogin.Visible = false;
                        panelLogin.Hide();

                        menuStripMainForm.Enabled = true;
                        this.AcceptButton = btnLogout;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed. Please refer to log for more details.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Login failed.", ex);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void LogOut()
        {
            panelLogOut.Visible = false;
            panelLogOut.Hide();

            panelLogin.Visible = true;
            panelLogin.Show();

            ApplicationContext.UserName = string.Empty;
            ApplicationContext.UserType = 0;
            ApplicationContext.CanContinue = false;
            ApplicationContext.IsLoggedIn = false;

            menuStripMainForm.Enabled = false;
            this.AcceptButton = btnLogin;

            MessageBox.Show("User logged out.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void logOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LogOut();
        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
