using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate
{
    public class BUPlanAdjustmentModel
    {
        public string RefId { get; set; }

        public int RefType { get; set; }

        public DateTime RefDate { get; set; }

        public DateTime PostedDate { get; set; }

        public string RefNo { get; set; }

        public string ParalellRefNo { get; set; }

        public DateTime DecisionDate { get; set; }

        public string DecisionNo { get; set; }

        public string JournalMemo { get; set; }

        public bool Posted { get; set; }

        public decimal TotalPreAdjustmentAmount { get; set; }

        public decimal TotalAdjustmentAmount { get; set; }

        public decimal TotalPostAdjustmentAmount { get; set; }

        public int PostVersion { get; set; }

        public int EditVersion { get; set; }

        public IList<BUPlanAdjustmentDetailModel> BuPlanAdjustmentDetailModels { get; set; }

        /// <summary>
        /// Tỉ giá quy đổi
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Tổng tiền sau quy đổi
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Đơn vị tiền quy đổi
        /// </summary>
        public string CurrencyCode { get; set; }
    }
}
