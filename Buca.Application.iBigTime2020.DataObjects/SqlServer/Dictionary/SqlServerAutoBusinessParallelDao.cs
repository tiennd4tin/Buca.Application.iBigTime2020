/***********************************************************************
 * <copyright file="SqlServerAutoBusinessParallelDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 26 September 2017
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
    /// SqlServerAutoBusinessParallelDao
    /// </summary>
    public class SqlServerAutoBusinessParallelDao : IAutoBusinessParallelDao
    {
        /// <summary>
        /// Gets the autoBusinessParallel.
        /// </summary>
        /// <param name="autoBusinessParallelId">The autoBusinessParallel identifier.</param>
        /// <returns></returns>
        public AutoBusinessParallelEntity GetAutoBusinessParallel(string autoBusinessParallelId)
        {
            const string sql = @"uspGet_AutoBusinessParallel_ByID";

            object[] parms = { "@AutoBusinessParallelId", autoBusinessParallelId };
            return Db.Read(sql, true, Make, parms);
        }

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
        public AutoBusinessParallelEntity GetAutoBusinessParallelsByAutoBussinessInformation(string debitAccount, string creditAccount, string budgetSourceId, string budgetChapterCode, string budgetKindItemCode, 
            string budgetSubKindItemCode, string budgetItemCode, string budgetSubItemCode, int? methodDistributeId, int? cashWithDrawTypeId)
        {
            const string sql = @"uspGet_AutoBusinessParallel_ByAutoBussinessInformation";

            object[] parms =
            {
                "@DebitAccount", debitAccount,
                "@CreditAccount", creditAccount,
                "@BudgetSourceID", budgetSourceId,
                "@BudgetChapterCode", budgetChapterCode,
                "@BudgetKindItemCode", budgetKindItemCode,
                "@BudgetSubKindItemCode", budgetSubKindItemCode,
                "@BudgetItemCode", budgetItemCode,
                "@BudgetSubItemCode", budgetSubItemCode,
                "@MethodDistributeID", methodDistributeId,
                "@CashWithDrawTypeID", cashWithDrawTypeId
            };
            return Db.Read(sql, true, Make, parms);
        }

        public List<AutoBusinessParallelEntity> GetAutoBusinessParallelsByAutoBussinessInformations(string debitAccount, string creditAccount, string budgetSourceId, string budgetChapterCode, string budgetKindItemCode,
            string budgetSubKindItemCode, string budgetItemCode, string budgetSubItemCode, int? methodDistributeId, int? cashWithDrawTypeId)
        {
            const string sql = @"uspGet_AutoBusinessParallel_ByAutoBussinessInformation";

            object[] parms =
            {
                "@DebitAccount", debitAccount,
                "@CreditAccount", creditAccount,
                "@BudgetSourceID", budgetSourceId,
                "@BudgetChapterCode", budgetChapterCode,
                "@BudgetKindItemCode", budgetKindItemCode,
                "@BudgetSubKindItemCode", budgetSubKindItemCode,
                "@BudgetItemCode", budgetItemCode,
                "@BudgetSubItemCode", budgetSubItemCode,
                "@MethodDistributeID", methodDistributeId,
                "@CashWithDrawTypeID", cashWithDrawTypeId
            };
            return Db.ReadList(sql, true, Make, parms);
        }
        /// <summary>
        /// Gets the AutoBusinessParallels.
        /// </summary>
        /// <returns></returns>
        public List<AutoBusinessParallelEntity> GetAutoBusinessParallels()
        {
            const string procedures = @"uspGet_All_AutoBusinessParallel";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the AutoBusinessParallels by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<AutoBusinessParallelEntity> GetAutoBusinessParallelsByActive(bool isActive)
        {
            const string sql = @"uspGet_AutoBusinessParallel_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the autoBusinessParallel.
        /// </summary>
        /// <param name="autoBusinessParallel">The autoBusinessParallel.</param>
        /// <returns></returns>
        public string InsertAutoBusinessParallel(AutoBusinessParallelEntity autoBusinessParallel)
        {
            const string sql = @"uspInsert_AutoBusinessParallel";
            return Db.Insert(sql, true, Take(autoBusinessParallel));
        }

        /// <summary>
        /// Updates the autoBusinessParallel.
        /// </summary>
        /// <param name="autoBusinessParallel">The autoBusinessParallel.</param>
        /// <returns></returns>
        public string UpdateAutoBusinessParallel(AutoBusinessParallelEntity autoBusinessParallel)
        {
            const string sql = @"uspUpdate_AutoBusinessParallel";
            return Db.Update(sql, true, Take(autoBusinessParallel));
        }

        /// <summary>
        /// Deletes the autoBusinessParallel.
        /// </summary>
        /// <param name="autoBusinessParallel">The autoBusinessParallel.</param>
        /// <returns></returns>
        public string DeleteAutoBusinessParallel(AutoBusinessParallelEntity autoBusinessParallel)
        {
            const string sql = @"uspDelete_AutoBusinessParallel";

            object[] parms = { "@AutoBusinessParallelID", autoBusinessParallel.AutoBusinessParallelId };
            return Db.Delete(sql, true, parms);
        }

        public string DeleteAutoBusinessParallelConvert()
        {
            const string sql = @"usp_ConvertAutoBusinessParallel";

            object[] parms = { };
            return Db.Delete(sql, true, parms);
        }
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, AutoBusinessParallelEntity> Make = reader =>
            new AutoBusinessParallelEntity
            {
                AutoBusinessParallelId = reader["AutoBusinessParallelID"].AsString(),
                AutoBusinessCode = reader["AutoBusinessCode"].AsString(),
                AutoBusinessName = reader["AutoBusinessName"].AsString(),
                Description = reader["Description"].AsString(),
                IsActive = reader["IsActive"].AsBool(),
                DebitAccount = reader["DebitAccount"].AsString(),
                CreditAccount = reader["CreditAccount"].AsString(),
                BudgetSourceId = reader["BudgetSourceID"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                MethodDistributeId = reader["MethodDistributeID"].AsInt(),
                CashWithDrawTypeId = reader["CashWithDrawTypeID"].AsInt(),
                DebitAccountParallel = reader["DebitAccountParallel"].AsString(),
                CreditAccountParallel = reader["CreditAccountParallel"].AsString(),
                BudgetSourceIdParallel = reader["BudgetSourceIDParallel"].AsString(),
                BudgetChapterCodeParallel = reader["BudgetChapterCodeParallel"].AsString(),
                BudgetKindItemCodeParallel = reader["BudgetKindItemCodeParallel"].AsString(),
                BudgetSubKindItemCodeParallel = reader["BudgetSubKindItemCodeParallel"].AsString(),
                BudgetItemCodeParallel = reader["BudgetItemCodeParallel"].AsString(),
                BudgetSubItemCodeParallel = reader["BudgetSubItemCodeParallel"].AsString(),
                MethodDistributeIdParallel = reader["MethodDistributeIDParallel"].AsInt(),
                CashWithDrawTypeIdParallel = reader["CashWithDrawTypeIDParallel"].AsInt(),
                SortOrder = reader["SortOrder"].AsInt()
            };

        /// <summary>
        /// Takes the specified autoBusinessParallel.
        /// </summary>
        /// <param name="autoBusinessParallelEntity">The automatic business parallel entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(AutoBusinessParallelEntity autoBusinessParallelEntity)
        {
            return new object[]
            {
                "@AutoBusinessParallelID",autoBusinessParallelEntity.AutoBusinessParallelId,
                "@AutoBusinessCode",autoBusinessParallelEntity.AutoBusinessCode,
                "@AutoBusinessName",autoBusinessParallelEntity.AutoBusinessName,
                "@Description",autoBusinessParallelEntity.Description,
                "@IsActive",autoBusinessParallelEntity.IsActive,
                "@DebitAccount",autoBusinessParallelEntity.DebitAccount,
                "@CreditAccount",autoBusinessParallelEntity.CreditAccount,
                "@BudgetSourceID",autoBusinessParallelEntity.BudgetSourceId,
                "@BudgetChapterCode",autoBusinessParallelEntity.BudgetChapterCode,
                "@BudgetKindItemCode",autoBusinessParallelEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",autoBusinessParallelEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",autoBusinessParallelEntity.BudgetItemCode,
                "@BudgetSubItemCode",autoBusinessParallelEntity.BudgetSubItemCode,
                "@MethodDistributeID",autoBusinessParallelEntity.MethodDistributeId,
                "@CashWithDrawTypeID",autoBusinessParallelEntity.CashWithDrawTypeId,
                "@DebitAccountParallel",autoBusinessParallelEntity.DebitAccountParallel,
                "@CreditAccountParallel",autoBusinessParallelEntity.CreditAccountParallel,
                "@BudgetSourceIDParallel",autoBusinessParallelEntity.BudgetSourceIdParallel,
                "@BudgetChapterCodeParallel",autoBusinessParallelEntity.BudgetChapterCodeParallel,
                "@BudgetKindItemCodeParallel",autoBusinessParallelEntity.BudgetKindItemCodeParallel,
                "@BudgetSubKindItemCodeParallel",autoBusinessParallelEntity.BudgetSubKindItemCodeParallel,
                "@BudgetItemCodeParallel",autoBusinessParallelEntity.BudgetItemCodeParallel,
                "@BudgetSubItemCodeParallel",autoBusinessParallelEntity.BudgetSubItemCodeParallel,
                "@MethodDistributeIDParallel",autoBusinessParallelEntity.MethodDistributeIdParallel,
                "@CashWithDrawTypeIDParallel",autoBusinessParallelEntity.CashWithDrawTypeIdParallel,
                "@SortOrder",autoBusinessParallelEntity.SortOrder,
            };
        }
    }
}
