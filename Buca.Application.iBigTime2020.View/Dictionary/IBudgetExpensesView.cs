/***********************************************************************
 * <copyright file="IBudgetExpensesView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
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
    /// Interface IBudgetExpensesView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IBudgetExpensesView : IView
    {
        /// <summary>
        /// Sets the budget expenses.
        /// </summary>
        /// <value>The budget expenses.</value>
        IList<BudgetExpenseModel> BudgetExpenses { set; }
    }
}
