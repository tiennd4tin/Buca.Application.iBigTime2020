/***********************************************************************
 * <copyright file="PaymentEstimateDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 18 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate
{
    /// <summary>
    /// EstimateDetailEntity
    /// </summary>
    public class BUPlanWithdrawEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BUPlanWithdrawEntity"/> class.
        /// </summary>
        public BUPlanWithdrawEntity()
        {
            // AddRule(new ValidateRequired("RefId"));
            AddRule(new ValidateRequired("CashWithDrawType"));
            AddRule(new ValidateRequired("RefType"));
        }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the cash with draw.
        /// </summary>
        /// <value>The type of the cash with draw.</value>
        public int CashWithDrawType { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType { get; set; }

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
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>The paralell reference no.</value>
        public string ParalellRefNo { get; set; }

        /// <summary>
        /// Gets or sets the target program identifier.
        /// </summary>
        /// <value>The target program identifier.</value>
        public string TargetProgramId { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string BankId { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        public string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string JournalMemo { get; set; }

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
        /// Gets or sets the generated reference identifier.
        /// </summary>
        /// <value>The generated reference identifier.</value>
        public string GeneratedRefId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BUPlanWithdrawEntity"/> is posted.
        /// </summary>
        /// <value><c>true</c> if posted; otherwise, <c>false</c>.</value>
        public bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the bu commitment request identifier.
        /// </summary>
        /// <value>The bu commitment request identifier.</value>
        public string BUCommitmentRequestId { get; set; }

        /// <summary>
        /// Gets or sets the bu plan withdraw details.
        /// </summary>
        /// <value>The bu plan withdraw details.</value>
        public IList<BUPlanWithdrawDetailEntity> BUPlanWithdrawDetails { get; set; }

        /// <summary>
        /// Gets or sets the accounting object bank i.
        /// </summary>
        /// <value>
        /// The accounting object bank i.
        /// </value>
        public string AccountingObjectBankId { get; set; }

        /// <summary>
        /// Id Liên kết: rút dự toán tiền mặt - phiếu thu từ ngân sách nhà nước
        /// </summary>
        public string CAReceiptRefId { get; set; }

        /// <summary>
        /// Số phiếu liên kết
        /// </summary>
        public string LinkRefNo { get; set; }
    }
}
