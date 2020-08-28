/***********************************************************************
 * <copyright file="SqlServerBADepositDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 16, 2017
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
    ///     SqlServerBADepositDetailDao
    /// </summary>
    /// <seealso cref="IBADepositDetailDao" />
    public class SqlServerBADepositDetailDao : IBADepositDetailDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, BADepositDetailEntity> Make = reader =>
            new BADepositDetailEntity
            {
                RefDetailId = reader["RefDetailID"].AsString(),
                RefId = reader["RefID"].AsString(),
                Description = reader["Description"].AsString(),
                DebitAccount = reader["DebitAccount"].AsString(),
                CreditAccount = reader["CreditAccount"].AsString(),
                Amount = reader["Amount"].AsDecimal(),
                AmountOC = reader["AmountOC"].AsDecimal(),
                BudgetSourceId = reader["BudgetSourceID"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                MethodDistributeId = reader["MethodDistributeID"].AsIntForNull(),
                CashWithDrawTypeId = reader["CashWithDrawTypeID"].AsIntForNull(),
                AccountingObjectId = reader["AccountingObjectID"].AsString(),
                ActivityId = reader["ActivityID"].AsString(),
                ProjectId = reader["ProjectID"].AsString(),
                ProjectActivityId = reader["ProjectActivityID"].AsString(),
                ProjectExpenseId = reader["ProjectExpenseID"].AsString(),
                ListItemId = reader["ListItemID"].AsString(),
                SortOrder = reader["SortOrder"].AsIntForNull(),
                BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
                FundStructureId = reader["FundStructureID"].AsString(),
                BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
                BankId = reader["BankID"].AsString(),
                ContractId = reader["ContractID"].AsString(),
                CapitalPlanId = reader["CapitalPlanID"].AsString(),
                AutoBusinessId = reader["AutoBusinessID"].AsString()
            };

        /// <summary>
        ///     Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public List<BADepositDetailEntity> GetBADepositDetailsByRefId(string refId)
        {
            const string procedures = @"uspGet_BADepositDetail_ByMaster";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="bADepositDetail">The bADeposit detail.</param>
        /// <returns></returns>
        public string InsertBADepositDetail(BADepositDetailEntity bADepositDetail)
        {
            const string sql = @"uspInsert_BADepositDetail";
            return Db.Insert(sql, true, Take(bADepositDetail));
        }

        public string DeleteBADepositDetailByRefId(string refId)
        {
            const string procedures = @"uspDelete_BADepositDetail_ByMaster";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        ///     Takes the specified bADeposit.
        /// </summary>
        /// <param name="bADepositDetail">The bADeposit.</param>
        /// <returns></returns>
        private object[] Take(BADepositDetailEntity bADepositDetail)
        {
            return new object[]
            {
                "@RefDetailID", bADepositDetail.RefDetailId,
                "@RefID", bADepositDetail.RefId,
                "@Description", bADepositDetail.Description,
                "@DebitAccount", bADepositDetail.DebitAccount,
                "@CreditAccount", bADepositDetail.CreditAccount,
                "@Amount", bADepositDetail.Amount,
                "@AmountOC", bADepositDetail.AmountOC,
                "@BudgetSourceID", bADepositDetail.BudgetSourceId,
                "@BudgetChapterCode", bADepositDetail.BudgetChapterCode,
                "@BudgetKindItemCode", bADepositDetail.BudgetKindItemCode,
                "@BudgetSubKindItemCode", bADepositDetail.BudgetSubKindItemCode,
                "@BudgetItemCode", bADepositDetail.BudgetItemCode,
                "@BudgetSubItemCode", bADepositDetail.BudgetSubItemCode,
                "@MethodDistributeID", bADepositDetail.MethodDistributeId,
                "@CashWithDrawTypeID", bADepositDetail.CashWithDrawTypeId,
                "@AccountingObjectID", bADepositDetail.AccountingObjectId,
                "@ActivityID", bADepositDetail.ActivityId,
                "@ProjectID", bADepositDetail.ProjectId,
                "@ProjectActivityID", bADepositDetail.ProjectActivityId,
                "@ProjectExpenseID", bADepositDetail.ProjectExpenseId,
                "@ListItemID", bADepositDetail.ListItemId,
                "@SortOrder", bADepositDetail.SortOrder,
                "@BudgetDetailItemCode", bADepositDetail.BudgetDetailItemCode,
                "@FundStructureID", bADepositDetail.FundStructureId,
                "@BudgetExpenseID", bADepositDetail.BudgetExpenseId,
                "@BankID", bADepositDetail.BankId,
                "@ContractID", bADepositDetail.ContractId,
                "@CapitalPlanId", bADepositDetail.CapitalPlanId,
                "@AutoBusinessID", bADepositDetail.AutoBusinessId,
            };
        }
    }
}