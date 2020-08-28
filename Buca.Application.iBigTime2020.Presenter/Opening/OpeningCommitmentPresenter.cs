/***********************************************************************
 * <copyright file="OpeningCommitmentPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Friday, December 8, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateFriday, December 8, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;
using Buca.Application.iBigTime2020.View.OpeningCommitment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Opening
{
    /// <summary>
    /// Class OpeningCommitmentPresenter.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{Buca.Application.iBigTime2020.View.OpeningCommitment.IOpeningCommitmentView}" />
    public class OpeningCommitmentPresenter : Presenter<IOpeningCommitmentView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BUCommitmentRequestPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public OpeningCommitmentPresenter(IOpeningCommitmentView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(string refId)
        {
            var openingCommitment = Model.GetOpeningCommitmentVoucher(refId, true) ?? new OpeningCommitmentModel();
            View.RefId = openingCommitment.RefId;
            View.RefDate = openingCommitment.RefDate;
            View.PostedDate = openingCommitment.PostedDate;
            View.RefNo = openingCommitment.RefNo;
            View.RefType = openingCommitment.RefType;
            View.AccountingObjectId = openingCommitment.AccountingObjectId;
            View.AccountingObjectName = openingCommitment.AccountingObjectName;
            View.TABMISCode = openingCommitment.TABMISCode;
            View.BankAccount = openingCommitment.BankAccount;
            View.BankName = openingCommitment.BankName;
            View.ContractNo = openingCommitment.ContractNo;
            View.ContractFrameNo = openingCommitment.ContractFrameNo;
            View.BudgetSourceKind = openingCommitment.BudgetSourceKind;
            View.TotalAmountOC = openingCommitment.TotalAmountOC;
            View.IsForeignCurrency = openingCommitment.IsForeignCurrency;
            //    View.Posted = openingCommitment.Posted;
            View.EditVersion = openingCommitment.EditVersion;
            View.PostVersion = openingCommitment.PostVersion;
            View.ProjectInvestmentCode = openingCommitment.ProjectInvestmentCode;
            View.ProjectInvestmentName = openingCommitment.ProjectInvestmentName;
            View.SignDate = openingCommitment.SignDate;
            View.ContractAmount = openingCommitment.ContractAmount;
            View.PrevYearCommitmentAmount = openingCommitment.PrevYearCommitmentAmount;
            View.OpeningCommitmentDetails = openingCommitment.OpeningCommitmentDetails.ToList() ?? new List<OpeningCommitmentDetailModel>();
            View.TotalAmount = openingCommitment.TotalAmount;
        }

        public void DisplayNoIsForeignCurrency(string refId)
        {
            var openingCommitment = Model.GetOpeningCommitmentVoucher(refId, true) ?? new OpeningCommitmentModel();
            View.RefId = openingCommitment.RefId;
            View.RefDate = openingCommitment.RefDate;
            View.PostedDate = openingCommitment.PostedDate;
            View.RefNo = openingCommitment.RefNo;
            View.RefType = openingCommitment.RefType;
            View.AccountingObjectId = openingCommitment.AccountingObjectId;
            View.AccountingObjectName = openingCommitment.AccountingObjectName;
            View.TABMISCode = openingCommitment.TABMISCode;
            View.BankAccount = openingCommitment.BankAccount;
            View.BankName = openingCommitment.BankName;
            View.ContractNo = openingCommitment.ContractNo;
            View.ContractFrameNo = openingCommitment.ContractFrameNo;
            View.BudgetSourceKind = openingCommitment.BudgetSourceKind;
            View.TotalAmount = openingCommitment.TotalAmount;
            View.TotalAmountOC = openingCommitment.TotalAmountOC;
            //View.IsForeignCurrency = openingCommitment.IsForeignCurrency;
            //    View.Posted = openingCommitment.Posted;
            View.EditVersion = openingCommitment.EditVersion;
            View.PostVersion = openingCommitment.PostVersion;
            View.ProjectInvestmentCode = openingCommitment.ProjectInvestmentCode;
            View.ProjectInvestmentName = openingCommitment.ProjectInvestmentName;
            View.SignDate = openingCommitment.SignDate;
            View.ContractAmount = openingCommitment.ContractAmount;
            View.PrevYearCommitmentAmount = openingCommitment.PrevYearCommitmentAmount;
            View.OpeningCommitmentDetails = openingCommitment.OpeningCommitmentDetails.ToList() ?? new List<OpeningCommitmentDetailModel>();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Save()
        {
            var OpeningCommitment = new OpeningCommitmentModel()
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
                ContractNo = View.ContractNo,
                ContractFrameNo = View.ContractFrameNo,
                BudgetSourceKind = View.BudgetSourceKind,
                TotalAmount = View.TotalAmount,
                TotalAmountOC = View.TotalAmountOC,
                IsForeignCurrency = View.IsForeignCurrency,
                //              Posted = View.Posted,
                EditVersion = View.EditVersion,
                PostVersion = View.PostVersion,
                ProjectInvestmentCode = View.ProjectInvestmentCode,
                ProjectInvestmentName = View.ProjectInvestmentName,
                SignDate = View.SignDate,
                ContractAmount = View.ContractAmount,
                PrevYearCommitmentAmount = View.PrevYearCommitmentAmount,

                OpeningCommitmentDetails = View.OpeningCommitmentDetails
            };
            if (View.RefId == null)
                return Model.InsertOpeningCommitment(OpeningCommitment);
            return Model.UpdateOpeningCommitment(OpeningCommitment);
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string Delete(string refId)
        {
            return Model.DeleteOpeningCommitment(refId);
        }
    }
}
