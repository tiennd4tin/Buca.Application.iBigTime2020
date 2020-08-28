/***********************************************************************
 * <copyright file="IFAIncrementDecrementView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement;

namespace Buca.Application.iBigTime2020.View.IncrementDecrement
{
    /// <summary>
    ///     IFAIncrementDecrementView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IFAAdjustmentView : IView
    {
        IList<FAAdjustmentDetailModel> FAAdjustmentDetails { get; set; }
        IList<FAAdjustmentDetailParallelModel> FAAdjustmentDetailParallels { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        /// The type of the reference.
        /// </value>
        int RefType { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>
        /// The paralell reference no.
        /// </value>
        string ParalellRefNo { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        /// The fixed asset identifier.
        /// </value>
        string FixedAssetId { get; set; }

        /// <summary>
        /// Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>
        /// The name of the fixed asset.
        /// </value>
        string FixedAssetName { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FAAdjustmentModel"/> is posted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if posted; otherwise, <c>false</c>.
        /// </value>
        bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the post version.
        /// </summary>
        /// <value>
        /// The post version.
        /// </value>
        int PostVersion { get; set; }

        /// <summary>
        /// Gets or sets the edit version.
        /// </summary>
        /// <value>
        /// The edit version.
        /// </value>
        int? EditVersion { get; set; }

        /// <summary>
        /// Gets or sets the applied year.
        /// </summary>
        /// <value>
        /// The applied year.
        /// </value>
        int AppliedYear { get; set; }

        /// <summary>
        /// Gets or sets the end year.
        /// </summary>
        /// <value>
        /// The end year.
        /// </value>
        int EndYear { get; set; }

        /// <summary>
        /// Gets or sets the fa reference order.
        /// </summary>
        /// <value>
        /// The fa reference order.
        /// </value>
        int FARefOrder { get; set; }

        /// <summary>
        /// Gets or sets the end devaluation date.
        /// </summary>
        /// <value>
        /// The end devaluation date.
        /// </value>
        DateTime EndDevaluationDate { get; set; }

        /// <summary>
        /// Gets or sets the new org price.
        /// </summary>
        /// <value>
        /// The new org price.
        /// </value>
        decimal NewOrgPrice { get; set; }

        /// <summary>
        /// Gets or sets the old org price.
        /// </summary>
        /// <value>
        /// The old org price.
        /// </value>
        decimal OldOrgPrice { get; set; }

        /// <summary>
        /// Gets or sets the difference org price.
        /// </summary>
        /// <value>
        /// The difference org price.
        /// </value>
        decimal DiffOrgPrice { get; set; }

        /// <summary>
        /// Gets or sets the new devaluation amount.
        /// </summary>
        /// <value>
        /// The new devaluation amount.
        /// </value>
        decimal NewDevaluationAmount { get; set; }

        /// <summary>
        /// Gets or sets the old devaluation amount.
        /// </summary>
        /// <value>
        /// The old devaluation amount.
        /// </value>
        decimal OldDevaluationAmount { get; set; }

        /// <summary>
        /// Gets or sets the difference devaluation amount.
        /// </summary>
        /// <value>
        /// The difference devaluation amount.
        /// </value>
        decimal DiffDevaluationAmount { get; set; }

        /// <summary>
        /// Gets or sets the new accum devaluation amount.
        /// </summary>
        /// <value>
        /// The new accum devaluation amount.
        /// </value>
        decimal NewAccumDevaluationAmount { get; set; }

        /// <summary>
        /// Gets or sets the old accum devaluation amount.
        /// </summary>
        /// <value>
        /// The old accum devaluation amount.
        /// </value>
        decimal OldAccumDevaluationAmount { get; set; }

        /// <summary>
        /// Gets or sets the difference accum devaluation amount.
        /// </summary>
        /// <value>
        /// The difference accum devaluation amount.
        /// </value>
        decimal DiffAccumDevaluationAmount { get; set; }

        /// <summary>
        /// Gets or sets the new remaining amount.
        /// </summary>
        /// <value>
        /// The new remaining amount.
        /// </value>
        decimal NewRemainingAmount { get; set; }

        /// <summary>
        /// Gets or sets the old remaining amount.
        /// </summary>
        /// <value>
        /// The old remaining amount.
        /// </value>
        decimal OldRemainingAmount { get; set; }

        /// <summary>
        /// Gets or sets the difference remaining amount.
        /// </summary>
        /// <value>
        /// The difference remaining amount.
        /// </value>
        decimal DiffRemainingAmount { get; set; }

        /// <summary>
        /// Gets or sets the new quantity.
        /// </summary>
        /// <value>
        /// The new quantity.
        /// </value>
        decimal NewQuantity { get; set; }

        /// <summary>
        /// Gets or sets the old quantity.
        /// </summary>
        /// <value>
        /// The old quantity.
        /// </value>
        decimal OldQuantity { get; set; }

        /// <summary>
        /// Gets or sets the difference quantity.
        /// </summary>
        /// <value>
        /// The difference quantity.
        /// </value>
        decimal DiffQuantity { get; set; }

        /// <summary>
        /// Gets or sets the old annual depreciation amount.
        /// </summary>
        /// <value>
        /// The old annual depreciation amount.
        /// </value>
        decimal OldAnnualDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the new annual depreciation amount.
        /// </summary>
        /// <value>
        /// The new annual depreciation amount.
        /// </value>
        decimal NewAnnualDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the new accum depreciation amount.
        /// </summary>
        /// <value>
        /// The new accum depreciation amount.
        /// </value>
        decimal NewAccumDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the difference accum depreciation amount.
        /// </summary>
        /// <value>
        /// The difference accum depreciation amount.
        /// </value>
        decimal DiffAccumDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the difference annual depreciation amount.
        /// </summary>
        /// <value>
        /// The difference annual depreciation amount.
        /// </value>
        decimal DiffAnnualDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the old accum depreciation amount.
        /// </summary>
        /// <value>
        /// The old accum depreciation amount.
        /// </value>
        decimal OldAccumDepreciationAmount { get; set; }

    }
}