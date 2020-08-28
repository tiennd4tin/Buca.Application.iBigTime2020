/***********************************************************************
 * <copyright file="BUCommitmentRequestPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 6, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 6, 2017Author SonTV  Description 
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
    /// Class BUCommitmentRequestPresenter.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{Buca.Application.iBigTime2020.View.Estimate.IBUCommitmentRequestView}" />
    public class BUCommitmentRequestPresenter : Presenter<IBUCommitmentRequestView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BUCommitmentRequestPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BUCommitmentRequestPresenter(IBUCommitmentRequestView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(string refId)
        {
            var bUCommitmentRequest = Model.GetBUCommitmentRequestVoucher(refId, true) ?? new BUCommitmentRequestModel();
            View.RefId = bUCommitmentRequest.RefId;
            View.RefDate = bUCommitmentRequest.RefDate;
            View.PostedDate = bUCommitmentRequest.PostedDate;
            View.RefNo = bUCommitmentRequest.RefNo;
            View.RefType = bUCommitmentRequest.RefType;
            View.AccountingObjectId = bUCommitmentRequest.AccountingObjectId;
            View.AccountingObjectName = bUCommitmentRequest.AccountingObjectName;
            View.TABMISCode = bUCommitmentRequest.TABMISCode;
            View.BankAccount = bUCommitmentRequest.BankAccount;
            View.BankName = bUCommitmentRequest.BankName;
            View.ContractNo = bUCommitmentRequest.ContractNo;
            View.ContractFrameNo = bUCommitmentRequest.ContractFrameNo;
            View.BudgetSourceKind = bUCommitmentRequest.BudgetSourceKind;
            View.TotalAmountOC = bUCommitmentRequest.TotalAmountOC;
            View.IsForeignCurrency = bUCommitmentRequest.IsForeignCurrency;
            View.Posted = bUCommitmentRequest.Posted;
            View.EditVersion = bUCommitmentRequest.EditVersion;
            View.PostVersion = bUCommitmentRequest.PostVersion;
            View.ProjectInvestmentCode = bUCommitmentRequest.ProjectInvestmentCode;
            View.ProjectInvestmentName = bUCommitmentRequest.ProjectInvestmentName;
            View.SignDate = bUCommitmentRequest.SignDate;
            View.ContractAmount = bUCommitmentRequest.ContractAmount;
            View.PrevYearCommitmentAmount = bUCommitmentRequest.PrevYearCommitmentAmount;
            View.BUCommitmentRequestDetails = bUCommitmentRequest.BUCommitmentRequestDetails.ToList() ?? new List<BUCommitmentRequestDetailModel>();
            View.TotalAmount = bUCommitmentRequest.TotalAmount;
        }

        public void DisplayNoIsForeignCurrency(string refId)
        {
            var bUCommitmentRequest = Model.GetBUCommitmentRequestVoucher(refId, true) ?? new BUCommitmentRequestModel();
            View.RefId = bUCommitmentRequest.RefId;
            View.RefDate = bUCommitmentRequest.RefDate;
            View.PostedDate = bUCommitmentRequest.PostedDate;
            View.RefNo = bUCommitmentRequest.RefNo;
            View.RefType = bUCommitmentRequest.RefType;
            View.AccountingObjectId = bUCommitmentRequest.AccountingObjectId;
            View.AccountingObjectName = bUCommitmentRequest.AccountingObjectName;
            View.TABMISCode = bUCommitmentRequest.TABMISCode;
            View.BankAccount = bUCommitmentRequest.BankAccount;
            View.BankName = bUCommitmentRequest.BankName;
            View.ContractNo = bUCommitmentRequest.ContractNo;
            View.ContractFrameNo = bUCommitmentRequest.ContractFrameNo;
            View.BudgetSourceKind = bUCommitmentRequest.BudgetSourceKind;
            View.TotalAmount = bUCommitmentRequest.TotalAmount;
            View.TotalAmountOC = bUCommitmentRequest.TotalAmountOC;
            //View.IsForeignCurrency = bUCommitmentRequest.IsForeignCurrency;
            View.Posted = bUCommitmentRequest.Posted;
            View.EditVersion = bUCommitmentRequest.EditVersion;
            View.PostVersion = bUCommitmentRequest.PostVersion;
            View.ProjectInvestmentCode = bUCommitmentRequest.ProjectInvestmentCode;
            View.ProjectInvestmentName = bUCommitmentRequest.ProjectInvestmentName;
            View.SignDate = bUCommitmentRequest.SignDate;
            View.ContractAmount = bUCommitmentRequest.ContractAmount;
            View.PrevYearCommitmentAmount = bUCommitmentRequest.PrevYearCommitmentAmount;
            View.BUCommitmentRequestDetails = bUCommitmentRequest.BUCommitmentRequestDetails.ToList() ?? new List<BUCommitmentRequestDetailModel>();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Save()
        {
            var BUCommitmentRequest = new BUCommitmentRequestModel()
            {

                RefId = View.RefId,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,                
                RefNo = View.RefNo,
                RefType = View.RefType,
                AccountingObjectId = View.AccountingObjectId,
                AccountingObjectName = View.AccountingObjectName,
                TABMISCode = View.TABMISCode == null ? string.Empty : View.TABMISCode,
                BankAccount = View.BankAccount == null ? string.Empty : View.BankAccount,
                BankName = View.BankName,
                ContractNo = View.ContractNo == null ? string.Empty : View.ContractNo,
                ContractFrameNo = View.ContractFrameNo == null ? string.Empty : View.ContractFrameNo,
                BudgetSourceKind = View.BudgetSourceKind,
                TotalAmount = View.TotalAmount,
                TotalAmountOC = View.TotalAmountOC,
                IsForeignCurrency = View.IsForeignCurrency,
                Posted = View.Posted,
                EditVersion = View.EditVersion,
                PostVersion = View.PostVersion,
                ProjectInvestmentCode = View.ProjectInvestmentCode,
                ProjectInvestmentName = View.ProjectInvestmentName,
                SignDate = View.SignDate,
                ContractAmount = View.ContractAmount,
                PrevYearCommitmentAmount = View.PrevYearCommitmentAmount,
                BUCommitmentRequestDetails = View.BUCommitmentRequestDetails,
            };
            if (View.RefId == null)
                return Model.InsertBUCommitmentRequest(BUCommitmentRequest);
            return Model.UpdateBUCommitmentRequest(BUCommitmentRequest);
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string Delete(string refId)
        {
            return Model.DeleteBUCommitmentRequest(refId);
        }
    }
}
