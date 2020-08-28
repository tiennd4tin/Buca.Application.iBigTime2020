/***********************************************************************
 * <copyright file="FixedAssetEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhTN
 * Email:    linhtn@buca.vn
 * Website:
 * Create Date: Wednesday, April 18, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    public class FixedAssetDetailAccessoryEntity : BusinessEntities
    {
        /// <summary>
        /// Gets or sets the fixed asset detail accessory identifier.
        /// </summary>
        /// <value>
        /// The fixed asset detail accessory identifier.
        /// </value>
        public int FixedAssetDetailAccessoryId { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        /// The fixed asset identifier.
        /// </value>
        public string FixedAssetId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>
        /// The unit.
        /// </value>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public decimal? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder { get; set; }
    }
}
