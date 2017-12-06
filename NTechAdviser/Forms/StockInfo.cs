using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTechAdviser.Forms
{
    /// <summary>
    /// Accounts Info class.
    /// </summary>
    public class StockInfo
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
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public string Item
        { get; set; }


        /// <summary>
        /// Gets or sets the units.
        /// </summary>
        /// <value>
        /// The units.
        /// </value>
        public Decimal UnitsIn
        { get; set; }

        /// <summary>
        /// Gets or sets the units.
        /// </summary>
        /// <value>
        /// The units.
        /// </value>
        public Decimal UnitsOut
        { get; set; }

        /// <summary>
        /// Gets or sets the vehicle no.
        /// </summary>
        /// <value>
        /// The vehicle no.
        /// </value>
        public string VehicleNo
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
        { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public string CreatedBy
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
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public string DateCreated
        { get; set; }

        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        /// <value>
        /// The date updated.
        /// </value>
        public string DateUpdated
        { get; set; }

        /// <summary>
        /// Gets or sets the slip no.
        /// </summary>
        /// <value>
        /// The slip no.
        /// </value>
        public string SlipNo
        { get; set; }

        /// <summary>
        /// Gets or sets the inward bill no.
        /// </summary>
        /// <value>
        /// The inward bill no.
        /// </value>
        public string InwardBillNo
        { get; set; }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>
        /// The volume.
        /// </value>
        public string Volume
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsInfo"/> class.
        /// </summary>
        public StockInfo()
        {
            RecordID = 0;
            ProjectName = string.Empty;
            Particulars = string.Empty;
            Item = string.Empty;
            UnitsIn = 0;
            UnitsOut = 0;
            SlipNo = string.Empty;
            InwardBillNo = string.Empty;
            Volume = string.Empty;
            VehicleNo = string.Empty;
            CreatedBy = string.Empty;
            UpdatedBy = string.Empty;
            BankDetails = string.Empty;
            DateCreated = string.Empty;
            DateUpdated = string.Empty;
            Debit = 0;
            Credit = 0;
            Details = string.Empty;
            Tag = string.Empty;
        }
    }
}
