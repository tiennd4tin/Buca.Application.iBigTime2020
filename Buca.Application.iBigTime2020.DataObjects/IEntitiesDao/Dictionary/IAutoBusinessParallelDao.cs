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
    /// IAutoBusinessParallelDao
    /// </summary>
    public interface IAutoBusinessParallelDao
    {
        /// <summary>
        /// Gets the automatic business parallel.
        /// </summary>
        /// <param name="autoBusinessParallelId">The automatic business identifier.</param>
        /// <returns>AutoBusinessParallelEntity.</returns>
        AutoBusinessParallelEntity GetAutoBusinessParallel(string autoBusinessParallelId);

        /// <summary>
        /// Gets the automatic business parallels.
        /// </summary>
        /// <returns>List&lt;AutoBusinessParallelEntity&gt;.</returns>
        List<AutoBusinessParallelEntity> GetAutoBusinessParallels();

        /// <summary>
        /// Gets the automatic business parallels by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;AutoBusinessParallelEntity&gt;.</returns>
        List<AutoBusinessParallelEntity> GetAutoBusinessParallelsByActive(bool isActive);

        /// <summary>
        /// Gets the automatic business parallels by automatic bussiness information.
        /// </summary>
        /// <param name="debitAccount">The debit account.</param>
        /// <param name="creditAccount">The credit account.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetKindItemCode">The budget kind item code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="budgetSubItemCode">The budget sub item code.</param>
        /// <param name="methodDistributeId">The method distribute identifier.</param>
        /// <param name="cashWithDrawTypeId">The cash with draw type identifier.</param>
        /// <returns>AutoBusinessParallelEntity.</returns>
        AutoBusinessParallelEntity GetAutoBusinessParallelsByAutoBussinessInformation(string debitAccount, string creditAccount, string budgetSourceId, string budgetChapterCode, string budgetKindItemCode,
            string budgetSubKindItemCode, string budgetItemCode, string budgetSubItemCode, int? methodDistributeId, int? cashWithDrawTypeId);

       List<AutoBusinessParallelEntity> GetAutoBusinessParallelsByAutoBussinessInformations(string debitAccount, string creditAccount, string budgetSourceId, string budgetChapterCode, string budgetKindItemCode,
            string budgetSubKindItemCode, string budgetItemCode, string budgetSubItemCode, int? methodDistributeId, int? cashWithDrawTypeId);

        /// <summary>
        /// Inserts the automatic business parallel.
        /// </summary>
        /// <param name="autoBusinessParallel">The automatic business.</param>
        /// <returns>System.String.</returns>
        string InsertAutoBusinessParallel(AutoBusinessParallelEntity autoBusinessParallel);

        /// <summary>
        /// Updates the automatic business parallel.
        /// </summary>
        /// <param name="autoBusinessParallel">The automatic business.</param>
        /// <returns>System.String.</returns>
        string UpdateAutoBusinessParallel(AutoBusinessParallelEntity autoBusinessParallel);

        /// <summary>
        /// Deletes the automatic business parallel.
        /// </summary>
        /// <param name="autoBusinessParallel">The automatic business.</param>
        /// <returns>System.String.</returns>
        string DeleteAutoBusinessParallel(AutoBusinessParallelEntity autoBusinessParallel);
        string DeleteAutoBusinessParallelConvert();
    }
}
