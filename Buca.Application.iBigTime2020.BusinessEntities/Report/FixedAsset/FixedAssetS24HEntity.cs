/***********************************************************************
 * <copyright file="FixedAssetS24HEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Friday, January 12, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * DateFriday, January 12, 2018 Author SonTV  Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.FixedAsset
{
    /// <summary>
    ///     Class FixedAssetS24HEntity.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class FixedAssetS24HEntity : BusinessEntities
    {
        /// <summary>
        ///     Gets or sets the fixed asset category identifier.
        /// </summary>
        /// <value>
        ///     The fixed asset category identifier.
        /// </value>
        public string FixedAssetCategoryId { get; set; }

        /// <summary>
        ///     Gets or sets the fixed asset category code.
        /// </summary>
        /// <value>
        ///     The fixed asset category code.
        /// </value>
        public string FixedAssetCategoryCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the fixed asset category.
        /// </summary>
        /// <value>
        ///     The name of the fixed asset category.
        /// </value>
        public string FixedAssetCategoryName { get; set; }

        /// <summary>
        ///     Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        ///     The fixed asset identifier.
        /// </value>
        public string FixedAssetId { get; set; }

        /// <summary>
        ///     Gets or sets the fixed asset code.
        /// </summary>
        /// <value>
        ///     The fixed asset code.
        /// </value>
        public string FixedAssetCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>
        ///     The name of the fixed asset.
        /// </value>
        public string FixedAssetName { get; set; }

        /// <summary>
        ///     Gets or sets the department identifier.
        /// </summary>
        /// <value>
        ///     The department identifier.
        /// </value>
        public string DepartmentId { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the made in.
        /// </summary>
        /// <value>
        ///     The made in.
        /// </value>
        public string MadeIn { get; set; }

        /// <summary>
        ///     Gets or sets the used date.
        /// </summary>
        /// <value>
        ///     The used date.
        /// </value>
        public DateTime? UsedDate { get; set; }

        /// <summary>
        ///     Gets or sets the serial number.
        /// </summary>
        /// <value>
        ///     The serial number.
        /// </value>
        public string SerialNumber { get; set; }

        /// <summary>
        ///     Gets or sets the depreciation rate.
        /// </summary>
        /// <value>
        ///     The depreciation rate.
        /// </value>
        public decimal? DepreciationRate { get; set; }

        /// <summary>
        /// Gets or sets the devaluation rate
        /// </summary>
        public decimal? DevaluationRate { get; set; }

        /// <summary>
        ///     Gets or sets the period depreciation amount.
        /// </summary>
        /// <value>
        ///     The period depreciation amount.
        /// </value>
        public decimal? PeriodDepreciationAmount { get; set; }

        /// <summary>
        ///     Gets or sets the increment reference identifier.
        /// </summary>
        /// <value>
        ///     The increment reference identifier.
        /// </value>
        public string IncrementRefId { get; set; }

        /// <summary>
        ///     Gets or sets the increment reference no.
        /// </summary>
        /// <value>
        ///     The increment reference no.
        /// </value>
        public string IncrementRefNo { get; set; }

        /// <summary>
        ///     Gets or sets the increment reference date.
        /// </summary>
        /// <value>
        ///     The increment reference date.
        /// </value>
        public DateTime? IncrementRefDate { get; set; }

        /// <summary>
        ///     Gets or sets the type of the increment reference.
        /// </summary>
        /// <value>
        ///     The type of the increment reference.
        /// </value>
        public int? IncrementRefType { get; set; }

        /// <summary>
        ///     Gets or sets the increment quantity.
        /// </summary>
        /// <value>
        ///     The increment quantity.
        /// </value>
        public int IncrementQuantity { get; set; }

        /// <summary>
        ///     Gets or sets the org price.
        /// </summary>
        /// <value>
        ///     The org price.
        /// </value>
        public decimal? OrgPrice { get; set; }

        /// <summary>
        ///     Gets or sets the decrement reference identifier.
        /// </summary>
        /// <value>
        ///     The decrement reference identifier.
        /// </value>
        public string DecrementRefId { get; set; }

        /// <summary>
        ///     Gets or sets the decrement reference no.
        /// </summary>
        /// <value>
        ///     The decrement reference no.
        /// </value>
        public string DecrementRefNo { get; set; }

        /// <summary>
        ///     Gets or sets the decrement reference date.
        /// </summary>
        /// <value>
        ///     The decrement reference date.
        /// </value>
        public DateTime? DecrementRefDate { get; set; }

        /// <summary>
        ///     Gets or sets the type of the decrement reference.
        /// </summary>
        /// <value>
        ///     The type of the decrement reference.
        /// </value>
        public int? DecrementRefType { get; set; }

        /// <summary>
        ///     Gets or sets the decrement quantity.
        /// </summary>
        /// <value>
        ///     The decrement quantity.
        /// </value>
        public int DecrementQuantity { get; set; }

        /// <summary>
        ///     Gets or sets the journal memo.
        /// </summary>
        /// <value>
        ///     The journal memo.
        /// </value>
        public string JournalMemo { get; set; }

        /// <summary>
        ///     Gets or sets the remaining fixed asset amount.
        /// </summary>
        /// <value>
        ///     The remaining fixed asset amount.
        /// </value>
        public decimal? RemainingFixedAssetAmount { get; set; }

        /// <summary>
        ///     Gets or sets the depreciation credit amount last year.
        /// </summary>
        /// <value>
        ///     The depreciation credit amount last year.
        /// </value>
        public decimal? DepreciationCreditAmountLastYear { get; set; }

        /// <summary>
        ///     Gets or sets the depreciation credit amount this year.
        /// </summary>
        /// <value>
        ///     The depreciation credit amount this year.
        /// </value>
        public decimal? DepreciationCreditAmountThisYear { get; set; }

        /// <summary>
        /// Gets or sets the devaluation credit amount this year
        /// </summary>
        public decimal? DevaluationCreditAmountThisYear { get; set; }

        /// <summary>
        ///     Gets or sets the sort order.
        /// </summary>
        /// <value>
        ///     The sort order.
        /// </value>
        public string SortOrder { get; set; }

        /// <summary>
        ///     Gets or sets the name of the department.
        /// </summary>
        /// <value>
        ///     The name of the department.
        /// </value>
        public string DepartmentName { get; set; }
    }
}