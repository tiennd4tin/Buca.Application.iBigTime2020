/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IBudgetItemDao
    /// </summary>
    public interface IBudgetSourceDao
    {
        /// <summary>
        /// Gets the budgetSource.
        /// </summary>
        /// <param name="budgetSourceId">The budgetSource identifier.</param>
        /// <returns></returns>
        BudgetSourceEntity GetBudgetSource(string budgetSourceId);

        /// <summary>
        /// Gets the budgetSources.
        /// </summary>
        /// <returns></returns>
        List<BudgetSourceEntity> GetBudgetSources();

        /// <summary>
        /// Gets the budgetSources.
        /// </summary>
        /// <returns></returns>
        List<BudgetSourceEntity> GetBudgetSourcesByFund();

        /// <summary>
        /// Gets the budgetSources for combo tree.
        /// </summary>
        /// <param name="budgetSourceId">The budgetSource identifier.</param>
        /// <returns></returns>
        List<BudgetSourceEntity> GetBudgetSourcesForComboTree(string budgetSourceId);

        /// <summary>
        /// Gets the budgetSources active.
        /// </summary>
        /// <returns></returns>
        List<BudgetSourceEntity> GetBudgetSourcesActive();

        /// <summary>
        /// Gets the budget sources by code.
        /// </summary>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <returns></returns>
        BudgetSourceEntity GetBudgetSourcesByCode(string budgetSourceCode);

        /// <summary>
        /// Gets the budget sources is parent.
        /// </summary>
        /// <param name="isParent">if set to <c>true</c> [is parent].</param>
        /// <returns></returns>
        List<BudgetSourceEntity> GetBudgetSourcesIsParent(bool isParent);

        /// <summary>
        /// Inserts the budgetSource.
        /// </summary>
        /// <param name="budgetSource">The budgetSource.</param>
        /// <returns></returns>
        string InsertBudgetSource(BudgetSourceEntity budgetSource);

        /// <summary>
        /// Updates the budgetSource.
        /// </summary>
        /// <param name="budgetSource">The budgetSource.</param>
        /// <returns></returns>
        string UpdateBudgetSource(BudgetSourceEntity budgetSource);

        /// <summary>
        /// Deletes the budgetSource.
        /// </summary>
        /// <param name="budgetSource">The budgetSource.</param>
        /// <returns></returns>
        string DeleteBudgetSource(BudgetSourceEntity budgetSource);

        string DeleteBudgetSourceConvert();
    }
}