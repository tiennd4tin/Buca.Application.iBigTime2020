﻿/***********************************************************************
 * <copyright file="IFixedAssetView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;


namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// FixedAssets View Interface
    /// </summary>
    public interface IFixedAssetsView : IView
    {
        /// <summary>
        /// Sets the fixed assets.
        /// </summary>
        /// <value>
        /// The fixed assets.
        /// </value>
        IList<FixedAssetModel> FixedAssets { set; }
    }
}
