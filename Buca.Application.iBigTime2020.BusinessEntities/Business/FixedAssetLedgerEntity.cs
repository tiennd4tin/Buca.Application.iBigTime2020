/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: December 06, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    06/12/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business
{
    /// <summary>
    /// FixedAssetLedger
    /// </summary>
    public class FixedAssetLedgerEntity : BusinessEntities
    {
        /// <summary>
        /// Gets or sets the fixed asset ledger identifier.
        /// </summary>
        /// <value>
        /// The fixed asset ledger identifier.
        /// </value>
        public string FixedAssetLedgerId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        /// The type of the reference.
        /// </value>
        public int? RefType { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        /// The fixed asset identifier.
        /// </value>
        public string FixedAssetId { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public string DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the life time.
        /// </summary>
        /// <value>
        /// The life time.
        /// </value>
        public decimal LifeTime { get; set; }

        /// <summary>
        /// Gets or sets the annual depreciation rate.
        /// </summary>
        /// <value>
        /// The annual depreciation rate.
        /// </value>
        public decimal AnnualDepreciationRate { get; set; }

        /// <summary>
        /// Gets or sets the annual depreciation amount.
        /// </summary>
        /// <value>
        /// The annual depreciation amount.
        /// </value>
        public decimal AnnualDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the org price account.
        /// </summary>
        /// <value>
        /// The org price account.
        /// </value>
        public string OrgPriceAccount { get; set; }

        /// <summary>
        /// Gets or sets the org price debit amount.
        /// </summary>
        /// <value>
        /// The org price debit amount.
        /// </value>
        public decimal OrgPriceDebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the org price credit amount.
        /// </summary>
        /// <value>
        /// The org price credit amount.
        /// </value>
        public decimal OrgPriceCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the depreciation account.
        /// </summary>
        /// <value>
        /// The depreciation account.
        /// </value>
        public string DepreciationAccount { get; set; }

        /// <summary>
        /// Gets or sets the depreciation debit amount.
        /// </summary>
        /// <value>
        /// The depreciation debit amount.
        /// </value>
        public decimal DepreciationDebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the depreciation credit amount.
        /// </summary>
        /// <value>
        /// The depreciation credit amount.
        /// </value>
        public decimal DepreciationCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the capital account.
        /// </summary>
        /// <value>
        /// The capital account.
        /// </value>
        public string CapitalAccount { get; set; }

        /// <summary>
        /// Gets or sets the capital debit amount.
        /// </summary>
        /// <value>
        /// The capital debit amount.
        /// </value>
        public decimal CapitalDebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the capital credit amount.
        /// </summary>
        /// <value>
        /// The capital credit amount.
        /// </value>
        public decimal CapitalCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the remaining life time.
        /// </summary>
        /// <value>
        /// The remaining life time.
        /// </value>
        public int? RemainingLifeTime { get; set; }

        /// <summary>
        /// Gets or sets the end year.
        /// </summary>
        /// <value>
        /// The end year.
        /// </value>
        public int? EndYear { get; set; }

        /// <summary>
        /// Gets or sets the fa reference order.
        /// </summary>
        /// <value>The fa reference order.</value>
        public int FARefOrder { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset order.
        /// </summary>
        /// <value>The fixed asset order.</value>
        public int FixedAssetOrder { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the difference quantity.
        /// </summary>
        /// <value>The difference quantity.</value>
        public decimal DifferenceQuantity { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset code.
        /// </summary>
        /// <value>The fixed asset code.</value>
        public string FixedAssetCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>The name of the fixed asset.</value>
        public string FixedAssetName { get; set; }

        /// <summary>
        /// Gets or sets the devaluation period.
        /// </summary>
        /// <value>The devaluation period.</value>
        public int DevaluationPeriod { get; set; }

        /// <summary>
        /// Gets or sets the devaluation rate.
        /// </summary>
        /// <value>The devaluation rate.</value>
        public decimal DevaluationRate { get; set; }

        /// <summary>
        /// Gets or sets the period devaluation amount.
        /// </summary>
        /// <value>The period devaluation amount.</value>
        public decimal PeriodDevaluationAmount { get; set; }

        /// <summary>
        /// Gets or sets the devaluation debit amount.
        /// </summary>
        /// <value>The devaluation debit amount.</value>
        public decimal DevaluationDebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the devaluation credit amount.
        /// </summary>
        /// <value>The devaluation credit amount.</value>
        public decimal DevaluationCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the remaining devaluation life time.
        /// </summary>
        /// <value>The remaining devaluation life time.</value>
        public decimal RemainingDevaluationLifeTime { get; set; }

        /// <summary>
        /// Gets or sets the end devaluation date.
        /// </summary>
        /// <value>The end devaluation date.</value>
        public DateTime? EndDevaluationDate { get; set; }

        /// <summary>
        /// Gets or sets the devaluation amount.
        /// </summary>
        /// <value>The devaluation amount.</value>
        public decimal DevaluationAmount { get; set; }

        /// <summary>
        /// Lí do ghi giảm TSCĐ
        /// </summary>
        public int DecreaseReasonId { get; set; }
    }
}