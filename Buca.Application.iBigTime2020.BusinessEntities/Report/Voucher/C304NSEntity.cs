using System;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher
{
    public class C304NSEntity : BusinessEntities
    {
        public int RefIDSortOrder { get; set; }

        public string RefID { get; set; }

        public int RefType { get; set; }

        public bool IsCash { get; set; }

        public string RefNo { get; set; }

        public DateTime RefDate { get; set; }

        public DateTime PostedDate { get; set; }

        public string BankAccount { get; set; }

        public bool OpenInBudget { get; set; }

        public string BankName { get; set; }

        public string ProjectName { get; set; }

        public string ProjectCode { get; set; }

        public string BudgetDistributionCode { get; set; }

        public string ProgramName { get; set; }

        public string ProgramCode { get; set; }

        public string TreasuaryBankName { get; set; }

        public string AccountingObjectBankName { get; set; }

        public string IdentificationNumber { get; set; }

        public DateTime IssueDate { get; set; }

        public string IssueBy { get; set; }

        public string Description { get; set; }

        public string BudgetChapterCode { get; set; }

        public string BudgetSubKindItemCode { get; set; }

        public string GovSourceCode { get; set; }

        public decimal Amount { get; set; }

        public int SortOrder { get; set; }

        public int Part { get; set; }

        public int LineInGroup { get; set; }

        public int MaxRow { get; set; }
        public string BudgetSubItemCode { get; set; }
    }
}
