using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTechAdviser.Forms
{
    /// <summary>
    /// Accounts Info class.
    /// </summary>
    public class AccountsInfo
    {
        /// <summary>
        /// Gets or sets the record unique identifier.
        /// </summary>
        /// <value>
        /// The record unique identifier.
        /// </value>
        public int RecordID
        { get; set; }

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        /// <value>
        /// The name of the project.
        /// </value>
        public string ProjectName
        { get; set; }

        /// <summary>
        /// Gets or sets the particulars.
        /// </summary>
        /// <value>
        /// The particulars.
        /// </value>
        public string Particulars
        { get; set; }

        /// <summary>
        /// Gets or sets the pay mode.
        /// </summary>
        /// <value>
        /// The pay mode.
        /// </value>
        public string PayMode
        { get; set; }

        /// <summary>
        /// Gets or sets the bank details.
        /// </summary>
        /// <value>
        /// The bank details.
        /// </value>
        public string BankDetails
        { get; set; }

        /// <summary>
        /// Gets or sets the pay mode reference.
        /// </summary>
        /// <value>
        /// The pay mode reference.
        /// </value>
        public string PayModeReference
        { get;  set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public string CreatedBy
        { get; set; }
        
        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public string CreatedDate
        { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public string UpdatedBy
        { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>
        /// The updated date.
        /// </value>
        public string UpdatedDate
        { get; set; }

        /// <summary>
        /// Gets or sets the debit.
        /// </summary>
        /// <value>
        /// The debit.
        /// </value>
        public Decimal Debit
        { get; set; }

        /// <summary>
        /// Gets or sets the credit.
        /// </summary>
        /// <value>
        /// The credit.
        /// </value>
        public Decimal Credit
        { get; set; }

        /// <summary>
        /// Gets or sets the pending credit.
        /// </summary>
        /// <value>
        /// The pending credit.
        /// </value>
        public Decimal PendingCredit
        { get; set; }

        /// <summary>
        /// Gets or sets the pending debit.
        /// </summary>
        /// <value>
        /// The pending debit.
        /// </value>
        public Decimal PendingDebit
        { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        public string Details
        { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string Tag
        { get; set; }

        /// <summary>
        /// Gets or sets the stock cargo unique identifier.
        /// </summary>
        /// <value>
        /// The stock cargo unique identifier.
        /// </value>
        public string StockCargoID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsInfo"/> class.
        /// </summary>
        public AccountsInfo()
        {
            RecordID = 0;
            ProjectName = string.Empty;
            Particulars = string.Empty;
            CreatedBy = string.Empty;
            UpdatedBy = string.Empty;
            CreatedDate = string.Empty;
            UpdatedDate = string.Empty;
            BankDetails = string.Empty;
            Debit = 0;
            Credit = 0;
            PendingCredit = 0;
            PendingDebit = 0;
            Details = string.Empty;
            Tag = string.Empty;
            StockCargoID = string.Empty;
        }
    }
}
