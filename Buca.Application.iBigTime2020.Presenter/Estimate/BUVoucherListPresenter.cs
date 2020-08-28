/***********************************************************************
 * <copyright file="BUVoucherListPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Tuesday, June 5, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.View.Estimate;

namespace Buca.Application.iBigTime2020.Presenter.Estimate
{
    /// <summary>
    ///     BUVoucherListPresenter
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{IBUVoucherListView}" />
    public class BUVoucherListPresenter : Presenter<IBUVoucherListView>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BUVoucherListPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BUVoucherListPresenter(IBUVoucherListView view) : base(view)
        {
        }

        /// <summary>
        ///     Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="includeDetail">if set to <c>true</c> [include detail].</param>
        /// <param name="includeDetailParallel">if set to <c>true</c> [include detail parallel].</param>
        /// <param name="includeDetailTransfer">if set to <c>true</c> [include detail transfer].</param>
        public void Display(string refId, bool includeDetail, bool includeDetailParallel,
            bool includeDetailTransfer)
        {
            var bUVoucherList =
                Model.GetBUVoucherList(refId, includeDetail, includeDetailParallel, includeDetailTransfer);
            bUVoucherList = bUVoucherList ?? new BUVoucherListModel();
            View.RefId = bUVoucherList.RefId;
            View.RefType = bUVoucherList.RefType;
            View.RefDate = bUVoucherList.RefDate;
            View.PostedDate = bUVoucherList.PostedDate;
            View.RefNo = bUVoucherList.RefNo;
            View.ParalellRefNo = bUVoucherList.ParalellRefNo;
            View.FromDate = bUVoucherList.FromDate;
            View.ToDate = bUVoucherList.ToDate;
            View.JournalMemo = bUVoucherList.JournalMemo;
            View.Posted = bUVoucherList.Posted;
            View.PostVersion = bUVoucherList.PostVersion;
            View.EditVersion = bUVoucherList.EditVersion;
            View.TotalAmountOC = bUVoucherList.TotalAmountOC;
            View.BUVoucherListDetailModels = bUVoucherList.BUVoucherListDetailModels;
            View.BUVoucherListDetailParallelModels = bUVoucherList.BUVoucherListDetailParallelModels;
            View.BUVoucherListDetailTransferModels = bUVoucherList.BUVoucherListDetailTransferModels;
            View.CurrencyCode = bUVoucherList.CurrencyCode;
            View.ExchangeRate = bUVoucherList.ExchangeRate;
            View.TotalAmount = bUVoucherList.TotalAmount;
        }

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var bUVoucherList = new BUVoucherListModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                ParalellRefNo = View.ParalellRefNo,
                FromDate = View.FromDate,
                ToDate = View.ToDate,
                JournalMemo = View.JournalMemo,
                Posted = View.Posted,
                TotalAmount = View.TotalAmount,
                PostVersion = View.PostVersion,
                EditVersion = View.EditVersion,
                BUVoucherListDetailModels = View.BUVoucherListDetailModels,
                BUVoucherListDetailTransferModels = View.BUVoucherListDetailTransferModels,
                BUVoucherListDetailParallelModels = View.BUVoucherListDetailParallelModels,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                TotalAmountOC = View.TotalAmountOC
            };
            if (View.RefId == null)
                return Model.InsertBUVoucherList(bUVoucherList);
            return Model.UpdateBUVoucherList(bUVoucherList);
        }

        /// <summary>
        ///     Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public string Delete(string refId)
        {
            return Model.DeleteBUVoucherList(refId);
        }
    }
}