/***********************************************************************
 * <copyright file="SqlServerBUVoucherListDetailTransferDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, May 31, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Estimate
{
    /// <summary>
    ///     SqlServerBUVoucherListDetailTransferDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate.IBUVoucherListDetailTransferDao" />
    public class SqlServerBUVoucherListDetailTransferDao : IBUVoucherListDetailTransferDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, BUVoucherListDetailTransferEntity> Make = reader =>
            new BUVoucherListDetailTransferEntity
            {
                RefDetailId = reader["RefDetailID"].AsString(),
                RefId = reader["RefID"].AsString(),
                BudgetSourceId = reader["BudgetSourceID"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                MethodDistributeId = reader["MethodDistributeID"].AsInt(),
                CashWithDrawTypeId = reader["CashWithDrawTypeID"].AsInt(),
                Amount = reader["Amount"].AsDecimal(),
                DebitAccount = reader["DebitAccount"].AsString(),
                CreditAccount = reader["CreditAccount"].AsString(),
                Description = reader["Description"].AsString(),
                ActivityId = reader["ActivityID"].AsString(),
                ProjectId = reader["ProjectID"].AsString(),
                SortOrder = reader["SortOrder"].AsInt(),
                BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
                AmountOC = reader["AmountOC"].AsDecimal(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                FundStructureId = reader["FundStructureID"].AsString(),
                BankAccount = reader["BankAccount"].AsString(),
                AccountingObjectId = reader["AccountingObjectID"].AsString(),
                ProjectActivityId = reader["ProjectActivityID"].AsString(),
                ProjectExpenseId = reader["ProjectExpenseID"].AsString(),
                ListItemId = reader["ListItemID"].AsString(),
                ProjectExpenseEAId = reader["ProjectExpenseEAID"].AsString(),
                ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
                BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
                BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
            };

        /// <summary>
        ///     Deletes the ba with draw detail parallel identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public string DeleteBUVoucherListDetailTransferById(string refId)
        {
            const string procedures = @"uspDelete_BUVoucherListDetailTransfer";
            object[] parms = {"@RefId", refId};
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        ///     Gets the ba with draw detail parallelby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     List&lt;BUVoucherListDetailTransferEntity&gt;.
        /// </returns>
        public List<BUVoucherListDetailTransferEntity> GetBUVoucherListDetailTransferByRefId(string refId)
        {
            const string procedures = @"uspGet_BUVoucherListDetailTransfer_ByRefId";
            object[] parms = {"@RefId", refId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bu voucher list detail parallel.
        /// </summary>
        /// <param name="bUVoucherListDetailTransferEntity">The b u voucher list detail parallel entity.</param>
        /// <returns></returns>
        public string InsertBUVoucherListDetailTransfer(
            BUVoucherListDetailTransferEntity bUVoucherListDetailTransferEntity)
        {
            const string procedures = @"uspInsert_BUVoucherListDetailTransfer";
            return Db.Insert(procedures, true, Take(bUVoucherListDetailTransferEntity));
        }

        /// <summary>
        ///     Updates the bu voucher list detail parallel.
        /// </summary>
        /// <param name="bUVoucherListDetailTransferEntity">The b u voucher list detail parallel entity.</param>
        /// <returns></returns>
        public string UpdateBUVoucherListDetailTransfer(
            BUVoucherListDetailTransferEntity bUVoucherListDetailTransferEntity)
        {
            const string procedures = @"uspUpdate_BUVoucherListDetailTransfer";
            return Db.Update(procedures, true, Take(bUVoucherListDetailTransferEntity));
        }

        /// <summary>
        ///     Takes the specified b u voucher list detail transfer entity.
        /// </summary>
        /// <param name="bUVoucherListDetailTransferEntity">The b u voucher list detail transfer entity.</param>
        /// <returns></returns>
        private static object[] Take(BUVoucherListDetailTransferEntity bUVoucherListDetailTransferEntity)
        {
            return new object[]
            {
                "@RefDetailID", bUVoucherListDetailTransferEntity.RefDetailId,
                "@RefID", bUVoucherListDetailTransferEntity.RefId,
                "@BudgetSourceID", bUVoucherListDetailTransferEntity.BudgetSourceId,
                "@BudgetChapterCode", bUVoucherListDetailTransferEntity.BudgetChapterCode,
                "@BudgetKindItemCode", bUVoucherListDetailTransferEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode", bUVoucherListDetailTransferEntity.BudgetSubKindItemCode,
                "@BudgetItemCode", bUVoucherListDetailTransferEntity.BudgetItemCode,
                "@BudgetSubItemCode", bUVoucherListDetailTransferEntity.BudgetSubItemCode,
                "@MethodDistributeID", bUVoucherListDetailTransferEntity.MethodDistributeId,
                "@CashWithDrawTypeID", bUVoucherListDetailTransferEntity.CashWithDrawTypeId,
                "@Amount", bUVoucherListDetailTransferEntity.Amount,
                "@DebitAccount", bUVoucherListDetailTransferEntity.DebitAccount,
                "@CreditAccount", bUVoucherListDetailTransferEntity.CreditAccount,
                "@Description", bUVoucherListDetailTransferEntity.Description,
                "@ActivityID", bUVoucherListDetailTransferEntity.ActivityId,
                "@ProjectID", bUVoucherListDetailTransferEntity.ProjectId,
                "@SortOrder", bUVoucherListDetailTransferEntity.SortOrder,
                "@BudgetDetailItemCode", bUVoucherListDetailTransferEntity.BudgetDetailItemCode,
                "@AmountOC", bUVoucherListDetailTransferEntity.AmountOC,
                "@CurrencyCode", bUVoucherListDetailTransferEntity.CurrencyCode,
                "@ExchangeRate", bUVoucherListDetailTransferEntity.ExchangeRate,
                "@FundStructureID", bUVoucherListDetailTransferEntity.FundStructureId,
                "@BankAccount", bUVoucherListDetailTransferEntity.BankAccount,
                "@AccountingObjectID", bUVoucherListDetailTransferEntity.AccountingObjectId,
                "@ProjectActivityID", bUVoucherListDetailTransferEntity.ProjectActivityId,
                "@ProjectExpenseID", bUVoucherListDetailTransferEntity.ProjectExpenseId,
                "@ListItemID", bUVoucherListDetailTransferEntity.ListItemId,
                "@ProjectExpenseEAID", bUVoucherListDetailTransferEntity.ProjectExpenseEAId,
                "@ProjectActivityEAID", bUVoucherListDetailTransferEntity.ProjectActivityEAId,
                "@BudgetProvideCode", bUVoucherListDetailTransferEntity.BudgetProvideCode,
                "@BudgetExpenseID", bUVoucherListDetailTransferEntity.BudgetExpenseId,
            };
        }
    }
}