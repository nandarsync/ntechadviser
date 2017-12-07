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
    public partial class StockForm : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(StockForm));
        public StockForm()
        {
            InitializeComponent();
        }

        private void StockForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            Utilities utils = new Utilities();
            List<StockInfo> stockInfoColl = new List<StockInfo>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                StockInfo stockInfo = new StockInfo();
                stockInfo.ProjectName = GetValueOrNullForString(row, "columnProject");
                stockInfo.Particulars = GetValueOrNullForString(row, "columnParticulars");
                stockInfo.PayMode = GetValueOrNullForString(row, "columnPaymode");
                stockInfo.BankDetails = GetValueOrNullForString(row, "columnBankDetails");
                stockInfo.PayModeReference = GetValueOrNullForString(row, "columnPayModeReference");
                stockInfo.Debit = GetValueOrNullForDecimal(row, "columnDebit");
                stockInfo.Credit = GetValueOrNullForDecimal(row, "columnCredit");
                stockInfo.Item = GetValueOrNullForString(row, "columnItem");
                stockInfo.UnitsIn = GetValueOrNullForDecimal(row, "columnUnitsIn");
                stockInfo.UnitsOut = GetValueOrNullForDecimal(row, "columnUnitsOut");
                stockInfo.VehicleNo = GetValueOrNullForString(row, "columnVehicleNo");
                stockInfo.SlipNo = GetValueOrNullForString(row, "columnSlipNo");
                stockInfo.InwardBillNo = GetValueOrNullForString(row, "columnInwardBillNo");
                stockInfo.Volume = GetValueOrNullForString(row, "columnVolume");
                stockInfo.ItemSize = GetValueOrNullForString(row, "columnItemSize");

                //CreatedDate and UpdatedDate.
                string createdDate = GetValueOrNullForString(row, "columnDateCreated");
                string updatedDate = GetValueOrNullForString(row, "columnDateUpdated");
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

                stockInfo.DateCreated = createdDate;
                stockInfo.DateUpdated = updatedDate;

                stockInfo.CreatedBy = ApplicationContext.UserName;
                stockInfo.UpdatedBy = ApplicationContext.UserName;

                stockInfo.Details = GetValueOrNullForString(row, "columnDetails");
                stockInfo.Tag = GetValueOrNullForString(row, "columnTag");

                if (!(string.IsNullOrEmpty(stockInfo.ProjectName) || string.IsNullOrEmpty(stockInfo.Particulars)))
                {
                    stockInfoColl.Add(stockInfo);
                }
                else
                {
                    log.Info("Record skipped.");
                    MessageBox.Show("Row has empty ProjectName or Particulars. This row will not be added. Remaining will be processed. Press OK to continue.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            var stockInfoEmptyData = stockInfoColl.Where(acc => string.IsNullOrEmpty(acc.ProjectName) || string.IsNullOrEmpty(acc.Particulars));
            if (!(stockInfoEmptyData == null || stockInfoEmptyData.ToList().Count.Equals(0)))
            {
                if (MessageBox.Show("One or two rows has empty ProjectName or Particulars. These rows will not be inserted. Press OK to continue.", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                    return;
            }

            int i = 0;
            foreach (StockInfo stockInfo in stockInfoColl)
            {
                if (!(string.IsNullOrEmpty(stockInfo.ProjectName) || string.IsNullOrEmpty(stockInfo.Particulars)))
                {
                    try
                    {
                        utils.ExecuteAddStockData(stockInfo.ProjectName,
                            stockInfo.Particulars,
                            stockInfo.PayMode,
                            stockInfo.BankDetails,
                            stockInfo.PayModeReference,
                            stockInfo.SlipNo,
                            stockInfo.InwardBillNo,
                            stockInfo.Volume,
                            stockInfo.Debit,
                            stockInfo.Credit,
                            stockInfo.Item,
                            stockInfo.UnitsIn,
                            stockInfo.UnitsOut,
                            stockInfo.ItemSize,
                            stockInfo.VehicleNo,
                            stockInfo.Details,
                            stockInfo.Tag,
                            stockInfo.CreatedBy,
                            stockInfo.UpdatedBy,
                            stockInfo.DateCreated,
                            stockInfo.DateUpdated);
                        i++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("Problem with adding record with ProjectName {0}, Particulars {1}, PayMode {2}, PayModeReference {3}", stockInfo.ProjectName, stockInfo.Particulars, stockInfo.PayMode, stockInfo.PayModeReference), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            if (i != 0)
            {
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
