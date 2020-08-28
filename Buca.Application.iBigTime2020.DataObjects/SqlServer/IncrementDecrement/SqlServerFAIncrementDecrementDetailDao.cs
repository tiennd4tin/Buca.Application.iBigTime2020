/***********************************************************************
 * <copyright file="SqlServerFAIncrementDecrementDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 30, 2017
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
    ///     SqlServerFAIncrementDecrementDetailDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement.IFAIncrementDecrementDetailDao" />
    public class SqlServerFAIncrementDecrementDetailDao : IFAIncrementDecrementDetailDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, FAIncrementDecrementDetailEntity> Make = reader =>
            new FAIncrementDecrementDetailEntity
            {
                RefDetailId = reader["RefDetailID"].AsString(),
                RefId = reader["RefID"].AsString(),
                FixedAssetId = reader["FixedAssetID"].AsString(),
                Description = reader["Description"].AsString(),
                DepartmentId = reader["DepartmentID"].AsString(),
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
                CashWithDrawTypeId = reader["CashWithDrawTypeID"].AsInt(),
                AccountingObjectId = reader["AccountingObjectID"].AsString(),
                ActivityId = reader["ActivityID"].AsString(),
                ProjectId = reader["ProjectID"].AsString(),
                ProjectActivityId = reader["ProjectActivityID"].AsString(),
                ListItemId = reader["ListItemID"].AsString(),
                Approved = reader["Approved"].AsBool(),
                SortOrder = reader["SortOrder"].AsInt(),
                BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
                FundStructureId = reader["FundStructureID"].AsString(),
                BankId = reader["BankID"].AsString(),
                ProjectExpenseEAId = reader["ProjectExpenseEAID"].AsString(),
                ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
                DecreaseReasonId = reader["DecreaseReasonID"].AsInt(),
                BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
                Quantity = reader["Quantity"].AsInt(),
            };

        /// <summary>
        ///     Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public List<FAIncrementDecrementDetailEntity> GetFAIncrementDecrementDetailsByRefId(string refId)
        {
            const string procedures = @"uspGet_FAIncrementDecrementDetail_ByMaster";
            object[] parms = {"@RefID", refId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="fAIncrementDecrementDetail">The bADeposit detail.</param>
        /// <returns></returns>
        public string InsertFAIncrementDecrementDetail(FAIncrementDecrementDetailEntity fAIncrementDecrementDetail)
        {
            const string sql = @"uspInsert_FAIncrementDecrementDetail";
            return Db.Insert(sql, true, Take(fAIncrementDecrementDetail));
        }

        public string DeleteFAIncrementDecrementDetailByRefId(string refId)
        {
            const string procedures = @"uspDelete_FAIncrementDecrementDetail_ByMaster";
            object[] parms = {"@RefID", refId};
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        ///     Takes the specified bADeposit.
        /// </summary>
        /// <param name="fAIncrementDecrementDetail">The bADeposit.</param>
        /// <returns></returns>
        private object[] Take(FAIncrementDecrementDetailEntity fAIncrementDecrementDetail)
        {
            return new object[]
            {
                "@RefDetailID", fAIncrementDecrementDetail.RefDetailId,
                "@RefID", fAIncrementDecrementDetail.RefId,
                "@FixedAssetID", fAIncrementDecrementDetail.FixedAssetId,
                "@Description", fAIncrementDecrementDetail.Description,
                "@DepartmentID", fAIncrementDecrementDetail.DepartmentId,
                "@DebitAccount", fAIncrementDecrementDetail.DebitAccount,
                "@CreditAccount", fAIncrementDecrementDetail.CreditAccount,
                "@Amount", fAIncrementDecrementDetail.Amount,
                "@BudgetSourceID", fAIncrementDecrementDetail.BudgetSourceId,
                "@BudgetChapterCode", fAIncrementDecrementDetail.BudgetChapterCode,
                "@BudgetKindItemCode", fAIncrementDecrementDetail.BudgetKindItemCode,
                "@BudgetSubKindItemCode", fAIncrementDecrementDetail.BudgetSubKindItemCode,
                "@BudgetItemCode", fAIncrementDecrementDetail.BudgetItemCode,
                "@BudgetSubItemCode", fAIncrementDecrementDetail.BudgetSubItemCode,
                "@MethodDistributeID", fAIncrementDecrementDetail.MethodDistributeId,
                "@CashWithDrawTypeID", fAIncrementDecrementDetail.CashWithDrawTypeId,
                "@AccountingObjectID", fAIncrementDecrementDetail.AccountingObjectId,
                "@ActivityID", fAIncrementDecrementDetail.ActivityId,
                "@ProjectID", fAIncrementDecrementDetail.ProjectId,
                "@ProjectActivityID", fAIncrementDecrementDetail.ProjectActivityId,
                "@ListItemID", fAIncrementDecrementDetail.ListItemId,
                "@Approved", fAIncrementDecrementDetail.Approved,
                "@SortOrder", fAIncrementDecrementDetail.SortOrder,
                "@BudgetDetailItemCode", fAIncrementDecrementDetail.BudgetDetailItemCode,
                "@FundStructureID", fAIncrementDecrementDetail.FundStructureId,
                "@BankID", fAIncrementDecrementDetail.BankId,
                "@ProjectExpenseEAID", fAIncrementDecrementDetail.ProjectExpenseEAId,
                "@ProjectActivityEAID", fAIncrementDecrementDetail.ProjectActivityEAId,
                "@DecreaseReasonID", fAIncrementDecrementDetail.DecreaseReasonId,
                "@BudgetExpenseID", fAIncrementDecrementDetail.BudgetExpenseId,
                "@Quantity", fAIncrementDecrementDetail.Quantity,
            };
        }
    }
}