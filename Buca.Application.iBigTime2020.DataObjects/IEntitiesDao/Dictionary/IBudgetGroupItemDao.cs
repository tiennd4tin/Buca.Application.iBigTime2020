/***********************************************************************
 * <copyright file="IBudgetGroupItemDao.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IBudgetGroupItemDao
    /// </summary>
    public interface IBudgetGroupItemDao
    {
        /// <summary>
        /// Gets the budget group items.
        /// </summary>
        /// <returns></returns>
        List<BudgetGroupItemEntity> GetBudgetGroupItems();
    }
}
