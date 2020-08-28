using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher
{
    public class C203NSEntity
    {
        public string RefID { get; set; }
        public bool IsSystemDate { get; set; }
        public bool IsRefDate { get; set; }
        public string ReportNameType { get; set; }
        public DateTime SystemDate { get; set; }
        public DateTime RefDate { get; set; }
        public string RefNo { get; set; }
        public string JournalMemo { get; set; }
        public string BudgetSourceCode { get; set; }
        public string BudgetChapterCode { get; set; }
        public string BudgetKindItemCode { get; set; }
        public string BudgetSubKindItemCode { get; set; }
        public string BudgetItemCode { get; set; }
        public string BudgetSubItemCode { get; set; }
        public decimal AdvancePaymentAmount { get; set; }
        public decimal PayAmount { get; set; }
        public decimal PayableAmount { get; set; }
        public string TargetProgramCode { get; set; }
        public string TargetProgramName { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public string Description { get; set; }
        public bool CheckCashWithDrawType { get; set; }
        public decimal Col1 { get; set; }
        public decimal Col2 { get; set; }
        public decimal Col3 { get; set; }
    }
}
