/***********************************************************************
 * <copyright file="SqlServerBudgetExpenseDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Friday, March 14, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
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
    /// Class SqlServerBudgetExpenseDao.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary.IBudgetExpenseDao" />
    public class SqlServerBudgetExpenseDao : IBudgetExpenseDao
    {
        #region IBudgetExpenseDao Members

        /// <summary>
        /// Gets the budget expense.
        /// </summary>
        /// <param name="budgetExpenseId">The budget expense identifier.</param>
        /// <returns>BudgetExpenseEntity.</returns>
        public BudgetExpenseEntity GetBudgetExpense(string budgetExpenseId)
        {

            const string sql = @"uspGet_BudgetExpense_ByID";
            object[] parms = { "@BudgetExpenseID", budgetExpenseId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the budget expense by budget expense code.
        /// </summary>
        /// <param name="budgetExpenseCode">The budget expense code.</param>
        /// <returns>BudgetExpenseEntity.</returns>
        public BudgetExpenseEntity GetBudgetExpenseByBudgetExpenseCode(string budgetExpenseCode)
        {
            const string sql = @"uspGet_BudgetExpense_ByBudgetExpenseCode";
            object[] parms = { "@BudgetExpenseCode", budgetExpenseCode };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the budget expenses.
        /// </summary>
        /// <returns>List&lt;BudgetExpenseEntity&gt;.</returns>
        public List<BudgetExpenseEntity> GetBudgetExpenses()
        {
            const string procedures = @"uspGet_All_BudgetExpense";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budget expenses by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;BudgetExpenseEntity&gt;.</returns>
        public List<BudgetExpenseEntity> GetBudgetExpensesByIsActive(bool isActive)
        {

            const string procedures = @"uspGet_BudgetExpense_ByActive";
            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the budget expense.
        /// </summary>
        /// <param name="budgetExpense">The budget expense.</param>
        /// <returns>System.String.</returns>
        public string InsertBudgetExpense(BudgetExpenseEntity budgetExpense)
        {

            const string sql = "uspInsert_BudgetExpense";
            return Db.Insert(sql, true, Take(budgetExpense));
        }

        /// <summary>
        /// Updates the budget expense.
        /// </summary>
        /// <param name="budgetExpense">The budget expense.</param>
        /// <returns>System.String.</returns>
        public string UpdateBudgetExpense(BudgetExpenseEntity budgetExpense)
        {

            const string sql = "uspUpdate_BudgetExpense";
            return Db.Update(sql, true, Take(budgetExpense));
        }

        /// <summary>
        /// Deletes the budget expense.
        /// </summary>
        /// <param name="budgetExpense">The budget expense.</param>
        /// <returns>System.String.</returns>
        public string DeleteBudgetExpense(BudgetExpenseEntity budgetExpense)
        {

            const string sql = @"uspDelete_BudgetExpense";
            object[] parms = { "@BudgetExpenseID", budgetExpense.BudgetExpenseId };
            return Db.Delete(sql, true, parms);
        }
        public string DeleteBudgetExpenseConvert()
        {

            const string sql = @"usp_ConvertExpense";
            object[] parms = {  };
            return Db.Delete(sql, true, parms);
        }


        #endregion

        /// <summary>
        /// Takes the specified budget expense entity.
        /// </summary>
        /// <param name="budgetExpenseEntity">The budget expense entity.</param>
        /// <returns>System.Object[].</returns>
        private object[] Take(BudgetExpenseEntity budgetExpenseEntity)
        {
            return new object[]
            {
                "@BudgetExpenseID",budgetExpenseEntity.BudgetExpenseId,
                "@BudgetExpenseCode",budgetExpenseEntity.BudgetExpenseCode,
                "@BudgetExpenseName",budgetExpenseEntity.BudgetExpenseName,
                "@IsActive",budgetExpenseEntity.IsActive,
                "@IsSystem",budgetExpenseEntity.IsSystem,
                "@BudgetExpenseType",budgetExpenseEntity.BudgetExpenseType
            };
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BudgetExpenseEntity> Make = reader =>
            new BudgetExpenseEntity
            {
                BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
                BudgetExpenseCode = reader["BudgetExpenseCode"].AsString(),
                BudgetExpenseName = reader["BudgetExpenseName"].AsString(),
                IsActive = reader["IsActive"].AsBool(),
                IsSystem = reader["IsSystem"].AsBool(),
                BudgetExpenseType = reader["BudgetExpenseType"].AsInt()
            };
    }
}
