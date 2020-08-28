/***********************************************************************
 * <copyright file="suincrementdecrementpresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, October 25, 2017
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
    ///     SUIncrementDecrementPresenter
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{ISUIncrementDecrementView}" />
    public class SUIncrementDecrementPresenter : Presenter<ISUIncrementDecrementView>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SUIncrementDecrementPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public SUIncrementDecrementPresenter(ISUIncrementDecrementView view) : base(view)
        {
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        public void Display(string refId, bool hasDetail)
        {
            var sUIncrementDecrement =
                Model.GetSUIncrementDecrement(refId, hasDetail) ?? new SUIncrementDecrementModel();

            View.RefId = sUIncrementDecrement.RefId;
            View.RefType = sUIncrementDecrement.RefType;
            View.RefDate = sUIncrementDecrement.RefDate;
            View.PostedDate = sUIncrementDecrement.PostedDate;
            View.RefNo = sUIncrementDecrement.RefNo;
            View.ParalellRefNo = sUIncrementDecrement.ParalellRefNo;
            View.JournalMemo = sUIncrementDecrement.JournalMemo;
            View.TotalAmount = sUIncrementDecrement.TotalAmount;
            View.EditVersion = sUIncrementDecrement.EditVersion;
            View.SUIncrementDecrementDetails = sUIncrementDecrement.SUIncrementDecrementDetails;
        }

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var sUIncrementDecrement = new SUIncrementDecrementModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                ParalellRefNo = View.ParalellRefNo,
                JournalMemo = View.JournalMemo,
                TotalAmount = View.TotalAmount,
                EditVersion = View.EditVersion,
                SUIncrementDecrementDetails = View.SUIncrementDecrementDetails
            };
            if (View.RefId == null)
                return Model.AddSUIncrementDecrement(sUIncrementDecrement);
            return Model.UpdateSUIncrementDecrement(sUIncrementDecrement);
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
            return Model.DeleteSUIncrementDecrement(refId);
        }
    }
}