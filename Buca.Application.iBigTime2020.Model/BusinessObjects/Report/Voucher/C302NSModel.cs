using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher
{
    public class C302NSModel
    {
        public DateTime RefDate { get; set; }
        public string RefNo { get; set; }
        public string Description { get; set; }
        public string BudgetChapterCode { get; set; }
        public string BudgetKindItemCode { get; set; }
        public string BudgetSubKindItemCode { get; set; }
        public string BudgetItemCode { get; set; }
        public string BudgetSubItemCode { get; set; }
        public decimal AdvancePaymentAmount { get; set; }
        public decimal PayAmount { get; set; }
        public decimal PayableAmount { get; set; }
        public string Property { get; set; }
        public string TargetProgramCode { get; set; }
        public string TargetProgramName { get; set; }
        public string BudgetDistributionCode { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public string InvestmentNumber { get; set; }
        public DateTime InvestmentDate { get; set; }
        public string YearPlan { get; set; }
        public bool CheckCashWithDrawType { get; set; }
        public DateTime CreateDate { get; set; }
        public string BudgetSourceCode { get; set; }
        public string ProjectBankName { get; set; }
        public string ProjectBankAccount { get; set; }
        public List<C302NSModel> Details { get; set; }
    }
}
