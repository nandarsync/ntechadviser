namespace NTechAdviser.Forms
{
    partial class StockForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddData = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.columnDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnParticulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSlipNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnInwardBillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnQuantityIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnQuantityOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnItemSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnVehicleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPaymode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnBankDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPayModeReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 356);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 110);
            this.panel1.TabIndex = 0;
            // 
            // btnAddData
            // 
            this.btnAddData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddData.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddData.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddData.Location = new System.Drawing.Point(843, 36);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(120, 40);
            this.btnAddData.TabIndex = 1;
            this.btnAddData.Text = "Add Data";
            this.btnAddData.UseVisualStyleBackColor = true;
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 356);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 42;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnDateCreated,
            this.columnProject,
            this.columnParticulars,
            this.columnItem,
            this.columnSlipNo,
            this.columnInwardBillNo,
            this.columnVolume,
            this.columnQuantityIn,
            this.columnQuantityOut,
            this.columnItemSize,
            this.columnVehicleNo,
            this.columnReference,
            this.columnPaymode,
            this.columnBankDetails,
            this.columnPayModeReference,
            this.columnDebit,
            this.columnCredit,
            this.columnDetails,
            this.columnTag});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1028, 356);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // columnDateCreated
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnDateCreated.DefaultCellStyle = dataGridViewCellStyle2;
            this.columnDateCreated.HeaderText = "Date";
            this.columnDateCreated.Name = "columnDateCreated";
            // 
            // columnProject
            // 
            this.columnProject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnProject.DefaultCellStyle = dataGridViewCellStyle3;
            this.columnProject.HeaderText = "Project";
            this.columnProject.MinimumWidth = 200;
            this.columnProject.Name = "columnProject";
            this.columnProject.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnProject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnProject.Width = 200;
            // 
            // columnParticulars
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnParticulars.DefaultCellStyle = dataGridViewCellStyle4;
            this.columnParticulars.HeaderText = "Particulars";
            this.columnParticulars.MinimumWidth = 200;
            this.columnParticulars.Name = "columnParticulars";
            this.columnParticulars.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnParticulars.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnParticulars.Width = 200;
            // 
            // columnItem
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnItem.DefaultCellStyle = dataGridViewCellStyle5;
            this.columnItem.HeaderText = "Item";
            this.columnItem.MinimumWidth = 100;
            this.columnItem.Name = "columnItem";
            this.columnItem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnItem.Width = 200;
            // 
            // columnSlipNo
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnSlipNo.DefaultCellStyle = dataGridViewCellStyle6;
            this.columnSlipNo.HeaderText = "Slip No";
            this.columnSlipNo.Name = "columnSlipNo";
            // 
            // columnInwardBillNo
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnInwardBillNo.DefaultCellStyle = dataGridViewCellStyle7;
            this.columnInwardBillNo.HeaderText = "Inward Bill No";
            this.columnInwardBillNo.Name = "columnInwardBillNo";
            // 
            // columnVolume
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnVolume.DefaultCellStyle = dataGridViewCellStyle8;
            this.columnVolume.HeaderText = "Volume";
            this.columnVolume.Name = "columnVolume";
            // 
            // columnQuantityIn
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = "0";
            this.columnQuantityIn.DefaultCellStyle = dataGridViewCellStyle9;
            this.columnQuantityIn.HeaderText = "Quantity In";
            this.columnQuantityIn.MinimumWidth = 50;
            this.columnQuantityIn.Name = "columnQuantityIn";
            this.columnQuantityIn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnQuantityIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnQuantityOut
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = "0";
            this.columnQuantityOut.DefaultCellStyle = dataGridViewCellStyle10;
            this.columnQuantityOut.HeaderText = "Quantity Out";
            this.columnQuantityOut.MinimumWidth = 50;
            this.columnQuantityOut.Name = "columnQuantityOut";
            this.columnQuantityOut.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnQuantityOut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnItemSize
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnItemSize.DefaultCellStyle = dataGridViewCellStyle11;
            this.columnItemSize.HeaderText = "Item Size";
            this.columnItemSize.Name = "columnItemSize";
            // 
            // columnVehicleNo
            // 
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnVehicleNo.DefaultCellStyle = dataGridViewCellStyle12;
            this.columnVehicleNo.HeaderText = "Vehicle Number";
            this.columnVehicleNo.Name = "columnVehicleNo";
            // 
            // columnReference
            // 
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnReference.DefaultCellStyle = dataGridViewCellStyle13;
            this.columnReference.HeaderText = "Reference";
            this.columnReference.Name = "columnReference";
            // 
            // columnPaymode
            // 
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnPaymode.DefaultCellStyle = dataGridViewCellStyle14;
            this.columnPaymode.HeaderText = "Payment Mode";
            this.columnPaymode.MinimumWidth = 150;
            this.columnPaymode.Name = "columnPaymode";
            this.columnPaymode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnPaymode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnPaymode.Width = 150;
            // 
            // columnBankDetails
            // 
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnBankDetails.DefaultCellStyle = dataGridViewCellStyle15;
            this.columnBankDetails.HeaderText = "Bank Details";
            this.columnBankDetails.Name = "columnBankDetails";
            // 
            // columnPayModeReference
            // 
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnPayModeReference.DefaultCellStyle = dataGridViewCellStyle16;
            this.columnPayModeReference.HeaderText = "Payment Reference";
            this.columnPayModeReference.MinimumWidth = 200;
            this.columnPayModeReference.Name = "columnPayModeReference";
            this.columnPayModeReference.Width = 200;
            // 
            // columnDebit
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.Format = "N2";
            dataGridViewCellStyle17.NullValue = "0";
            this.columnDebit.DefaultCellStyle = dataGridViewCellStyle17;
            this.columnDebit.HeaderText = "Debit";
            this.columnDebit.MinimumWidth = 100;
            this.columnDebit.Name = "columnDebit";
            // 
            // columnCredit
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.Format = "N2";
            dataGridViewCellStyle18.NullValue = "0";
            this.columnCredit.DefaultCellStyle = dataGridViewCellStyle18;
            this.columnCredit.HeaderText = "Credit";
            this.columnCredit.MinimumWidth = 100;
            this.columnCredit.Name = "columnCredit";
            // 
            // columnDetails
            // 
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnDetails.DefaultCellStyle = dataGridViewCellStyle19;
            this.columnDetails.HeaderText = "Details";
            this.columnDetails.MinimumWidth = 100;
            this.columnDetails.Name = "columnDetails";
            // 
            // columnTag
            // 
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnTag.DefaultCellStyle = dataGridViewCellStyle20;
            this.columnTag.HeaderText = "Tag";
            this.columnTag.MinimumWidth = 100;
            this.columnTag.Name = "columnTag";
            // 
            // StockForm
            // 
            this.AcceptButton = this.btnAddData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 466);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "StockForm";
            this.Text = "Stock Details";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StockForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddData;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnParticulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSlipNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnInwardBillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnQuantityIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnQuantityOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnItemSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnVehicleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPaymode;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnBankDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPayModeReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTag;

    }
}