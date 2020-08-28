/***********************************************************************
 * <copyright file="BUCommitmentAdjustmentPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Monday, December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateMonday, December 11, 2017Author SonTV  Description 
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
    /// Class BUCommitmentAdjustmentPresenter.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{Buca.Application.iBigTime2020.View.Estimate.IBUCommitmentAdjustmentView}" />
    public class BUCommitmentAdjustmentPresenter : Presenter<IBUCommitmentAdjustmentView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BUCommitmentAdjustmentPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BUCommitmentAdjustmentPresenter(IBUCommitmentAdjustmentView view)
            : base(view)
        {
        }
        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(string refId)
        {
            var bUCommitmentAdjustment = Model.GetBUCommitmentAdjustmentVoucher(refId, true) ?? new BUCommitmentAdjustmentModel();
            View.RefId = bUCommitmentAdjustment.RefId;
            View.RefDate = bUCommitmentAdjustment.RefDate;
            View.PostedDate = bUCommitmentAdjustment.PostedDate;
            View.RefNo = bUCommitmentAdjustment.RefNo;
            View.BUCommitmentRequestId = bUCommitmentAdjustment.BUCommitmentRequestId;
            View.ContractNo = bUCommitmentAdjustment.ContractNo;
            View.ContractFrameNo = bUCommitmentAdjustment.ContractFrameNo;
            View.RealContractNo = bUCommitmentAdjustment.RealContractNo;
            View.RefType = bUCommitmentAdjustment.RefType;
            View.TotalAmountOC = bUCommitmentAdjustment.TotalAmountOC;
            View.IsForeignCurrency = bUCommitmentAdjustment.IsForeignCurrency;
            View.Posted = bUCommitmentAdjustment.Posted;
            View.EditVersion = bUCommitmentAdjustment.EditVersion;
            View.PostVersion = bUCommitmentAdjustment.PostVersion;
            View.IsSuggestAdjustment = bUCommitmentAdjustment.IsSuggestAdjustment;
            View.IsSuggestSupplement = bUCommitmentAdjustment.IsSuggestSupplement;
            View.AdjustmentProviderBankAccount = bUCommitmentAdjustment.AdjustmentProviderBankAccount;
            View.AdjustmentProviderBankName = bUCommitmentAdjustment.AdjustmentProviderBankName;
            View.BankAccount = bUCommitmentAdjustment.BankAccount;
            View.BankName = bUCommitmentAdjustment.BankName;
          
            View.BUCommitmentAdjustmentDetails = bUCommitmentAdjustment.BUCommitmentAdjustmentDetails.ToList() ?? new List<BUCommitmentAdjustmentDetailModel>();
            View.ExchangeRate = bUCommitmentAdjustment.ExchangeRate;
            View.CurrencyCode = bUCommitmentAdjustment.CurrencyCode;
            View.TotalAmount = bUCommitmentAdjustment.TotalAmount;

        }
        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Save()
        {
            var bUCommitmentAdjustment = new BUCommitmentAdjustmentModel()
            {

                RefId = View.RefId,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                BUCommitmentRequestId = View.BUCommitmentRequestId,
                ContractNo = View.ContractNo,
                ContractFrameNo = View.ContractFrameNo,
                RealContractNo = View.RealContractNo,
                RefType = View.RefType,
                TotalAmountOC = View.TotalAmountOC,
                TotalAmount = View.TotalAmount,
                IsForeignCurrency = View.IsForeignCurrency,
                Posted = View.Posted,
                EditVersion = View.EditVersion,
                ExchangeRate = View.ExchangeRate,
                CurrencyCode = View.CurrencyCode,
                PostVersion = View.PostVersion,
                IsSuggestAdjustment = View.IsSuggestAdjustment,
                IsSuggestSupplement = View.IsSuggestSupplement,
                AdjustmentProviderBankAccount = View.AdjustmentProviderBankAccount,
                AdjustmentProviderBankName = View.AdjustmentProviderBankName,
                BankAccount = View.BankAccount,
                BankName = View.BankName,


                BUCommitmentAdjustmentDetails = View.BUCommitmentAdjustmentDetails
            };
            if (View.RefId == null)
                return Model.InsertBUCommitmentAdjustment(bUCommitmentAdjustment);
            return Model.UpdateBUCommitmentAdjustment(bUCommitmentAdjustment);
        }
        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string Delete(string refId)
        {
            return Model.DeleteBUCommitmentAdjustment(refId);
        }

    }
}
