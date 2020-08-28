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

using System;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerBudgetSourceCategoryDao
    /// </summary>
    public class SqlServerBudgetSourceCategoryDao : IBudgetSourceCategoryDao
    {
        /// <summary>
        /// Gets the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategoryId">The budgetSourceCategory identifier.</param>
        /// <returns></returns>
        public BudgetSourceCategoryEntity GetBudgetSourceCategory(string budgetSourceCategoryId)
        {
            const string sql = @"uspGet_BudgetSourceCategory_ByID";

            object[] parms = { "@BudgetSourceCategoryID", budgetSourceCategoryId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the budgetSourceCategories.
        /// </summary>
        /// <returns></returns>
        public List<BudgetSourceCategoryEntity> GetBudgetSourceCategories()
        {
            const string procedures = @"uspGet_All_BudgetSourceCategory";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budgetSourceCategories by budgetSourceCategory code.
        /// </summary>
        /// <param name="budgetSourceCategoryCode">The budgetSourceCategory code.</param>
        /// <returns></returns>
        public List<BudgetSourceCategoryEntity> GetBudgetSourceCategoriesByBudgetSourceCategoryCode(string budgetSourceCategoryCode)
        {
            const string sql = @"uspGet_BudgetSourceCategory_ByBudgetSourceCategoryCode";

            object[] parms = { "@BudgetSourceCategoryCode", budgetSourceCategoryCode };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the budgetSourceCategories by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<BudgetSourceCategoryEntity> GetBudgetSourceCategoriesByActive(bool isActive)
        {
            const string sql = @"uspGet_BudgetSourceCategory_ByActive";

            object[] parms = { "@IsActive", true };
            return Db.ReadList(sql, true, Make);
        }

        /// <summary>
        /// Inserts the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns></returns>
        public string InsertBudgetSourceCategory(BudgetSourceCategoryEntity budgetSourceCategory)
        {
            const string sql = @"uspInsert_BudgetSourceCategory";
            return Db.Insert(sql, true, Take(budgetSourceCategory));
        }

        /// <summary>
        /// Updates the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns></returns>
        public string UpdateBudgetSourceCategory(BudgetSourceCategoryEntity budgetSourceCategory)
        {
            const string sql = @"uspUpdate_BudgetSourceCategory";
            return Db.Update(sql, true, Take(budgetSourceCategory));
        }

        /// <summary>
        /// Deletes the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns></returns>
        public string DeleteBudgetSourceCategory(BudgetSourceCategoryEntity budgetSourceCategory)
        {
            const string sql = @"uspDelete_BudgetSourceCategory";

            object[] parms = { "@BudgetSourceCategoryId", budgetSourceCategory.BudgetSourceCategoryId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BudgetSourceCategoryEntity> Make = reader =>
            new BudgetSourceCategoryEntity
            {
                BudgetSourceCategoryId = reader["BudgetSourceCategoryID"].AsGuid().AsString(),
                BudgetSourceCategoryCode = reader["BudgetSourceCategoryCode"].AsString(),
                BudgetSourceCategoryName = reader["BudgetSourceCategoryName"].AsString(),
                ParentId = reader["ParentID"].AsString(),
                IsParent = reader["IsParent"].AsBool(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        /// Takes the specified budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns></returns>
        private static object[] Take(BudgetSourceCategoryEntity budgetSourceCategory)
        {
            return new object[]  
            {
                "@BudgetSourceCategoryID", budgetSourceCategory.BudgetSourceCategoryId,
                "@BudgetSourceCategoryCode", budgetSourceCategory.BudgetSourceCategoryCode,
                "@BudgetSourceCategoryName", budgetSourceCategory.BudgetSourceCategoryName,
                "@ParentID",budgetSourceCategory.ParentId,
	            "@IsParent",budgetSourceCategory.IsParent,
	            "@IsActive",budgetSourceCategory.IsActive
            };
        }
    }
}
