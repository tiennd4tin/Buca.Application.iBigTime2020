/***********************************************************************
 * <copyright file="SqlServerAutoBusinessDao.cs" company="BUCA JSC">
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
    /// SqlServerAutoBusinessDao
    /// </summary>
    public class SqlServerAutoBusinessDao : IAutoBusinessDao
    {
        /// <summary>
        /// Gets the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns></returns>
        public AutoBusinessEntity GetAutoBusiness(string autoBusinessId)
        {
            const string sql = @"uspGet_AutoBusiness_ByID";

            object[] parms = { "@AutoBusinessId", autoBusinessId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the AutoBusinesses.
        /// </summary>
        /// <returns></returns>
        public List<AutoBusinessEntity> GetAutoBusinesses()
        {
            const string procedures = @"uspGet_All_AutoBusiness";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the AutoBusinesses by autoBusiness account.
        /// </summary>
        /// <param name="autoBusinessAccountCode">The automatic business account code.</param>
        /// <returns></returns>
        public AutoBusinessEntity GetAutoBusinessesByAutoBusinessCode(string autoBusinessAccountCode)
        {
            const string sql = @"uspGet_AutoBusiness_ByAutoBusinessCode";

            object[] parms = { "@AutoBusinessCode", autoBusinessAccountCode };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the AutoBusinesses by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<AutoBusinessEntity> GetAutoBusinessesByActive(bool isActive)
        {
            const string sql = @"uspGet_AutoBusiness_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the automatic business.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public List<AutoBusinessEntity> GetAutoBusinessByRefType(int refTypeId, bool isActive)
        {
            const string sql = @"uspGet_AutoBusiness_ByRefTypeID";

            object[] parms = { "@RefTypeID", refTypeId, "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns></returns>
        public string InsertAutoBusiness(AutoBusinessEntity autoBusiness)
        {
            const string sql = @"uspInsert_AutoBusiness";
            return Db.Insert(sql, true, Take(autoBusiness));
        }

        /// <summary>
        /// Updates the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns></returns>
        public string UpdateAutoBusiness(AutoBusinessEntity autoBusiness)
        {
            const string sql = @"uspUpdate_AutoBusiness";
            return Db.Update(sql, true, Take(autoBusiness));
        }

        /// <summary>
        /// Deletes the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns></returns>
        public string DeleteAutoBusiness(AutoBusinessEntity autoBusiness)
        {
            const string sql = @"uspDelete_AutoBusiness";

            object[] parms = { "@AutoBusinessId", autoBusiness.AutoBusinessId };
            return Db.Delete(sql, true, parms);
        }
        public string DeleteAutoBusinessConvert()
        {
            const string sql = @"usp_ConvertAutoBusiness";

            object[] parms = {  };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, AutoBusinessEntity> Make = reader =>
            new AutoBusinessEntity
            {
                AutoBusinessId = reader["AutoBusinessID"].AsGuid().AsString(),
                AutoBusinessCode = reader["AutoBusinessCode"].AsString(),
                AutoBusinessName = reader["AutoBusinessName"].AsString(),
                RefTypeId = reader["RefTypeID"].AsInt(),
                DebitAccount = reader["DebitAccount"].AsString(),
                CreditAccount = reader["CreditAccount"].AsString(),
                BudgetSourceId = reader["BudgetSourceID"].AsGuid().AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                MethodDistributeId = reader["MethodDistributeID"].AsInt(),
                CashWithDrawTypeId = reader["CashWithDrawTypeID"].AsInt(),
                Description = reader["Description"].AsString(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        /// Takes the specified autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns></returns>
        private static object[] Take(AutoBusinessEntity autoBusiness)
        {
            return new object[]  
            {
                "@AutoBusinessID", autoBusiness.AutoBusinessId,
                "@AutoBusinessCode", autoBusiness.AutoBusinessCode,
                "@AutoBusinessName", autoBusiness.AutoBusinessName,
                "@RefTypeID", autoBusiness.RefTypeId,
                "@DebitAccount", autoBusiness.DebitAccount,
                "@CreditAccount", autoBusiness.CreditAccount,
                "@BudgetSourceID", autoBusiness.BudgetSourceId,
                "@BudgetChapterCode", autoBusiness.BudgetChapterCode,
                "@BudgetKindItemCode", autoBusiness.BudgetKindItemCode,
                "@BudgetSubKindItemCode", autoBusiness.BudgetSubKindItemCode,
                "@BudgetItemCode", autoBusiness.BudgetItemCode,
                "@BudgetSubItemCode", autoBusiness.BudgetSubItemCode,
                "@MethodDistributeID", autoBusiness.MethodDistributeId,
                "@CashWithDrawTypeID", autoBusiness.CashWithDrawTypeId,
                "@Description", autoBusiness.Description,
                "@IsActive", autoBusiness.IsActive
            };
        }
    }
}
