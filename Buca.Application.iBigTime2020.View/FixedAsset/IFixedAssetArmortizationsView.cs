/***********************************************************************
 * <copyright file="IFixedAssetArmortizationsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.FixedAsset;


namespace Buca.Application.iBigTime2020.View.FixedAsset
{
    /// <summary>
    /// IFixedAssetArmortizationsView
    /// </summary>
    public interface IFixedAssetArmortizationsView : IView
    {
        /// <summary>
        /// Sets the fixed asset armortizations.
        /// </summary>
        /// <value>
        /// The fixed asset armortizations.
        /// </value>
        IList<FixedAssetArmortizationModel> FixedAssetArmortizations { set; }
    }
}
