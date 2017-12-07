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
                accountsInfo.PendingDebit = GetValueOrNullForDecimal(row, "columnPendingDebit");
                accountsInfo.PendingCredit = GetValueOrNullForDecimal(row, "columnPendingCredit");

                //CreatedBy and UpdatedBy.
                accountsInfo.CreatedBy = ApplicationContext.UserName;
                accountsInfo.UpdatedBy = ApplicationContext.UserName;

                //CreatedDate and UpdatedDate.
                //CreatedDate should come from entry.
                string createdDate = GetValueOrNullForString(row, "columnDateCreated");
                //UpdatedDate should always be the current date.
                string updatedDate = DateTime.Now.Date.ToString("yyyy-MM-dd");//GetValueOrNullForString(row, "columnDateUpdated");
                if (string.IsNullOrEmpty(createdDate))
                {
                    createdDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
                }
                else
                {
                    DateTime inputVal = Convert.ToDateTime(createdDate);
                    createdDate = inputVal.ToString("yyyy-MM-dd");
                }
                if (string.IsNullOrEmpty(updatedDate))
                {
                    updatedDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
                }
                else
                {
                    DateTime inputVal = Convert.ToDateTime(updatedDate);
                    updatedDate = inputVal.ToString("yyyy-MM-dd");
                }

                createdDate = utils.ValidateDate(createdDate);
                updatedDate = utils.ValidateDate(updatedDate);

                accountsInfo.CreatedDate = createdDate;
                accountsInfo.UpdatedDate = updatedDate;

                accountsInfo.Details = GetValueOrNullForString(row, "columnDetails");
                accountsInfo.Tag = GetValueOrNullForString(row, "columnTag");
                if (!(string.IsNullOrEmpty(accountsInfo.ProjectName) || string.IsNullOrEmpty(accountsInfo.Particulars)))
                {
                    accountsInfoColl.Add(accountsInfo);
                }
                else
                {
                    log.Info("Record skipped.");
                    MessageBox.Show("Row has empty ProjectName or Particulars. This row will not be inserted. Remaining will be processed. Press OK to continue.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            var accInfoEmptyData = accountsInfoColl.Where(acc => string.IsNullOrEmpty(acc.ProjectName) || string.IsNullOrEmpty(acc.Particulars));
            if (!(accInfoEmptyData == null || accInfoEmptyData.ToList().Count.Equals(0)))
            {
                log.Info("One or two rows has empty ProjectName or Particulars. These rows will not be inserted. Press OK to continue.");
                if (MessageBox.Show("One or two rows has empty ProjectName or Particulars. These rows will not be inserted. Press OK to continue.", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                    return;
            }

            List<int> errorRecords = new List<int>();
            int i = 0;
            foreach (AccountsInfo accInfo in accountsInfoColl)
            {
                if (!(string.IsNullOrEmpty(accInfo.ProjectName) || string.IsNullOrEmpty(accInfo.Particulars)))
                {
                    try
                    {
                        utils.ExecuteAddAccountsData(accInfo.ProjectName, accInfo.Particulars, accInfo.PayMode, accInfo.BankDetails, accInfo.PayModeReference, accInfo.Debit, accInfo.Credit, accInfo.PendingDebit, accInfo.PendingCredit, accInfo.CreatedBy, accInfo.UpdatedBy, accInfo.Details, accInfo.Tag, accInfo.CreatedDate, accInfo.UpdatedDate);
                        i++;
                    }
                    catch (Exception ex)
                    {
                        log.Info(string.Format("Problem with adding record with ProjectName {0}, Particulars {1}, PayMode {2}, PayModeReference {3}", accInfo.ProjectName, accInfo.Particulars, accInfo.PayMode, accInfo.PayModeReference));
                        errorRecords.Add(i);                       
                    }
                }
            }

            if (errorRecords.Count <= 0)
            {
                log.Info("All data added successfully.");
                MessageBox.Show("All data added successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(string.Format("Records with index {0} has failed. Remaining got updated.", string.Join(",", errorRecords)), "Add Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
