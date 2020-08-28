/***********************************************************************
 * <copyright file="BUPlanWithdrawPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, November 1, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, November 1, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.View.Cash;
using Buca.Application.iBigTime2020.View.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Estimate
{
    /// <summary>
    /// Class BUPlanWithdrawPresenter.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{Buca.Application.iBigTime2020.View.Estimate.IBUPlanWithdrawView}" />
    public class BUPlanWithdrawTransferInsurrancePresenter : Presenter<IBUPlanWithdrawTransferInsurranceView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BUPlanWithdrawPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BUPlanWithdrawTransferInsurrancePresenter(IBUPlanWithdrawTransferInsurranceView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedBUPlanWithdrawDetail">if set to <c>true</c> [is included bu plan withdraw detail].</param>
        public void Display(string refId, bool isIncludedBUPlanWithdrawDetail)
        {
            var bUPlanWithdraw = Model.GetBUPlanWithdrawByRefId(refId, isIncludedBUPlanWithdrawDetail) ?? new BUPlanWithdrawModel();
            View.RefId = bUPlanWithdraw.RefId;
            View.CashWithDrawType = bUPlanWithdraw.CashWithDrawType;
            View.RefType = bUPlanWithdraw.RefType;
            View.RefDate = bUPlanWithdraw.RefDate;
            View.PostedDate = bUPlanWithdraw.PostedDate;
            View.RefNo = bUPlanWithdraw.RefNo;
            View.CurrencyCode = bUPlanWithdraw.CurrencyCode;
            View.ExchangeRate = bUPlanWithdraw.ExchangeRate;
            View.ParalellRefNo = bUPlanWithdraw.ParalellRefNo;
            View.TargetProgramId = bUPlanWithdraw.TargetProgramId;
            View.BankId = bUPlanWithdraw.BankId;
            View.AccountingObjectId = bUPlanWithdraw.AccountingObjectId;
            View.JournalMemo = bUPlanWithdraw.JournalMemo;
            View.TotalAmountOC = bUPlanWithdraw.TotalAmountOC;
            View.GeneratedRefId = bUPlanWithdraw.GeneratedRefId;
            View.Posted = bUPlanWithdraw.Posted;
            View.BUCommitmentRequestId = bUPlanWithdraw.BUCommitmentRequestId;
            View.BUPlanWithdrawDetails = bUPlanWithdraw.BUPlanWithdrawDetails.ToList() ?? new List<BUPlanWithdrawDetailModel>();
            View.AccountingObjectBankId = bUPlanWithdraw.AccountingObjectBankId;
            View.TotalAmount = bUPlanWithdraw.TotalAmount;
        }
        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Save()
        {
            var bUPlanWithdraw = new BUPlanWithdrawModel
            {

                RefId = View.RefId,
                CashWithDrawType = View.CashWithDrawType,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                ParalellRefNo = View.ParalellRefNo == null ? string.Empty : View.ParalellRefNo.Trim(),
                TargetProgramId = View.TargetProgramId,
                BankId = View.BankId,
                AccountingObjectId = View.AccountingObjectId,
                JournalMemo = View.JournalMemo,
                TotalAmount = View.TotalAmount,
                TotalAmountOC = View.TotalAmountOC,
                GeneratedRefId = View.GeneratedRefId,
                Posted = View.Posted,
                BUCommitmentRequestId = View.BUCommitmentRequestId,
                AccountingObjectBankId = View.AccountingObjectBankId,
                BUPlanWithdrawDetails = View.BUPlanWithdrawDetails
            };
            if (View.RefId == null)
                return Model.InsertBUPlanWithdraw(bUPlanWithdraw);
            return Model.UpdateBUPlanWithdraw(bUPlanWithdraw);
        }
        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string Delete(string refId)
        {
            return Model.DeleteBUPlanWithdraw(refId);
        }

    }
}
