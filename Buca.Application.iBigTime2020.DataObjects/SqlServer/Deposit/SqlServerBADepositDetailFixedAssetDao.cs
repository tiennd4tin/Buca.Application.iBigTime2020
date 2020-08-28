using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Deposit
{
    public class SqlServerBADepositDetailFixedAssetFixedAssetDao : IBADepositDetailFixedAssetDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, BADepositDetailFixedAssetEntity> Make = reader =>
            new BADepositDetailFixedAssetEntity
            {
                RefDetailId = reader["RefDetailID"].AsString(),
                RefId = reader["RefID"].AsString(),
                FixedAssetId = reader["FixedAssetID"].AsString(),
                Description = reader["Description"].AsString(),
                DebitAccount = reader["DebitAccount"].AsString(),
                CreditAccount = reader["CreditAccount"].AsString(),
                Amount = reader["Amount"].AsDecimal(),
                TaxRate = reader["TaxRate"].AsDecimal(),
                TaxAmount = reader["TaxAmount"].AsDecimal(),
                TaxAccount = reader["TaxAccount"].AsString(),
                BudgetSourceId = reader["BudgetSourceID"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                MethodDistributeId = reader["MethodDistributeID"].AsInt(),
                CashWithdrawTypeId = reader["CashWithdrawTypeID"].AsInt(),
                AccountingObjectId = reader["AccountingObjectID"].AsString(),
                ActivityId = reader["ActivityID"].AsString(),
                ProjectId = reader["ProjectID"].AsString(),
                ProjectActivityId = reader["ProjectActivityID"].AsString(),
                ProjectExpenseId = reader["ProjectExpenseID"].AsString(),
                ListItemId = reader["ListItemID"].AsString(),
                SortOrder = reader["SortOrder"].AsInt(),
                BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
                FundStructureId = reader["FundStructureID"].AsString(),
                ProjectExpenseEAId = reader["ProjectExpenseEAID"].AsString(),
                ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),

            };

        /// <summary>
        ///     Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public List<BADepositDetailFixedAssetEntity> GetBADepositDetailFixedAssetsByRefId(string refId)
        {
            const string procedures = @"uspGet_BADepositDetailFixedAsset_ByMaster";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="bADepositDetailFixedAsset">The bADeposit detail.</param>
        /// <returns></returns>
        public string InsertBADepositDetailFixedAsset(BADepositDetailFixedAssetEntity bADepositDetailFixedAsset)
        {
            const string sql = @"uspInsert_BADepositDetailFixedAsset";
            return Db.Insert(sql, true, Take(bADepositDetailFixedAsset));
        }

        /// <summary>
        ///     Deletes the bADeposit detail by bADeposit identifier.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public string DeleteBADepositDetailFixedAssetByRefId(string refId)
        {
            const string procedures = @"uspDelete_BADepositDetailFixedAsset_ByMaster";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        ///     Takes the specified bADeposit.
        /// </summary>
        /// <param name="bADepositDetailFixedAsset">The bADeposit.</param>
        /// <returns></returns>
        private static object[] Take(BADepositDetailFixedAssetEntity bADepositDetailFixedAssetEntity)
        {
            return new object[]
            {
                "@RefDetailID", bADepositDetailFixedAssetEntity.RefDetailId,
                "@RefID", bADepositDetailFixedAssetEntity.RefId,
                "@FixedAssetID", bADepositDetailFixedAssetEntity.FixedAssetId,
                "@Description", bADepositDetailFixedAssetEntity.Description,
                "@DebitAccount", bADepositDetailFixedAssetEntity.DebitAccount,
                "@CreditAccount", bADepositDetailFixedAssetEntity.CreditAccount,
                "@Amount", bADepositDetailFixedAssetEntity.Amount,
                "@TaxRate", bADepositDetailFixedAssetEntity.TaxRate,
                "@TaxAmount", bADepositDetailFixedAssetEntity.TaxAmount,
                "@TaxAccount", bADepositDetailFixedAssetEntity.TaxAccount,
                "@BudgetSourceID", bADepositDetailFixedAssetEntity.BudgetSourceId,
                "@BudgetChapterCode", bADepositDetailFixedAssetEntity.BudgetChapterCode,
                "@BudgetKindItemCode", bADepositDetailFixedAssetEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode", bADepositDetailFixedAssetEntity.BudgetSubKindItemCode,
                "@BudgetItemCode", bADepositDetailFixedAssetEntity.BudgetItemCode,
                "@BudgetSubItemCode", bADepositDetailFixedAssetEntity.BudgetSubItemCode,
                "@MethodDistributeID", bADepositDetailFixedAssetEntity.MethodDistributeId,
                "@CashWithdrawTypeID", bADepositDetailFixedAssetEntity.CashWithdrawTypeId,
                "@AccountingObjectID", bADepositDetailFixedAssetEntity.AccountingObjectId,
                "@ActivityID", bADepositDetailFixedAssetEntity.ActivityId,
                "@ProjectID", bADepositDetailFixedAssetEntity.ProjectId,
                "@ProjectActivityID", bADepositDetailFixedAssetEntity.ProjectActivityId,
                "@ProjectExpenseID", bADepositDetailFixedAssetEntity.ProjectExpenseId,
                "@ListItemID", bADepositDetailFixedAssetEntity.ListItemId,
                "@SortOrder", bADepositDetailFixedAssetEntity.SortOrder,
                "@BudgetDetailItemCode", bADepositDetailFixedAssetEntity.BudgetDetailItemCode,
                "@FundStructureID", bADepositDetailFixedAssetEntity.FundStructureId,
                "@ProjectExpenseEAID", bADepositDetailFixedAssetEntity.ProjectExpenseEAId,
                "@ProjectActivityEAID", bADepositDetailFixedAssetEntity.ProjectActivityEAId
            };
        }
    }
}