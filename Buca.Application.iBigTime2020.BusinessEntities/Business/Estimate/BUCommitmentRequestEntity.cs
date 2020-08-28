/***********************************************************************
 * <copyright file="BUCommitmentRequestEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Tuesday, December 5, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateTuesday, December 5, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate
{
    /// <summary>
    /// Class BUCommitmentRequestEntity.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class BUCommitmentRequestEntity : BusinessEntities
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        public DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        public string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>The name of the accounting object.</value>
        public string AccountingObjectName { get; set; }

        /// <summary>
        /// Gets or sets the tabmis code.
        /// </summary>
        /// <value>The tabmis code.</value>
        public string TABMISCode { get; set; }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>The bank account.</value>
        public string BankAccount { get; set; }

        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>The name of the bank.</value>
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the contract no.
        /// </summary>
        /// <value>The contract no.</value>
        public string ContractNo { get; set; }

        /// <summary>
        /// Gets or sets the contract frame no.
        /// </summary>
        /// <value>The contract frame no.</value>
        public string ContractFrameNo { get; set; }

        /// <summary>
        /// Gets or sets the kind of the budget source.
        /// </summary>
        /// <value>The kind of the budget source.</value>
        public int BudgetSourceKind { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        public decimal TotalAmountOC { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is foreign currency.
        /// </summary>
        /// <value><c>true</c> if this instance is foreign currency; otherwise, <c>false</c>.</value>
        public bool IsForeignCurrency { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BUCommitmentRequestEntity" /> is posted.
        /// </summary>
        /// <value><c>true</c> if posted; otherwise, <c>false</c>.</value>
        public bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the edit version.
        /// </summary>
        /// <value>The edit version.</value>
        public int? EditVersion { get; set; }

        /// <summary>
        /// Gets or sets the post version.
        /// </summary>
        /// <value>The post version.</value>
        public int? PostVersion { get; set; }

        /// <summary>
        /// Gets or sets the project investment code.
        /// </summary>
        /// <value>The project investment code.</value>
        public string ProjectInvestmentCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the project investment.
        /// </summary>
        /// <value>The name of the project investment.</value>
        public string ProjectInvestmentName { get; set; }

        /// <summary>
        /// Gets or sets the sign date.
        /// </summary>
        /// <value>The sign date.</value>
        public DateTime? SignDate { get; set; }

        /// <summary>
        /// Gets or sets the contract amount.
        /// </summary>
        /// <value>The contract amount.</value>
        public decimal? ContractAmount { get; set; }

        /// <summary>
        /// Gets or sets the previous year commitment amount.
        /// </summary>
        /// <value>The previous year commitment amount.</value>
        public decimal? PrevYearCommitmentAmount { get; set; }

        /// <summary>
        /// Gets or sets the bu commitment request details.
        /// </summary>
        /// <value>The bu commitment request details.</value>
        public IList<BUCommitmentRequestDetailEntity> BUCommitmentRequestDetails { get; set; }


    }
}
