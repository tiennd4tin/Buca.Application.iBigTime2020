/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 28, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement;

namespace Buca.Application.iBigTime2020.View.IncrementDecrement
{
    /// <summary>
    /// ISUTransfersView
    /// </summary>
    public interface ISUTransfersView: IView
    {
        /// <summary>
        /// Gets or sets the su transfer details.
        /// </summary>
        /// <value>
        /// The su transfer details.
        /// </value>
        IList<SUTransferModel> SUTransfers { set; }
    }
}
