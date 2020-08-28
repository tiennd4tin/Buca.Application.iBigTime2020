/***********************************************************************
 * <copyright file="BudgetGroupItemFacade.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// BudgetGroupItemFacade
    /// </summary>
    public class BudgetGroupItemFacade
    {
        /// <summary>
        /// The budget group item DAO
        /// </summary>
        private static readonly IBudgetGroupItemDao BudgetGroupItemDao = DataAccess.DataAccess.BudgetGroupItemDao;

        /// <summary>
        /// Gets the budget chapters.
        /// </summary>
        /// <returns></returns>
        public List<BudgetGroupItemEntity> GetBudgetGroupItems()
        {
            return BudgetGroupItemDao.GetBudgetGroupItems();
        }
    }
}
