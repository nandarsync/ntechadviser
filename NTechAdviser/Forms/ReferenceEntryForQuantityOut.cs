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
    public partial class ReferenceEntryForQuantityOut : Form
    {
        public String ReferenceText
        {
            get { return this.textBox1.Text; }
        }

        public ReferenceEntryForQuantityOut()
        {
            InitializeComponent();
        }

        private void ReferenceEntryForQuantityOut_Load(object sender, EventArgs e)
        {

        }
    }
}