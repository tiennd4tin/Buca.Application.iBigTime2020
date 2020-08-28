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
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerAccountTransferDao
    /// </summary>
    public class SqlServerAccountTransferDao : IAccountTransferDao
    {
        /// <summary>
        /// Gets the account tranfer.
        /// </summary>
        /// <param name="accountTransferId">The account transfer identifier.</param>
        /// <returns></returns>
        public AccountTransferEntity GetAccountTransfer(string accountTransferId)
        {
            const string sql = @"uspGet_AccountTransfer_ByID";

            object[] parms = { "@AccountTransferID", accountTransferId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the account tranfers.
        /// </summary>
        /// <returns></returns>
        public List<AccountTransferEntity> GetAccountTransfers()
        {
            const string procedures = @"uspGet_All_AccountTransfer";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the account tranfers by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<AccountTransferEntity> GetAccountTransfersByActive(bool isActive)
        {
            const string sql = @"uspGet_AccountTransfer_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the account tranfers by account tranfer code.
        /// </summary>
        /// <param name="accountTransferCode">The account tranfer code.</param>
        /// <returns></returns>
        public AccountTransferEntity GetAccountTransfersByAccountTransferCode(string accountTransferCode)
        {
            const string sql = @"uspGet_AccountTransfer_ByAccountTransferCode";

            object[] parms = { "@AccountTransferCode", accountTransferCode };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the account tranfer.
        /// </summary>
        /// <param name="accountTransfer">The account tranfer.</param>
        /// <returns></returns>
        public string InsertAccountTransfer(AccountTransferEntity accountTransfer)
        {
            const string sql = "uspInsert_AccountTransfer";
            return Db.Insert(sql, true, Take(accountTransfer));
        }

        /// <summary>
        /// Updates the account tranfer.
        /// </summary>
        /// <param name="accountTransfer">The account tranfer.</param>
        /// <returns></returns>
        public string UpdateAccountTransfer(AccountTransferEntity accountTransfer)
        {
            const string sql = "uspUpdate_AccountTransfer";
            return Db.Update(sql, true, Take(accountTransfer));
        }

        /// <summary>
        /// Deletes the account tranfer.
        /// </summary>
        /// <param name="accountTransfer">The account tranfer.</param>
        /// <returns></returns>
        public string DeleteAccountTransfer(AccountTransferEntity accountTransfer)
        {
            const string sql = @"uspDelete_AccountTransfer";

            object[] parms = { "@AccountTransferID", accountTransfer.AccountTransferId };
            return Db.Delete(sql, true, parms);
        }
        public string DeleteAccountTransferConvert()
        {
            const string sql = @"usp_ConvertAccountTransfer";

            object[] parms = { };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, AccountTransferEntity> Make = reader =>
            new AccountTransferEntity
            {
                AccountTransferId = reader["AccountTransferID"].AsGuid().AsString(),
                AccountTransferCode = reader["AccountTransferCode"].AsString(),
                BusinessType = reader["BusinessType"].AsInt(),
                ReferentAccount = reader["ReferentAccount"].AsString(),
                TransferOrder = reader["TransferOrder"].AsInt(),
                FromAccount = reader["FromAccount"].AsString(),
                ToAccount = reader["ToAccount"].AsString(),
                TransferSide = reader["TransferSide"].AsInt(),
                BudgetSourceId = reader["BudgetSourceID"].AsGuid().AsString(),
                Description = reader["Description"].AsString(),
                IsSystem = reader["IsSystem"].AsBool(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        /// Takes the specified account tranfer.
        /// </summary>
        /// <param name="accountTransfer">The account tranfer.</param>
        /// <param name="accountTransfer">The account tranfer.</param>
        /// <returns></returns>
        private static object[] Take(AccountTransferEntity accountTransfer)
        {
            return new object[]  
            {
                "@AccountTransferID", accountTransfer.AccountTransferId,
                "@AccountTransferCode", accountTransfer.AccountTransferCode,
                "@BusinessType", accountTransfer.BusinessType,
                "@ReferentAccount", accountTransfer.ReferentAccount,
                "@TransferOrder", accountTransfer.TransferOrder,
                "@FromAccount", accountTransfer.FromAccount,
                "@ToAccount", accountTransfer.ToAccount,
                "@TransferSide", accountTransfer.TransferSide,
                "@BudgetSourceID", accountTransfer.BudgetSourceId,
                "@Description", accountTransfer.Description,
                "@IsSystem", accountTransfer.IsSystem,
                "@IsActive", accountTransfer.IsActive
            };
        }
    }
}