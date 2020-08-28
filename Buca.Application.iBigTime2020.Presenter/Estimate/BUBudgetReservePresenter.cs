/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    11/12/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.View.Estimate;

namespace Buca.Application.iBigTime2020.Presenter.Estimate
{
    /// <summary>
    /// BUBudgetReservePresenter
    /// </summary>
    public class BUBudgetReservePresenter : Presenter<IBUBudgetReserveView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BUPlanReceiptPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BUBudgetReservePresenter(IBUBudgetReserveView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(string refId)
        {
            var bUBudgetReserve = Model.GetBUBudgetReserveByRefId(refId, true) ?? new BUBudgetReserveModel();

            View.RefId = bUBudgetReserve.RefId;
            View.RefDate = bUBudgetReserve.RefDate;
            View.PostedDate = bUBudgetReserve.PostedDate;
            View.RefNo = bUBudgetReserve.RefNo;
            View.RefType = bUBudgetReserve.RefType;
            View.BudgetChapterCode = bUBudgetReserve.BudgetChapterCode;
            View.BudgetChapterName = bUBudgetReserve.BudgetChapterName;
            View.JournalMemo = bUBudgetReserve.JournalMemo;
            View.CurrencyCode = bUBudgetReserve.CurrencyCode;
            View.ExchangeRate = bUBudgetReserve.ExchangeRate;
            View.TotalAmountOC = bUBudgetReserve.TotalAmountOC;
            View.Posted = bUBudgetReserve.Posted;
            View.EditVersion = bUBudgetReserve.EditVersion;
            View.PostVersion = bUBudgetReserve.PostVersion;
            View.BUBudgetReserveDetails = bUBudgetReserve.BUBudgetReserveDetails.ToList();
            View.TotalAmount = bUBudgetReserve.TotalAmount;

        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>
        /// System.String.
        /// </returns>
        public string Save()
        {
            var bUBudgetReserve = new BUBudgetReserveModel
            {

                RefId = View.RefId,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                RefType = View.RefType,
                BudgetChapterCode = View.BudgetChapterCode,
                BudgetChapterName = View.BudgetChapterName,
                JournalMemo = View.JournalMemo,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                TotalAmount = View.TotalAmount,
                TotalAmountOC = View.TotalAmountOC,
                Posted = View.Posted,
                EditVersion = View.EditVersion,
                PostVersion = View.PostVersion,
                BUBudgetReserveDetails = View.BUBudgetReserveDetails
            };
            if (View.RefId == null)
                return Model.InsertBUBudgetReserve(bUBudgetReserve);
            return Model.UpdateBUBudgetReserve(bUBudgetReserve);
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
            return Model.DeleteBUBudgetReserve(refId);
        }
    }
}
