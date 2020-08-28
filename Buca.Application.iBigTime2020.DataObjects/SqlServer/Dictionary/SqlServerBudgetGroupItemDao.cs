/***********************************************************************
 * <copyright file="SqlServerBudgetGroupItemDao.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerBudgetGroupItemDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary.IBudgetGroupItemDao" />
    public class SqlServerBudgetGroupItemDao : IBudgetGroupItemDao
    {
        /// <summary>
        /// Gets the budget group items.
        /// </summary>
        /// <returns></returns>
        public List<BudgetGroupItemEntity> GetBudgetGroupItems()
        {
            const string procedures = @"uspGet_All_BudgetGroupItem";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BudgetGroupItemEntity> Make = reader =>
           new BudgetGroupItemEntity
           {
               BudgetGroupItemId = reader["BudgetGroupItemID"].AsString(),
               BudgetGroupItemCode = reader["BudgetGroupItemCode"].AsString(),
               BudgetGroupItemName = reader["BudgetGroupItemName"].AsString(),
               RepBudgetItemCode = reader["RepBudgetItemCode"].AsString(),
               IsActive = reader["IsActive"].AsBool()
           };
    }
}
