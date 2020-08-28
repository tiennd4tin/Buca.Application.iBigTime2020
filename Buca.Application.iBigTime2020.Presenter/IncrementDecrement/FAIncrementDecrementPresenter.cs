/***********************************************************************
 * <copyright file="FAIncrementDecrementPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement;
using Buca.Application.iBigTime2020.View.IncrementDecrement;

namespace Buca.Application.iBigTime2020.Presenter.IncrementDecrement
{
    /// <summary>
    ///     FAIncrementDecrementPresenter
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{IFAIncrementDecrementView}" />
    public class FAIncrementDecrementPresenter : Presenter<IFAIncrementDecrementView>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FAIncrementDecrementPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FAIncrementDecrementPresenter(IFAIncrementDecrementView view) : base(view)
        {
        }

        /// <summary>
        ///     Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        public void Display(string refId, bool hasDetail)
        {
            var fAIncrementDecrement = Model.GetFAIncrementDecrement(refId, hasDetail) ?? new FAIncrementDecrementModel();

            View.TotalAmount = fAIncrementDecrement.TotalAmount;
            View.RefId = fAIncrementDecrement.RefId;
            View.RefType = fAIncrementDecrement.RefType;
            View.RefDate = fAIncrementDecrement.RefDate;
            View.PostedDate = fAIncrementDecrement.PostedDate;
            View.RefNo = fAIncrementDecrement.RefNo;
            View.ParalellRefNo = fAIncrementDecrement.ParalellRefNo;
            View.JournalMemo = fAIncrementDecrement.JournalMemo;
            View.GeneratedRefId = fAIncrementDecrement.GeneratedRefId;
            View.FAIncrementDecrementDetails = fAIncrementDecrement.FAIncrementDecrementDetails;
        }

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var fAIncrementDecrement = new FAIncrementDecrementModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                ParalellRefNo = View.ParalellRefNo,
                JournalMemo = View.JournalMemo,
                TotalAmount = View.TotalAmount,
                GeneratedRefId = View.GeneratedRefId,
                FAIncrementDecrementDetails = View.FAIncrementDecrementDetails
            };
            return Model.AddFAIncrementDecrement(fAIncrementDecrement);
        }

        /// <summary>
        ///     Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public string Delete(string refId)
        {
            return Model.DeleteFAIncrementDecrement(refId);
        }
    }
}