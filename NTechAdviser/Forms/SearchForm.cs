using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;
using NTechAdviser.Print;
using System.IO;
using System.Reflection;

namespace NTechAdviser.Forms
{
    public partial class SearchForm : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(SearchForm));
        public SearchForm()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetDebitInfoDataSet();
                if (ds != null && ds.Tables.Count > 0)
                {
                    this.dataGridViewSearch.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Some problem in searching for the data. Please refer log files for details.");
                }
            }
            catch (Exception ex)
            {
                log.Error("Error getting data during search.", ex);
                MessageBox.Show("Some problem in searching for the data. Please refer log files for details.");
            }
        }

        public DataSet GetDebitInfoDataSet()
        {
            DataSet retVal = new DataSet();
            Utilities utils = new Utilities();
            BuildSearchQuery quer = new BuildSearchQuery();
            string query = quer.BuildQuery(comboProjName.Text, comboParticular.Text, SearchModeEnum.DebitData);

            if (string.IsNullOrEmpty(query))
            {
                Console.WriteLine("No query to search.");
                return retVal;
            }

            retVal = utils.GetManagementInfoDataSet(query);

            string[] columnsOrder = File.ReadAllLines("accounts_info_column_order.txt");
            if (columnsOrder != null && columnsOrder.Length > 1)
            {
                try
                {
                    utils.SetColumnsOrder(retVal, columnsOrder);
                }
                catch (Exception ex)
                {
                    log.Error("Failed to order columns.", ex);
                }
            }
            return retVal;
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            string cmdString = "select * from accounts_info order by DateCreated";
            Utilities utils = new Utilities();
            DataSet ds = utils.GetManagementInfoDataSet(cmdString);
            string[] columnsOrder = File.ReadAllLines("accounts_info_column_order.txt");
            if (columnsOrder != null && columnsOrder.Length > 1)
            {
                try
                {
                    utils.SetColumnsOrder(ds, columnsOrder);
                }
                catch (Exception ex)
                {
                    log.Error("Failed to order columns.", ex);
                }
            }
            this.dataGridViewSearch.DataSource = ds.Tables[0];
        }

        private void updateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateData(true);
        }

        private void UpdateData(bool silent)
        {
            DataGridViewSelectedRowCollection dataGridViewRowColl = dataGridViewSearch.SelectedRows;
            List<AccountsInfo> accountsInfoColl = new List<AccountsInfo>();
            foreach (DataGridViewRow row in dataGridViewRowColl)
            {
                accountsInfoColl.Add(GetAccountsInfo(row));
            }
            UpdateAccountsInfoCollToDB(silent, accountsInfoColl);
        }

        private List<AccountsInfo> GetAllCurrentDataFromGridView()
        {
            DataGridViewRowCollection dataGridViewRowColl = dataGridViewSearch.Rows;
            List<AccountsInfo> accountsInfoColl = new List<AccountsInfo>();
            foreach (DataGridViewRow row in dataGridViewRowColl)
            {
                accountsInfoColl.Add(GetAccountsInfo(row));
            }
            return accountsInfoColl;
        }

        private AccountsInfo GetAccountsInfo(DataGridViewRow row)
        {
            AccountsInfo accountsInfo = new AccountsInfo();
            accountsInfo.RecordID = GetValueOrNullForInt(row, "RecordID");
            accountsInfo.CreatedBy = GetValueOrNullForString(row, "CreatedBy");
            accountsInfo.UpdatedBy = GetValueOrNullForString(row, "UpdatedBy");
            accountsInfo.UpdatedDate = GetValueOrNullForString(row, "DateUpdated");
            accountsInfo.ProjectName = GetValueOrNullForString(row, "Project");
            accountsInfo.Particulars = GetValueOrNullForString(row, "Particulars");
            accountsInfo.PayMode = GetValueOrNullForString(row, "PayMode");
            accountsInfo.BankDetails = GetValueOrNullForString(row, "BankDetails");
            accountsInfo.PayModeReference = GetValueOrNullForString(row, "PayModeReference");
            accountsInfo.Debit = GetValueOrNullForDecimal(row, "Debit");
            accountsInfo.Credit = GetValueOrNullForDecimal(row, "Credit");
            //This goes to CreditDebit info form.
            //accountsInfo.PendingDebit = GetValueOrNullForDecimal(row, "PendingDebit");
            //accountsInfo.PendingCredit = GetValueOrNullForDecimal(row, "PendingCredit");
            accountsInfo.Details = GetValueOrNullForString(row, "Details");
            accountsInfo.Tag = GetValueOrNullForString(row, "Tag");

            return accountsInfo;
        }

        private void UpdateAccountsInfoCollToDB(bool silent, List<AccountsInfo> accountsInfoColl)
        {
            Utilities utils = new Utilities();
            var accInfoEmptyData = accountsInfoColl.Where(acc => string.IsNullOrEmpty(acc.ProjectName) || string.IsNullOrEmpty(acc.Particulars));
            if (!(accInfoEmptyData == null || accInfoEmptyData.ToList().Count.Equals(0)))
            {
                if (!silent)
                {
                    if (MessageBox.Show("One or two rows has empty ProjectName or Particulars. These rows will not be updated. Press OK to continue.", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                        return;
                }
                else
                {

                }
            }

            int i = 0;
            foreach (AccountsInfo accInfo in accountsInfoColl)
            {
                try
                {
                    utils.UpdateAcccountsData(accInfo);
                    i++;
                }
                catch (Exception ex)
                {
                    if (!silent)
                    {
                        MessageBox.Show(string.Format("Problem with updating record with ProjectName {0}, Particulars {1}, PayMode {2}, PayModeReference {3}", accInfo.ProjectName, accInfo.Particulars, accInfo.PayMode, accInfo.PayModeReference), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                    }
                }
            }

            if (i != 0)
            {
                if (!silent)
                {
                    MessageBox.Show("All data updated successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ApplicationContext.PrintContentGenerated = false;
            //PrintDataGrid.PrintDGV.Print_DataGridView(dataGridViewSearch);
            PrintFileGenerator printFileGen = new PrintFileGenerator();
            printFileGen.GeneratePrintFile(dataGridViewSearch, "SearchForm");

            List<AccountsInfo> accountsinfoColl = GetAllCurrentDataFromGridView();
            string printFileContent = CreatePrintFile(printFileGen, accountsinfoColl);

            if (ApplicationContext.PrintContentGenerated)
            {
                WebBrowserControlForm webBrowserControlForm = new WebBrowserControlForm(printFileContent);
                webBrowserControlForm.Show();
            }
            ////return; //Use this for debugging.
            //// Create a WebBrowser instance. 
            //WebBrowser webBrowserForPrinting = new WebBrowser();

            //// Add an event handler that prints the document after it loads.
            //webBrowserForPrinting.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(PrintDocument);

            //// Set the Url property to load the document.
            //webBrowserForPrinting.DocumentText = printFileContent;
        }

        private void PrintDocument(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = sender as WebBrowser;

            webBrowser.ShowPrintDialog();

            // Print the document now that it is fully loaded.
            ((WebBrowser)sender).Print();

            // Dispose the WebBrowser now that the task is complete. 
            ((WebBrowser)sender).Dispose();
        }

        decimal totalCredit;
        decimal totalDebit;
        private string CreatePrintFile(PrintFileGenerator printFileGen, List<AccountsInfo> accountsinfoColl)
        {
            string retVal = string.Empty;
            string headerString = string.Empty;

            if (accountsinfoColl.Count > 0)
            {
                totalCredit = accountsinfoColl.Sum(item => item.Credit); //Amt Received.
                totalDebit = accountsinfoColl.Sum(item => item.Debit); //Amount Given.

                //Add the total amount to the list.
                AccountsInfo accInfoTotal = new AccountsInfo();
                accInfoTotal.Particulars = "Total";
                accInfoTotal.Credit = totalCredit;
                accInfoTotal.Debit = totalDebit;

                accountsinfoColl.Add(accInfoTotal);
            }

            foreach (string str in printFileGen.SelectedColumns)
            {
                headerString = headerString + ("<td id=\"headerRow\">" + str + "</td>");
            }
            headerString = "<tr>" + headerString + "</tr>";

            List<string> tableCellsForBody = new List<string>();
            foreach (AccountsInfo accInfo in accountsinfoColl)
            {
                string rowString = string.Empty;
                foreach (string str in printFileGen.SelectedColumns)
                {
                    if (str.Equals("RecordID", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.RecordID + "</td>");
                    }
                    else if (str.Equals("DateCreated", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.CreatedDate + "</td>");
                    }
                    else if (str.Equals("CreatedBy", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.CreatedBy + "</td>");
                    }
                    if (str.Equals("DateUpdated", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.UpdatedDate + "</td>");
                    }
                    else if (str.Equals("UpdatedBy", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.UpdatedBy + "</td>");
                    }
                    else if (str.Equals("Project", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.ProjectName + "</td>");
                    }
                    else if (str.Equals("Particulars", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.Particulars + "</td>");
                    }
                    else if (str.Equals("PayMode", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.PayMode + "</td>");
                    }
                    else if (str.Equals("PayModeReference", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.PayModeReference + "</td>");
                    }
                    else if (str.Equals("BankDetails", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.BankDetails + "</td>");
                    }
                    else if (str.Equals("Debit", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.Debit + "</td>");
                    }
                    else if (str.Equals("Credit", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.Credit + "</td>");
                    }
                    //Do not display this in the SearchForm. It will come in CreditDebit form.
                    //else if (str.Equals("PendingDebit", StringComparison.InvariantCultureIgnoreCase))
                    //{
                    //    rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.PendingDebit + "</td>");
                    //}
                    //else if (str.Equals("PendingCredit", StringComparison.InvariantCultureIgnoreCase))
                    //{
                    //    rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.PendingCredit + "</td>");
                    //}
                    else if (str.Equals("Details", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.Details + "</td>");
                    }
                    else if (str.Equals("Tag", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.Tag + "</td>");
                    }
                    //Not required any more.
                    //else if (str.Equals("StockCargoID", StringComparison.InvariantCultureIgnoreCase))
                    //{
                    //    rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.StockCargoID + "</td>");
                    //}
                }
                tableCellsForBody.Add("<tr>" + rowString + "</tr>");
            }

            string bodyString = string.Empty;
            foreach (string str in tableCellsForBody)
            {
                bodyString = bodyString + str;
            }
            retVal = headerString + bodyString;

            string printFileContent = string.Empty;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("NTechAdviser.Resources.accounts_print.htm"))
            {
                TextReader tr = new StreamReader(stream);
                printFileContent = tr.ReadToEnd();
                if (!string.IsNullOrEmpty(printFileGen.PrintTitle))
                    printFileContent = printFileContent.Replace("##TitleText##", printFileGen.PrintTitle);
                if (!string.IsNullOrEmpty(retVal))
                    printFileContent = printFileContent.Replace("##textContentForPrint##", retVal);
                retVal = printFileContent;
            }

            return retVal;
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

        private int GetValueOrNullForInt(DataGridViewRow row, string columnName)
        {
            int retVal = 0;
            retVal = (row.Cells[columnName].Value == null) ? 0 : Convert.ToInt32(row.Cells[columnName].Value);
            return retVal;
        }

        private void dataGridViewSearch_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CheckIsAdmin();
            if (ApplicationContext.CanContinue)
            {
                DataGridViewRow row = this.dataGridViewSearch.Rows[e.RowIndex];
                List<AccountsInfo> accountsInfoColl = new List<AccountsInfo>();
                accountsInfoColl.Add(GetAccountsInfo(row));
                UpdateAccountsInfoCollToDB(true, accountsInfoColl);
                ApplicationContext.CanContinue = false;
            }
            else
            {
                //Cancel the changes to the cell.
                ApplicationContext.CanContinue = false;
                DataGridView dataGridView = sender as DataGridView;
                var underlyingDataRow = ((DataRowView)dataGridView.Rows[e.RowIndex].DataBoundItem).Row;
                underlyingDataRow.RejectChanges();
            }
        }

        private static void CheckIsAdmin()
        {
            ApplicationContext.CanContinue = false;
            if (ApplicationContext.IsLoggedIn && ApplicationContext.UserType != 1)
            {
                MessageBox.Show("Only Admin can edit a previously existing data.", "Admin?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                AdminKeyForm adminKeyForm = new AdminKeyForm();
                adminKeyForm.ShowDialog();
                if (adminKeyForm.DialogResult == DialogResult.OK)
                {
                    //do nothing.
                    //adminKeyForm.Close();
                }
            }
            else if (ApplicationContext.IsLoggedIn && ApplicationContext.UserType == 1)
                ApplicationContext.CanContinue = true;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.comboProjName.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.comboProjName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
                if (ApplicationContext.ProjectNames != null && ApplicationContext.ProjectNames.Count > 0)
                {
                    coll.AddRange(ApplicationContext.ProjectNames.ToArray());
                    this.comboProjName.AutoCompleteCustomSource = coll;
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception during auto complete set for ProjectNames.", ex);
            }

            try
            {
                this.comboParticular.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.comboParticular.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection collPart = new AutoCompleteStringCollection();
                if (ApplicationContext.ParticularDetails != null && ApplicationContext.ParticularDetails.Count > 0)
                {
                    collPart.AddRange(ApplicationContext.ParticularDetails.ToArray());
                    this.comboParticular.AutoCompleteCustomSource = collPart;
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception during auto complete set for Particulars.", ex);
            }
        }

        private void deleteDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CheckIsAdmin();
                if (ApplicationContext.CanContinue)
                {
                    DataGridViewSelectedRowCollection dataGridViewRowColl = dataGridViewSearch.SelectedRows;
                    List<AccountsInfo> accountsInfoColl = new List<AccountsInfo>();
                    foreach (DataGridViewRow row in dataGridViewRowColl)
                    {
                        accountsInfoColl.Add(GetAccountsInfo(row));
                    }
                    DeleteAccountsInfoCollToDB(false, accountsInfoColl);

                    foreach (DataGridViewRow row in dataGridViewRowColl)
                    {
                        DataGridView dataGridView = dataGridViewSearch as DataGridView;
                        var underlyingDataRow = ((DataRowView)dataGridView.Rows[row.Index].DataBoundItem).Row;
                        underlyingDataRow.Delete();
                    }

                    ApplicationContext.CanContinue = false;
                }
                else
                {
                    //Cancel the changes to the cell.
                    ApplicationContext.CanContinue = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void DeleteAccountsInfoCollToDB(bool silent, List<AccountsInfo> accountsInfoColl)
        {
            Utilities utils = new Utilities();
            var accInfoEmptyData = accountsInfoColl.Where(acc => string.IsNullOrEmpty(acc.ProjectName) || string.IsNullOrEmpty(acc.Particulars));
            if (!(accInfoEmptyData == null || accInfoEmptyData.ToList().Count.Equals(0)))
            {
                if (!silent)
                {
                    if (MessageBox.Show("One or two rows has empty ProjectName or Particulars. These rows will not be updated. Press OK to continue.", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                        return;
                }
                else
                {

                }
            }

            int i = 0;
            foreach (AccountsInfo accInfo in accountsInfoColl)
            {
                try
                {
                    utils.DeleteAcccountsData(accInfo);
                    i++;
                }
                catch (Exception ex)
                {
                    if (!silent)
                    {
                        MessageBox.Show(string.Format("Problem with updating record with ProjectName {0}, Particulars {1}, PayMode {2}, PayModeReference {3}", accInfo.ProjectName, accInfo.Particulars, accInfo.PayMode, accInfo.PayModeReference), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                    }
                }
            }

            if (i != 0)
            {
                if (!silent)
                {
                    MessageBox.Show("All data updated successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                }
            }

            dataGridViewSearch.Refresh();
        }
    }
}
