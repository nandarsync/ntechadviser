using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using NTechAdviser.Print;
using System.IO;
using System.Reflection;

namespace NTechAdviser.Forms
{
    public partial class PendingDebitUpdate : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(PendingDebitUpdate));
        public PendingDebitUpdate()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBoxProject.Text) || string.IsNullOrEmpty(txtBoxParticular.Text))
                {
                    MessageBox.Show("Project and Particular should not be empty.", "Save?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Utilities utils = new Utilities();
                CreditDebitInfo credDebtInfo = new CreditDebitInfo();
                credDebtInfo.Project = txtBoxProject.Text;
                credDebtInfo.Particulars = txtBoxParticular.Text;
                credDebtInfo.Credit = string.IsNullOrEmpty(txtBoxCredit.Text) ? 0 : Convert.ToDecimal(txtBoxCredit.Text);
                credDebtInfo.Debit = string.IsNullOrEmpty(txtBoxDebit.Text) ? 0 : Convert.ToDecimal(txtBoxDebit.Text);

                //CreatedBy and UpdatedBy.
                credDebtInfo.CreatedBy = ApplicationContext.UserName;
                credDebtInfo.LastUpdatedBy = ApplicationContext.UserName;

                //CreatedDate and UpdatedDate.
                string createdDate = datePickerDate.Text;
                string updatedDate = string.Empty;
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
                    createdDate = inputVal.ToString("yyyy-MM-dd");
                }

                createdDate = utils.ValidateDate(createdDate);
                updatedDate = utils.ValidateDate(updatedDate);
                credDebtInfo.CreatedDate = createdDate;
                credDebtInfo.LastUpdatedDate = updatedDate;
                utils.AddCreditDebitInfo(credDebtInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception when adding data.", "Save?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Save Error - Pending Debit Update", ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Utilities utils = new Utilities();
                DataSet ds = utils.GetCreditDebitInfo();
                List<CreditDebitInfo> creditDebitInfoColl = GetCreditDebitInfoColl(ds);

                List<CreditDebitInfo> resultVal = new List<CreditDebitInfo>();
                if (!string.IsNullOrEmpty(txtBoxProject.Text) && string.IsNullOrEmpty(txtBoxParticular.Text))
                {
                    resultVal = creditDebitInfoColl.Where(item => item.Project.ToLower().Contains(txtBoxProject.Text.ToLower())).ToList();
                }
                else if (string.IsNullOrEmpty(txtBoxProject.Text) && !string.IsNullOrEmpty(txtBoxParticular.Text))
                {
                    resultVal = creditDebitInfoColl.Where(item => item.Particulars.ToLower().Contains(txtBoxParticular.Text.ToLower())).ToList();
                }
                else if (!string.IsNullOrEmpty(txtBoxProject.Text) && !string.IsNullOrEmpty(txtBoxParticular.Text))
                {
                    resultVal = creditDebitInfoColl.Where(item =>
                        item.Particulars.ToLower().Contains(txtBoxParticular.Text.ToLower())
                        &&
                        item.Project.ToLower().Contains(txtBoxProject.Text.ToLower())
                        ).ToList();
                }
                else
                {
                    log.Info("No selection. So no value will be shown.");
                }

                if (resultVal == null || resultVal.Count <= 0)
                {
                    dataGridViewDebitReview.DataSource = null;
                    dataGridViewDebitReview.Rows.Clear();
                    return;
                }
                else
                {
                    resultVal.Sort((x, y) => x.LastUpdatedDate.CompareTo(y.LastUpdatedDate));
                    SetupDataGridView();
                    dataGridViewDebitReview.DataSource = resultVal;
                    DoCalculation(resultVal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with search", "Save?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Error with search.", ex);
            }
        }

        private void DoCalculation(List<CreditDebitInfo> resultVal)
        {
            decimal amtToGet = resultVal.Sum(item => item.CreDebInfoCreditValue); //Amt to Get.
            decimal amtToGive = resultVal.Sum(item => item.CreDebInfoDebitValue); //Amt to Give.
            decimal amtCredit = resultVal.Sum(item => item.Credit); //Amt Received.
            decimal amtDebit = resultVal.Sum(item => item.Debit); //Amount Given.

            txtBoxDebittedAmount.Text = amtDebit.ToString();
            txtBoxCredittedAmount.Text = amtCredit.ToString();
            txtBoxAmountToGet.Text = amtToGet.ToString();
            txtBoxAmtToGive.Text = amtToGive.ToString();

            decimal pendingDebit = amtToGive - amtDebit;
            decimal pendingCredit = amtToGet - amtCredit;

            txtBoxPendingCredit.Text = pendingCredit.ToString();
            txtBoxPendingAmount.Text = pendingDebit.ToString();
        }
    
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //PrintDataGrid.PrintDGV.Print_DataGridView(dataGridViewSearch);
                PrintFileGenerator printFileGen = new PrintFileGenerator();
                printFileGen.GeneratePrintFile(dataGridViewDebitReview, "CreditDebitForm");

                List<CreditDebitInfo> accountsinfoColl = GetAllCurrentDataFromGridView();
                string printFileContent = CreatePrintFile(printFileGen, accountsinfoColl);

                if (ApplicationContext.PrintContentGenerated)
                {
                    WebBrowserControlForm webBrowserControlForm = new WebBrowserControlForm(printFileContent);
                    webBrowserControlForm.Show();
                }

                //if (ApplicationContext.PrintContentGenerated)
                //{
                //    //return; //Comment later.
                //    // Create a WebBrowser instance. 
                //    WebBrowser webBrowserForPrinting = new WebBrowser();

                //    // Add an event handler that prints the document after it loads.
                //    webBrowserForPrinting.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(PrintDocument);

                //    // Set the Url property to load the document.
                //    webBrowserForPrinting.DocumentText = printFileContent;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print Error.", "Print?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Print Error.", ex);
            }
        }


        private List<CreditDebitInfo> GetAllCurrentDataFromGridView()
        {
            DataGridViewRowCollection dataGridViewRowColl = dataGridViewDebitReview.Rows;
            List<CreditDebitInfo> creditDebitInfoColl = new List<CreditDebitInfo>();
            foreach (DataGridViewRow row in dataGridViewRowColl)
            {
                creditDebitInfoColl.Add(GetCreditDebitInfo(row));
            }
            return creditDebitInfoColl;
        }

        private CreditDebitInfo GetCreditDebitInfo(DataGridViewRow row)
        {
            CreditDebitInfo accountsInfo = new CreditDebitInfo();
            accountsInfo.RecID_AccInfo = GetValueOrNullForInt(row, "RecID_AccInfo");
            accountsInfo.CreditDebitID = GetValueOrNullForInt(row, "CreditDebitID");
            accountsInfo.Project = GetValueOrNullForString(row, "Project");
            accountsInfo.PayMode = GetValueOrNullForString(row, "PayMode");
            accountsInfo.PayModeReference = GetValueOrNullForString(row, "PayModeReference");
            accountsInfo.BankDetails = GetValueOrNullForString(row, "BankDetails");
            accountsInfo.Particulars = GetValueOrNullForString(row, "Particulars");
            accountsInfo.CreDebInfoDebitValue = GetValueOrNullForDecimal(row, "CreDebInfoDebitValue");
            accountsInfo.CreDebInfoCreditValue = GetValueOrNullForDecimal(row, "CreDebInfoCreditValue");
            accountsInfo.Debit = GetValueOrNullForDecimal(row, "Debit");
            accountsInfo.Credit = GetValueOrNullForDecimal(row, "Credit");
            accountsInfo.Details = GetValueOrNullForString(row, "Details");
            accountsInfo.Tag = GetValueOrNullForString(row, "Tag");
            accountsInfo.LastUpdatedBy = GetValueOrNullForString(row, "LastUpdatedBy");
            accountsInfo.LastUpdatedDate = GetValueOrNullForString(row, "LastUpdatedDate");

            return accountsInfo;
        }

        decimal totalCreDebInfoDebitValue = 0;
        decimal totalCreDebInfoCreditValue = 0;
        decimal totalCredit = 0;
        decimal totalDebit = 0;
        //decimal pendingDebit = 0;
        //decimal pendingCredit = 0;

        private string CreatePrintFile(PrintFileGenerator printFileGen, List<CreditDebitInfo> accountsinfoColl)
        {
            string retVal = string.Empty;
            string headerString = string.Empty;

            if (accountsinfoColl.Count > 0)
            {
                totalCreDebInfoCreditValue = accountsinfoColl.Sum(item => item.CreDebInfoCreditValue); //Amt to Get.
                totalCreDebInfoDebitValue = accountsinfoColl.Sum(item => item.CreDebInfoDebitValue); //Amt to Give.
                totalCredit = accountsinfoColl.Sum(item => item.Credit); //Amt Received.
                totalDebit = accountsinfoColl.Sum(item => item.Debit); //Amount Given.

                //Add the total amount to the list.
                CreditDebitInfo creditDebitInfoTotal = new CreditDebitInfo();
                creditDebitInfoTotal.Particulars = "Total";
                creditDebitInfoTotal.CreDebInfoDebitValue = totalCreDebInfoDebitValue;
                creditDebitInfoTotal.CreDebInfoCreditValue = totalCreDebInfoCreditValue;
                creditDebitInfoTotal.Credit = totalCredit;
                creditDebitInfoTotal.Debit = totalDebit;

                accountsinfoColl.Add(creditDebitInfoTotal);
            }

            foreach (string str in printFileGen.SelectedColumns)
            {
                headerString = headerString + ("<td id=\"headerRow\">" + str + "</td>");
            }
            headerString = "<tr>" + headerString + "</tr>";

            List<string> tableCellsForBody = new List<string>();
            foreach (CreditDebitInfo accInfo in accountsinfoColl)
            {
                string rowString = string.Empty;
                foreach (string str in printFileGen.SelectedColumns)
                {
                    if (str.Equals("Account Info ID", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.RecID_AccInfo + "</td>");
                    }
                    else if (str.Equals("Credit Debit Info ID", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.CreditDebitID + "</td>");
                    }
                    else if (str.Equals("Project", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.Project + "</td>");
                    }
                    else if (str.Equals("Pay Mode", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.PayMode + "</td>");
                    }
                    else if (str.Equals("Pay Mode Reference", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.PayModeReference + "</td>");
                    }
                    else if (str.Equals("Bank Details", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.BankDetails + "</td>");
                    }
                    else if (str.Equals("Particulars", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.Particulars + "</td>");
                    }
                    else if (str.Equals("Amount To Give", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.CreDebInfoDebitValue + "</td>");
                    }
                    else if (str.Equals("Amount To Get", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.CreDebInfoCreditValue + "</td>");
                    }
                    else if (str.Equals("Debit", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.Debit + "</td>");
                    }
                    else if (str.Equals("Credit", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.Credit + "</td>");
                    }
                    else if (str.Equals("Date Updated", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.LastUpdatedDate + "</td>");
                    }
                    else if (str.Equals("Updated By", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.LastUpdatedBy + "</td>");
                    }
                    else if (str.Equals("Details", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.Details + "</td>");
                    }
                    else if (str.Equals("Tag", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + accInfo.Tag + "</td>");
                    }
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
                if(!string.IsNullOrEmpty(printFileGen.PrintTitle))
                    printFileContent = printFileContent.Replace("##TitleText##", printFileGen.PrintTitle);
                if(!string.IsNullOrEmpty(retVal))
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

        private void PrintDocument(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Print the document now that it is fully loaded.
            ((WebBrowser)sender).Print();

            // Dispose the WebBrowser now that the task is complete. 
            ((WebBrowser)sender).Dispose();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PendingDebitUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBoxProject.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.txtBoxProject.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
                if (ApplicationContext.ProjectNames != null && ApplicationContext.ProjectNames.Count > 0)
                {
                    coll.AddRange(ApplicationContext.ProjectNames.ToArray());
                    this.txtBoxProject.AutoCompleteCustomSource = coll;
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception during auto complete set for ProjectNames.", ex);
            }

            try
            {
                this.txtBoxParticular.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.txtBoxParticular.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection collPart = new AutoCompleteStringCollection();
                if (ApplicationContext.ParticularDetails != null && ApplicationContext.ParticularDetails.Count > 0)
                {
                    collPart.AddRange(ApplicationContext.ParticularDetails.ToArray());
                    this.txtBoxParticular.AutoCompleteCustomSource = collPart;
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception during auto complete set for Particulars.", ex);
            }
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            try
            {
                Utilities utils = new Utilities();
                DataSet ds = utils.GetCreditDebitInfo();
                List<CreditDebitInfo> creditDebitInfoColl = GetCreditDebitInfoColl(ds);

                creditDebitInfoColl.Sort((x, y) => x.LastUpdatedDate.CompareTo(y.LastUpdatedDate));

                SetupDataGridView();
                dataGridViewDebitReview.DataSource = creditDebitInfoColl;
                DoCalculation(creditDebitInfoColl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error.", "Search?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dataGridViewDebitReview.DataSource = null;
            dataGridViewDebitReview.Rows.Clear();
            dataGridViewDebitReview.AutoGenerateColumns = false;
            dataGridViewDebitReview.ColumnCount = 15;

            //Add Columns

            dataGridViewDebitReview.Columns[0].Name = "RecID_AccInfo"; // name
            dataGridViewDebitReview.Columns[0].HeaderText = "Account Info ID"; // header text
            dataGridViewDebitReview.Columns[0].DataPropertyName = "RecID_AccInfo"; // field name

            dataGridViewDebitReview.Columns[1].Name = "CreditDebitID"; // name
            dataGridViewDebitReview.Columns[1].HeaderText = "Credit Debit Info ID"; // header text
            dataGridViewDebitReview.Columns[1].DataPropertyName = "CreditDebitID"; // field name

            dataGridViewDebitReview.Columns[2].Name = "Project"; // name
            dataGridViewDebitReview.Columns[2].HeaderText = "Project"; // header text
            dataGridViewDebitReview.Columns[2].DataPropertyName = "Project"; // field name

            dataGridViewDebitReview.Columns[3].Name = "PayMode"; // name
            dataGridViewDebitReview.Columns[3].HeaderText = "Pay Mode"; // header text
            dataGridViewDebitReview.Columns[3].DataPropertyName = "PayMode"; // field name

            dataGridViewDebitReview.Columns[4].Name = "PayModeReference"; // name
            dataGridViewDebitReview.Columns[4].HeaderText = "Pay Mode Reference"; // header text
            dataGridViewDebitReview.Columns[4].DataPropertyName = "PayModeReference"; // field name

            dataGridViewDebitReview.Columns[5].Name = "BankDetails"; // name
            dataGridViewDebitReview.Columns[5].HeaderText = "Bank Details"; // header text
            dataGridViewDebitReview.Columns[5].DataPropertyName = "BankDetails"; // field name

            dataGridViewDebitReview.Columns[6].Name = "Particulars"; // name
            dataGridViewDebitReview.Columns[6].HeaderText = "Particulars"; // header text
            dataGridViewDebitReview.Columns[6].DataPropertyName = "Particulars"; // field name

            dataGridViewDebitReview.Columns[7].Name = "CreDebInfoDebitValue"; // name
            dataGridViewDebitReview.Columns[7].HeaderText = "Amount To Give"; // header text
            dataGridViewDebitReview.Columns[7].DataPropertyName = "CreDebInfoDebitValue"; // field name

            dataGridViewDebitReview.Columns[8].Name = "CreDebInfoCreditValue"; // name
            dataGridViewDebitReview.Columns[8].HeaderText = "Amount to Get"; // header text
            dataGridViewDebitReview.Columns[8].DataPropertyName = "CreDebInfoCreditValue"; // field name

            dataGridViewDebitReview.Columns[9].Name = "Debit"; // name
            dataGridViewDebitReview.Columns[9].HeaderText = "Debit"; // header text
            dataGridViewDebitReview.Columns[9].DataPropertyName = "Debit"; // field name

            dataGridViewDebitReview.Columns[10].Name = "Credit"; // name
            dataGridViewDebitReview.Columns[10].HeaderText = "Credit"; // header text
            dataGridViewDebitReview.Columns[10].DataPropertyName = "Credit"; // field name

            dataGridViewDebitReview.Columns[11].Name = "Details"; // name
            dataGridViewDebitReview.Columns[11].HeaderText = "Details"; // header text
            dataGridViewDebitReview.Columns[11].DataPropertyName = "Details"; // field name

            dataGridViewDebitReview.Columns[12].Name = "Tag"; // name
            dataGridViewDebitReview.Columns[12].HeaderText = "Tag"; // header text
            dataGridViewDebitReview.Columns[12].DataPropertyName = "Tag"; // field name

            dataGridViewDebitReview.Columns[13].Name = "LastUpdatedDate"; // name
            dataGridViewDebitReview.Columns[13].HeaderText = "Date Updated"; // header text
            dataGridViewDebitReview.Columns[13].DataPropertyName = "LastUpdatedDate"; // field name

            dataGridViewDebitReview.Columns[14].Name = "LastUpdatedBy"; // name
            dataGridViewDebitReview.Columns[14].HeaderText = "Updated By"; // header text
            dataGridViewDebitReview.Columns[14].DataPropertyName = "LastUpdatedBy"; // field name
        }

        private List<CreditDebitInfo> GetCreditDebitInfoColl(DataSet ds)
        {
            List<CreditDebitInfo> credDebInfoColl = new List<CreditDebitInfo>();
            if (ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    CreditDebitInfo credDebInfo = GetCreditDebitInfoFromDataRow(dr);
                    credDebInfoColl.Add(credDebInfo);
                }
            }
            return credDebInfoColl;
        }

        private CreditDebitInfo GetCreditDebitInfoFromDataRow(DataRow dr)
        {
            CreditDebitInfo credDebInfo = new CreditDebitInfo();
            //credDebInfo.CreatedBy = GetValueOrNullForString(dr, "");
            credDebInfo.Details = GetValueOrNullForString(dr, "DETAILS_ACC_INFO");
            credDebInfo.LastUpdatedBy = GetValueOrNullForString(dr, "UPDATED_BY_ACC_INFO");
            credDebInfo.Particulars = GetValueOrNullForString(dr, "PART_ACC_INFO");
            credDebInfo.Project = GetValueOrNullForString(dr, "PROJ_ACC_INFO");

            credDebInfo.PayMode = GetValueOrNullForString(dr, "PAYMODE_ACC_INFO");
            credDebInfo.PayModeReference = GetValueOrNullForString(dr, "PAY_REF_ACC_INFO");
            credDebInfo.BankDetails = GetValueOrNullForString(dr, "BANK_DET_ACC_INFO");

            credDebInfo.Tag = GetValueOrNullForString(dr, "TAG_ACC_INFO");
            credDebInfo.TableRef = GetValueOrNullForString(dr, "TABLE_REF");

            if (credDebInfo.TableRef == "account_info")
            {
                credDebInfo.RecID_AccInfo = GetValueOrNullForInt(dr, "REC_ID_ACC_INFO");
                credDebInfo.Credit = GetValueOrNullForDecimal(dr, "CREDIT_ACC_INFO");
                credDebInfo.Debit = GetValueOrNullForDecimal(dr, "DEBIT_ACC_INFO");
            }
            else
            {
                credDebInfo.CreditDebitID = GetValueOrNullForInt(dr, "REC_ID_ACC_INFO");
                credDebInfo.CreDebInfoCreditValue = GetValueOrNullForDecimal(dr, "CREDIT_ACC_INFO");
                credDebInfo.CreDebInfoDebitValue = GetValueOrNullForDecimal(dr, "DEBIT_ACC_INFO");
            }

            //DateTime? getDateCreated = GetValueOrNullForDate(dr, "");
            //credDebInfo.CreatedDate = getDateCreated.HasValue ? getDateCreated.Value.ToShortDateString() : string.Empty;

            DateTime? getDateUpdated = GetValueOrNullForDate(dr, "DATE_ACC_INFO");
            credDebInfo.LastUpdatedDate = getDateUpdated.HasValue ? getDateUpdated.Value.ToShortDateString() : string.Empty;
            return credDebInfo;
        }

        private string GetValueOrNullForString(DataRow row, string columnName)
        {
            string retVal = string.Empty;
            retVal = (row[columnName] == null) ? string.Empty : row[columnName].ToString();
            return retVal;
        }

        private Decimal GetValueOrNullForDecimal(DataRow row, string columnName)
        {
            Decimal retVal = 0;
            retVal = (row[columnName] == null) ? 0 : Convert.ToDecimal(row[columnName]);
            return retVal;
        }

        private int GetValueOrNullForInt(DataRow row, string columnName)
        {
            int retVal = 0;
            retVal = (row[columnName] == null) ? 0 : Convert.ToInt32(row[columnName]);
            return retVal;
        }

        private DateTime? GetValueOrNullForDate(DataRow row, string columnName)
        {
            DateTime? date = Convert.ToDateTime(row[columnName]);
            return date;
        }

        private void dataGridViewDebitReview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //ApplicationContext.CanContinue = false;
            //if (ApplicationContext.IsLoggedIn && ApplicationContext.UserType != 1)
            //{
            //    MessageBox.Show("Only Admin can edit a previously existing data.", "Admin?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    AdminKeyForm adminKeyForm = new AdminKeyForm();
            //    adminKeyForm.ShowDialog();
            //    if (adminKeyForm.DialogResult == DialogResult.OK)
            //    {
            //        //do nothing.
            //        //adminKeyForm.Close();
            //    }
            //}
            //else if (ApplicationContext.IsLoggedIn && ApplicationContext.UserType == 1)
            //    ApplicationContext.CanContinue = true;
            //if (ApplicationContext.CanContinue)
            //{
            //    DataGridViewRow row = this.dataGridViewSearch.Rows[e.RowIndex];
            //    List<AccountsInfo> accountsInfoColl = new List<AccountsInfo>();
            //    accountsInfoColl.Add(GetAccountsInfo(row));
            //    UpdateAccountsInfoCollToDB(true, accountsInfoColl);
            //    ApplicationContext.CanContinue = false;
            //}
        }
    }
}
