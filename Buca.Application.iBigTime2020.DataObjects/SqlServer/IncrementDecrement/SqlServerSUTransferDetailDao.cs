/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 27, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.IncrementDecrement
{
    /// <summary>
    /// SqlServerSUTransferDetailDao
    /// </summary>
    public class SqlServerSUTransferDetailDao : ISUTransferDetailDao
    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, SUTransferDetailEntity> Make = reader =>
            new SUTransferDetailEntity
            {
                RefDetailId = reader["RefDetailID"].AsString(),
                RefId = reader["RefID"].AsString(),
                InventoryItemId = reader["InventoryItemID"].AsString(),
                Description = reader["Description"].AsString(),
                FromDepartmentId = reader["FromDepartmentID"].AsString(),
                ToDepartmentId = reader["ToDepartmentID"].AsString(),
                DebitAccount = reader["DebitAccount"].AsString(),
                CreditAccount = reader["CreditAccount"].AsString(),
                Quantity = reader["Quantity"].AsDecimal(),
                UnitPrice = reader["UnitPrice"].AsDecimal(),
                Amount = reader["Amount"].AsDecimal(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                ListItemId = reader["ListItemID"].AsString(),
                SortOrder = reader["SortOrder"].AsIntForNull()
            };

        /// <summary>
        /// Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public List<SUTransferDetailEntity> GetSUTransferDetailsByRefId(string refId)
        {
            const string procedures = @"uspGet_SUTransferDetail_ByMaster";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the bADeposit detail.
        /// </summary>
        /// <param name="suTransferDetailEntity">The bADeposit detail.</param>
        /// <returns></returns>
        public string InsertSUTransferDetail(SUTransferDetailEntity suTransferDetailEntity)
        {
            const string sql = @"uspInsert_SUTransferDetail";
            return Db.Insert(sql, true, Take(suTransferDetailEntity));
        }

        /// <summary>
        /// Deletes the su transfer detail entity by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public string DeleteSUTransferDetailByRefId(string refId)
        {
            const string procedures = @"uspDelete_SUTransferDetail_ByMaster";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Takes the specified bADeposit.
        /// </summary>
        /// <param name="suTransferDetailEntity">The bADeposit.</param>
        /// <returns></returns>
        private object[] Take(SUTransferDetailEntity suTransferDetailEntity)
        {
            return new object[]
            {
                "@RefDetailID", suTransferDetailEntity.RefDetailId,
                "@RefID", suTransferDetailEntity.RefId,
                "@InventoryItemID", suTransferDetailEntity.InventoryItemId,
                "@Description", suTransferDetailEntity.Description,
                "@FromDepartmentID", suTransferDetailEntity.FromDepartmentId,
                "@ToDepartmentID", suTransferDetailEntity.ToDepartmentId,
                "@DebitAccount", suTransferDetailEntity.DebitAccount,
                "@CreditAccount", suTransferDetailEntity.CreditAccount,
                "@Quantity", suTransferDetailEntity.Quantity,
                "@UnitPrice", suTransferDetailEntity.UnitPrice,
                "@Amount", suTransferDetailEntity.Amount,
                "@BudgetChapterCode", suTransferDetailEntity.BudgetChapterCode,
                "@ListItemID", suTransferDetailEntity.ListItemId,
                "@SortOrder", suTransferDetailEntity.SortOrder,
                "@Unit", suTransferDetailEntity.Unit
            };
        }
    }
}
