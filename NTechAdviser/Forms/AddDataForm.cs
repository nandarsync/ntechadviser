using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NTechAdviser.Forms
{
    public partial class StockAddForm : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(StockAddForm)); 
        public StockAddForm()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            Utilities utils = new Utilities();
            List<AccountsInfo> accountsInfoColl = new List<AccountsInfo>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                AccountsInfo accountsInfo = new AccountsInfo();
                accountsInfo.ProjectName = GetValueOrNullForString(row, "columnProject");
                accountsInfo.Particulars = GetValueOrNullForString(row, "columnParticulars");
                accountsInfo.PayMode = GetValueOrNullForString(row, "columnPaymode");
                accountsInfo.BankDetails = GetValueOrNullForString(row, "columnBankDetails");
                accountsInfo.PayModeReference = GetValueOrNullForString(row, "columnPayModeReference");
                accountsInfo.Debit = GetValueOrNullForDecimal(row, "columnDebit");
                accountsInfo.Credit = GetValueOrNullForDecimal(row, "columnCredit");
                accountsInfo.PendingDebit = 0;
                accountsInfo.PendingCredit = 0;
                accountsInfo.Details = GetValueOrNullForString(row, "columnDetails");
                accountsInfo.Tag = GetValueOrNullForString(row, "columnTag");
                accountsInfoColl.Add(accountsInfo);
            }
            var accInfoEmptyData = accountsInfoColl.Where(acc => string.IsNullOrEmpty(acc.ProjectName) || string.IsNullOrEmpty(acc.Particulars));
            if (!(accInfoEmptyData == null || accInfoEmptyData.ToList().Count.Equals(0)))
            {
                log.Info("One or two rows has empty ProjectName or Particulars. These rows will not be inserted. Press OK to continue.");
                if (MessageBox.Show("One or two rows has empty ProjectName or Particulars. These rows will not be inserted. Press OK to continue.", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                    return;
            }

            int i = 0;
            foreach (AccountsInfo accInfo in accountsInfoColl)
            {
                if (!(string.IsNullOrEmpty(accInfo.ProjectName) || string.IsNullOrEmpty(accInfo.Particulars)))
                {
                    try
                    {
                        utils.ExecuteAddAccountsData(accInfo.ProjectName, accInfo.Particulars, accInfo.PayMode, accInfo.BankDetails, accInfo.PayModeReference, accInfo.Debit, accInfo.Credit, accInfo.PendingDebit, accInfo.PendingCredit, accInfo.Details, accInfo.Tag);
                        i++;
                    }
                    catch (Exception ex)
                    {
                        log.Info(string.Format("Problem with adding record with ProjectName {0}, Particulars {1}, PayMode {2}, PayModeReference {3}", accInfo.ProjectName, accInfo.Particulars, accInfo.PayMode, accInfo.PayModeReference));
                        MessageBox.Show(string.Format("Problem with adding record with ProjectName {0}, Particulars {1}, PayMode {2}, PayModeReference {3}", accInfo.ProjectName, accInfo.Particulars, accInfo.PayMode, accInfo.PayModeReference), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            if (i != 0)
            {
                log.Info("All data added successfully.");
                MessageBox.Show("All data added successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetValueOrNullForString(DataGridViewRow row, string columnName)
        {
            string retVal = string.Empty;
            retVal = (row.Cells[columnName].Value == null) ? string.Empty : row.Cells[columnName].Value.ToString();
            return retVal;
        }

        private Decimal GetValueOrNullForDecimal(DataGridViewRow row, string columnName)
        {
            Decimal retVal = 0;
            retVal = (row.Cells[columnName].Value == null) ? 0 : Convert.ToDecimal(row.Cells[columnName].Value);
            return retVal;
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStripAddData_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
