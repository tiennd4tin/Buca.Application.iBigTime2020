using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.View.Estimate;

namespace Buca.Application.iBigTime2020.Presenter.Estimate
{
    /// <summary>
    /// BUPlanReceiptPresenter
    /// </summary>
    public class BUPlanReceiptPresenter : Presenter<IBUPlanReceiptView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BUPlanReceiptPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BUPlanReceiptPresenter(IBUPlanReceiptView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(string refId)
        {
            var bUPlanReceipt = Model.GetBUPlanReceiptVoucherByRefId(refId, true) ?? new BUPlanReceiptModel();

            View.RefId = bUPlanReceipt.RefId;
            View.RefType = bUPlanReceipt.RefType;
            View.RefDate = bUPlanReceipt.RefDate;
            View.PostedDate = bUPlanReceipt.PostedDate;
            View.RefNo = bUPlanReceipt.RefNo;
            View.ExchangeRate = bUPlanReceipt.ExchangeRate;
            View.ParalellRefNo = bUPlanReceipt.ParalellRefNo;
            View.DecisionDate = bUPlanReceipt.DecisionDate;
            View.DecisionNo = bUPlanReceipt.DecisionNo;
            View.BudgetChapterCode = bUPlanReceipt.BudgetChapterCode;
            View.JournalMemo = bUPlanReceipt.JournalMemo;
            View.Posted = bUPlanReceipt.Posted;
            View.TotalAmountOC = bUPlanReceipt.TotalAmountOC;
            View.AllocationConfig = bUPlanReceipt.AllocationConfig;
            View.BuPlanReceiptDetailModels = bUPlanReceipt.BUPlanReceiptDetails.ToList() ?? new List<BUPlanReceiptDetailModel>();
            View.CurrencyCode = bUPlanReceipt.CurrencyCode;
            View.TotalAmount = bUPlanReceipt.TotalAmount;

        }
        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>
        /// System.String.
        /// </returns>
        public string Save()
        {
            var bUPlanReceipt = new BUPlanReceiptModel()
            {

                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo.Trim(),
                ExchangeRate = View.ExchangeRate,
                CurrencyCode = View.CurrencyCode,
                ParalellRefNo = View.ParalellRefNo,
                DecisionDate = View.DecisionDate,
                DecisionNo = View.DecisionNo.Trim(),
                BudgetChapterCode = View.BudgetChapterCode,
                JournalMemo = View.JournalMemo.Trim(),
                Posted = View.Posted,
                TotalAmount = View.TotalAmount,
                TotalAmountOC = View.TotalAmountOC,
                AllocationConfig = View.AllocationConfig,
                BUPlanReceiptDetails = View.BuPlanReceiptDetailModels
               
            };
            if (View.RefId == null)
                return Model.InsertBUPlanReceipt(bUPlanReceipt);
            return Model.UpdateBUPlanReceipt(bUPlanReceipt);
        }
        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        public string Delete(string refId)
        {
            return Model.DeleteBUPlanReceipt(refId);
        }


    }
}
