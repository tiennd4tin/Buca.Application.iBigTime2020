/***********************************************************************
 * <copyright file="sqlserverbuvoucherlistdetailparalleldao.cs" company="BUCA JSC">
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
    ///     SqlServerBUVoucherListDetailParallelDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate.IBUVoucherListDetailParallelDao" />
    public class SqlServerBUVoucherListDetailParallelDao : IBUVoucherListDetailParallelDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, BUVoucherListDetailParallelEntity> Make = reader =>
            new BUVoucherListDetailParallelEntity
            {
                RefDetailId = reader["RefDetailID"].AsString(),
                ParentRefDetailId = reader["ParentRefDetailID"].AsString(),
                RefId = reader["RefID"].AsString(),
                Description = reader["Description"].AsString(),
                DebitAccount = reader["DebitAccount"].AsString(),
                CreditAccount = reader["CreditAccount"].AsString(),
                Amount = reader["Amount"].AsDecimal(),
                AmountOC = reader["AmountOC"].AsDecimal(),
                BudgetSourceId = reader["BudgetSourceID"].AsString(),
                BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
                MethodDistributeId = reader["MethodDistributeID"].AsInt(),
                CashWithdrawTypeId = reader["CashWithdrawTypeID"].AsInt(),
                AccountingObjectId = reader["AccountingObjectID"].AsString(),
                ActivityId = reader["ActivityID"].AsString(),
                ProjectId = reader["ProjectID"].AsString(),
                ListItemId = reader["ListItemID"].AsString(),
                Approved = reader["Approved"].AsBool(),
                SortOrder = reader["SortOrder"].AsInt(),
                OrgRefNo = reader["OrgRefNo"].AsString(),
                OrgRefDate = reader["OrgRefDate"].AsDateTime(),
                FundStructureId = reader["FundStructureID"].AsString(),
                BankAccount = reader["BankAccount"].AsString(),
                BudgetExpenseId = reader["BudgetExpenseID"].AsString()
            };

        /// <summary>
        ///     Deletes the ba with draw detail parallel identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public string DeleteBUVoucherListDetailParallelById(string refId)
        {
            const string procedures = @"uspDelete_BUVoucherListDetailParallel";
            object[] parms = {"@RefId", refId};
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        ///     Gets the ba with draw detail parallelby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     List&lt;BUVoucherListDetailParallelEntity&gt;.
        /// </returns>
        public List<BUVoucherListDetailParallelEntity> GetBUVoucherListDetailParallelByRefId(string refId)
        {
            const string procedures = @"uspGet_BUVoucherListDetailParallel_ByRefId";
            object[] parms = {"@RefId", refId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bu voucher list detail parallel.
        /// </summary>
        /// <param name="bUVoucherListDetailParallelEntity">The b u voucher list detail parallel entity.</param>
        /// <returns></returns>
        public string InsertBUVoucherListDetailParallel(
            BUVoucherListDetailParallelEntity bUVoucherListDetailParallelEntity)
        {
            const string procedures = @"uspInsert_BUVoucherListDetailParallel";
            return Db.Insert(procedures, true, Take(bUVoucherListDetailParallelEntity));
        }

        /// <summary>
        ///     Updates the bu voucher list detail parallel.
        /// </summary>
        /// <param name="bUVoucherListDetailParallelEntity">The b u voucher list detail parallel entity.</param>
        /// <returns></returns>
        public string UpdateBUVoucherListDetailParallel(
            BUVoucherListDetailParallelEntity bUVoucherListDetailParallelEntity)
        {
            const string procedures = @"uspUpdate_BUVoucherListDetailParallel";
            return Db.Update(procedures, true, Take(bUVoucherListDetailParallelEntity));
        }

        /// <summary>
        ///     Takes the specified b u voucher list detail parallel entity.
        /// </summary>
        /// <param name="bUVoucherListDetailParallelEntity">The b u voucher list detail parallel entity.</param>
        /// <returns></returns>
        private static object[] Take(BUVoucherListDetailParallelEntity bUVoucherListDetailParallelEntity)
        {
            return new object[]
            {
                "@RefDetailID", bUVoucherListDetailParallelEntity.RefDetailId,
                "@ParentRefDetailID", bUVoucherListDetailParallelEntity.ParentRefDetailId,
                "@RefID", bUVoucherListDetailParallelEntity.RefId,
                "@Description", bUVoucherListDetailParallelEntity.Description,
                "@DebitAccount", bUVoucherListDetailParallelEntity.DebitAccount,
                "@CreditAccount", bUVoucherListDetailParallelEntity.CreditAccount,
                "@Amount", bUVoucherListDetailParallelEntity.Amount,
                "@AmountOC", bUVoucherListDetailParallelEntity.AmountOC,
                "@BudgetSourceID", bUVoucherListDetailParallelEntity.BudgetSourceId,
                "@BudgetProvideCode", bUVoucherListDetailParallelEntity.BudgetProvideCode,
                "@BudgetChapterCode", bUVoucherListDetailParallelEntity.BudgetChapterCode,
                "@BudgetKindItemCode", bUVoucherListDetailParallelEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode", bUVoucherListDetailParallelEntity.BudgetSubKindItemCode,
                "@BudgetItemCode", bUVoucherListDetailParallelEntity.BudgetItemCode,
                "@BudgetSubItemCode", bUVoucherListDetailParallelEntity.BudgetSubItemCode,
                "@BudgetDetailItemCode", bUVoucherListDetailParallelEntity.BudgetDetailItemCode,
                "@MethodDistributeID", bUVoucherListDetailParallelEntity.MethodDistributeId,
                "@CashWithdrawTypeID", bUVoucherListDetailParallelEntity.CashWithdrawTypeId,
                "@AccountingObjectID", bUVoucherListDetailParallelEntity.AccountingObjectId,
                "@ActivityID", bUVoucherListDetailParallelEntity.ActivityId,
                "@ProjectID", bUVoucherListDetailParallelEntity.ProjectId,
                "@ListItemID", bUVoucherListDetailParallelEntity.ListItemId,
                "@Approved", bUVoucherListDetailParallelEntity.Approved,
                "@SortOrder", bUVoucherListDetailParallelEntity.SortOrder,
                "@OrgRefNo", bUVoucherListDetailParallelEntity.OrgRefNo,
                "@OrgRefDate", bUVoucherListDetailParallelEntity.OrgRefDate,
                "@FundStructureID", bUVoucherListDetailParallelEntity.FundStructureId,
                "@BankAccount", bUVoucherListDetailParallelEntity.BankAccount,
                "@BudgetExpenseID", bUVoucherListDetailParallelEntity.BudgetExpenseId
            };
        }
    }
}