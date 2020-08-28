/***********************************************************************
 * <copyright file="IBudgetProvidenceDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, October 26, 2017
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
    ///     IBudgetProvidenceDao
    /// </summary>
    public interface IBudgetProvidenceDao
    {
        /// <summary>
        ///     Gets the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidenceId">The budgetProvidence identifier.</param>
        /// <returns></returns>
        BudgetProvidenceEntity GetBudgetProvidence(string budgetProvidenceId);

        /// <summary>
        ///     Gets the budgetProvidences.
        /// </summary>
        /// <returns></returns>
        List<BudgetProvidenceEntity> GetBudgetProvidences();

        /// <summary>
        ///     Inserts the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidence">The budgetProvidence.</param>
        /// <returns></returns>
        string InsertBudgetProvidence(BudgetProvidenceEntity budgetProvidence);

        /// <summary>
        ///     Updates the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidence">The budgetProvidence.</param>
        /// <returns></returns>
        string UpdateBudgetProvidence(BudgetProvidenceEntity budgetProvidence);

        /// <summary>
        ///     Deletes the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidence">The budgetProvidence.</param>
        /// <returns>System.String.</returns>
        string DeleteBudgetProvidence(BudgetProvidenceEntity budgetProvidence);

        /// <summary>
        ///     Gets the budgetProvidences by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;BudgetProvidenceEntity&gt;.</returns>
        List<BudgetProvidenceEntity> GetBudgetProvidencesByIsActive(bool isActive);

        /// <summary>
        ///     Lấy danh sách các kho theo mã
        /// </summary>
        /// <param name="budgetProvidenceCode"></param>
        /// <returns></returns>
        List<BudgetProvidenceEntity> GetBudgetProvidencesByBudgetProvidenceCode(string budgetProvidenceCode);
    }
}