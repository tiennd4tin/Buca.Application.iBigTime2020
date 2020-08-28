using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate
{
    public class BUPlanReceiptEntity:BusinessEntities
    {
        public BUPlanReceiptEntity()
        {
            AddRule(new ValidateRequired("RefType"));
            AddRule(new ValidateRequired("RefDate"));          
        }
        public string RefId { get; set; }

        public int RefType { get; set; }

        public DateTime RefDate { get; set; }

        public DateTime PostedDate { get; set; }

        public string RefNo { get; set; }

        public string CurrencyCode { get; set; }

        public decimal ExchangeRate { get; set; }
        public string ParalellRefNo { get; set; }

        public DateTime? DecisionDate { get; set; }

        public string DecisionNo { get; set; }

        public string BudgetChapterCode { get; set; }

        public string JournalMemo { get; set; }

        public bool Posted { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalAmountOC { get; set; }

        public int AllocationConfig { get; set; }
        public IList<BUPlanReceiptDetailEntity> BuPlanReceiptDetails { get; set; }
    }
}
