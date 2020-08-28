using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Deposit
{
    /// <summary>
    /// Class SqlServerBADepositDetailParallelDao.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit.IBADepositDetailParallelDao" />
    public class SqlServerBADepositDetailParallelDao : IBADepositDetailParallelDao
    {
        /// <summary>
        /// Deletes the ba deposit detail parallel identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteBADepositDetailParallelById(string refId)
        {
            const string procedures = @"uspDelete_BADepositDetailParallel_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Gets the ca payment detailby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BADepositDetailParallelEntity&gt;.</returns>
        public List<BADepositDetailParallelEntity> GetBADepositDetailParallelByRefId(string refId)
        {
            const string procedures = @"uspGet_BADepositDetailParallel_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the ba deposit detail parallel.
        /// </summary>
        /// <param name="depositDetail">The deposit detail.</param>
        /// <returns>System.String.</returns>
        public string InsertBADepositDetailParallel(BADepositDetailParallelEntity depositDetail)
        {
            const string procedures = @"uspInsert_BADepositDetailParallel";
            return Db.Insert(procedures, true, Take(depositDetail));
        }

        /// <summary>
        /// Updates the ba deposit detail parallel.
        /// </summary>
        /// <param name="depositDetail">The deposit detail.</param>
        /// <returns>System.String.</returns>
        public string UpdateBADepositDetailParallel(BADepositDetailParallelEntity depositDetail)
        {
            const string procedures = @"uspUpdate_BADepositDetailParallel";
            return Db.Update(procedures, true, Take(depositDetail));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BADepositDetailParallelEntity> Make = reader =>
            new BADepositDetailParallelEntity
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
                BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
                MethodDistributeId = reader["MethodDistributeID"].AsInt(),
                CashWithdrawTypeId = reader["CashWithdrawTypeID"].AsInt(),
                AccountingObjectId = reader["AccountingObjectID"].AsString(),
                ActivityId = reader["ActivityID"].AsString(),
                ProjectId = reader["ProjectID"].AsString(),
                FundId = reader["FundID"].AsString(),
                TaskId = reader["TaskID"].AsString(),
                ListItemId = reader["ListItemID"].AsString(),
                SortOrder = reader["SortOrder"].AsInt(),
                OrgRefNo = reader["OrgRefNo"].AsString(),
                OrgRefDate = reader["OrgRefDate"].AsDateTimeForNull(),
                FundStructureId = reader["FundStructureID"].AsString(),
                BankId = reader["BankID"].AsString(),
                BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
                TopicId = reader["TopicID"].AsString(),
                BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
                Approved = reader["Approved"].AsBool(),
                ContractId = reader["ContractID"].AsString(),
                CapitalPlanId = reader["CapitalPlanID"].AsString()
            };

        /// <summary>
        /// Takes the specified c a payment detail parallel entity.
        /// </summary>
        /// <param name="bADepositDetailParallelEntity">The b a deposit detail parallel entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(BADepositDetailParallelEntity bADepositDetailParallelEntity)
        {
            return new object[]
            {
                "@RefDetailID",bADepositDetailParallelEntity.RefDetailId,
                "@RefID",bADepositDetailParallelEntity.RefId,
                "@Description",bADepositDetailParallelEntity.Description,
                "@DebitAccount",bADepositDetailParallelEntity.DebitAccount,
                "@CreditAccount",bADepositDetailParallelEntity.CreditAccount,
                "@Amount",bADepositDetailParallelEntity.Amount,
                "@AmountOC",bADepositDetailParallelEntity.AmountOC,
                "@BudgetSourceID",bADepositDetailParallelEntity.BudgetSourceId,
                "@BudgetChapterCode",bADepositDetailParallelEntity.BudgetChapterCode,
                "@BudgetKindItemCode",bADepositDetailParallelEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",bADepositDetailParallelEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",bADepositDetailParallelEntity.BudgetItemCode,
                "@BudgetSubItemCode",bADepositDetailParallelEntity.BudgetSubItemCode,
                "@BudgetDetailItemCode",bADepositDetailParallelEntity.BudgetDetailItemCode,
                "@MethodDistributeID",bADepositDetailParallelEntity.MethodDistributeId,
                "@CashWithdrawTypeID",bADepositDetailParallelEntity.CashWithdrawTypeId,
                "@AccountingObjectID",bADepositDetailParallelEntity.AccountingObjectId,
                "@ActivityID",bADepositDetailParallelEntity.ActivityId,
                "@ProjectID",bADepositDetailParallelEntity.ProjectId,
                "@FundID",bADepositDetailParallelEntity.FundId,
                "@TaskID",bADepositDetailParallelEntity.TaskId,
                "@ListItemID",bADepositDetailParallelEntity.ListItemId,
                "@SortOrder",bADepositDetailParallelEntity.SortOrder,
                "@OrgRefNo",bADepositDetailParallelEntity.OrgRefNo,
                "@OrgRefDate",bADepositDetailParallelEntity.OrgRefDate,
                "@FundStructureID",bADepositDetailParallelEntity.FundStructureId,
                "@BankID",bADepositDetailParallelEntity.BankId,
                "@BudgetProvideCode",bADepositDetailParallelEntity.BudgetProvideCode,
                "@TopicID",bADepositDetailParallelEntity.TopicId,
                "@BudgetExpenseID",bADepositDetailParallelEntity.BudgetExpenseId,
                "@Approved",bADepositDetailParallelEntity.Approved,
                "@ContractID", bADepositDetailParallelEntity.ContractId,
                "@CapitalPlanID", bADepositDetailParallelEntity.CapitalPlanId,
            };
        }
    }
}