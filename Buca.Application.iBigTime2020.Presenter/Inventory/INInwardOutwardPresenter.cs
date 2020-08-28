/***********************************************************************
 * <copyright file="ReceiptVouchersPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 19, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Inventory;
using Buca.Application.iBigTime2020.View.Inventory;

namespace Buca.Application.iBigTime2020.Presenter.Inventory
{
    /// <summary>
    /// ReceiptVouchersPresenter class
    /// </summary>
    public class INInwardOutwardPresenter : Presenter<IINInwardOutwardView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="INInwardOutwardPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public INInwardOutwardPresenter(IINInwardOutwardView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(string refId)
        {
            var inwardOutward = Model.GetINInwardOutward(refId, false,false) ?? new INInwardOutwardModel();

            View.RefId = inwardOutward.RefId;
            View.RefType = inwardOutward.RefType;
            View.RefDate = inwardOutward.RefDate;
            View.PostedDate = inwardOutward.PostedDate;
            View.RefNo = inwardOutward.RefNo;
            View.ParalellRefNo = inwardOutward.ParalellRefNo;
            View.AccountingObjectId = inwardOutward.AccountingObjectId;
            View.JournalMemo = inwardOutward.JournalMemo;
            View.TotalTaxAmount = inwardOutward.TotalTaxAmount;
            View.GeneratedRefId = inwardOutward.GeneratedRefId;
            View.RefOrder = inwardOutward.RefOrder;
            View.InwardOutwardDetails = inwardOutward.InwardOutwardDetails.ToList();
            View.CurrencyCode = inwardOutward.CurrencyCode;
            View.ExchangeRate = inwardOutward.ExchangeRate;
            View.TotalAmount = inwardOutward.TotalAmount;
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncluedDetail">if set to <c>true</c> [is inclued detail].</param>
        public void Display(string refId, bool isIncluedDetail,bool isIncludeDetailParaller)
        {
            var inwardOutward = Model.GetINInwardOutward(refId, isIncluedDetail, isIncludeDetailParaller) ?? new INInwardOutwardModel();

            View.RefId = inwardOutward.RefId;
            View.RefType = inwardOutward.RefType;
            View.RefDate = inwardOutward.RefDate;
            View.PostedDate = inwardOutward.PostedDate;
            View.RefNo = inwardOutward.RefNo;
            View.ParalellRefNo = inwardOutward.ParalellRefNo;
            View.AccountingObjectId = inwardOutward.AccountingObjectId;
            View.JournalMemo = inwardOutward.JournalMemo;
            View.GeneratedRefId = inwardOutward.GeneratedRefId;
            View.RefOrder = inwardOutward.RefOrder;
            View.InwardOutwardDetails = inwardOutward.InwardOutwardDetails;
            View.DocumentInclued = inwardOutward.DocumentInclued;
            View.INInwardOutwardDetailParallels = inwardOutward.InwardOutwardDetailParallels;
            View.CurrencyCode = inwardOutward.CurrencyCode;
            View.ExchangeRate = inwardOutward.ExchangeRate;
            View.TotalAmount = inwardOutward.TotalAmount;
            View.TotalTaxAmount = inwardOutward.TotalTaxAmount;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Save()
        {
            var inwardOutward = new INInwardOutwardModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo.Trim(),
                ParalellRefNo = View.ParalellRefNo,
                AccountingObjectId = View.AccountingObjectId,
                JournalMemo = View.JournalMemo.Trim(),
                TotalAmount = View.TotalAmount,
                TotalTaxAmount = View.TotalTaxAmount,
                GeneratedRefId = View.GeneratedRefId,
                RefOrder = View.RefOrder,
                InwardOutwardDetails = View.InwardOutwardDetails,
                DocumentInclued = View.DocumentInclued.Trim(),
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
            InwardOutwardDetailParallels =View.INInwardOutwardDetailParallels,
                
            };
            return View.RefId == null ? Model.AddINInwardOutward(inwardOutward) : Model.UpdateINInwardOutward(inwardOutward);
        }
        /// <summary>
        /// Saves the specified is automatic generate parallel.
        /// </summary>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        public string Save(bool isAutoGenerateParallel, bool IsOutwardNegativeStock)
        {

            var inwardOutward = new INInwardOutwardModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo.Trim(),
                ParalellRefNo = View.ParalellRefNo,
                AccountingObjectId = View.AccountingObjectId,
                JournalMemo = View.JournalMemo.Trim(),
                TotalAmount = View.TotalAmount,
                TotalTaxAmount = View.TotalTaxAmount,
                GeneratedRefId = View.GeneratedRefId,
                RefOrder = View.RefOrder,
                InwardOutwardDetails = View.InwardOutwardDetails,
                DocumentInclued = View.DocumentInclued.Trim(),
                CurrencyCode = View.CurrencyCode,
                InwardOutwardDetailParallels = View.INInwardOutwardDetailParallels,
                ExchangeRate=View.ExchangeRate,
            };
            if (View.RefId == null)
                return Model.AddINInwardOutward(inwardOutward, isAutoGenerateParallel, IsOutwardNegativeStock);
            return Model.UpdateINInwardOutward(inwardOutward, isAutoGenerateParallel, IsOutwardNegativeStock);

        }
        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string Delete(string refId)
        {
            return Model.DeleteINInwardOutward(refId);
        }

        public bool IsExistRefNo(string refId, string refNo, int refType)
        {
            var INInwardOutward = Model.GetINInwardOutwards().Where(x => x.RefId != refId && x.RefNo == refNo && x.RefType == refType).ToList();
            if(INInwardOutward.Count >0)
            {
                return true;
            }
            return false;
        }
    }
}