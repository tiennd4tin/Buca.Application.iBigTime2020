using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher
{
    public class C205aEntity
    {
        public bool IsCash { get; set; }
        public string RefID { get; set; }
        public int RefIDSortOrder { get; set; }
        public string RefNo { get; set; }
        public DateTime RefDate { get; set; }
        public DateTime PostedDate { get; set; }
        public int RefType { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public string JournalMemo { get; set; }
        public string GovSourceCode { get; set; }
        public string BudgetDistributionCode { get; set; }
        public string AccountingObjectName { get; set; }
        public string Description { get; set; }
        public string BudgetChapterCode { get; set; }
        public string BudgetSubKindItemCode { get; set; }
        public string BudgetItemCode { get; set; }
        public string BudgetSubItemCode { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountOC { get; set; }
        public string CurrencyCode { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public int BudgetType { get; set; }
        public int Part { get; set; }
        public int LineInGroup { get; set; }
        public int MaxRow { get; set; }
    }
}
