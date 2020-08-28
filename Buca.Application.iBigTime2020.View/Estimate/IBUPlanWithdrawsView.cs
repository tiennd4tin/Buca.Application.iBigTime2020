/***********************************************************************
 * <copyright file="IBUPlanWithdrawsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, November 1, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, November 1, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.Estimate
{
    public interface IBUPlanWithdrawsView : IView
    {
        /// <summary>
        /// Sets the bu plan withdraw.
        /// </summary>
        /// <value>The bu plan withdraw.</value>
        IList<BUPlanWithdrawModel> BUPlanWithdraws { set; }
    }
}
