/***********************************************************************
 * <copyright file="sqlserverbuvoucherlistdetaildao.cs" company="BUCA JSC">
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
    ///     SqlServerBUVoucherListDetailDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate.IBUVoucherListDetailDao" />
    public class SqlServerBUVoucherListDetailDao : IBUVoucherListDetailDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, BUVoucherListDetailEntity> Make = reader =>
            new BUVoucherListDetailEntity
            {
                RefDetailId = reader["RefDetailID"].AsString(),
                RefId = reader["RefID"].AsString(),
                VoucherRefType = reader["VoucherRefType"].AsInt(),
                VoucherRefDetailId = reader["VoucherRefDetailID"].AsString(),
                VoucherRefId = reader["VoucherRefID"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefNo = reader["RefNo"].AsString(),
                Description = reader["Description"].AsString(),
                DebitAccount = reader["DebitAccount"].AsString(),
                CreditAccount = reader["CreditAccount"].AsString(),
                Amount = reader["Amount"].AsDecimal(),
                BudgetSourceId = reader["BudgetSourceID"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                MethodDistributeId = reader["MethodDistributeID"].AsInt(),
                CashWithdrawTypeId = reader["CashWithdrawTypeID"].AsInt(),
                ProjectId = reader["ProjectID"].AsString(),
                ActivityId = reader["ActivityID"].AsString(),
                SortOrder = reader["SortOrder"].AsInt(),
                Approved = reader["Approved"].AsBool(),
                BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
                OrgRefNo = reader["OrgRefNo"].AsString(),
                OrgRefDate = reader["OrgRefDate"].AsDateTimeForNull(),
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
        ///     Deletes the bu commitment request detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public string DeleteBUVoucherListDetail(string refId)
        {
            const string procedures = @"uspDelete_BUVoucherListDetail";
            object[] parms = {"@RefId", refId};
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        ///     Gets the bu commitment request detailby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     List&lt;BUCommitmentRequestDetailEntity&gt;.
        /// </returns>
        public List<BUVoucherListDetailEntity> GetBUVoucherListDetailbyRefId(string refId)
        {
            const string procedures = @"uspGet_BUVoucherListDetail_ByRefId";
            object[] parms = {"@RefId", refId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bu voucher list detail.
        /// </summary>
        /// <param name="bUVoucherListDetailEntity">The b u voucher list detail entity.</param>
        /// <returns></returns>
        public string InsertBUVoucherListDetail(BUVoucherListDetailEntity bUVoucherListDetailEntity)
        {
            const string procedures = @"uspInsert_BUVoucherListDetail";
            return Db.Insert(procedures, true, Take(bUVoucherListDetailEntity));
        }

        /// <summary>
        /// Gets the original general ledger not in bu voucher list detail by cash withdraw no.
        /// </summary>
        /// <param name="cashWithdrawNo">The cash withdraw no.</param>
        /// <returns></returns>
        public List<BUVoucherListDetailEntity> GetOriginalGeneralLedgerNotInBUVoucherListDetailByCashWithdrawNo(string cashWithdrawNo)
        {
            const string procedures = @"[dbo].[uspGet_All_OriginalGeneralLedger_NotInBUVoucherListDetail_ByCashWithdrawNo]";
            object[] parms = { "@CashWithdrawNo", cashWithdrawNo };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Takes the specified b u voucher list detail entity.
        /// </summary>
        /// <param name="bUVoucherListDetailEntity">The b u voucher list detail entity.</param>
        /// <returns></returns>
        private static object[] Take(BUVoucherListDetailEntity bUVoucherListDetailEntity)
        {
            return new object[]
            {
                "@RefDetailID", bUVoucherListDetailEntity.RefDetailId,
                "@RefID", bUVoucherListDetailEntity.RefId,
                "@VoucherRefType", bUVoucherListDetailEntity.VoucherRefType,
                "@VoucherRefID", bUVoucherListDetailEntity.VoucherRefId,
                "@VoucherRefDetailID", bUVoucherListDetailEntity.VoucherRefDetailId,
                "@RefDate", bUVoucherListDetailEntity.RefDate,
                "@PostedDate", bUVoucherListDetailEntity.PostedDate,
                "@RefNo", bUVoucherListDetailEntity.RefNo,
                "@Description", bUVoucherListDetailEntity.Description,
                "@DebitAccount", bUVoucherListDetailEntity.DebitAccount,
                "@CreditAccount", bUVoucherListDetailEntity.CreditAccount,
                "@Amount", bUVoucherListDetailEntity.Amount,
                "@BudgetSourceID", bUVoucherListDetailEntity.BudgetSourceId,
                "@BudgetChapterCode", bUVoucherListDetailEntity.BudgetChapterCode,
                "@BudgetKindItemCode", bUVoucherListDetailEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode", bUVoucherListDetailEntity.BudgetSubKindItemCode,
                "@BudgetItemCode", bUVoucherListDetailEntity.BudgetItemCode,
                "@BudgetSubItemCode", bUVoucherListDetailEntity.BudgetSubItemCode,
                "@MethodDistributeID", bUVoucherListDetailEntity.MethodDistributeId,
                "@CashWithdrawTypeID", bUVoucherListDetailEntity.CashWithdrawTypeId,
                "@ProjectID", bUVoucherListDetailEntity.ProjectId,
                "@ActivityID", bUVoucherListDetailEntity.ActivityId,
                "@SortOrder", bUVoucherListDetailEntity.SortOrder,
                "@Approved", bUVoucherListDetailEntity.Approved,
                "@BudgetDetailItemCode", bUVoucherListDetailEntity.BudgetDetailItemCode,
                "@OrgRefNo", bUVoucherListDetailEntity.OrgRefNo,
                "@OrgRefDate", bUVoucherListDetailEntity.OrgRefDate,
                "@AmountOC", bUVoucherListDetailEntity.AmountOC,
                "@CurrencyCode", bUVoucherListDetailEntity.CurrencyCode,
                "@ExchangeRate", bUVoucherListDetailEntity.ExchangeRate,
                "@FundStructureID", bUVoucherListDetailEntity.FundStructureId,
                "@BankAccount", bUVoucherListDetailEntity.BankAccount,
                "@AccountingObjectID", bUVoucherListDetailEntity.AccountingObjectId,
                "@ProjectActivityID", bUVoucherListDetailEntity.ProjectActivityId,
                "@ProjectExpenseID", bUVoucherListDetailEntity.ProjectExpenseId,
                "@ListItemID", bUVoucherListDetailEntity.ListItemId,
                "@ProjectExpenseEAID", bUVoucherListDetailEntity.ProjectExpenseEAId,
                "@ProjectActivityEAID", bUVoucherListDetailEntity.ProjectActivityEAId,
                "@BudgetProvideCode", bUVoucherListDetailEntity.BudgetProvideCode,
                "@BudgetExpenseID", bUVoucherListDetailEntity.BudgetExpenseId,

            };
        }
    }
}