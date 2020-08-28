/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 28, 2017
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
    /// SUTransferPresenter
    /// </summary>
    public class SUTransferPresenter : Presenter<ISUTransferView>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SUIncrementDecrementPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public SUTransferPresenter(ISUTransferView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        public void Display(string refId, bool hasDetail)
        {
            var suTransfers =
                Model.GetSUTransfer(refId, hasDetail) ?? new SUTransferModel();

            View.RefId = suTransfers.RefId;
            View.RefType = suTransfers.RefType;
            View.RefDate = suTransfers.RefDate;
            View.PostedDate = suTransfers.PostedDate;
            View.RefNo = suTransfers.RefNo;
            View.ParalellRefNo = suTransfers.ParalellRefNo;
            View.JournalMemo = suTransfers.JournalMemo;
            View.TotalAmount = suTransfers.TotalAmount;
            View.EditVersion = suTransfers.EditVersion;
            View.SUTransferDetails = suTransfers.SUTransferDetails;
        }

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var suTransfers = new SUTransferModel
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
                SUTransferDetails = View.SUTransferDetails
            };
            if (View.RefId == null)
                return Model.AddSUTransfer(suTransfers);
            return Model.UpdateSUTransfer(suTransfers);
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
            return Model.DeleteSUTransfer(refId);
        }
    }
}
