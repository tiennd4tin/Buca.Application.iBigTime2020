/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   KienNT
 * Email:    kiennt@buca.vn
 * Website:
 * Create Date: October 17, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  17/10/2017       Author    kiennt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.View.Cash;

namespace Buca.Application.iBigTime2020.Presenter.Cash.PaymentVoucher
{
    /// <summary>
    /// CAPaymentPresenter
    /// </summary>
    public class CAPaymentPresenter : Presenter<ICAPaymentView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CAPaymentPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public CAPaymentPresenter(ICAPaymentView view)
            : base(view)
        {
        }
        string bankId;

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(string refId)
        {
            var caPayment = Model.GetPaymentVoucher(refId) ?? new CAPaymentModel();
            View.RefId = caPayment.RefId;
            View.RefType = caPayment.RefType;
            View.RefDate = caPayment.RefDate;
            View.PostedDate = caPayment.PostedDate;
            View.RefNo = caPayment.RefNo;
            View.CurrencyCode = caPayment.CurrencyCode;
            View.ExchangeRate = caPayment.ExchangeRate;
            View.ParalellRefNo = caPayment.ParalellRefNo;
            View.IncrementRefNo = caPayment.IncrementRefNo;
            View.InwardRefNo = caPayment.InwardRefNo;
            View.AccountingObjectId = caPayment.AccountingObjectId;
            View.JournalMemo = caPayment.JournalMemo;
            View.DocumentIncluded = caPayment.DocumentIncluded;
            View.BankId = caPayment.BankId;
            View.TotalAmount = caPayment.TotalAmount;
            View.TotalAmountOC = caPayment.TotalAmountOC;
            View.TotalTaxAmount = caPayment.TotalTaxAmount;
            View.TotalFreightAmount = caPayment.TotalFreightAmount;
            View.TotalInwardAmount = caPayment.TotalInwardAmount;
            View.Posted = caPayment.Posted;
            View.RefOrder = caPayment.RefOrder;
            View.RelationRefId = caPayment.RelationRefId;
            View.TotalPaymentAmount = caPayment.TotalPaymentAmount;
            View.CaPaymentDetails = caPayment.CAPaymentDetails.ToList();
            View.CaPaymentDetailTaxes = caPayment.CaPaymentDetailTaxes.ToList();
            View.CAPaymentDetailParallels = caPayment.CAPaymentDetailParallels.ToList();
            View.Receiver = caPayment.Receiver;
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncluedDetail">if set to <c>true</c> [is inclued detail].</param>
        /// <param name="isIncludedDetailTax">if set to <c>true</c> [is included detail tax].</param>
        public void Display(string refId, bool isIncluedDetail, bool isIncludedDetailTax)
        {
            var caPayment = Model.GetPaymentVoucher(refId, isIncluedDetail, isIncludedDetailTax) ?? new CAPaymentModel();
            View.RefId = caPayment.RefId;
            View.RefType = caPayment.RefType;
            View.RefDate = caPayment.RefDate;
            View.PostedDate = caPayment.PostedDate;
            View.RefNo = caPayment.RefNo;
            View.ParalellRefNo = caPayment.ParalellRefNo;
            View.IncrementRefNo = caPayment.IncrementRefNo;
            View.InwardRefNo = caPayment.InwardRefNo;
            View.AccountingObjectId = caPayment.AccountingObjectId;
            View.Address = caPayment.Address;
            View.JournalMemo = caPayment.JournalMemo;
            View.DocumentIncluded = caPayment.DocumentIncluded;
            View.BankId = caPayment.BankId;
            View.TotalAmountOC = caPayment.TotalAmountOC;
            View.TotalTaxAmount = caPayment.TotalTaxAmount;
            View.TotalFreightAmount = caPayment.TotalFreightAmount;
            View.TotalInwardAmount = caPayment.TotalInwardAmount;
            View.Posted = caPayment.Posted;
            View.RefOrder = caPayment.RefOrder;
            View.RelationRefId = caPayment.RelationRefId;
            View.TotalPaymentAmount = caPayment.TotalPaymentAmount;
            View.Receiver = caPayment.Receiver;
            View.CaPaymentDetails = caPayment.CAPaymentDetails == null ? new List<CAPaymentDetailModel>() : caPayment.CAPaymentDetails.ToList();
            View.CaPaymentDetailTaxes = caPayment.CaPaymentDetailTaxes == null ? new List<CAPaymentDetailTaxModel>() : caPayment.CaPaymentDetailTaxes.ToList();
            View.CAPaymentDetailParallels = caPayment.CAPaymentDetailParallels == null ? new List<CAPaymentDetailParallelModel>() : caPayment.CAPaymentDetailParallels.ToList();
            View.CurrencyCode = caPayment.CurrencyCode;
            View.ExchangeRate = caPayment.ExchangeRate;
            View.TotalAmount = caPayment.TotalAmount;

        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncluedDetail">if set to <c>true</c> [is inclued detail].</param>
        /// <param name="isIncludedDetailTax">if set to <c>true</c> [is included detail tax].</param>
        /// <param name="isIncludedDetailPurchase">if set to <c>true</c> [is included detail purchase].</param>
        public void Display(string refId, bool isIncluedDetail, bool isIncludedDetailTax, bool isIncludedDetailPurchase)
        {
            var caPayment = Model.GetPaymentVoucher(refId, isIncluedDetail, isIncludedDetailTax, isIncludedDetailPurchase) ?? new CAPaymentModel();
            View.RefId = caPayment.RefId;
            View.RefType = caPayment.RefType;
            View.RefDate = caPayment.RefDate;
            View.PostedDate = caPayment.PostedDate;
            View.RefNo = caPayment.RefNo;
            View.ParalellRefNo = caPayment.ParalellRefNo;
            View.IncrementRefNo = caPayment.IncrementRefNo;
            View.InwardRefNo = caPayment.InwardRefNo;
            View.AccountingObjectId = caPayment.AccountingObjectId;
            View.JournalMemo = caPayment.JournalMemo;
            View.DocumentIncluded = caPayment.DocumentIncluded;
            View.BankId = caPayment.BankId;
            View.TotalAmountOC = caPayment.TotalAmountOC;
            View.TotalTaxAmount = caPayment.TotalTaxAmount;
            View.TotalFreightAmount = caPayment.TotalFreightAmount;
            View.TotalInwardAmount = caPayment.TotalInwardAmount;
            View.Posted = caPayment.Posted;
            View.RefOrder = caPayment.RefOrder;
            View.RelationRefId = caPayment.RelationRefId;
            View.TotalPaymentAmount = caPayment.TotalPaymentAmount;
            View.Receiver = caPayment.Receiver;
            View.CaPaymentDetails = (List<CAPaymentDetailModel>)(caPayment.CAPaymentDetails ?? new List<CAPaymentDetailModel>());
            View.CaPaymentDetailTaxes = (List<CAPaymentDetailTaxModel>)(caPayment.CaPaymentDetailTaxes ?? new List<CAPaymentDetailTaxModel>());
            View.CAPaymentDetailPurchases = (List<CAPaymentDetailPurchaseModel>)(caPayment.CAPaymentDetailPurchases ?? new List<CAPaymentDetailPurchaseModel>());
            View.CAPaymentDetailParallels = caPayment.CAPaymentDetailParallels == null ? new List<CAPaymentDetailParallelModel>() : caPayment.CAPaymentDetailParallels.ToList();
            View.CurrencyCode = caPayment.CurrencyCode;
            View.ExchangeRate = caPayment.ExchangeRate;
            View.TotalAmount = caPayment.TotalAmount;
        }
        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncluedDetail">if set to <c>true</c> [is inclued detail].</param>
        /// <param name="isIncludedDetailTax">if set to <c>true</c> [is included detail tax].</param>
        /// <param name="isIncludedDetailPurchase">if set to <c>true</c> [is included detail purchase].</param>
        /// <param name="isIncludedDetailFixedAsset">if set to <c>true</c> [is included detail fixed asset].</param>
        public void Display(string refId, bool isIncluedDetail, bool isIncludedDetailTax, bool isIncludedDetailPurchase, bool isIncludedDetailFixedAsset)
        {
            var caPayment = Model.GetPaymentVoucher(refId, isIncluedDetail, isIncludedDetailTax, isIncludedDetailPurchase, isIncludedDetailFixedAsset) ?? new CAPaymentModel();
            View.RefId = caPayment.RefId;
            if (caPayment.RefType != null && caPayment.RefType != 0)
            {
                View.RefType = caPayment.RefType;
            };
            View.RefDate = caPayment.RefDate;
            View.PostedDate = caPayment.PostedDate;
            View.RefNo = caPayment.RefNo;
            View.ParalellRefNo = caPayment.ParalellRefNo;
            View.IncrementRefNo = caPayment.IncrementRefNo;
            View.InwardRefNo = caPayment.InwardRefNo;
            View.AccountingObjectId = caPayment.AccountingObjectId;
            View.JournalMemo = caPayment.JournalMemo;
            View.DocumentIncluded = caPayment.DocumentIncluded;
            View.BankId = caPayment.BankId;
            View.TotalAmountOC = caPayment.TotalAmountOC;
            View.TotalTaxAmount = caPayment.TotalTaxAmount;
            View.TotalFreightAmount = caPayment.TotalFreightAmount;
            View.TotalInwardAmount = caPayment.TotalInwardAmount;
            View.Posted = caPayment.Posted;
            View.RefOrder = caPayment.RefOrder;
            View.RelationRefId = caPayment.RelationRefId;
            View.TotalPaymentAmount = caPayment.TotalPaymentAmount;
            View.Receiver = caPayment.Receiver;
            View.CaPaymentDetails = (List<CAPaymentDetailModel>)(caPayment.CAPaymentDetails ?? new List<CAPaymentDetailModel>());
            View.CaPaymentDetailTaxes = (List<CAPaymentDetailTaxModel>)(caPayment.CaPaymentDetailTaxes ?? new List<CAPaymentDetailTaxModel>());
            View.CAPaymentDetailPurchases = (List<CAPaymentDetailPurchaseModel>)(caPayment.CAPaymentDetailPurchases ?? new List<CAPaymentDetailPurchaseModel>());
            View.CAPaymentDetailFixedAssets = (List<CAPaymentDetailFixedAssetModel>)caPayment.CAPaymentDetailFixedAssets ?? new List<CAPaymentDetailFixedAssetModel>();
            View.CAPaymentDetailParallels = caPayment.CAPaymentDetailParallels == null ? new List<CAPaymentDetailParallelModel>() : caPayment.CAPaymentDetailParallels.ToList();
            View.CurrencyCode = caPayment.CurrencyCode;
            View.ExchangeRate = caPayment.ExchangeRate;
            View.TotalAmount = caPayment.TotalAmount;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var payment = new CAPaymentModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo.Trim(),
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                ParalellRefNo = View.ParalellRefNo,
                IncrementRefNo = View.IncrementRefNo,
                InwardRefNo = View.InwardRefNo,
                AccountingObjectId = View.AccountingObjectId,
                JournalMemo = View.JournalMemo == null ? "" : View.JournalMemo.Trim(),
                DocumentIncluded = View.DocumentIncluded == null ? "" : View.DocumentIncluded.Trim(),
                BankId = View.BankId,
                TotalAmount = View.TotalAmount,
                TotalAmountOC = View.TotalAmountOC,
                TotalTaxAmount = View.TotalTaxAmount,
                TotalFreightAmount = View.TotalFreightAmount,
                TotalInwardAmount = View.TotalInwardAmount,
                Posted = View.Posted,
                RefOrder = View.RefOrder,
                RelationRefId = View.RelationRefId,
                Receiver = View.Receiver,
                TotalPaymentAmount = View.TotalPaymentAmount,
                CAPaymentDetails = View.CaPaymentDetails,
                CaPaymentDetailTaxes = View.CaPaymentDetailTaxes,
                CAPaymentDetailPurchases = View.CAPaymentDetailPurchases,
                CAPaymentDetailFixedAssets = View.CAPaymentDetailFixedAssets,
                CAPaymentDetailParallels = View.CAPaymentDetailParallels
            };
            if (View.RefId == null)
                return Model.InsertCAPayment(payment);
            return Model.UpdateCAPayment(payment);

        }

        /// <summary>
        /// Saves the specified is automatic generate parallel.
        /// </summary>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        public string Save(bool isAutoGenerateParallel)
        {
            
            var payment = new CAPaymentModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo.Trim(),
                CurrencyCode = View.CurrencyCode,
                Address = View.Address,
                ExchangeRate = View.ExchangeRate,
                ParalellRefNo = View.ParalellRefNo,
                IncrementRefNo = View.IncrementRefNo == null ? string.Empty : View.IncrementRefNo.Trim(), // View.IncrementRefNo,
                InwardRefNo = View.InwardRefNo,
                AccountingObjectId = View.AccountingObjectId,
                JournalMemo = View.JournalMemo == null ? "" : View.JournalMemo.Trim(),
                DocumentIncluded = View.DocumentIncluded == null ? "" : View.DocumentIncluded.Trim(),
                BankId = View.BankId,
                TotalAmount = View.TotalAmount,
                TotalAmountOC = View.TotalAmountOC,
                TotalTaxAmount = View.TotalTaxAmount,
                TotalFreightAmount = View.TotalFreightAmount,
                TotalInwardAmount = View.TotalInwardAmount,
                Posted = View.Posted,
                Receiver = View.Receiver,
                RefOrder = View.RefOrder,
                RelationRefId = View.RelationRefId,
                TotalPaymentAmount = View.TotalPaymentAmount,
                CAPaymentDetails = View.CaPaymentDetails,
                CaPaymentDetailTaxes = View.CaPaymentDetailTaxes,
                CAPaymentDetailPurchases = View.CAPaymentDetailPurchases,
                CAPaymentDetailFixedAssets = View.CAPaymentDetailFixedAssets,
                CAPaymentDetailParallels = View.CAPaymentDetailParallels,
                Parallels = View.Parallels

            };
            var paralelle = View.CAPaymentDetailParallels.ToList();

            if (View.RefId == null)
                return Model.InsertCAPayment(payment, isAutoGenerateParallel);
            return Model.UpdateCAPayment(payment, isAutoGenerateParallel);

        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public string Delete(string refId)
        {
            return Model.DeleteCAPayment(refId);
        }
    }
}