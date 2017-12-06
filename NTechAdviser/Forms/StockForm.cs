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
                stockInfo.Details = GetValueOrNullForString(row, "columnDetails");
                stockInfo.Tag = GetValueOrNullForString(row, "columnTag");
                stockInfoColl.Add(stockInfo);
            }
            var stockInfoEmptyData = stockInfoColl.Where(acc => string.IsNullOrEmpty(acc.ProjectName) || string.IsNullOrEmpty(acc.Particulars));
            if (!(stockInfoEmptyData == null || stockInfoEmptyData.ToList().Count.Equals(0)))
            {
                if (MessageBox.Show("One or two rows has empty ProjectName or Particulars. These rows will not be inserted. Press OK to continue.", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                    return;
            }

            int i = 0;
            foreach (StockInfo accInfo in stockInfoColl)
            {
                if (!(string.IsNullOrEmpty(accInfo.ProjectName) || string.IsNullOrEmpty(accInfo.Particulars)))
                {
                    try
                    {
                        utils.ExecuteAddStockData(accInfo.ProjectName, accInfo.Particulars, accInfo.PayMode, accInfo.BankDetails, accInfo.PayModeReference, accInfo.SlipNo, accInfo.InwardBillNo, accInfo.Volume, accInfo.Debit, accInfo.Credit, accInfo.Item, accInfo.UnitsIn, accInfo.UnitsOut, accInfo.VehicleNo, accInfo.Details, accInfo.Tag);
                        i++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("Problem with adding record with ProjectName {0}, Particulars {1}, PayMode {2}, PayModeReference {3}", accInfo.ProjectName, accInfo.Particulars, accInfo.PayMode, accInfo.PayModeReference), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
