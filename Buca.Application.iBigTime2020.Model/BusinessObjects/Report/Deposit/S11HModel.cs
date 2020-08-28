using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Deposit
{
    public  class S11HModel
    {
        public DateTime StartOfMonth { get; set; }
        public int OrderType { get; set; }
        public string RefId { get; set; }
        public int RefType { get; set; }
        public DateTime PostedDate { get; set; }
        public string RefNo { get; set; }
        public DateTime RefDate { get; set; }
        public string JournalMemo { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string BudgetChapterCode { get; set; }
        public string BudgetSourceCode { get; set; }
        public string BudgetSourceName { get; set; }
        public string BudgetSubKindItemCode { get; set; }
        public string AccountingObjectName { get; set; }
        public string SortOrder { get; set; }
        public decimal Cot1 { get; set; }
        public decimal Cot2 { get; set; }
        public decimal AccCot2 { get; set; }
        public decimal QuyCot2 { get; set; }
        public decimal Cot3 { get; set; }
        public decimal AccCot3 { get; set; }
        public decimal QuyCot3 { get; set; }
    }
}
