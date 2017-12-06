using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using PrintDataGrid;

namespace NTechAdviser.Print
{
    public class PrintFileGenerator
    {
        private static StringFormat StrFormat;  // Holds content of a TextBox Cell to write by DrawString
        private static StringFormat StrFormatComboBox; // Holds content of a Boolean Cell to write by DrawImage
        private static Button CellButton;       // Holds the Contents of Button Cell
        private static CheckBox CellCheckBox;   // Holds the Contents of CheckBox Cell 
        private static ComboBox CellComboBox;   // Holds the Contents of ComboBox Cell

        private static int TotalWidth;          // Summation of Columns widths
        private static int RowPos;              // Position of currently printing row 
        private static bool NewPage;            // Indicates if a new page reached
        private static int PageNo;              // Number of pages to print
        private static ArrayList ColumnLefts = new ArrayList();  // Left Coordinate of Columns
        private static ArrayList ColumnWidths = new ArrayList(); // Width of Columns
        private static ArrayList ColumnTypes = new ArrayList();  // DataType of Columns
        private static int CellHeight;          // Height of DataGrid Cell
        private static int RowsPerPage;         // Number of Rows per Page
        private static System.Drawing.Printing.PrintDocument printDoc =
                       new System.Drawing.Printing.PrintDocument();  // PrintDocumnet Object used for printing

        public string PrintTitle
        {
            get;
            set;
        }
        private static DataGridView dgv;        // Holds DataGridView Object to print its contents
        public List<string> SelectedColumns
        {
            get;
            set;
        }// The Columns Selected by user to print.
        public List<string> AvailableColumns
        { get; set; }// All Columns avaiable in DataGrid 
        public bool PrintAllRows
        {
            get;
            set;
        }// True = print all rows,  False = print selected rows    
        private static bool FitToPageWidth = true; // True = Fits selected columns to page width ,  False = Print columns as showed    
        private static int HeaderHeight = 0;

        /// <summary>
        /// Generates the print file.
        /// </summary>
        /// <param name="dgv1">The DGV1.</param>
        /// <param name="formKey">send some key to identify the form. Use proper case.</param>
        public void GeneratePrintFile(DataGridView dgv1, string formKey)
        {
            PrintTitle = string.Empty;
            SelectedColumns = new List<string>();
            AvailableColumns = new List<string>();
            PrintAllRows = false;

            // Getting DataGridView object to print
            dgv = dgv1;

            // Getting all Coulmns Names in the DataGridView
            AvailableColumns.Clear();
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                if (!c.Visible) continue;

                if (formKey == "SearchForm")
                {
                    if (!ApplicationContext.AvoidableColumnsForAccountsSearch.Contains(c.HeaderText))
                        AvailableColumns.Add(c.HeaderText);
                }
                else if (formKey == "CreditDebitForm")
                {
                    if (!ApplicationContext.AvoidableColumnsForCreDebSearch.Contains(c.HeaderText))
                        AvailableColumns.Add(c.HeaderText);
                }
                else if (formKey == "StockSearchForm")
                {
                    if (!ApplicationContext.AvoidableColumnsForStocksSearch.Contains(c.HeaderText))
                        AvailableColumns.Add(c.HeaderText);
                }
            }

            ReArrangeList arrangeListDlg = new ReArrangeList(AvailableColumns);
            if (arrangeListDlg.ShowDialog() != DialogResult.OK)
            {
                ApplicationContext.PrintContentGenerated = false;
                return;
            }
            AvailableColumns = arrangeListDlg.GetItemsInRearrangedOrder();

            // Showing the PrintOption Form
            PrintFileOptions dlg = new PrintFileOptions(AvailableColumns);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                ApplicationContext.PrintContentGenerated = false;
                return;
            }
            PrintTitle = dlg.PrintTitle;
            PrintAllRows = dlg.PrintAllRows;
            FitToPageWidth = dlg.FitToPageWidth;
            SelectedColumns = dlg.GetSelectedColumns();
            ApplicationContext.PrintContentGenerated = true;
        }
    }
}
