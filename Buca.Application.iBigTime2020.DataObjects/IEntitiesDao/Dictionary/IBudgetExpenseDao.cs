/***********************************************************************
 * <copyright file="IBudgetExpenseDao.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;


namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// Interface IBudgetExpenseDao
    /// </summary>
    public interface IBudgetExpenseDao
    {
        /// <summary>
        /// Gets the budget expense.
        /// </summary>
        /// <param name="budgetExpenseId">The budget expense identifier.</param>
        /// <returns>BudgetExpenseEntity.</returns>
        BudgetExpenseEntity GetBudgetExpense(string budgetExpenseId);

        /// <summary>
        /// Gets the budget expense by budget expense code.
        /// </summary>
        /// <param name="budgetExpenseCode">The budget expense code.</param>
        /// <returns>BudgetExpenseEntity.</returns>
        BudgetExpenseEntity GetBudgetExpenseByBudgetExpenseCode(string budgetExpenseCode);

        /// <summary>
        /// Gets the budget expenses.
        /// </summary>
        /// <returns>List&lt;BudgetExpenseEntity&gt;.</returns>
        List<BudgetExpenseEntity> GetBudgetExpenses();

        /// <summary>
        /// Gets the budget expenses by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;BudgetExpenseEntity&gt;.</returns>
        List<BudgetExpenseEntity> GetBudgetExpensesByIsActive(bool isActive);

        /// <summary>
        /// Inserts the budget expense.
        /// </summary>
        /// <param name="budgetExpense">The budget expense.</param>
        /// <returns>System.String.</returns>
        string InsertBudgetExpense(BudgetExpenseEntity budgetExpense);

        /// <summary>
        /// Updates the budget expense.
        /// </summary>
        /// <param name="budgetExpense">The budget expense.</param>
        /// <returns>System.String.</returns>
        string UpdateBudgetExpense(BudgetExpenseEntity budgetExpense);

        /// <summary>
        /// Deletes the budget expense.
        /// </summary>
        /// <param name="budgetExpense">The budget expense.</param>
        /// <returns>System.String.</returns>
        string DeleteBudgetExpense(BudgetExpenseEntity budgetExpense);
        string DeleteBudgetExpenseConvert();
    }
}
