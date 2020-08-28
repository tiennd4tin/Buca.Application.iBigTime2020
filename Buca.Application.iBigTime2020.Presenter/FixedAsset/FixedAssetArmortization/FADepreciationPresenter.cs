/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using Buca.Application.iBigTime2020.Model.BusinessObjects.FixedAsset;
using Buca.Application.iBigTime2020.View.FixedAsset;

namespace Buca.Application.iBigTime2020.Presenter.FixedAsset.FixedAssetArmortization
{
    public class FADepreciationPresenter : Presenter<IFADepreciationView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FADepreciationPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FADepreciationPresenter(IFADepreciationView view)
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
            var fADepreciation =
                Model.GetFADepreciation(refId, hasDetail) ?? new FADepreciationModel();

            View.RefId = fADepreciation.RefId;
            View.RefType = fADepreciation.RefType;
            View.RefDate = fADepreciation.RefDate;
            View.PostedDate = fADepreciation.PostedDate;
            View.RefNo = fADepreciation.RefNo;
            View.ParalellRefNo = fADepreciation.ParalellRefNo;
            View.JournalMemo = fADepreciation.JournalMemo;
            View.TotalAmount = fADepreciation.TotalAmount;
            View.PeriodType = fADepreciation.PeriodType;
            View.PeriodTypeName = fADepreciation.PeriodTypeName;
            View.FADepreciationDetails = fADepreciation.FADepreciationDetails;
        }

        /// <summary>
        /// Displays the devaluation.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        public void DisplayDevaluation(string refId, bool hasDetail)
        {
            var fADepreciation =
                Model.GetFADevaluation(refId, hasDetail) ?? new FADepreciationModel();

            View.RefId = fADepreciation.RefId;
            View.RefType = fADepreciation.RefType;
            View.RefDate = fADepreciation.RefDate;
            View.PostedDate = fADepreciation.PostedDate;
            View.RefNo = fADepreciation.RefNo;
            View.ParalellRefNo = fADepreciation.ParalellRefNo;
            View.JournalMemo = fADepreciation.JournalMemo;
            View.TotalAmount = fADepreciation.TotalAmount;
            View.PeriodType = fADepreciation.PeriodType;
            View.PeriodTypeName = fADepreciation.PeriodTypeName;
            View.FADepreciationDetails = fADepreciation.FADepreciationDetails;
        }

        public void Display(string refId, DateTime fromDate, DateTime toDate)
        {
            var fADepreciation =
                Model.GetFADepreciation(refId, fromDate, toDate) ?? new FADepreciationModel();

            View.RefId = fADepreciation.RefId;
            View.RefType = fADepreciation.RefType;
            View.RefDate = fADepreciation.RefDate;
            View.PostedDate = fADepreciation.PostedDate;
            View.RefNo = fADepreciation.RefNo;
            View.ParalellRefNo = fADepreciation.ParalellRefNo;
            View.JournalMemo = fADepreciation.JournalMemo;
            View.TotalAmount = fADepreciation.TotalAmount;
            View.PeriodType = fADepreciation.PeriodType;
            View.PeriodTypeName = fADepreciation.PeriodTypeName;
            View.FADepreciationDetails = fADepreciation.FADepreciationDetails;
        }

        public void Display(string refId, DateTime fromDate, DateTime toDate, int periodType)
        {
            var fADepreciation =
                Model.GetFADepreciation(refId, fromDate, toDate, periodType) ?? new FADepreciationModel();

            View.RefId = fADepreciation.RefId;
            View.RefType = fADepreciation.RefType;
            View.RefDate = fADepreciation.RefDate;
            View.PostedDate = fADepreciation.PostedDate;
            View.RefNo = fADepreciation.RefNo;
            View.ParalellRefNo = fADepreciation.ParalellRefNo;
            View.JournalMemo = fADepreciation.JournalMemo;
            View.TotalAmount = fADepreciation.TotalAmount;
            View.PeriodType = fADepreciation.PeriodType;
            View.PeriodTypeName = fADepreciation.PeriodTypeName;
            View.FADepreciationDetails = fADepreciation.FADepreciationDetails;
        }

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var suTransfers = new FADepreciationModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                ParalellRefNo = View.ParalellRefNo,
                JournalMemo = View.JournalMemo,
                TotalAmount = View.TotalAmount,
                PeriodType = View.PeriodType,
                PeriodTypeName = View.PeriodTypeName,
                FADepreciationDetails = View.FADepreciationDetails
            };
            if (View.RefId == null)
                return Model.AddFADepreciation(suTransfers);
            return Model.UpdateFADepreciation(suTransfers);
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
            return Model.DeleteFADepreciation(refId);
        }
    }
}
