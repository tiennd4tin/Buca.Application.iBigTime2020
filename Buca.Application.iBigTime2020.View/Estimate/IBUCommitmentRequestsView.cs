/***********************************************************************
 * <copyright file="IBUCommitmentRequestsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 6, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 6, 2017Author SonTV  Description 
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
    /// Interface IBUCommitmentRequestsView
    /// </summary>
    public interface IBUCommitmentRequestsView
    {
        /// <summary>
        /// Sets the bu commitment requests.
        /// </summary>
        /// <value>The bu commitment requests.</value>
        IList<BUCommitmentRequestModel> BUCommitmentRequests { set; }
    }
}
