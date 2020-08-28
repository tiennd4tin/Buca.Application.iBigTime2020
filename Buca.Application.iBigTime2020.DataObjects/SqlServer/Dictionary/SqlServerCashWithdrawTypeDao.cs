/***********************************************************************
 * <copyright file="SqlServerCashWithdrawTypeDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Friday, September 29, 2017
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
    /// SqlServerCashWithdrawTypeDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary.ICashWithdrawTypeDao" />
    public class SqlServerCashWithdrawTypeDao : ICashWithdrawTypeDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, CashWithdrawTypeEntity> Make = reader =>
            new CashWithdrawTypeEntity
            {
                CashWithdrawTypeId = reader["CashWithdrawTypeID"].AsInt(),
                CashWithdrawTypeName = reader["CashWithdrawTypeName"].AsString(),
                CashWithdrawNo = reader["CashWithdrawNo"].AsString(),
                SubSystemId = reader["SubSystemId"].AsInt()
            };

        /// <summary>
        ///     Gets the cashWithdrawType.
        /// </summary>
        /// <param name="cashWithdrawTypeId">The cashWithdrawType identifier.</param>
        /// <returns></returns>
        public CashWithdrawTypeEntity GetCashWithdrawType(int cashWithdrawTypeId)
        {
            const string sql = @"uspGet_CashWithdrawType_ByID";

            object[] parms = {"@CashWithdrawTypeID", cashWithdrawTypeId};
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        ///     Gets the cashWithdrawTypes.
        /// </summary>
        /// <returns></returns>
        public List<CashWithdrawTypeEntity> GetCashWithdrawTypes()
        {
            const string sql = @"uspGetAll_CashWithdrawType";
            return Db.ReadList(sql, true, Make);
        }
    }
}