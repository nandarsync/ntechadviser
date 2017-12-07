using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NTechAdviser.Print;
using System.IO;
using System.Reflection;

namespace NTechAdviser.Forms
{
    public partial class StockSearchForm : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(StockSearchForm));
        public StockSearchForm()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Utilities utils = new Utilities();
            BuildSearchQuery quer = new BuildSearchQuery();
            string query = quer.BuildQuery(comboProjName.Text, comboParticular.Text, SearchModeEnum.StockData);

            if (string.IsNullOrEmpty(query))
            {
                log.Info("No query to search.");
                Console.WriteLine("No query to search.");
                return;
            }

            DataSet ds = utils.GetManagementInfoDataSet(query);
            this.dataGridViewSearch.DataSource = ds.Tables[0];
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            try
            {
                string cmdString = "select * from stock_info";
                Utilities utils = new Utilities();
                DataSet ds = utils.GetManagementInfoDataSet(cmdString);
                this.dataGridViewSearch.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error("Error during search all.", ex);
            }
        }

        private void updateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateData(true);
        }

        private void UpdateData(bool silent)
        {
            DataGridViewSelectedRowCollection dataGridViewRowColl = dataGridViewSearch.SelectedRows;
            List<StockInfo> stockInfoColl = new List<StockInfo>();
            foreach (DataGridViewRow row in dataGridViewRowColl)
            {
                stockInfoColl.Add(GetStockInfo(row));
            }
            UpdateStockInfoCollToDB(silent, stockInfoColl);
        }

        private StockInfo GetStockInfo(DataGridViewRow row)
        {
            StockInfo stockInfo = new StockInfo();
            stockInfo.RecordID = GetValueOrNullForInt(row, "RecordID");
            stockInfo.CreatedBy = GetValueOrNullForString(row, "CreatedBy");
            stockInfo.UpdatedBy = GetValueOrNullForString(row, "UpdatedBy");
            stockInfo.DateCreated = GetValueOrNullForString(row, "DateCreated");
            stockInfo.DateUpdated = GetValueOrNullForString(row, "DateUpdated");
            stockInfo.ProjectName = GetValueOrNullForString(row, "Project");
            stockInfo.Particulars = GetValueOrNullForString(row, "Particulars");
            stockInfo.SlipNo = GetValueOrNullForString(row, "SlipNo");
            stockInfo.InwardBillNo = GetValueOrNullForString(row, "InwardBillNo");
            stockInfo.Volume = GetValueOrNullForString(row, "Volume");
            stockInfo.Item = GetValueOrNullForString(row, "Item");
            stockInfo.ItemSize = GetValueOrNullForString(row, "ItemSize");
            stockInfo.UnitsIn = GetValueOrNullForDecimal(row, "UnitsIn");
            stockInfo.UnitsOut = GetValueOrNullForDecimal(row, "UnitsOut");
            stockInfo.VehicleNo = GetValueOrNullForString(row, "VehicleNo");
            stockInfo.PayMode = GetValueOrNullForString(row, "PayMode");
            stockInfo.BankDetails = GetValueOrNullForString(row, "BankDetails");
            stockInfo.PayModeReference = GetValueOrNullForString(row, "PayModeReference");
            stockInfo.Debit = GetValueOrNullForDecimal(row, "Debit");
            stockInfo.Credit = GetValueOrNullForDecimal(row, "Credit");
            stockInfo.Details = GetValueOrNullForString(row, "Details");
            stockInfo.Tag = GetValueOrNullForString(row, "Tag");

            return stockInfo;
        }

        private void UpdateStockInfoCollToDB(bool silent, List<StockInfo> stockInfoColl)
        {
            Utilities utils = new Utilities();
            var stockInfoEmptyData = stockInfoColl.Where(acc => string.IsNullOrEmpty(acc.ProjectName) || string.IsNullOrEmpty(acc.Particulars));
            if (!(stockInfoEmptyData == null || stockInfoEmptyData.ToList().Count.Equals(0)))
            {
                if (!silent)
                {
                    log.Info("One or two rows has empty ProjectName or Particulars. These rows will not be updated. Press OK to continue.");
                    if (MessageBox.Show("One or two rows has empty ProjectName or Particulars. These rows will not be updated. Press OK to continue.", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                        return;
                }
                else
                {

                }
            }

            int i = 0;
            foreach (StockInfo stockInfo in stockInfoColl)
            {
                try
                {
                    utils.UpdateStockInfoData(stockInfo);
                    i++;
                }
                catch (Exception ex)
                {
                    if (!silent)
                    {
                        log.Info(string.Format("Problem with updating record with ProjectName {0}, Particulars {1}, PayMode {2}, PayModeReference {3}", stockInfo.ProjectName, stockInfo.Particulars, stockInfo.PayMode, stockInfo.PayModeReference));
                        MessageBox.Show(string.Format("Problem with updating record with ProjectName {0}, Particulars {1}, PayMode {2}, PayModeReference {3}", stockInfo.ProjectName, stockInfo.Particulars, stockInfo.PayMode, stockInfo.PayModeReference), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    log.Info("All data updated successfully.");
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
            printFileGen.GeneratePrintFile(dataGridViewSearch, "StockSearchForm");

            List<StockInfo> stockinfoColl = GetAllCurrentDataFromGridView();
            string printFileContent = CreatePrintFile(printFileGen, stockinfoColl);

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

        private List<StockInfo> GetAllCurrentDataFromGridView()
        {
            DataGridViewRowCollection dataGridViewRowColl = dataGridViewSearch.Rows;
            List<StockInfo> stockInfoColl = new List<StockInfo>();
            foreach (DataGridViewRow row in dataGridViewRowColl)
            {
                stockInfoColl.Add(GetStockInfo(row));
            }
            return stockInfoColl;
        }

        private void PrintDocument(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Print the document now that it is fully loaded.
            ((WebBrowser)sender).Print();

            // Dispose the WebBrowser now that the task is complete. 
            ((WebBrowser)sender).Dispose();
        }

        private string CreatePrintFile(PrintFileGenerator printFileGen, List<StockInfo> stockInfoColl)
        {
            string retVal = string.Empty;
            string headerString = string.Empty;

            foreach (string str in printFileGen.SelectedColumns)
            {
                headerString = headerString + ("<td id=\"headerRow\">" + str + "</td>");
            }
            headerString = "<tr>" + headerString + "</tr>";

            List<string> tableCellsForBody = new List<string>();
            foreach (StockInfo stockInfo in stockInfoColl)
            {
                string rowString = string.Empty;
                foreach (string str in printFileGen.SelectedColumns)
                {
                    if (str.Equals("RecordID", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.RecordID + "</td>");
                    }
                    else if (str.Equals("DateCreated", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.DateCreated + "</td>");
                    }
                    else if (str.Equals("CreatedBy", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.CreatedBy + "</td>");
                    }
                    else if (str.Equals("DateUpdated", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.DateUpdated + "</td>");
                    }
                    else if (str.Equals("UpdatedBy", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.UpdatedBy + "</td>");
                    }
                    else if (str.Equals("Project", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.ProjectName + "</td>");
                    }
                    else if (str.Equals("Particulars", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.Particulars + "</td>");
                    }
                    else if (str.Equals("Item", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.Item + "</td>");
                    }
                    else if (str.Equals("ItemSize", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.ItemSize + "</td>");
                    }
                    else if (str.Equals("UnitsIn", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.UnitsIn + "</td>");
                    }
                    else if (str.Equals("UnitsOut", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.UnitsOut + "</td>");
                    }
                    else if (str.Equals("VehicleNo", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.VehicleNo + "</td>");
                    }
                    else if (str.Equals("PayMode", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.PayMode + "</td>");
                    }

                    else if (str.Equals("SlipNo", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.SlipNo + "</td>");
                    }

                    else if (str.Equals("InwardBillNo", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.InwardBillNo + "</td>");
                    }

                    else if (str.Equals("Volume", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.Volume + "</td>");
                    }

                    else if (str.Equals("PayModeReference", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.PayModeReference + "</td>");
                    }
                    else if (str.Equals("BankDetails", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.BankDetails + "</td>");
                    }
                    else if (str.Equals("Debit", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.Debit + "</td>");
                    }
                    else if (str.Equals("Credit", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.Credit + "</td>");
                    }
                    else if (str.Equals("PendingDebit", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + string.Empty + "</td>");
                    }
                    else if (str.Equals("PendingCredit", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + string.Empty + "</td>");
                    }
                    else if (str.Equals("Details", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.Details + "</td>");
                    }
                    else if (str.Equals("Tag", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rowString = rowString + ("<td id=\"" + str + "\">" + stockInfo.Tag + "</td>");
                    }

                    //Not required any more.
                    //else if (str.Equals("StockCargoID", StringComparison.InvariantCultureIgnoreCase))
                    //{
                    //    rowString = rowString + ("<td id=\"" + str + "\">" + string.Empty + "</td>");
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
            ApplicationContext.CanContinue = false;
            if (ApplicationContext.IsLoggedIn && ApplicationContext.UserType != 1)
            {
                log.Info("Only Admin can edit a previously existing data.");
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
            if (ApplicationContext.CanContinue)
            {
                DataGridViewRow row = this.dataGridViewSearch.Rows[e.RowIndex];
                List<StockInfo> accountsInfoColl = new List<StockInfo>();
                accountsInfoColl.Add(GetStockInfo(row));
                UpdateStockInfoCollToDB(true, accountsInfoColl);
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
    }
}
