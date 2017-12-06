using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NTechAdviser.Print
{
    public partial class ReArrangeList : Form
    {
        private List<string> AvailableColumns;
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(ReArrangeList)); 
        public ReArrangeList()
        {
            InitializeComponent();
        }

        public ReArrangeList(List<string> AvailableColumns)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.AvailableColumns = AvailableColumns;

            foreach (string field in AvailableColumns)
                listBox1.Items.Add(field);
        }

        public List<string> GetItemsInRearrangedOrder()
        {
            List<string> retval = new List<string>();
            if (this.listBox1.Items != null && this.listBox1.Items.Count > 0)
            {
                foreach (object item in listBox1.Items)
                    retval.Add(item.ToString());
            }
            return retval;
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.listBox1.SelectedItem == null) return;
            this.listBox1.DoDragDrop(this.listBox1.SelectedItem, DragDropEffects.Move);
        }

        private void listBox1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            Point point = listBox1.PointToClient(new Point(e.X, e.Y));
            int index = this.listBox1.IndexFromPoint(point);
            if (index < 0) index = this.listBox1.Items.Count - 1;
            object data = listBox1.SelectedItem;
            this.listBox1.Items.Remove(data);
            this.listBox1.Items.Insert(index, data);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
