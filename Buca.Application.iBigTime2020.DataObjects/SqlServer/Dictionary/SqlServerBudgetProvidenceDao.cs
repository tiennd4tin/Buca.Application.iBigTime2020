/***********************************************************************
 * <copyright file="SqlServerBudgetProvidenceDao.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    ///     SqlServerBudgetProvidenceDao
    /// </summary>
    /// <seealso cref="IBudgetProvidenceDao" />
    public class SqlServerBudgetProvidenceDao : IBudgetProvidenceDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, BudgetProvidenceEntity> Make = reader =>
            new BudgetProvidenceEntity
            {
                BudgetProvideId = reader["BudgetProvideID"].AsString(),
                BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
                BudgetProvideName = reader["BudgetProvideName"].AsString(),
                IsSystem = reader["IsSystem"].AsBool(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        ///     Lấy kho theo budgetProvidenceId
        /// </summary>
        /// <param name="budgetProvidenceId">The identifier.</param>
        /// <returns>BudgetProvidenceEntity.</returns>
        public BudgetProvidenceEntity GetBudgetProvidence(string budgetProvidenceId)
        {
            const string sql = @"uspGet_BudgetProvidence_ByID";
            object[] parms = {"@BudgetProvidenceID", budgetProvidenceId};
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        ///     Lấy danh sách các kho
        /// </summary>
        /// <returns>List{BudgetProvidenceEntity}.</returns>
        public List<BudgetProvidenceEntity> GetBudgetProvidences()
        {
            const string sql = @"uspGet_All_BudgetProvidence";
            return Db.ReadList(sql, true, Make);
        }

        /// <summary>
        ///     Inserts the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidence">The budgetProvidence.</param>
        /// <returns></returns>
        public string InsertBudgetProvidence(BudgetProvidenceEntity budgetProvidence)
        {
            const string sql = @"uspInsert_BudgetProvidence";
            return Db.Insert(sql, true, Take(budgetProvidence));
        }

        /// <summary>
        ///     Updates the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidence">The budgetProvidence.</param>
        /// <returns></returns>
        public string UpdateBudgetProvidence(BudgetProvidenceEntity budgetProvidence)
        {
            const string sql = @"uspUpdate_BudgetProvidence";
            return Db.Update(sql, true, Take(budgetProvidence));
        }

        /// <summary>
        ///     Deletes the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidence">The budgetProvidence.</param>
        /// <returns>System.String.</returns>
        public string DeleteBudgetProvidence(BudgetProvidenceEntity budgetProvidence)
        {
            const string sql = @"uspDelete_BudgetProvidence";
            object[] parms = {"@BudgetProvidenceID", budgetProvidence.BudgetProvideId};
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        ///     Lấy danh sách Kho được hoạt động.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List{BudgetProvidenceEntity}.</returns>
        public List<BudgetProvidenceEntity> GetBudgetProvidencesByIsActive(bool isActive)
        {
            const string sql = @"uspGet_BudgetProvidence_ByIsActive";
            object[] parms = {"@IsActive", isActive};
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        ///     Lấy danh sách kho theo mã
        /// </summary>
        /// <param name="budgetProvidenceCode"></param>
        /// <returns></returns>
        public List<BudgetProvidenceEntity> GetBudgetProvidencesByBudgetProvidenceCode(string budgetProvidenceCode)
        {
            const string sql = @"uspGet_BudgetProvidence_ByBudgetProvidenceCode";
            object[] parms = {"@BudgetProvidenceCode", budgetProvidenceCode};
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        ///     Takes the specified budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidence">The budgetProvidence.</param>
        /// <returns></returns>
        private object[] Take(BudgetProvidenceEntity budgetProvidence)
        {
            return new object[]
            {
                "@BudgetProvideID", budgetProvidence.BudgetProvideId,
                "@BudgetProvideName", budgetProvidence.BudgetProvideName,
                "@BudgetProvideCode", budgetProvidence.BudgetProvideCode,
                "@IsSystem", budgetProvidence.IsSystem,
                "@IsActive", budgetProvidence.IsActive
            };
        }
    }
}