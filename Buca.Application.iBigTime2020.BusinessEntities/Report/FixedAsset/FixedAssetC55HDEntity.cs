/***********************************************************************
 * <copyright file="FixedAssetC55HDEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Monday, July 09, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.FixedAsset
{
    /// <summary>
    /// FixedAssetC55HDEntity
    /// </summary>
    public class FixedAssetC55HDEntity: BusinessEntities
    {
        /// <summary>
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        /// The fixed asset identifier.
        /// </value>
        public string FixedAssetCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset code.
        /// </summary>
        /// <value>
        /// The fixed asset code.
        /// </value>
        public string FixedAssetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>
        /// The name of the fixed asset.
        /// </value>
        public string FixedAssetCategoryName { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public string ParentId { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets the original price.
        /// </summary>
        /// <value>
        /// The original price.
        /// </value>
        public decimal OriginalPrice { get; set; }

        /// <summary>
        /// Gets or sets the depreciation rate.
        /// </summary>
        /// <value>
        /// The depreciation rate.
        /// </value>
        public decimal DepreciationRate { get; set; }

        /// <summary>
        /// Gets or sets the depreciation amount.
        /// </summary>
        /// <value>
        /// The depreciation amount.
        /// </value>
        public decimal DepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is fixed asset.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is fixed asset; otherwise, <c>false</c>.
        /// </value>
        public bool IsFixedAsset { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is parent.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is parent; otherwise, <c>false</c>.
        /// </value>
        public bool IsParent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is detail by fixed asset.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is detail by fixed asset; otherwise, <c>false</c>.
        /// </value>
        public bool IsDetailByFixedAsset { get; set; }
    }
}
