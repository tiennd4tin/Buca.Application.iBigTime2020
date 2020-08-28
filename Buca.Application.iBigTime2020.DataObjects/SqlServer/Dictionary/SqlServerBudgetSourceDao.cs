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

using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// Class SqlServerBudgetSourceDao.
    /// </summary>
    public class SqlServerBudgetSourceDao : IBudgetSourceDao
    {
        /// <summary>
        /// Gets the budgetSource.
        /// </summary>
        /// <param name="budgetSourceId">The budgetSource identifier.</param>
        /// <returns>BudgetSourceEntity.</returns>
        public BudgetSourceEntity GetBudgetSource(string budgetSourceId)
        {
            const string sql = @"uspGet_BudgetSource_ByID";

            object[] parms = { "@BudgetSourceID", budgetSourceId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the budgetSources.
        /// </summary>
        /// <returns>List{BudgetSourceEntity}.</returns>
        public List<BudgetSourceEntity> GetBudgetSourcesByFund()
        {
            const string procedures = @"uspGet_BudgetSource_By_Fund";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budgetSources for combo tree.
        /// </summary>
        /// <param name="budgetSourceId">The budgetSource identifier.</param>
        /// <returns>List{BudgetSourceEntity}.</returns>
        public List<BudgetSourceEntity> GetBudgetSourcesForComboTree(string budgetSourceId)
        {
            const string sql = @"uspGet_BudgetSource_ForComboTreee";

            object[] parms = { "@BudgetSourceID", budgetSourceId };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the budgetSources.
        /// </summary>
        /// <returns>List{BudgetSourceEntity}.</returns>
        public List<BudgetSourceEntity> GetBudgetSources()
        {
            const string procedures = @"uspGet_All_BudgetSource";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budgetSources active.
        /// </summary>
        /// <returns>List{BudgetSourceEntity}.</returns>
        public List<BudgetSourceEntity> GetBudgetSourcesActive()
        {
            const string procedures = @"uspGet_BudgetSource_ByActive";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budget sources by code.
        /// </summary>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <returns></returns>
        public BudgetSourceEntity GetBudgetSourcesByCode(string budgetSourceCode)
        {
            const string procedures = @"uspGet_BudgetSource_ByCode";
            object[] parms = { "@BudgetSourceCode", budgetSourceCode };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the budget sources is parent.
        /// </summary>
        /// <param name="isParent">if set to <c>true</c> [is parent].</param>
        /// <returns></returns>
        public List<BudgetSourceEntity> GetBudgetSourcesIsParent(bool isParent)
        {
            const string procedures = @"uspGet_BudgetSource_ByIsParent";
            object[] parms = { "@IsParent", isParent };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the budgetSource.
        /// </summary>
        /// <param name="budgetSource">The budgetSource.</param>
        /// <returns>System.Int32.</returns>
        public string InsertBudgetSource(BudgetSourceEntity budgetSource)
        {
            const string sql = "uspInsert_BudgetSource";
            return Db.Insert(sql, true, Take(budgetSource));
        }

        /// <summary>
        /// Updates the budgetSource.
        /// </summary>
        /// <param name="budgetSource">The budgetSource.</param>
        /// <returns>System.String.</returns>
        public string UpdateBudgetSource(BudgetSourceEntity budgetSource)
        {
            const string sql = "uspUpdate_BudgetSource";
            return Db.Update(sql, true, Take(budgetSource));
        }

        /// <summary>
        /// Deletes the budgetSource.
        /// </summary>
        /// <param name="budgetSource">The budgetSource.</param>
        /// <returns>System.String.</returns>
        public string DeleteBudgetSource(BudgetSourceEntity budgetSource)
        {
            const string sql = @"uspDelete_BudgetSource";

            object[] parms = { "@BudgetSourceID", budgetSource.BudgetSourceId };
            return Db.Delete(sql, true, parms);
        }

        public string DeleteBudgetSourceConvert()
        {
            const string sql = @"usp_ConvertBudgetSource";

            object[] parms = { };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BudgetSourceEntity> Make = reader =>
            new BudgetSourceEntity
            {
                BudgetSourceId = reader["BudgetSourceID"].AsGuid().AsString(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                BudgetSourceName = reader["BudgetSourceName"].AsString(),
                ParentId = reader["ParentID"].AsGuid().AsString(),
                IsParent = reader["IsParent"].AsBool(),
                IsSavingExpenses = reader["IsSavingExpenses"].AsBool(),
                BudgetSourceCategoryId = reader["BudgetSourceCategoryID"].AsGuid().AsString(),
                BudgetSourceProperty = reader["BudgetSourceProperty"].AsByte(),
                BankAccountId = reader["BankAccountID"].AsGuid().AsString(),
                PayableBankAccountId = reader["PayableBankAccountID"].AsGuid().AsString(),
                ProjectId = reader["ProjectID"].AsGuid().AsString(),
                IsSelfControl = reader["IsSelfControl"].AsBool(),
                IsActive = reader["IsActive"].AsBool(),
                BudgetCode = reader["BudgetCode"].AsString(),
                BudgetSourceType = reader["BudgetSourceType"].AsShort()
            };

        /// <summary>
        /// Takes the specified budget source.
        /// </summary>
        /// <param name="budgetSource">The budget source.</param>
        /// <returns>System.Object[][].</returns>
        private object[] Take(BudgetSourceEntity budgetSource)
        {
            return new object[]  
            {
                "@BudgetSourceID",budgetSource.BudgetSourceId,
		        "@BudgetSourceCode",budgetSource.BudgetSourceCode,
		        "@BudgetSourceName",budgetSource.BudgetSourceName,
		        "@ParentID",budgetSource.ParentId,
		        "@IsParent",budgetSource.IsParent,
		        "@IsSavingExpenses",budgetSource.IsSavingExpenses,
		        "@BudgetSourceCategoryID",budgetSource.BudgetSourceCategoryId,
		        "@BudgetSourceProperty",budgetSource.BudgetSourceProperty,
		        "@BankAccountID",budgetSource.BankAccountId,
		        "@PayableBankAccountID",budgetSource.PayableBankAccountId,
		        "@ProjectID",budgetSource.ProjectId,
		        "@IsSelfControl",budgetSource.IsSelfControl,
		        "@IsActive",budgetSource.IsActive,
                "@BudgetCode", budgetSource.BudgetCode,
                "@BudgetSourceType", budgetSource.BudgetSourceType
            };
        }
    }
}
