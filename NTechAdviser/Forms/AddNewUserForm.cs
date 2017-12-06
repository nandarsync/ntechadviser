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
    public partial class AddNewUserForm : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(AddNewUserForm));

        public AddNewUserForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ApplicationContext.UserType != 1)
                {
                    MessageBox.Show("Only Administrator can create a new user. Please re-try after logged in as Admin.", "User Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Only Administrator can create a new user.");
                    return;
                }
                UserInfo userInfo = new UserInfo();
                userInfo.UserName = txtUserName.Text;
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    userInfo.Password = txtPassword.Text;
                }
                else
                {
                    MessageBox.Show("Passwords in both text box should match. Please re-try a new password.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Password text do not match. Please re-try.");
                    return;
                }
                userInfo.UserEmail = textEmail.Text;
                userInfo.UserType = chkIsAdmin.Checked ? 1 : 0;

                Utilities utils = new Utilities();

                UserInfo existingUser = utils.GetUserDetails(userInfo.UserName);
                if (existingUser != null && (!string.IsNullOrEmpty(existingUser.UserName)) && existingUser.UserName.ToLower().Equals(userInfo.UserName.ToLower()))
                {
                    MessageBox.Show("User exists already. Please try a different user name.", "User Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("User exists already. Should try a new user name.");
                }
                else
                {
                    utils.AddUserInfo(userInfo.UserName, userInfo.UserEmail, userInfo.Password, userInfo.UserType);
                    log.Info("User added successfully.");
                    MessageBox.Show("User added successfully.", "User Addition", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in user creation. Please refer to log for more details.", "User Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Error in user creation.", ex);
            }
        }
    }
}
