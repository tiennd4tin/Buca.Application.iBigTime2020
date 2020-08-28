using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.General
{
    public class GLVoucherListParamaterEntity : BusinessEntities
    {
        public string RefDetailId { get; set; }
        public string RefId { get; set; }
        public int DetailRefType { get; set; }      
        public string BudgetSourceId { get; set; }
        public DateTime RefDate { get; set; }
        public DateTime PostedDate { get; set; }
        public string RefNo { get; set; }
        public string Description { get; set; }
        public string DebitAccount { get; set; }
        public string CreditAccount { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountOC { get; set; }
        public string OrgRefNo { get; set; }
        public DateTime OrgRefDate { get; set; }
        public string ProjectId { get; set; }
        public string BudgetChapterCode { get; set; }
        public string BudgetSubKindItemCode { get; set; }
        public string BudgetItemCode { get; set; }
        public string BudgetSubItemCode { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
