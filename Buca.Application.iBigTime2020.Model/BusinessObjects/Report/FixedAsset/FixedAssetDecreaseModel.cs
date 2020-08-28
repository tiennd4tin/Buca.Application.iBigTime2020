/***********************************************************************
 * <copyright file="FixedAssetDecreaseModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, May 3, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.FixedAsset
{
    /// <summary>
    /// FixedAssetDecreaseModel
    /// </summary>
    public class FixedAssetDecreaseModel
    {
        /// <summary>
        ///     Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>
        ///     The name of the fixed asset.
        /// </value>
        public string FixedAssetName { get; set; }

        /// <summary>
        ///     Gets or sets the unit.
        /// </summary>
        /// <value>
        ///     The unit.
        /// </value>
        public string Unit { get; set; }

        /// <summary>
        ///     Gets or sets the fixed asset code.
        /// </summary>
        /// <value>
        ///     The fixed asset code.
        /// </value>
        public string FixedAssetCode { get; set; }

        /// <summary>
        ///     Gets or sets the serial number.
        /// </summary>
        /// <value>
        ///     The serial number.
        /// </value>
        public string SerialNumber { get; set; }

        /// <summary>
        ///     Gets or sets the made in.
        /// </summary>
        /// <value>
        ///     The made in.
        /// </value>
        public string MadeIn { get; set; }

        /// <summary>
        ///     Gets or sets the production year.
        /// </summary>
        /// <value>
        ///     The production year.
        /// </value>
        public int? ProductionYear { get; set; }

        /// <summary>
        ///     Gets or sets the used date.
        /// </summary>
        /// <value>
        ///     The used date.
        /// </value>
        public DateTime? UsedDate { get; set; }

        /// <summary>
        ///     Gets or sets the quantity.
        /// </summary>
        /// <value>
        ///     The quantity.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        ///     Gets or sets the volume.
        /// </summary>
        /// <value>
        ///     The volume.
        /// </value>
        public int Volume { get; set; }

        /// <summary>
        ///     Gets or sets the remaining rate.
        /// </summary>
        /// <value>
        ///     The remaining rate.
        /// </value>
        public decimal RemainingRate { get; set; }

        /// <summary>
        ///     Gets or sets the org price.
        /// </summary>
        /// <value>
        ///     The org price.
        /// </value>
        public decimal OrgPrice { get; set; }

        /// <summary>
        ///     Gets or sets the remaining amount.
        /// </summary>
        /// <value>
        ///     The remaining amount.
        /// </value>
        public decimal RemainingAmount { get; set; }
    }
}