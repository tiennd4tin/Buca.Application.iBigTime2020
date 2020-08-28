/***********************************************************************
 * <copyright file="ReceiptVouchersPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Thắng ND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: Wednesday, March 19, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.View.Cash;

namespace Buca.Application.iBigTime2020.Presenter.Cash.ReceiptVoucher
{
    /// <summary>
    /// ReceiptVouchersPresenter class
    /// </summary>
    public class CAReceiptPresenter : Presenter<ICAReceiptView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CAReceiptPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public CAReceiptPresenter(ICAReceiptView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(string refId)
        {
            var cAReceipt = Model.GetReceiptVoucher(refId) ?? new CAReceiptModel();

            View.RefId = cAReceipt.RefId;
            View.RefType = cAReceipt.RefType;
            View.RefDate = cAReceipt.RefDate;
            View.PostedDate = cAReceipt.PostedDate;
            View.RefNo = cAReceipt.RefNo;
            View.CurrencyCode = cAReceipt.CurrencyCode;
            View.ExchangeRate = cAReceipt.ExchangeRate;
            View.ParalellRefNo = cAReceipt.ParalellRefNo;
            View.OutwardRefNo = cAReceipt.OutwardRefNo;
            View.AccountingObjectId = cAReceipt.AccountingObjectId;
            View.JournalMemo = cAReceipt.JournalMemo;
            View.DocumentIncluded = cAReceipt.DocumentIncluded;
            View.InvType = cAReceipt.InvType;
            View.InvDateOrWithdrawRefDate = cAReceipt.InvDateOrWithdrawRefDate;
            View.InvSeries = cAReceipt.InvSeries;
            View.InvNoOrWithdrawRefNo = cAReceipt.InvNoOrWithdrawRefNo;
            View.BankId = cAReceipt.BankId;
            View.TotalAmount = cAReceipt.TotalAmount;
            View.TotalTaxAmount = cAReceipt.TotalTaxAmount;
            View.TotalOutwardAmount = cAReceipt.TotalOutwardAmount;
            View.Posted = cAReceipt.Posted;
            View.RefOrder = cAReceipt.RefOrder;
            View.InvoiceForm = cAReceipt.InvoiceForm;
            View.InvoiceFormNumberId = cAReceipt.InvoiceFormNumberId;
            View.InvSeriesPrefix = cAReceipt.InvSeriesPrefix;
            View.InvSeriesSuffix = cAReceipt.InvSeriesSuffix;
            View.PayForm = cAReceipt.PayForm;
            View.CompanyTaxcode = cAReceipt.CompanyTaxcode;
            View.RelationRefId = cAReceipt.RelationRefId;
            View.BUCommitmentRequestId = cAReceipt.BUCommitmentRequestId;
            View.AccountingObjectContactName = cAReceipt.AccountingObjectContactName;
            View.ListNo = cAReceipt.ListNo;
            View.ListDate = cAReceipt.ListDate;
            View.IsAttachList = cAReceipt.IsAttachList;
            View.ListCommonNameInventory = cAReceipt.ListCommonNameInventory;
            View.TotalReceiptAmount = cAReceipt.TotalReceiptAmount;
            View.CAReceiptDetails = cAReceipt.CAReceiptDetails.ToList();
            View.Payer = cAReceipt.Payer;
            View.TotalAmountOC = cAReceipt.TotalAmountOC;
        }

        public void Display(string refId, bool isIncluedDetail, bool isIncludedDetailTax)
        {
            var cAReceipt = Model.GetReceiptVoucher(refId, isIncluedDetail, isIncludedDetailTax) ?? new CAReceiptModel();

            View.RefId = cAReceipt.RefId;
            View.RefType = cAReceipt.RefType;
            View.RefDate = cAReceipt.RefDate;
            View.PostedDate = cAReceipt.PostedDate;
            View.RefNo = cAReceipt.RefNo;
            View.ParalellRefNo = cAReceipt.ParalellRefNo;
            //View.OutwardRefNo = cAReceipt.OutwardRefNo;
            View.AccountingObjectId = cAReceipt.AccountingObjectId;
            View.JournalMemo = cAReceipt.JournalMemo;
            View.DocumentIncluded = cAReceipt.DocumentIncluded;
            View.InvType = cAReceipt.InvType;
            View.InvDateOrWithdrawRefDate = cAReceipt.InvDateOrWithdrawRefDate;
            View.InvSeries = cAReceipt.InvSeries;
            View.Address = cAReceipt.Address;
            View.InvNoOrWithdrawRefNo = cAReceipt.InvNoOrWithdrawRefNo;
            View.BankId = cAReceipt.BankId;
            View.TotalAmountOC = cAReceipt.TotalAmountOC;
            View.TotalTaxAmount = cAReceipt.TotalTaxAmount;
            View.TotalOutwardAmount = cAReceipt.TotalOutwardAmount;
            View.Posted = cAReceipt.Posted;
            View.RefOrder = cAReceipt.RefOrder;
            View.InvoiceForm = cAReceipt.InvoiceForm;
            View.InvoiceFormNumberId = cAReceipt.InvoiceFormNumberId;
            View.InvSeriesPrefix = cAReceipt.InvSeriesPrefix;
            View.InvSeriesSuffix = cAReceipt.InvSeriesSuffix;
            View.PayForm = cAReceipt.PayForm;
            View.CompanyTaxcode = cAReceipt.CompanyTaxcode;
            View.RelationRefId = cAReceipt.RelationRefId;
            View.BUCommitmentRequestId = cAReceipt.BUCommitmentRequestId;
            View.AccountingObjectContactName = cAReceipt.AccountingObjectContactName;
            View.ListNo = cAReceipt.ListNo;
            View.ListDate = cAReceipt.ListDate;
            View.IsAttachList = cAReceipt.IsAttachList;
            View.ListCommonNameInventory = cAReceipt.ListCommonNameInventory;
            View.TotalReceiptAmount = cAReceipt.TotalReceiptAmount;
            View.CAReceiptDetails = cAReceipt.CAReceiptDetails == null ? new List<CAReceiptDetailModel>() : cAReceipt.CAReceiptDetails.ToList();
            View.CAReceiptDetailTaxes = cAReceipt.CAReceiptDetailTaxes == null ? new List<CAReceiptDetailTaxModel>() : cAReceipt.CAReceiptDetailTaxes.ToList();
            View.CAReceiptDetailParallels = cAReceipt.CAReceiptDetailParallels == null ? new List<CAReceiptDetailParallelModel>() : cAReceipt.CAReceiptDetailParallels.ToList();
            View.Payer = cAReceipt.Payer;
            View.CurrencyCode = cAReceipt.CurrencyCode;
            View.ExchangeRate = cAReceipt.ExchangeRate;
            View.TotalAmount = cAReceipt.TotalAmount;

        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Save()
        {
            var receipt = new CAReceiptModel
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
                JournalMemo = View.JournalMemo,
                DocumentIncluded = View.DocumentIncluded,
                InvType = View.InvType,
                InvDateOrWithdrawRefDate = View.InvDateOrWithdrawRefDate,
                InvSeries = View.InvSeries,
                InvNoOrWithdrawRefNo = View.InvNoOrWithdrawRefNo,
                BankId = View.BankId,
                TotalAmount = View.TotalAmount,
                TotalAmountOC = View.TotalAmountOC,
                TotalTaxAmount = View.TotalTaxAmount,
                TotalOutwardAmount = View.TotalOutwardAmount,
                Posted = View.Posted,
                RefOrder = View.RefOrder,
                InvoiceForm = View.InvoiceForm,
                InvoiceFormNumberId = View.InvoiceFormNumberId,
                InvSeriesPrefix = View.InvSeriesPrefix,
                InvSeriesSuffix = View.InvSeriesSuffix,
                PayForm = View.PayForm,
                CompanyTaxcode = View.CompanyTaxcode,
                RelationRefId = View.RelationRefId,
                BUCommitmentRequestId = View.BUCommitmentRequestId,
                AccountingObjectContactName = View.AccountingObjectContactName,
                ListNo = View.ListNo,
                ListDate = View.ListDate,
                IsAttachList = View.IsAttachList,
                ListCommonNameInventory = View.ListCommonNameInventory,
                TotalReceiptAmount = View.TotalReceiptAmount,
                CAReceiptDetails = View.CAReceiptDetails,
                CAReceiptDetailTaxes = View.CAReceiptDetailTaxes,
                Payer= View.Payer
            };
            return View.RefId == null ? Model.AddCAReceipt(receipt) : Model.UpdateCAReceipt(receipt);
        }

        /// <summary>
        /// Saves the specified is automatic generate parallel.
        /// </summary>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        public string Save(bool isAutoGenerateParallel)
        {
            var receipt = new CAReceiptModel
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
                JournalMemo = View.JournalMemo,
                DocumentIncluded = View.DocumentIncluded == null ? string.Empty : View.DocumentIncluded.Trim(),
                InvType = View.InvType,
                InvDateOrWithdrawRefDate = View.InvDateOrWithdrawRefDate,
                InvSeries = View.InvSeries,
                InvNoOrWithdrawRefNo = View.InvNoOrWithdrawRefNo == null ? string.Empty : View.InvNoOrWithdrawRefNo.Trim(),
                BankId = View.BankId,
                TotalAmount = View.TotalAmount,
                TotalAmountOC = View.TotalAmountOC,
                Address = View.Address,
                TotalTaxAmount = View.TotalTaxAmount,
                TotalOutwardAmount = View.TotalOutwardAmount,
                Posted = View.Posted,
                RefOrder = View.RefOrder,
                InvoiceForm = View.InvoiceForm,
                InvoiceFormNumberId = View.InvoiceFormNumberId,
                InvSeriesPrefix = View.InvSeriesPrefix,
                InvSeriesSuffix = View.InvSeriesSuffix,
                PayForm = View.PayForm,
                CompanyTaxcode = View.CompanyTaxcode,
                RelationRefId = View.RelationRefId,
                BUCommitmentRequestId = View.BUCommitmentRequestId,
                AccountingObjectContactName = View.AccountingObjectContactName,
                ListNo = View.ListNo,
                ListDate = View.ListDate,
                IsAttachList = View.IsAttachList,
                ListCommonNameInventory = View.ListCommonNameInventory,
                TotalReceiptAmount = View.TotalReceiptAmount,
                CAReceiptDetails = View.CAReceiptDetails,
                CAReceiptDetailTaxes = View.CAReceiptDetailTaxes,
                CAReceiptDetailParallels = View.CAReceiptDetailParallels,
                BUPlanWithdrawRefId = View.BUPlanWithdrawRefId,
                Payer =  View.Payer
            };
            if (View.RefId == null)
                return Model.AddCAReceipt(receipt, isAutoGenerateParallel);
            return Model.UpdateCAReceipt(receipt, isAutoGenerateParallel);
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string Delete(string refId)
        {
            return Model.DeleteCAReceipt(refId);
        }

        public string DeleteCAReceiptByBUPlanWithdrawRefID(string BUPlanWithdrawRefID)
        {
            return Model.DeleteCAReceiptByBUPlanWithdrawRefID(BUPlanWithdrawRefID);
        }

        /// <summary>
        /// References the no is exist.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RefNoIsExist(string refId, string refNo, int refType)
        {
            var receipt = Model.GetCAReceipts()
                .Where(x => x.RefId != refId && x.RefNo == refNo && x.RefType == refType).ToList();
            return receipt.Any();
        }

        /// <summary>
        /// Bus the plan withdraw reference identifier is exist.
        /// </summary>
        /// <param name="BUPlanWithdrawRefID">The bu plan withdraw reference identifier.</param>
        /// <returns></returns>
        public string BUPlanWithdrawRefIDIsExist(string BUPlanWithdrawRefID)
        {
            var receipt = Model.GetCAReceiptsByBUPlanWithdrawRefID(BUPlanWithdrawRefID);

            if (receipt != null)
                return receipt.RefNo;
            return string.Empty;
        }

    }
}
