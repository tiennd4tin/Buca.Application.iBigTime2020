using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher
{
    public class BusC302NSModel
    {
        public string BudgetItemCode { get; set; }
        public string BudgetChapterCode { get; set; }
        public string BudgetKindItemCode { get; set; }
        public string BudgetSourceCode { get; set; }
        public decimal? AmountOC { get; set; }
        public decimal? AdvanceRecovery { get; set; }
        public string ProjectName { get; set; }
        public string ProjectBankName { get; set; }
        public string ProjectBankAccount { get; set; }
        public string Investment { get; set; }
        public int? PostedYear { get; set; }
        public DateTime? PostedDate { get; set; }
    }
}
