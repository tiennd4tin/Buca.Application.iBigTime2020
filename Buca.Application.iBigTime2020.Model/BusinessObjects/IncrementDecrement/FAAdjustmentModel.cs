/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 27, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement
{
    /// <summary>
    /// SUTransferModel
    /// </summary>
    public class FAAdjustmentModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FAAdjustmentModel"/> class.
        /// </summary>
        public FAAdjustmentModel()
        {
            FAAdjustmentDetails = new List<FAAdjustmentDetailModel>();
            FAAdjustmentDetailParallels = new List<FAAdjustmentDetailParallelModel>();
        }

        /// <summary>
        /// Gets or sets the fa adjustment details.
        /// </summary>
        /// <value>
        /// The fa adjustment details.
        /// </value>
        public IList<FAAdjustmentDetailModel> FAAdjustmentDetails { get; set; }
        public IList<FAAdjustmentDetailParallelModel> FAAdjustmentDetailParallels { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>
        /// The reference detail identifier.
        /// </value>
        public string RefDetailId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        /// The type of the reference.
        /// </value>
        public int RefType { get; set; }

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
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>
        /// The paralell reference no.
        /// </value>
        public string ParalellRefNo { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        /// The fixed asset identifier.
        /// </value>
        public string FixedAssetId { get; set; }

        /// <summary>
        /// Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>
        /// The name of the fixed asset.
        /// </value>
        public string FixedAssetName { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FAAdjustmentModel"/> is posted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if posted; otherwise, <c>false</c>.
        /// </value>
        public bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the post version.
        /// </summary>
        /// <value>
        /// The post version.
        /// </value>
        public int PostVersion { get; set; }

        /// <summary>
        /// Gets or sets the edit version.
        /// </summary>
        /// <value>
        /// The edit version.
        /// </value>
        public int? EditVersion { get; set; }

        /// <summary>
        /// Gets or sets the applied year.
        /// </summary>
        /// <value>
        /// The applied year.
        /// </value>
        public int AppliedYear { get; set; }

        /// <summary>
        /// Gets or sets the end year.
        /// </summary>
        /// <value>
        /// The end year.
        /// </value>
        public int EndYear { get; set; }

        /// <summary>
        /// Gets or sets the fa reference order.
        /// </summary>
        /// <value>
        /// The fa reference order.
        /// </value>
        public int FARefOrder { get; set; }

        /// <summary>
        /// Gets or sets the end devaluation date.
        /// </summary>
        /// <value>
        /// The end devaluation date.
        /// </value>
        public DateTime EndDevaluationDate { get; set; }

        /// <summary>
        /// Gets or sets the new org price.
        /// </summary>
        /// <value>
        /// The new org price.
        /// </value>
        public decimal NewOrgPrice { get; set; }

        /// <summary>
        /// Gets or sets the old org price.
        /// </summary>
        /// <value>
        /// The old org price.
        /// </value>
        public decimal OldOrgPrice { get; set; }

        /// <summary>
        /// Gets or sets the difference org price.
        /// </summary>
        /// <value>
        /// The difference org price.
        /// </value>
        public decimal DiffOrgPrice { get; set; }

        /// <summary>
        /// Gets or sets the new devaluation amount.
        /// </summary>
        /// <value>
        /// The new devaluation amount.
        /// </value>
        public decimal NewDevaluationAmount { get; set; }

        /// <summary>
        /// Gets or sets the old devaluation amount.
        /// </summary>
        /// <value>
        /// The old devaluation amount.
        /// </value>
        public decimal OldDevaluationAmount { get; set; }

        /// <summary>
        /// Gets or sets the difference devaluation amount.
        /// </summary>
        /// <value>
        /// The difference devaluation amount.
        /// </value>
        public decimal DiffDevaluationAmount { get; set; }

        /// <summary>
        /// Gets or sets the new accum devaluation amount.
        /// </summary>
        /// <value>
        /// The new accum devaluation amount.
        /// </value>
        public decimal NewAccumDevaluationAmount { get; set; }

        /// <summary>
        /// Gets or sets the old accum devaluation amount.
        /// </summary>
        /// <value>
        /// The old accum devaluation amount.
        /// </value>
        public decimal OldAccumDevaluationAmount { get; set; }

        /// <summary>
        /// Gets or sets the difference accum devaluation amount.
        /// </summary>
        /// <value>
        /// The difference accum devaluation amount.
        /// </value>
        public decimal DiffAccumDevaluationAmount { get; set; }

        /// <summary>
        /// Gets or sets the new remaining amount.
        /// </summary>
        /// <value>
        /// The new remaining amount.
        /// </value>
        public decimal NewRemainingAmount { get; set; }

        /// <summary>
        /// Gets or sets the old remaining amount.
        /// </summary>
        /// <value>
        /// The old remaining amount.
        /// </value>
        public decimal OldRemainingAmount { get; set; }

        /// <summary>
        /// Gets or sets the difference remaining amount.
        /// </summary>
        /// <value>
        /// The difference remaining amount.
        /// </value>
        public decimal DiffRemainingAmount { get; set; }

        /// <summary>
        /// Gets or sets the new quantity.
        /// </summary>
        /// <value>
        /// The new quantity.
        /// </value>
        public decimal NewQuantity { get; set; }

        /// <summary>
        /// Gets or sets the old quantity.
        /// </summary>
        /// <value>
        /// The old quantity.
        /// </value>
        public decimal OldQuantity { get; set; }

        /// <summary>
        /// Gets or sets the difference quantity.
        /// </summary>
        /// <value>
        /// The difference quantity.
        /// </value>
        public decimal DiffQuantity { get; set; }

        /// <summary>
        /// Gets or sets the old annual depreciation amount.
        /// </summary>
        /// <value>
        /// The old annual depreciation amount.
        /// </value>
        public decimal OldAnnualDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the new annual depreciation amount.
        /// </summary>
        /// <value>
        /// The new annual depreciation amount.
        /// </value>
        public decimal NewAnnualDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the new accum depreciation amount.
        /// </summary>
        /// <value>
        /// The new accum depreciation amount.
        /// </value>
        public decimal NewAccumDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the difference accum depreciation amount.
        /// </summary>
        /// <value>
        /// The difference accum depreciation amount.
        /// </value>
        public decimal DiffAccumDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the difference annual depreciation amount.
        /// </summary>
        /// <value>
        /// The difference annual depreciation amount.
        /// </value>
        public decimal DiffAnnualDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the old accum depreciation amount.
        /// </summary>
        /// <value>
        /// The old accum depreciation amount.
        /// </value>
        public decimal OldAccumDepreciationAmount { get; set; }
    }
}
