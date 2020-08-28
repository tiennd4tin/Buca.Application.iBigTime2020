/***********************************************************************
 * <copyright file="IBudgetGroupItemsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Wednesday, October 10, 2018
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
    /// IBudgetGroupItemsView
    /// </summary>
    public interface IBudgetGroupItemsView
    {
        /// <summary>
        /// Sets the budget group items.
        /// </summary>
        /// <value>
        /// The budget group items.
        /// </value>
        IList<BudgetGroupItemModel> BudgetGroupItems { set; }
    }
}
