/***********************************************************************
 * <copyright file="IOpeningCommitmentView.cs" company="BUCA JSC">
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.OpeningCommitment
{
    /// <summary>
    /// Interface IOpeningCommitmentView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IOpeningCommitmentView : IView
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        string RefId { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        DateTime PostedDate { get; set; }
        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        int RefType { get; set; }

        /// <summary>
        /// Gets or sets the kind of the budget source.
        /// </summary>
        /// <value>The kind of the budget source.</value>
        int BudgetSourceKind { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        decimal TotalAmountOC { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is foreign currency.
        /// </summary>
        /// <value><c>true</c> if this instance is foreign currency; otherwise, <c>false</c>.</value>
        bool IsForeignCurrency { get; set; }

        /// <summary>
        /// Gets or sets the edit version.
        /// </summary>
        /// <value>The edit version.</value>
        int? EditVersion { get; set; }

        /// <summary>
        /// Gets or sets the post version.
        /// </summary>
        /// <value>The post version.</value>
        int? PostVersion { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>The name of the accounting object.</value>
        string AccountingObjectName { get; set; }

        /// <summary>
        /// Gets or sets the tabmis code.
        /// </summary>
        /// <value>The tabmis code.</value>
        string TABMISCode { get; set; }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>The bank account.</value>
        string BankAccount { get; set; }

        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>The name of the bank.</value>
        string BankName { get; set; }

        /// <summary>
        /// Gets or sets the contract no.
        /// </summary>
        /// <value>The contract no.</value>
        string ContractNo { get; set; }

        /// <summary>
        /// Gets or sets the contract frame no.
        /// </summary>
        /// <value>The contract frame no.</value>
        string ContractFrameNo { get; set; }

        /// <summary>
        /// Gets or sets the project investment code.
        /// </summary>
        /// <value>The project investment code.</value>
        string ProjectInvestmentCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the project investment.
        /// </summary>
        /// <value>The name of the project investment.</value>
        string ProjectInvestmentName { get; set; }

        /// <summary>
        /// Gets or sets the sign date.
        /// </summary>
        /// <value>The sign date.</value>
        DateTime? SignDate { get; set; }

        /// <summary>
        /// Gets or sets the contract amount.
        /// </summary>
        /// <value>The contract amount.</value>
        decimal? ContractAmount { get; set; }

        /// <summary>
        /// Gets or sets the previous year commitment amount.
        /// </summary>
        /// <value>The previous year commitment amount.</value>
        decimal? PrevYearCommitmentAmount { get; set; }

        /// <summary>
        /// Gets or sets the opening commitment details.
        /// </summary>
        /// <value>The opening commitment details.</value>
        IList<OpeningCommitmentDetailModel> OpeningCommitmentDetails { get; set; }
    }
}
