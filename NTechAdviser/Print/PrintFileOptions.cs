using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PrintDataGrid
{
    public partial class PrintFileOptions : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(PrintFileOptions)); 
        public PrintFileOptions()
        {
            InitializeComponent();
        }
        public PrintFileOptions(List<string> availableFields)
        {
            InitializeComponent();

            foreach (string field in availableFields)
                     chklst.Items.Add(field, true);
        }

        private void PrintOtions_Load(object sender, EventArgs e)
        {
            // Initialize some controls
            rdoAllRows.Checked = true;
            chkFitToPageWidth.Checked = true; 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public List<string> GetSelectedColumns()
        {
            List<string> lst = new List<string>();
            foreach (object item in chklst.CheckedItems)
                    lst.Add(item.ToString());
            return lst;
        }

        public string PrintTitle
        {
            get { return txtTitle.Text; }
        }

        public bool PrintAllRows
        {
            get { return rdoAllRows.Checked; }
        }

        public bool FitToPageWidth
        {
            get { return chkFitToPageWidth.Checked; }
        }

        private void chklst_MouseDown(object sender, MouseEventArgs e)
        {
            //if (this.chklst.SelectedItem == null) return;
            //this.chklst.DoDragDrop(this.chklst.SelectedItem, DragDropEffects.Move);
        }

        private void chklst_DragOver(object sender, DragEventArgs e)
        {
            //e.Effect = DragDropEffects.Move;
        }

        private void chklst_DragDrop(object sender, DragEventArgs e)
        {
            //Point point = chklst.PointToClient(new Point(e.X, e.Y));
            //int index = this.chklst.IndexFromPoint(point);
            //if (index < 0) index = this.chklst.Items.Count - 1;
            //object data = chklst.SelectedItem;
            //this.chklst.Items.Remove(data);
            //this.chklst.Items.Insert(index, data);
        }
    }
}