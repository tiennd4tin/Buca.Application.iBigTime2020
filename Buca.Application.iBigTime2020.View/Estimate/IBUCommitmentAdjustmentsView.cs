/***********************************************************************
 * <copyright file="IBUCommitmentAdjustmentsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Monday, December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateMonday, December 11, 2017Author SonTV  Description 
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
    /// Interface IBUCommitmentAdjustmentsView
    /// </summary>
    public interface IBUCommitmentAdjustmentsView
    {
        /// <summary>
        /// Sets the bu commitment adjustments.
        /// </summary>
        /// <value>The bu commitment adjustments.</value>
        IList<BUCommitmentAdjustmentModel> BUCommitmentAdjustments { set; }
    }
}
