/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    11/12/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;

namespace Buca.Application.iBigTime2020.View.Estimate
{
    /// <summary>
    /// IBUBudgetReservesView
    /// </summary>
    public interface IBUBudgetReservesView
    {
        /// <summary>
        /// Sets the bu budget reserves.
        /// </summary>
        /// <value>
        /// The bu budget reserves.
        /// </value>
        IList<BUBudgetReserveModel> BUBudgetReserves { set; }
    }
}
