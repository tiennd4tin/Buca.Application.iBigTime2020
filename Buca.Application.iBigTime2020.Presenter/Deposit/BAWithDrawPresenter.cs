/***********************************************************************
 * <copyright file="bawithdrawpresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Tuesday, October 24, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using Buca.Application.iBigTime2020.View.Deposit;

namespace Buca.Application.iBigTime2020.Presenter.Deposit
{
    /// <summary>
    ///     BAWithDrawPresenter
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{IBAWithDrawView}" />
    public class BAWithDrawPresenter : Presenter<IBAWithDrawView>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BAWithDrawPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BAWithDrawPresenter(IBAWithDrawView view) : base(view)
        {
        }

        /// <summary>
        ///     Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <param name="hasFixedAsset">if set to <c>true</c> [has fixed asset].</param>
        /// <param name="hasPurchase">if set to <c>true</c> [has purchase].</param>
        /// <param name="hasSalary">if set to <c>true</c> [has salary].</param>
        /// <param name="hasTax">if set to <c>true</c> [has tax].</param>
        public void Display(string refId, bool hasDetail, bool hasFixedAsset, bool hasPurchase, bool hasSalary, bool hasTax)
        {
            var bAWithDraw = Model.GetBAWithDraw(refId, hasDetail, hasFixedAsset, hasPurchase, hasSalary, hasTax) ??
                             new BAWithDrawModel();
            // có thể check null chỗ này hay chỗ hàm init data bắt actionmode = addnew
            View.RefId = bAWithDraw.RefId;
            View.RefType = bAWithDraw.RefType;
            View.RefDate = bAWithDraw.RefDate;
            View.PostedDate = bAWithDraw.PostedDate;
            View.RefNo = bAWithDraw.RefNo;
            View.ParalellRefNo = bAWithDraw.ParalellRefNo;
            View.InwardRefNo = bAWithDraw.InwardRefNo;
            View.IncrementRefNo = bAWithDraw.IncrementRefNo;
            View.BankId = bAWithDraw.BankId;
            View.BankName = bAWithDraw.BankName;
            View.JournalMemo = bAWithDraw.JournalMemo;
            View.AccountingObjectId = bAWithDraw.AccountingObjectId;
            View.TotalAmountOC = bAWithDraw.TotalAmountOC;
            View.TotalTaxAmount = bAWithDraw.TotalTaxAmount;
            View.TotalFreightAmount = bAWithDraw.TotalFreightAmount;
            View.TotalInwardAmount = bAWithDraw.TotalInwardAmount;
            View.AccountingObjectBankAccount = bAWithDraw.AccountingObjectBankAccount;
            View.Reconciled = bAWithDraw.Reconciled;
            View.Posted = bAWithDraw.Posted;
            View.PostVersion = bAWithDraw.PostVersion;
            View.EditVersion = bAWithDraw.EditVersion;
            View.RefOrder = bAWithDraw.RefOrder;
            View.RelationRefId = bAWithDraw.RelationRefId;
            View.TotalPaymentAmount = bAWithDraw.TotalPaymentAmount;
            View.BAWithDrawDetails = bAWithDraw.BAWithDrawDetails;
            View.BAWithDrawDetailFixedAssets = bAWithDraw.BAWithDrawDetailFixedAssets ?? new List<BAWithDrawDetailFixedAssetModel>();
            View.BAWithDrawDetailPurchases = bAWithDraw.BAWithDrawDetailPurchases ?? new List<BAWithDrawDetailPurchaseModel>();
            View.BAWithdrawDetailSalarys = bAWithDraw.BAWithdrawDetailSalarys ?? new List<BAWithdrawDetailSalaryModel>();
            View.BAWithdrawDetailTaxs = bAWithDraw.BAWithdrawDetailTaxs ?? new List<BAWithdrawDetailTaxModel>();
            View.BAWithDrawDetailParallels = bAWithDraw.BAWithDrawDetailParallels ?? new List<BAWithDrawDetailParallelModel>();
            View.ReceiveName = bAWithDraw.ReceiveName;
            View.ReceiveIssueDate = bAWithDraw.ReceiveIssueDate;
            View.ReceiveIssueLocation = bAWithDraw.ReceiveIssueLocation;
            View.ReceiveId = bAWithDraw.ReceiveId;
            View.CurrencyCode = bAWithDraw.CurrencyCode;
            View.ExchangeRate = bAWithDraw.ExchangeRate;
            View.TotalAmount = bAWithDraw.TotalAmount;

        }

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var bAWithDraw = new BAWithDrawModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo.Trim(),
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                ParalellRefNo = View.ParalellRefNo,
                InwardRefNo = View.InwardRefNo,
                IncrementRefNo = View.IncrementRefNo,
                BankId = View.BankId,
                BankName = View.BankName,
                JournalMemo = View.JournalMemo.Trim(),
                AccountingObjectId = View.AccountingObjectId,
                AccountingObjectBankAccount = View.AccountingObjectBankAccount,
                TotalAmount = View.TotalAmount,
                TotalAmountOC = View.TotalAmountOC,
                TotalTaxAmount = View.TotalTaxAmount,
                TotalFreightAmount = View.TotalFreightAmount,
                TotalInwardAmount = View.TotalInwardAmount,
                Reconciled = View.Reconciled,
                Posted = View.Posted,
                PostVersion = View.PostVersion,
                EditVersion = View.EditVersion,
                RefOrder = View.RefOrder,
                RelationRefId = View.RelationRefId,
                TotalPaymentAmount = View.TotalPaymentAmount,
                BAWithDrawDetails = View.BAWithDrawDetails,
                BAWithDrawDetailFixedAssets = View.BAWithDrawDetailFixedAssets,
                BAWithDrawDetailPurchases = View.BAWithDrawDetailPurchases,
                BAWithdrawDetailSalarys = View.BAWithdrawDetailSalarys,
                BAWithdrawDetailTaxs = View.BAWithdrawDetailTaxs
            };
            if (View.RefId == null)
                return Model.AddBAWithDraw(bAWithDraw);
            return Model.UpdateBAWithDraw(bAWithDraw);
        }

        /// <summary>
        /// Saves the specified is automatic generate parallel.
        /// </summary>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        public string Save(bool isAutoGenerateParallel)
        {
            var bAWithDraw = new BAWithDrawModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate, 
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                ParalellRefNo = View.ParalellRefNo,
                InwardRefNo = View.InwardRefNo,
                IncrementRefNo = View.IncrementRefNo,
                BankId = View.BankId,
                BankName = View.BankName,
                JournalMemo = View.JournalMemo,
                AccountingObjectId = View.AccountingObjectId,
                TotalAmount = View.TotalAmount,
                TotalAmountOC = View.TotalAmountOC,
                TotalTaxAmount = View.TotalTaxAmount,
                TotalFreightAmount = View.TotalFreightAmount,
                TotalInwardAmount = View.TotalInwardAmount,
                Reconciled = View.Reconciled,
                Posted = View.Posted,
                PostVersion = View.PostVersion,
                EditVersion = View.EditVersion,
                RefOrder = View.RefOrder,
                RelationRefId = View.RelationRefId,
                RelationType = View.RelationType,
                TotalPaymentAmount = View.TotalPaymentAmount,
                AccountingObjectBankAccount = View.AccountingObjectBankAccount,
                BAWithDrawDetails = View.BAWithDrawDetails,
                BAWithDrawDetailFixedAssets = View.BAWithDrawDetailFixedAssets,
                BAWithDrawDetailPurchases = View.BAWithDrawDetailPurchases, 
                BAWithdrawDetailSalarys = View.BAWithdrawDetailSalarys,
                BAWithdrawDetailTaxs = View.BAWithdrawDetailTaxs,
                BAWithDrawDetailParallels = View.BAWithDrawDetailParallels,
                ReceiveId = View.ReceiveId,
                ReceiveIssueDate = View.ReceiveIssueDate,
                ReceiveName = View.ReceiveName,
                ReceiveIssueLocation = View.ReceiveIssueLocation,
                Parallels = View.Parallels,
            };
            if (View.RefId == null)
                return Model.AddBAWithDraw(bAWithDraw, isAutoGenerateParallel);
            return Model.UpdateBAWithDraw(bAWithDraw, isAutoGenerateParallel);
        }

        /// <summary>
        ///     Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public string Delete(string refId)
        {
            return Model.DeleteBAWithDraw(refId);
        }
    }
}