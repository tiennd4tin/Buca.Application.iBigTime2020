// ***********************************************************************
// Assembly         : Buca.Application.iBigTime2020.Model
// Author           : thangnd
// Created          : 05-03-2018
//
// Last Modified By : thangnd
// Last Modified On : 05-03-2018
// ***********************************************************************
// <copyright file="MinutesFixedAssetModel.cs" company="by adguard">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.FixedAsset
{
    /// <summary>
    /// Class MinutesGetCountFixedAssetModel.
    /// </summary>
    public class MinutesFixedAssetModel
    {
        /// <summary>
        /// Gets or sets the minutes get count fixed assets.
        /// </summary>
        /// <value>The minutes get count fixed assets.</value>
        public List<MinutesGetCountFixedAssetModel> MinutesGetCountFixedAssets { get; set; }

        /// <summary>
        /// Gets or sets the fa minutes inventory fixed assets.
        /// </summary>
        /// <value>The fa minutes inventory fixed assets.</value>
        public List<FAMinutesInventoryFixedAssetModel> FAMinutesInventoryFixedAssets { get; set; }
    }
}
