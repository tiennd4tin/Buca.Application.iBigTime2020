using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher
{
    public class C301NSDetailEntity
    {
        public Guid RefDetailID { get; set; }
        public string ContentDetail { get; set; }
        public string BudgetCategoryCode { get; set; }
        public string BudgetChapterCode { get; set; }
        public string BudgetItemCode { get; set; }
        public string BudgetSubItemCode { get; set; }
        public string BudgetSourceCode { get; set; }
        public int PlanYear { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal CompanyAmount { get; set; }
        public decimal EstimateAmount { get; set; }
        public decimal YTDInAmount { get; set; }
        public decimal YTDOutAmount { get; set; }
        public decimal PaymentInAmount { get; set; }
        public decimal PaymentOutAmount { get; set; }
        public int BudgetSourceProperty { get; set; }
        public decimal AdvanceRecovery { get; set; }
        public decimal OldAdvanceRecovery { get; set; }
    }
}
