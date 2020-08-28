/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 30, 2017
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
    /// IFADepreciationsView
    /// </summary>
    public interface IFADepreciationsView : IView
    {
        /// <summary>
        /// Sets the fa depreciations.
        /// </summary>
        /// <value>
        /// The fa depreciations.
        /// </value>
        IList<FADepreciationModel> FADepreciations { set; }
    }
}
