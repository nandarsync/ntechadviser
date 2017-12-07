namespace NTechAdviser.Forms
{
    partial class PendingDebitUpdate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblProject = new System.Windows.Forms.Label();
            this.lblParticular = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.datePickerDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearchAll = new System.Windows.Forms.Button();
            this.txtBoxCredit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtBoxDebit = new System.Windows.Forms.TextBox();
            this.txtBoxParticular = new System.Windows.Forms.TextBox();
            this.txtBoxProject = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelPendingView = new System.Windows.Forms.Panel();
            this.txtBoxCredittedAmount = new System.Windows.Forms.TextBox();
            this.lblCreditedAmt = new System.Windows.Forms.Label();
            this.txtBoxAmountToGet = new System.Windows.Forms.TextBox();
            this.lalAmtToGet = new System.Windows.Forms.Label();
            this.txtBoxPendingCredit = new System.Windows.Forms.TextBox();
            this.lblPendingCredit = new System.Windows.Forms.Label();
            this.txtBoxPendingAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxDebittedAmount = new System.Windows.Forms.TextBox();
            this.lblAmtGiven = new System.Windows.Forms.Label();
            this.txtBoxAmtToGive = new System.Windows.Forms.TextBox();
            this.lblOverallSum = new System.Windows.Forms.Label();
            this.dataGridViewDebitReview = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelPendingView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDebitReview)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProject.Location = new System.Drawing.Point(30, 18);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(52, 18);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project";
            // 
            // lblParticular
            // 
            this.lblParticular.AutoSize = true;
            this.lblParticular.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParticular.Location = new System.Drawing.Point(30, 60);
            this.lblParticular.Name = "lblParticular";
            this.lblParticular.Size = new System.Drawing.Size(66, 18);
            this.lblParticular.TabIndex = 1;
            this.lblParticular.Text = "Particular";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(30, 102);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(42, 18);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "Debit";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(987, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.datePickerDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSearchAll);
            this.panel1.Controls.Add(this.txtBoxCredit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.txtBoxDebit);
            this.panel1.Controls.Add(this.txtBoxParticular);
            this.panel1.Controls.Add(this.txtBoxProject);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.lblProject);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.lblParticular);
            this.panel1.Controls.Add(this.lblAmount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1104, 183);
            this.panel1.TabIndex = 4;
            // 
            // datePickerDate
            // 
            this.datePickerDate.Location = new System.Drawing.Point(113, 139);
            this.datePickerDate.Name = "datePickerDate";
            this.datePickerDate.Size = new System.Drawing.Size(373, 26);
            this.datePickerDate.TabIndex = 11;
            this.datePickerDate.Value = new System.DateTime(2017, 12, 7, 17, 24, 44, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Date";
            // 
            // btnSearchAll
            // 
            this.btnSearchAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchAll.Location = new System.Drawing.Point(987, 96);
            this.btnSearchAll.Name = "btnSearchAll";
            this.btnSearchAll.Size = new System.Drawing.Size(90, 30);
            this.btnSearchAll.TabIndex = 7;
            this.btnSearchAll.Text = "Search All";
            this.btnSearchAll.UseVisualStyleBackColor = true;
            this.btnSearchAll.Click += new System.EventHandler(this.btnSearchAll_Click);
            // 
            // txtBoxCredit
            // 
            this.txtBoxCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxCredit.Location = new System.Drawing.Point(645, 99);
            this.txtBoxCredit.Name = "txtBoxCredit";
            this.txtBoxCredit.Size = new System.Drawing.Size(314, 26);
            this.txtBoxCredit.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(563, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Credit";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(987, 137);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 30);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtBoxDebit
            // 
            this.txtBoxDebit.Location = new System.Drawing.Point(113, 99);
            this.txtBoxDebit.Name = "txtBoxDebit";
            this.txtBoxDebit.Size = new System.Drawing.Size(373, 26);
            this.txtBoxDebit.TabIndex = 3;
            // 
            // txtBoxParticular
            // 
            this.txtBoxParticular.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxParticular.Location = new System.Drawing.Point(113, 57);
            this.txtBoxParticular.Name = "txtBoxParticular";
            this.txtBoxParticular.Size = new System.Drawing.Size(846, 26);
            this.txtBoxParticular.TabIndex = 2;
            // 
            // txtBoxProject
            // 
            this.txtBoxProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxProject.Location = new System.Drawing.Point(113, 15);
            this.txtBoxProject.Name = "txtBoxProject";
            this.txtBoxProject.Size = new System.Drawing.Size(846, 26);
            this.txtBoxProject.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(987, 54);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelPendingView);
            this.panel2.Controls.Add(this.dataGridViewDebitReview);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 207);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1104, 315);
            this.panel2.TabIndex = 5;
            // 
            // panelPendingView
            // 
            this.panelPendingView.Controls.Add(this.txtBoxCredittedAmount);
            this.panelPendingView.Controls.Add(this.lblCreditedAmt);
            this.panelPendingView.Controls.Add(this.txtBoxAmountToGet);
            this.panelPendingView.Controls.Add(this.lalAmtToGet);
            this.panelPendingView.Controls.Add(this.txtBoxPendingCredit);
            this.panelPendingView.Controls.Add(this.lblPendingCredit);
            this.panelPendingView.Controls.Add(this.txtBoxPendingAmount);
            this.panelPendingView.Controls.Add(this.label2);
            this.panelPendingView.Controls.Add(this.txtBoxDebittedAmount);
            this.panelPendingView.Controls.Add(this.lblAmtGiven);
            this.panelPendingView.Controls.Add(this.txtBoxAmtToGive);
            this.panelPendingView.Controls.Add(this.lblOverallSum);
            this.panelPendingView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPendingView.Location = new System.Drawing.Point(0, 218);
            this.panelPendingView.Name = "panelPendingView";
            this.panelPendingView.Size = new System.Drawing.Size(1104, 97);
            this.panelPendingView.TabIndex = 1;
            // 
            // txtBoxCredittedAmount
            // 
            this.txtBoxCredittedAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxCredittedAmount.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxCredittedAmount.Location = new System.Drawing.Point(513, 54);
            this.txtBoxCredittedAmount.Name = "txtBoxCredittedAmount";
            this.txtBoxCredittedAmount.Size = new System.Drawing.Size(201, 26);
            this.txtBoxCredittedAmount.TabIndex = 12;
            // 
            // lblCreditedAmt
            // 
            this.lblCreditedAmt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreditedAmt.AutoSize = true;
            this.lblCreditedAmt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditedAmt.Location = new System.Drawing.Point(383, 57);
            this.lblCreditedAmt.Name = "lblCreditedAmt";
            this.lblCreditedAmt.Size = new System.Drawing.Size(115, 18);
            this.lblCreditedAmt.TabIndex = 10;
            this.lblCreditedAmt.Text = "Credited Amount";
            // 
            // txtBoxAmountToGet
            // 
            this.txtBoxAmountToGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxAmountToGet.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxAmountToGet.Location = new System.Drawing.Point(144, 54);
            this.txtBoxAmountToGet.Name = "txtBoxAmountToGet";
            this.txtBoxAmountToGet.Size = new System.Drawing.Size(201, 26);
            this.txtBoxAmountToGet.TabIndex = 10;
            // 
            // lalAmtToGet
            // 
            this.lalAmtToGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lalAmtToGet.AutoSize = true;
            this.lalAmtToGet.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lalAmtToGet.Location = new System.Drawing.Point(15, 57);
            this.lalAmtToGet.Name = "lalAmtToGet";
            this.lalAmtToGet.Size = new System.Drawing.Size(100, 18);
            this.lalAmtToGet.TabIndex = 8;
            this.lalAmtToGet.Text = "Amount To Get";
            // 
            // txtBoxPendingCredit
            // 
            this.txtBoxPendingCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxPendingCredit.Enabled = false;
            this.txtBoxPendingCredit.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPendingCredit.Location = new System.Drawing.Point(869, 54);
            this.txtBoxPendingCredit.Name = "txtBoxPendingCredit";
            this.txtBoxPendingCredit.Size = new System.Drawing.Size(201, 26);
            this.txtBoxPendingCredit.TabIndex = 14;
            // 
            // lblPendingCredit
            // 
            this.lblPendingCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPendingCredit.AutoSize = true;
            this.lblPendingCredit.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingCredit.Location = new System.Drawing.Point(740, 57);
            this.lblPendingCredit.Name = "lblPendingCredit";
            this.lblPendingCredit.Size = new System.Drawing.Size(100, 18);
            this.lblPendingCredit.TabIndex = 6;
            this.lblPendingCredit.Text = "Pending Credit";
            // 
            // txtBoxPendingAmount
            // 
            this.txtBoxPendingAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxPendingAmount.Enabled = false;
            this.txtBoxPendingAmount.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPendingAmount.Location = new System.Drawing.Point(869, 18);
            this.txtBoxPendingAmount.Name = "txtBoxPendingAmount";
            this.txtBoxPendingAmount.Size = new System.Drawing.Size(201, 26);
            this.txtBoxPendingAmount.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(740, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pending Debit";
            // 
            // txtBoxDebittedAmount
            // 
            this.txtBoxDebittedAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxDebittedAmount.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDebittedAmount.Location = new System.Drawing.Point(513, 18);
            this.txtBoxDebittedAmount.Name = "txtBoxDebittedAmount";
            this.txtBoxDebittedAmount.Size = new System.Drawing.Size(201, 26);
            this.txtBoxDebittedAmount.TabIndex = 11;
            // 
            // lblAmtGiven
            // 
            this.lblAmtGiven.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmtGiven.AutoSize = true;
            this.lblAmtGiven.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmtGiven.Location = new System.Drawing.Point(383, 21);
            this.lblAmtGiven.Name = "lblAmtGiven";
            this.lblAmtGiven.Size = new System.Drawing.Size(116, 18);
            this.lblAmtGiven.TabIndex = 2;
            this.lblAmtGiven.Text = "Debitted Amount";
            // 
            // txtBoxAmtToGive
            // 
            this.txtBoxAmtToGive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxAmtToGive.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxAmtToGive.Location = new System.Drawing.Point(144, 18);
            this.txtBoxAmtToGive.Name = "txtBoxAmtToGive";
            this.txtBoxAmtToGive.Size = new System.Drawing.Size(201, 26);
            this.txtBoxAmtToGive.TabIndex = 9;
            // 
            // lblOverallSum
            // 
            this.lblOverallSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOverallSum.AutoSize = true;
            this.lblOverallSum.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverallSum.Location = new System.Drawing.Point(15, 21);
            this.lblOverallSum.Name = "lblOverallSum";
            this.lblOverallSum.Size = new System.Drawing.Size(106, 18);
            this.lblOverallSum.TabIndex = 0;
            this.lblOverallSum.Text = "Amount To Give";
            // 
            // dataGridViewDebitReview
            // 
            this.dataGridViewDebitReview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDebitReview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewDebitReview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDebitReview.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewDebitReview.Location = new System.Drawing.Point(3, 6);
            this.dataGridViewDebitReview.Name = "dataGridViewDebitReview";
            this.dataGridViewDebitReview.Size = new System.Drawing.Size(1098, 212);
            this.dataGridViewDebitReview.TabIndex = 0;
            this.dataGridViewDebitReview.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDebitReview_CellEndEdit);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1104, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // PendingDebitUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 522);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PendingDebitUpdate";
            this.Text = "Debit Credit Update";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PendingDebitUpdate_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelPendingView.ResumeLayout(false);
            this.panelPendingView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDebitReview)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label lblParticular;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewDebitReview;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TextBox txtBoxDebit;
        private System.Windows.Forms.TextBox txtBoxParticular;
        private System.Windows.Forms.TextBox txtBoxProject;
        private System.Windows.Forms.Panel panelPendingView;
        private System.Windows.Forms.TextBox txtBoxPendingAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxDebittedAmount;
        private System.Windows.Forms.Label lblAmtGiven;
        private System.Windows.Forms.TextBox txtBoxAmtToGive;
        private System.Windows.Forms.Label lblOverallSum;
        private System.Windows.Forms.TextBox txtBoxCredit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxPendingCredit;
        private System.Windows.Forms.Label lblPendingCredit;
        private System.Windows.Forms.TextBox txtBoxCredittedAmount;
        private System.Windows.Forms.Label lblCreditedAmt;
        private System.Windows.Forms.TextBox txtBoxAmountToGet;
        private System.Windows.Forms.Label lalAmtToGet;
        private System.Windows.Forms.Button btnSearchAll;
        private System.Windows.Forms.DateTimePicker datePickerDate;
        private System.Windows.Forms.Label label4;
    }
}