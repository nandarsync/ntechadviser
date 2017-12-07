namespace NTechAdviser.Forms
{
    partial class StockAddForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddData = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStripAddData = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnParticulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPaymode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPendingDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPendingCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnBankDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPayModeReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDateUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStripAddData.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 456);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 107);
            this.panel1.TabIndex = 0;
            // 
            // btnAddData
            // 
            this.btnAddData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddData.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddData.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddData.Location = new System.Drawing.Point(781, 35);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(120, 40);
            this.btnAddData.TabIndex = 0;
            this.btnAddData.Text = "Add Data";
            this.btnAddData.UseVisualStyleBackColor = true;
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
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
            this.columnProject,
            this.columnParticulars,
            this.columnPaymode,
            this.columnDebit,
            this.columnCredit,
            this.columnPendingDebit,
            this.columnPendingCredit,
            this.columnBankDetails,
            this.columnPayModeReference,
            this.columnDetails,
            this.columnTag,
            this.columnDateCreated,
            this.columnDateUpdated});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(949, 432);
            this.dataGridView1.TabIndex = 1;
            // 
            // menuStripAddData
            // 
            this.menuStripAddData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripAddData.Location = new System.Drawing.Point(0, 0);
            this.menuStripAddData.Name = "menuStripAddData";
            this.menuStripAddData.Size = new System.Drawing.Size(949, 24);
            this.menuStripAddData.TabIndex = 2;
            this.menuStripAddData.Text = "menuStrip1";
            this.menuStripAddData.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStripAddData_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDataToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addDataToolStripMenuItem
            // 
            this.addDataToolStripMenuItem.Name = "addDataToolStripMenuItem";
            this.addDataToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.addDataToolStripMenuItem.Text = "Add Data";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // columnProject
            // 
            this.columnProject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnProject.DefaultCellStyle = dataGridViewCellStyle2;
            this.columnProject.HeaderText = "Project";
            this.columnProject.MinimumWidth = 200;
            this.columnProject.Name = "columnProject";
            this.columnProject.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnProject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnProject.Width = 200;
            // 
            // columnParticulars
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnParticulars.DefaultCellStyle = dataGridViewCellStyle3;
            this.columnParticulars.HeaderText = "Particulars";
            this.columnParticulars.MinimumWidth = 200;
            this.columnParticulars.Name = "columnParticulars";
            this.columnParticulars.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnParticulars.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnParticulars.Width = 200;
            // 
            // columnPaymode
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnPaymode.DefaultCellStyle = dataGridViewCellStyle4;
            this.columnPaymode.HeaderText = "Payment Mode";
            this.columnPaymode.MinimumWidth = 150;
            this.columnPaymode.Name = "columnPaymode";
            this.columnPaymode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnPaymode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnPaymode.Width = 150;
            // 
            // columnDebit
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.columnDebit.DefaultCellStyle = dataGridViewCellStyle5;
            this.columnDebit.HeaderText = "Debit";
            this.columnDebit.MinimumWidth = 100;
            this.columnDebit.Name = "columnDebit";
            // 
            // columnCredit
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.columnCredit.DefaultCellStyle = dataGridViewCellStyle6;
            this.columnCredit.HeaderText = "Credit";
            this.columnCredit.MinimumWidth = 100;
            this.columnCredit.Name = "columnCredit";
            // 
            // columnPendingDebit
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.columnPendingDebit.DefaultCellStyle = dataGridViewCellStyle7;
            this.columnPendingDebit.HeaderText = "Pending Debit";
            this.columnPendingDebit.MinimumWidth = 100;
            this.columnPendingDebit.Name = "columnPendingDebit";
            // 
            // columnPendingCredit
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = "0";
            this.columnPendingCredit.DefaultCellStyle = dataGridViewCellStyle8;
            this.columnPendingCredit.HeaderText = "Pending Credit";
            this.columnPendingCredit.MinimumWidth = 100;
            this.columnPendingCredit.Name = "columnPendingCredit";
            // 
            // columnBankDetails
            // 
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnBankDetails.DefaultCellStyle = dataGridViewCellStyle9;
            this.columnBankDetails.HeaderText = "Bank Details";
            this.columnBankDetails.Name = "columnBankDetails";
            // 
            // columnPayModeReference
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnPayModeReference.DefaultCellStyle = dataGridViewCellStyle10;
            this.columnPayModeReference.HeaderText = "Payment Reference";
            this.columnPayModeReference.MinimumWidth = 200;
            this.columnPayModeReference.Name = "columnPayModeReference";
            this.columnPayModeReference.Width = 200;
            // 
            // columnDetails
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnDetails.DefaultCellStyle = dataGridViewCellStyle11;
            this.columnDetails.HeaderText = "Details";
            this.columnDetails.MinimumWidth = 100;
            this.columnDetails.Name = "columnDetails";
            // 
            // columnTag
            // 
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnTag.DefaultCellStyle = dataGridViewCellStyle12;
            this.columnTag.HeaderText = "Tag";
            this.columnTag.MinimumWidth = 100;
            this.columnTag.Name = "columnTag";
            // 
            // columnDateCreated
            // 
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnDateCreated.DefaultCellStyle = dataGridViewCellStyle13;
            this.columnDateCreated.HeaderText = "Date Created";
            this.columnDateCreated.Name = "columnDateCreated";
            // 
            // columnDateUpdated
            // 
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnDateUpdated.DefaultCellStyle = dataGridViewCellStyle14;
            this.columnDateUpdated.HeaderText = "Date Updated";
            this.columnDateUpdated.Name = "columnDateUpdated";
            // 
            // StockAddForm
            // 
            this.AcceptButton = this.btnAddData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 563);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStripAddData);
            this.MainMenuStrip = this.menuStripAddData;
            this.Name = "StockAddForm";
            this.Text = "Add Data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStripAddData.ResumeLayout(false);
            this.menuStripAddData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStripAddData;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button btnAddData;
        private System.Windows.Forms.ToolStripMenuItem addDataToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnParticulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPaymode;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPendingDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPendingCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnBankDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPayModeReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDateUpdated;
    }
}