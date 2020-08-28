using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher
{
    public class PaymentPurchaseEntity
    {
        public string RefId { get; set; }
        public string RefDetailId { get; set; }
        public string RefNo { get; set; }
        public DateTime PostedDate { get; set; }
        public string RefDate { get; set; }
        public int RefType { get; set; }
        public decimal DomesticArising { get; set; }
        public decimal ForeignArising { get; set; }
        public string BudgetChapterCode { get; set; }
        public string BudgetSubKindItemCode { get; set; }
        public string BudgetItemCode { get; set; }
        public string BudgetSubItemCode { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public string GovSourceCode { get; set; }
        public decimal ApprovedQuanlity { get; set; }
        public decimal DomesticAccumulated { get; set; }
        public decimal ForeignAccumulated { get; set; }
        public string EditVersion { get; set; }
    }
}
