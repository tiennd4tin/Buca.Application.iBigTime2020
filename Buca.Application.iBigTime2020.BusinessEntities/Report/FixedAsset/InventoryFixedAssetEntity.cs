/***********************************************************************
 * <copyright file="InventoryFixedAsset.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, April 26, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.FixedAsset
{
    /// <summary>
    ///     InventoryFixedAsset
    /// </summary>
    public class InventoryFixedAssetEntity
    {
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
        ///     Gets or sets the made in.
        /// </summary>
        /// <value>
        ///     The made in.
        /// </value>
        public string MadeIn { get; set; }

        /// <summary>
        ///     Gets or sets the serial number.
        /// </summary>
        /// <value>
        ///     The serial number.
        /// </value>
        public string SerialNumber { get; set; }

        /// <summary>
        ///     Gets or sets the user date.
        /// </summary>
        /// <value>
        ///     The user date.
        /// </value>
        public int UserDate { get; set; }

        /// <summary>
        ///     Gets or sets to date.
        /// </summary>
        /// <value>
        ///     To date.
        /// </value>
        public int ToDate { get; set; }

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
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the department.
        /// </summary>
        /// <value>
        ///     The name of the department.
        /// </value>
        public string DepartmentName { get; set; }

        /// <summary>
        ///     Gets or sets the book quantity.
        /// </summary>
        /// <value>
        ///     The book quantity.
        /// </value>
        public int BookQuantity { get; set; }

        /// <summary>
        ///     Gets or sets the org price.
        /// </summary>
        /// <value>
        ///     The org price.
        /// </value>
        public decimal OrgPrice { get; set; }

        /// <summary>
        ///     Gets or sets the depreciation credit amount.
        /// </summary>
        /// <value>
        ///     The depreciation credit amount.
        /// </value>
        public decimal DepreciationCreditAmount { get; set; }

        /// <summary>
        ///     Gets or sets the posted date.
        /// </summary>
        /// <value>
        ///     The posted date.
        /// </value>
        public DateTime PostedDate { get; set; }

        public int ReportItemIndex { get; set; }
    }
}