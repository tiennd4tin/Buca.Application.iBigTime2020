/***********************************************************************
 * <copyright file="badepositpresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, October 19, 2017
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
    /// BADepositPresenter
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{IBADepositView}" />
    public class BADepositPresenter : Presenter<IBADepositView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BADepositPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BADepositPresenter(IBADepositView view) : base(view)
        {
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <param name="hasFixedAsset">if set to <c>true</c> [has fixed asset].</param>
        /// <param name="hasSale">if set to <c>true</c> [has sale].</param>
        /// <param name="hasTax">if set to <c>true</c> [has tax].</param>
        public void Display(string refId, bool hasDetail, bool hasFixedAsset, bool hasSale, bool hasTax)
        {
            var bADeposit = Model.GetBADeposit(refId, hasDetail, hasFixedAsset, hasSale, hasTax) ?? new BADepositModel();

            View.RefId = bADeposit.RefId;
            View.RefType = bADeposit.RefType;
            View.RefDate = bADeposit.RefDate;
            View.PostedDate = bADeposit.PostedDate;
            View.RefNo = bADeposit.RefNo;
            View.ParalellRefNo = bADeposit.ParalellRefNo;
            View.OutwardRefNo = bADeposit.OutwardRefNo;
            View.AccountingObjectId = bADeposit.AccountingObjectId;
            View.BankId = bADeposit.BankId;
            View.InvType = bADeposit.InvType;
            View.InvDate = bADeposit.InvDate;
            View.InvSeries = bADeposit.InvSeries;
            View.InvNo = bADeposit.InvNo;
            View.JournalMemo = bADeposit.JournalMemo;
            View.TotalAmountOC = bADeposit.TotalAmountOC;
            View.TotalTaxAmount = bADeposit.TotalTaxAmount;
            View.TotalOutwardAmount = bADeposit.TotalOutwardAmount;
            View.Reconciled = bADeposit.Reconciled;
            View.Posted = bADeposit.Posted;
            View.PostVersion = bADeposit.PostVersion;
            View.EditVersion = bADeposit.EditVersion;
            View.RefOrder = bADeposit.RefOrder;
            View.InvoiceForm = bADeposit.InvoiceForm;
            View.InvoiceFormNumberId = bADeposit.InvoiceFormNumberId;
            View.InvSeriesPrefix = bADeposit.InvSeriesPrefix;
            View.InvSeriesSuffix = bADeposit.InvSeriesSuffix;
            View.PayForm = bADeposit.PayForm;
            View.ComPanyTaxcode = bADeposit.ComPanyTaxcode;
            View.AccountingObjectContactName = bADeposit.AccountingObjectContactName;
            View.ListNo = bADeposit.ListNo;
            View.ListDate = bADeposit.ListDate;
            View.IsAttachList = bADeposit.IsAttachList;
            View.ListCommonNameInventory = bADeposit.ListCommonNameInventory;
            View.BUCommitmentRequestId = bADeposit.BUCommitmentRequestId;
            View.TotalReceiptAmount = bADeposit.TotalReceiptAmount;
            View.BADepositDetails = bADeposit.BADepositDetailModels;
            View.BADepositDetailFixedAssets = bADeposit.BADepositDetailFixedAssetModels;
            View.BADepositDetailSales = bADeposit.BADepositDetailSaleModels;
            View.BADepositDetailTaxs = bADeposit.BADepositDetailTaxModels;
            View.BADepositDetailParallels = bADeposit.BADepositDetailParallels ?? new List<BADepositDetailParallelModel>();
            View.Payer = bADeposit.Payer;
            View.CurrencyCode = bADeposit.CurrencyCode == null ? "VND" : bADeposit.CurrencyCode;
            View.ExchangeRate = bADeposit.ExchangeRate;
            View.TotalAmount = bADeposit.TotalAmount;

        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var bADeposit = new BADepositModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                ParalellRefNo = View.ParalellRefNo,
                OutwardRefNo = View.OutwardRefNo,
                AccountingObjectId = View.AccountingObjectId,
                BankId = View.BankId,
                InvType = View.InvType,
                InvDate = View.InvDate,
                InvSeries = View.InvSeries,
                InvNo = View.InvNo,
                JournalMemo = View.JournalMemo,
                TotalAmount = View.TotalAmount,
                TotalAmountOC = View.TotalAmountOC,
                TotalTaxAmount = View.TotalTaxAmount,
                TotalOutwardAmount = View.TotalOutwardAmount,
                Reconciled = View.Reconciled,
                Posted = View.Posted,
                PostVersion = View.PostVersion,
                EditVersion = View.EditVersion,
                RefOrder = View.RefOrder,
                InvoiceForm = View.InvoiceForm,
                InvoiceFormNumberId = View.InvoiceFormNumberId,
                InvSeriesPrefix = View.InvSeriesPrefix,
                InvSeriesSuffix = View.InvSeriesSuffix,
                PayForm = View.PayForm,
                ComPanyTaxcode = View.ComPanyTaxcode,
                AccountingObjectContactName = View.AccountingObjectContactName,
                ListNo = View.ListNo,
                ListDate = View.ListDate,
                IsAttachList = View.IsAttachList,
                ListCommonNameInventory = View.ListCommonNameInventory,
                BUCommitmentRequestId = View.BUCommitmentRequestId,
                TotalReceiptAmount = View.TotalReceiptAmount,
                BADepositDetailModels = View.BADepositDetails,
                BADepositDetailFixedAssetModels = View.BADepositDetailFixedAssets,
                BADepositDetailSaleModels = View.BADepositDetailSales,
                BADepositDetailTaxModels = View.BADepositDetailTaxs,
                Payer =  View.Payer,
            };
            if (View.RefId == null)
                return Model.AddBADeposit(bADeposit);
            return Model.UpdateBADeposit(bADeposit);
        }

        /// <summary>
        /// Saves the specified is automatic generate parallel.
        /// </summary>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        public string Save(bool isAutoGenerateParallel)
        {
            var bADeposit = new BADepositModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                ParalellRefNo = View.ParalellRefNo,
                OutwardRefNo = View.OutwardRefNo,
                AccountingObjectId = View.AccountingObjectId,
                BankId = View.BankId,
                InvType = View.InvType,
                InvDate = View.InvDate,
                InvSeries = View.InvSeries,
                InvNo = View.InvNo,
                JournalMemo = View.JournalMemo,
                TotalAmount = View.TotalAmount,
                TotalAmountOC = View.TotalAmountOC,
                TotalTaxAmount = View.TotalTaxAmount,
                TotalOutwardAmount = View.TotalOutwardAmount,
                Reconciled = View.Reconciled,
                Posted = View.Posted,
                PostVersion = View.PostVersion,
                EditVersion = View.EditVersion,
                RefOrder = View.RefOrder,
                InvoiceForm = View.InvoiceForm,
                InvoiceFormNumberId = View.InvoiceFormNumberId,
                InvSeriesPrefix = View.InvSeriesPrefix,
                InvSeriesSuffix = View.InvSeriesSuffix,
                PayForm = View.PayForm,
                ComPanyTaxcode = View.ComPanyTaxcode,
                AccountingObjectContactName = View.AccountingObjectContactName,
                ListNo = View.ListNo,
                ListDate = View.ListDate,
                IsAttachList = View.IsAttachList,
                ListCommonNameInventory = View.ListCommonNameInventory,
                BUCommitmentRequestId = View.BUCommitmentRequestId,
                TotalReceiptAmount = View.TotalReceiptAmount,
                BADepositDetailModels = View.BADepositDetails,
                BADepositDetailFixedAssetModels = View.BADepositDetailFixedAssets,
                BADepositDetailSaleModels = View.BADepositDetailSales,
                BADepositDetailTaxModels = View.BADepositDetailTaxs,
                BADepositDetailParallels = View.BADepositDetailParallels,
                Payer = View.Payer,
                
            };
            if (View.RefId == null)
                return Model.AddBADeposit(bADeposit, isAutoGenerateParallel);
            return Model.UpdateBADeposit(bADeposit, isAutoGenerateParallel);
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
            return Model.DeleteBADeposit(refId);
        }
    }
}