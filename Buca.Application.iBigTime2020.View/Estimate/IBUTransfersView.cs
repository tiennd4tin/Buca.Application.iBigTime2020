/***********************************************************************
 * <copyright file="IBUTransfersView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 13, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.Estimate
{
    /// <summary>
    /// Interface IBUTransfersView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IBUTransfersView : IView
    {
        /// <summary>
        /// Sets the bu commitment adjustments.
        /// </summary>
        /// <value>The bu commitment adjustments.</value>
        IList<BUTransferModel> BUTransfers { set; }
    }
}
