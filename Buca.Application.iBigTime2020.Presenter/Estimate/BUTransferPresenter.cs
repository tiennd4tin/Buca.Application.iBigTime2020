/***********************************************************************
 * <copyright file="BUTransferPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 13, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.View.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Estimate
{
    /// <summary>
    /// Class BUTransferPresenter.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{Buca.Application.iBigTime2020.View.Estimate.IBUTransferView}" />
    public class BUTransferPresenter : Presenter<IBUTransferView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BUTransferPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BUTransferPresenter(IBUTransferView view)
            : base(view)
        {
        }
        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(string refId)
        {
            var bUTransfer = Model.GetBUTransferVoucher(refId, true) ?? new BUTransferModel();
            View.RefId = bUTransfer.RefId;
            View.RefType = bUTransfer.RefType;
            View.RefDate = bUTransfer.RefDate;
            View.PostedDate = bUTransfer.PostedDate;
            View.RefNo = bUTransfer.RefNo;
            View.CurrencyCode = bUTransfer.CurrencyCode;
            View.ExchangeRate = bUTransfer.ExchangeRate;
            View.ParalellRefNo = bUTransfer.ParalellRefNo;
            View.JournalMemo = bUTransfer.JournalMemo;
            View.TargetProgramId = bUTransfer.TargetProgramId;
            View.BankInfoId = bUTransfer.BankInfoId;
            View.AccountingObjectId = bUTransfer.AccountingObjectId;
            View.AccountingObjectName = bUTransfer.AccountingObjectName;
            View.AccountingObjectAddress = bUTransfer.AccountingObjectAddress;
            View.AccountingObjectBankAccount = bUTransfer.AccountingObjectBankAccount;
            View.AccountingObjectBankName = bUTransfer.AccountingObjectBankName;
            View.DocumentIncluded = bUTransfer.DocumentIncluded;
            View.InwardStockRefNo = bUTransfer.InwardStockRefNo;
            View.WithdrawRefDate = bUTransfer.WithdrawRefDate;
            View.WithdrawRefNo = bUTransfer.WithdrawRefNo;
            View.IncrementRefNo = bUTransfer.IncrementRefNo;
            View.TotalAmountOC = bUTransfer.TotalAmountOC;
            View.TotalTaxAmount = bUTransfer.TotalTaxAmount;
            View.TotalFreightAmount = bUTransfer.TotalFreightAmount;
            View.TotalInwardAmount = bUTransfer.TotalInwardAmount;
            View.Posted = bUTransfer.Posted;
            View.PostVersion = bUTransfer.PostVersion;
            View.EditVersion = bUTransfer.EditVersion;
            View.RefOrder = bUTransfer.RefOrder;
            View.RelationRefId = bUTransfer.RelationRefId;
            View.BUCommitmentRequestId = bUTransfer.BUCommitmentRequestId;
            View.TotalFixedAssetAmount = bUTransfer.TotalFixedAssetAmount;

            View.BUTransferDetails = bUTransfer.BUTransferDetails == null ? new List<BUTransferDetailModel>() : bUTransfer.BUTransferDetails.ToList();
            View.BuTransferDetailParallel = bUTransfer.BUTransferDetailParallel == null ? new List<BUTransferDetailParallelModel>() : bUTransfer.BUTransferDetailParallel.OrderBy(c => c.SortOrder).ToList();
            View.BUTransferDetailPurchases = bUTransfer.BUTransferDetailPurchases;
            View.BUTransferDetailFixedAssets = bUTransfer.BUTransferDetailFixedAssets;
            View.TotalAmount = bUTransfer.TotalAmount;

        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Save(bool isAutoGenerateParallel)
        {
            var bUTransfer = new BUTransferModel()
            {
                BUTransferDetailPurchases = View.BUTransferDetailPurchases, // Để trên cùng để set số tiền
                BUTransferDetailFixedAssets = View.BUTransferDetailFixedAssets,

                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                ParalellRefNo = View.ParalellRefNo,
                JournalMemo = View.JournalMemo,
                TargetProgramId = View.TargetProgramId,
                BankInfoId = View.BankInfoId,
                AccountingObjectId = View.AccountingObjectId,
                AccountingObjectName = View.AccountingObjectName,
                AccountingObjectAddress = View.AccountingObjectAddress,
                AccountingObjectBankAccount = View.AccountingObjectBankAccount,
                AccountingObjectBankName = View.AccountingObjectBankName,
                DocumentIncluded = View.DocumentIncluded,
                InwardStockRefNo = View.InwardStockRefNo,
                WithdrawRefDate = View.WithdrawRefDate,
                WithdrawRefNo = View.WithdrawRefNo,
                IncrementRefNo = View.IncrementRefNo,
                TotalAmount = View.TotalAmount,
                TotalAmountOC = View.TotalAmountOC,
                TotalTaxAmount = View.TotalTaxAmount,
                TotalFreightAmount = View.TotalFreightAmount,
                TotalInwardAmount = View.TotalInwardAmount,
                Posted = View.Posted,
                PostVersion = View.PostVersion,
                EditVersion = View.EditVersion,
                RefOrder = View.RefOrder,
                RelationRefId = View.RelationRefId,
                BUCommitmentRequestId = View.BUCommitmentRequestId,
                TotalFixedAssetAmount = View.TotalFixedAssetAmount,
                BUTransferDetails = View.BUTransferDetails,
                BUTransferDetailParallel = View.BuTransferDetailParallel,
                BUPlanWithdrawRefId = View.BUPlanWithdrawRefId,
                //Parallels = View.Parallels,
            };
            if (View.RefId == null)
                return Model.InsertBUTransfer(bUTransfer, isAutoGenerateParallel);
            return Model.UpdateBUTransfer(bUTransfer, isAutoGenerateParallel); 
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string Delete(string refId)
        {
            return Model.DeleteBUTransfer(refId);
        }

        /// <summary>
        /// Deletes the gl voucher by bu transfer reference identifier.
        /// </summary>
        /// <param name="buTransferRefId">The bu transfer reference identifier.</param>
        /// <returns></returns>
        public string DeleteBUTransferByBUTransferRefId(string buTransferRefId)
        {
            return Model.DeleteBUTransferByBUPlanWithdrawRefId(buTransferRefId);
        }

        /// <summary>
        /// Gets the bu transfer by reference identifier.
        /// </summary>
        /// <param name="buPlanWithdrawRefId">The bu plan withdraw reference identifier.</param>
        /// <returns></returns>
        public string GetBUTransferByBUPlanWithdrawRefId(string buPlanWithdrawRefId)
        {
            var receipt = Model.GetBUTransferByBUPlanWithdrawRefId(buPlanWithdrawRefId);

            if (receipt != null)
                return receipt.RefNo;
            return string.Empty;
        }
    }
}
