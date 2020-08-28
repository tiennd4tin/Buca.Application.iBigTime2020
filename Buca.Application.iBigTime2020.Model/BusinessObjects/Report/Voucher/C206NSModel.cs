using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher
{
    public class C206NSModel
    {
        public int RefIDSortOrder { get; set; }
        public int ID { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public string TargetProgramID { get; set; }
        public string TargetProgramCode { get; set; }
        public string TargetProgramName { get; set; }
        public string RefID { get; set; }
        public string RefNo { get; set; }
        public int RefType { get; set; }
        public DateTime RefDate { get; set; }
        public DateTime PostedDate { get; set; }
        public string JournalMemo { get; set; }
        public int CashWithDrawType { get; set; }
        public string AccountingObjectName { get; set; }
        public string AccountingObjectAddress { get; set; }
        public string AccountingObjectBankAccount { get; set; }
        public string AccountingObjectBankName { get; set; }
        public string AccountingObjectTargetProgramCode { get; set; }
        public string AccountingObjectTargetProgramName { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssueBy { get; set; }
        public string AreaCode { get; set; }
        public string IdentificationNumber { get; set; }
        public string BudgetCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public string CurrencyCode { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAmountOC { get; set; }
        public string BudgetSourceID { get; set; }
        public string BudgetSourceCode { get; set; }
        public string BudgetSourceName { get; set; }
        public string Property { get; set; }
        public string Description { get; set; }
        public string BudgetChapterCode { get; set; }
        public string BudgetKindItemCode { get; set; }
        public string BudgetSubKindItemCode { get; set; }
        public string BudgetItemCode { get; set; }
        public string BudgetSubItemCode { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountOC { get; set; }
        public int Part { get; set; }
        public int LineInGroup { get; set; }
        public int MaxRow { get; set; }
        public int OrderType { get; set; }
    }
}
