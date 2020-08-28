using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate
{
   public class BUPlanReceiptModel
    {
       public BUPlanReceiptModel()
       {
            BUPlanReceiptDetails = new List<BUPlanReceiptDetailModel>();

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

        public IList<BUPlanReceiptDetailModel> BUPlanReceiptDetails { set; get; }


    }
}
