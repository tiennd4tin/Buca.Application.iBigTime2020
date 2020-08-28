/***********************************************************************
 * <copyright file="BUCommitmentAdjustmentModel.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate
{
    /// <summary>
    /// Class BUCommitmentAdjustmentModel.
    /// </summary>
    public class BUCommitmentAdjustmentModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BUCommitmentAdjustmentModel"/> class.
        /// </summary>
        public BUCommitmentAdjustmentModel()
        {
            BUCommitmentAdjustmentDetails = new List<BUCommitmentAdjustmentDetailModel>();
        }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
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
        /// Gets or sets the bu commitment request identifier.
        /// </summary>
        /// <value>The bu commitment request identifier.</value>
        public string BUCommitmentRequestId { get; set; }

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
        /// Gets or sets the real contract no.
        /// </summary>
        /// <value>The real contract no.</value>
        public string RealContractNo { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType { get; set; }

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
        /// Gets or sets a value indicating whether this <see cref="BUCommitmentAdjustmentModel"/> is posted.
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
        /// Gets or sets a value indicating whether this instance is suggest adjustment.
        /// </summary>
        /// <value><c>true</c> if this instance is suggest adjustment; otherwise, <c>false</c>.</value>
        public bool IsSuggestAdjustment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is suggest supplement.
        /// </summary>
        /// <value><c>true</c> if this instance is suggest supplement; otherwise, <c>false</c>.</value>
        public bool IsSuggestSupplement { get; set; }

        /// <summary>
        /// Gets or sets the adjustment provider bank account.
        /// </summary>
        /// <value>The adjustment provider bank account.</value>
        public string AdjustmentProviderBankAccount { get; set; }

        /// <summary>
        /// Gets or sets the name of the adjustment provider bank.
        /// </summary>
        /// <value>The name of the adjustment provider bank.</value>
        public string AdjustmentProviderBankName { get; set; }

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
        /// Gets or sets the bu commitment adjustment details.
        /// </summary>
        /// <value>The bu commitment adjustment details.</value>
        public IList<BUCommitmentAdjustmentDetailModel> BUCommitmentAdjustmentDetails { get; set; }
    }
}
