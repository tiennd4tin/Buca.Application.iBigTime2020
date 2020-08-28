/***********************************************************************
 * <copyright file="IBUCommitmentAdjustmentView.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.Estimate
{
    /// <summary>
    /// Interface IBUCommitmentAdjustmentView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IBUCommitmentAdjustmentView : IView
    {

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        string RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the bu commitment request identifier.
        /// </summary>
        /// <value>The bu commitment request identifier.</value>
        string BUCommitmentRequestId { get; set; }
        string CurrencyCode { get; set; }
        decimal ExchangeRate { get; set; }

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
        /// Gets or sets the real contract no.
        /// </summary>
        /// <value>The real contract no.</value>
        string RealContractNo { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        int RefType { get; set; }

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
        /// Gets or sets a value indicating whether this <see cref="BUCommitmentAdjustmentModel" /> is posted.
        /// </summary>
        /// <value><c>true</c> if posted; otherwise, <c>false</c>.</value>
        bool Posted { get; set; }

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
        /// Gets or sets a value indicating whether this instance is suggest adjustment.
        /// </summary>
        /// <value><c>true</c> if this instance is suggest adjustment; otherwise, <c>false</c>.</value>
        bool IsSuggestAdjustment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is suggest supplement.
        /// </summary>
        /// <value><c>true</c> if this instance is suggest supplement; otherwise, <c>false</c>.</value>
        bool IsSuggestSupplement { get; set; }

        /// <summary>
        /// Gets or sets the adjustment provider bank account.
        /// </summary>
        /// <value>The adjustment provider bank account.</value>
        string AdjustmentProviderBankAccount { get; set; }

        /// <summary>
        /// Gets or sets the name of the adjustment provider bank.
        /// </summary>
        /// <value>The name of the adjustment provider bank.</value>
        string AdjustmentProviderBankName { get; set; }

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
        /// Gets or sets the bu commitment adjustment details.
        /// </summary>
        /// <value>The bu commitment adjustment details.</value>
        IList<BUCommitmentAdjustmentDetailModel> BUCommitmentAdjustmentDetails { get; set; }
    }
}
