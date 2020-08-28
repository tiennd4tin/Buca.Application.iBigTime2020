/***********************************************************************
 * <copyright file="sqlserverbawithdrawdetailsalarydao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 23, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Deposit
{
    /// <summary>
    ///     SqlServerBAWithdrawDetailSalaryDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit.IBAWithdrawDetailSalaryDao" />
    public class SqlServerBAWithdrawDetailSalaryDao : IBAWithdrawDetailSalaryDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, BAWithdrawDetailSalaryEntity> Make = reader =>
            new BAWithdrawDetailSalaryEntity
            {
                RefDetailId = reader["RefDetailID"].AsString(),
                RefId = reader["RefID"].AsString(),
                EmployeeId = reader["EmployeeID"].AsString(),
                NetWageAmount = reader["NetWageAmount"].AsDecimal(),
                SortOrder = reader["SortOrder"].AsInt()
            };

        /// <summary>
        ///     Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public List<BAWithdrawDetailSalaryEntity> GetBAWithdrawDetailSalaryEntitysByRefId(string refId)
        {
            const string procedures = @"uspGet_BAWithdrawDetailSalary_ByMaster";
            object[] parms = {"@RefID", refId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="bAWithdrawDetailSalary">The bADeposit detail.</param>
        /// <returns></returns>
        public string InsertBAWithdrawDetailSalaryEntity(BAWithdrawDetailSalaryEntity bAWithdrawDetailSalary)
        {
            const string sql = @"uspInsert_BAWithdrawDetailSalary";
            return Db.Insert(sql, true, Take(bAWithdrawDetailSalary));
        }

        /// <summary>
        ///     Deletes the bADeposit detail by bADeposit identifier.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public string DeleteBAWithdrawDetailSalaryEntityByRefId(string refId)
        {
            const string procedures = @"uspDelete_BAWithdrawDetailSalary_ByMaster";
            object[] parms = {"@RefID", refId};
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        ///     Takes the specified bADeposit.
        /// </summary>
        /// <param name="bAWithdrawDetailSalaryEntity">The b a with draw detail purchase entity.</param>
        /// <returns></returns>
        private object[] Take(BAWithdrawDetailSalaryEntity bAWithdrawDetailSalaryEntity)
        {
            return new object[]
            {
                "@RefDetailID", bAWithdrawDetailSalaryEntity.RefDetailId,
                "@RefID", bAWithdrawDetailSalaryEntity.RefId,
                "@EmployeeID", bAWithdrawDetailSalaryEntity.EmployeeId,
                "@NetWageAmount", bAWithdrawDetailSalaryEntity.NetWageAmount,
                "@SortOrder", bAWithdrawDetailSalaryEntity.SortOrder
            };
        }
    }
}