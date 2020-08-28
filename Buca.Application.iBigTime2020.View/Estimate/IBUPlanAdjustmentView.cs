using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;

namespace Buca.Application.iBigTime2020.View.Estimate
{
    public interface IBUPlanAdjustmentView : IView
    {
        string RefId { get; set; }

        int RefType { get; set; }

        DateTime RefDate { get; set; }

        DateTime PostedDate { get; set; }

        string RefNo { get; set; }

        string ParalellRefNo { get; set; }

        DateTime DecisionDate { get; set; }

        string DecisionNo { get; set; }

        string JournalMemo { get; set; }

        bool Posted { get; set; }

        decimal TotalPreAdjustmentAmount { get; set; }

        decimal TotalAdjustmentAmount { get; set; }

        decimal TotalPostAdjustmentAmount { get; set; }

        int PostVersion { get; set; }

        int EditVersion { get; set; }

        IList<BUPlanAdjustmentDetailModel> BUPlanAdjustmentDetails { get; set; }

        /// <summary>
        /// Tỉ giá quy đổi
        /// </summary>
        decimal ExchangeRate { get; set; }

        /// <summary>
        /// Tổng tiền sau quy đổi
        /// </summary>
        decimal TotalAmount { get; set; }

        /// <summary>
        /// Đơn vị tiền quy đổi
        /// </summary>
        string CurrencyCode { get; set; }
    }
}
