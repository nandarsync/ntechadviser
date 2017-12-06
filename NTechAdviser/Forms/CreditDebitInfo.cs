using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTechAdviser.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public class CreditDebitInfo
    {
        public int RecID_AccInfo
        { get; set; }

        public int CreditDebitID
        { get; set; }

        public Decimal CreDebInfoDebitValue
        { get; set; }

        public Decimal CreDebInfoCreditValue
        { get; set; }

        public string Project
        { get; set; }

        public string Particulars
        { get; set; }

        public string PayMode
        { get; set; }

        public string PayModeReference
        { get; set; }

        public string BankDetails
        { get; set; }

        public string CreatedBy
        { get; set; }

        public string CreatedDate
        { get; set; }

        public string LastUpdatedBy
        { get; set; }

        public string LastUpdatedDate
        { get; set; }

        public Decimal Credit
        { get; set; }

        public Decimal Debit
        { get; set; }

        public string Details
        { get; set; }

        public string Tag
        { get; set; }

        public string TableRef
        { get; set; }

        public CreditDebitInfo()
        {
            RecID_AccInfo = 0;
            CreditDebitID = 0;
            Project = string.Empty;
            Particulars = string.Empty;
            PayMode = string.Empty;
            PayModeReference = string.Empty;
            BankDetails = string.Empty;
            CreatedBy = string.Empty;
            CreatedDate = string.Empty;
            LastUpdatedBy = string.Empty;
            LastUpdatedDate = string.Empty;
            TableRef = string.Empty;
            Credit = 0;
            Debit = 0;
            Details = string.Empty;
            Tag = string.Empty;
        }
    }
}
