/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 20, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    20/11/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using Buca.Application.iBigTime2020.View.General;
using System;

namespace Buca.Application.iBigTime2020.Presenter.General
{
    public class GLVoucherLastYearPresenter : Presenter<IGLVoucherLastYearView>
    {
        public GLVoucherLastYearPresenter(IGLVoucherLastYearView view) : base(view)
        {
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <param name="hasTax">if set to <c>true</c> [has tax].</param>
        public void Display(string refId, bool hasDetail, bool hasTax)
        {
            var glVoucher = Model.GetGLVoucher(refId, hasDetail, hasTax) ?? new GLVoucherModel();

            View.RefId = glVoucher.RefId;
            View.RefType = glVoucher.RefType;
            View.RefDate = glVoucher.RefDate;
            View.PostedDate = glVoucher.PostedDate;
            View.RefNo = glVoucher.RefNo;
         
            View.ExchangeRate = glVoucher.ExchangeRate;
            View.ParalellRefNo = glVoucher.ParalellRefNo;
            View.JournalMemo = glVoucher.JournalMemo;
            View.TotalAmount = glVoucher.TotalAmount;
            View.TotalAmountOC = glVoucher.TotalAmountOC;
            View.ParentRefId = glVoucher.ParentRefId;
            View.Posted = glVoucher.Posted;
            View.Approved = glVoucher.Approved;
            View.PostVersion = glVoucher.PostVersion;
            View.EditVersion = glVoucher.EditVersion;
            View.AdvancePaymentOrder = glVoucher.AdvancePaymentOrder;
            View.GLVoucherDetails = glVoucher.GLVoucherDetails ?? new List<GLVoucherDetailModel>();
            View.GLVoucherDetailTaxes = glVoucher.GLVoucherDetailTaxes ?? new List<GLVoucherDetailTaxModel>();
            View.GLVoucherDetailParalles = glVoucher.GLVoucherDetailParalles ?? new List<GLVoucherDetailParallelModel>();
            View.CurrencyCode = glVoucher.CurrencyCode;
        }
        public void DisplayTranfer(int RefType, DateTime sysDate, bool hasTax,string projectIds = null)
        {
            var glVoucher = Model.GetGLVoucherTranfer(RefType, sysDate, hasTax,projectIds) ?? new GLVoucherModel();

            View.RefId = glVoucher.RefId;
        //    View.RefType = glVoucher.RefType;
      //      View.RefDate = glVoucher.RefDate;
      //      View.PostedDate = glVoucher.PostedDate;
       //     View.RefNo = glVoucher.RefNo;
           
            View.ExchangeRate = glVoucher.ExchangeRate;
            View.ParalellRefNo = glVoucher.ParalellRefNo;
            View.JournalMemo = glVoucher.JournalMemo;
            View.TotalAmount = glVoucher.TotalAmount;
            View.TotalAmountOC = glVoucher.TotalAmountOC;
            View.ParentRefId = glVoucher.ParentRefId;
            View.Posted = glVoucher.Posted;

            View.Approved = glVoucher.Approved;
            View.PostVersion = glVoucher.PostVersion;
            View.EditVersion = glVoucher.EditVersion;
            View.AdvancePaymentOrder = glVoucher.AdvancePaymentOrder;
            View.GLVoucherDetails = glVoucher.GLVoucherDetails ?? new List<GLVoucherDetailModel>();
            View.GLVoucherDetailTaxes = glVoucher.GLVoucherDetailTaxes ?? new List<GLVoucherDetailTaxModel>();
            View.GLVoucherDetailParalles = glVoucher.GLVoucherDetailParalles ?? new List<GLVoucherDetailParallelModel>();
            View.CurrencyCode = glVoucher.CurrencyCode;
        }

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var glVoucher = new GLVoucherModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                ParalellRefNo = View.ParalellRefNo,
                JournalMemo = View.JournalMemo,
                TotalAmount = View.TotalAmount,
                TotalAmountOC = View.TotalAmountOC,
                ParentRefId = View.ParentRefId,
                Posted = View.Posted,

                Approved = View.Approved,
                PostVersion = View.PostVersion,
                EditVersion = View.EditVersion,
                AdvancePaymentOrder = View.AdvancePaymentOrder,
                GLVoucherDetails = View.GLVoucherDetails,
                GLVoucherDetailTaxes = View.GLVoucherDetailTaxes,
            };
            if (View.RefId == null)
                return Model.InsertGLVoucher(glVoucher);
            return Model.UpdateGLVoucher(glVoucher);
        }

        /// <summary>
        /// Saves the specified is automatic generate parallel.
        /// </summary>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        public string Save(bool isAutoGenerateParallel)
        {
            var glVoucher = new GLVoucherModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                ParalellRefNo = View.ParalellRefNo,
                JournalMemo = View.JournalMemo,
                TotalAmount = View.TotalAmount,
                TotalAmountOC = View.TotalAmountOC,
                ParentRefId = View.ParentRefId,
                Posted = View.Posted,

                Approved = View.Approved,
                PostVersion = View.PostVersion,
                EditVersion = View.EditVersion,
                AdvancePaymentOrder = View.AdvancePaymentOrder,
                GLVoucherDetails = View.GLVoucherDetails,
                GLVoucherDetailTaxes = View.GLVoucherDetailTaxes,
                GLVoucherDetailParalles = View.GLVoucherDetailParalles
            };
            if (View.RefId == null)
                return Model.InsertGLVoucher(glVoucher, isAutoGenerateParallel);
            return Model.UpdateGLVoucher(glVoucher, isAutoGenerateParallel);
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
            return Model.DeleteGLVoucher(refId);
        }
    }
}
