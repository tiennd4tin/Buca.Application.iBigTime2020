using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Deposit
{
    /// <summary>
    /// Class SqlServerBABankTransferDetailParallelDao.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit.IBABankTransferDetailParallelDao" />
    public class SqlServerBABankTransferDetailParallelDao : IBABankTransferDetailParallelDao
    {
        /// <summary>
        /// Deletes the ba bank transfer detail parallel by identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteBABankTransferDetailParallelById(string refId)
        {
            const string procedures = @"uspDelete_BABankTransferDetailParallel_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Gets the ba bank transfer detail parallel by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BABankTransferDetailParallelEntity&gt;.</returns>
        public List<BABankTransferDetailParallelEntity> GetBABankTransferDetailParallelByRefId(string refId)
        {
            const string procedures = @"uspGet_BABankTransferDetailParallel_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the ba bank transfer detail parallel.
        /// </summary>
        /// <param name="bankTransferDetail">The bank transfer detail.</param>
        /// <returns>System.String.</returns>
        public string InsertBABankTransferDetailParallel(BABankTransferDetailParallelEntity bankTransferDetail)
        {
            const string procedures = @"uspInsert_BABankTransferDetailParallel";
            return Db.Insert(procedures, true, Take(bankTransferDetail));
        }

        /// <summary>
        /// Updates the ba bank transfer detail parallel.
        /// </summary>
        /// <param name="bankTransferDetail">The bank transfer detail.</param>
        /// <returns>System.String.</returns>
        public string UpdateBABankTransferDetailParallel(BABankTransferDetailParallelEntity bankTransferDetail)
        {
            const string procedures = @"uspUpdate_BABankTransferDetailParallel";
            return Db.Update(procedures, true, Take(bankTransferDetail));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BABankTransferDetailParallelEntity> Make = reader =>
            new BABankTransferDetailParallelEntity
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
            };

        /// <summary>
        /// Takes the specified b a with draw detail parallel entity.
        /// </summary>
        /// <param name="bAWithDrawDetailParallelEntity">The b a with draw detail parallel entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(BABankTransferDetailParallelEntity bAWithDrawDetailParallelEntity)
        {
            return new object[]
            {
                "@RefDetailID",bAWithDrawDetailParallelEntity.RefDetailId,
                "@ParentRefDetailID",bAWithDrawDetailParallelEntity.ParentRefDetailId,
                "@RefID",bAWithDrawDetailParallelEntity.RefId,
                "@Description",bAWithDrawDetailParallelEntity.Description,
                "@DebitAccount",bAWithDrawDetailParallelEntity.DebitAccount,
                "@CreditAccount",bAWithDrawDetailParallelEntity.CreditAccount,
                "@Amount",bAWithDrawDetailParallelEntity.Amount,
                "@AmountOC",bAWithDrawDetailParallelEntity.AmountOC,
                "@BudgetSourceID",bAWithDrawDetailParallelEntity.BudgetSourceId,
                "@BudgetChapterCode",bAWithDrawDetailParallelEntity.BudgetChapterCode,
                "@BudgetKindItemCode",bAWithDrawDetailParallelEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",bAWithDrawDetailParallelEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",bAWithDrawDetailParallelEntity.BudgetItemCode,
                "@BudgetSubItemCode",bAWithDrawDetailParallelEntity.BudgetSubItemCode,
                "@BudgetDetailItemCode",bAWithDrawDetailParallelEntity.BudgetDetailItemCode,
                "@MethodDistributeID",bAWithDrawDetailParallelEntity.MethodDistributeId,
                "@CashWithdrawTypeID",bAWithDrawDetailParallelEntity.CashWithdrawTypeId,
                "@AccountingObjectID",bAWithDrawDetailParallelEntity.AccountingObjectId,
                "@ActivityID",bAWithDrawDetailParallelEntity.ActivityId,
                "@ProjectID",bAWithDrawDetailParallelEntity.ProjectId,
                "@FundID",bAWithDrawDetailParallelEntity.FundId,
                "@TaskID",bAWithDrawDetailParallelEntity.TaskId,
                "@ListItemID",bAWithDrawDetailParallelEntity.ListItemId,
                "@SortOrder",bAWithDrawDetailParallelEntity.SortOrder,
                "@OrgRefNo",bAWithDrawDetailParallelEntity.OrgRefNo,
                "@OrgRefDate",bAWithDrawDetailParallelEntity.OrgRefDate,
                "@FundStructureID",bAWithDrawDetailParallelEntity.FundStructureId,
                "@BankID",bAWithDrawDetailParallelEntity.BankId,
                "@BudgetProvideCode",bAWithDrawDetailParallelEntity.BudgetProvideCode,
                "@TopicID",bAWithDrawDetailParallelEntity.TopicId,
                "@BudgetExpenseID",bAWithDrawDetailParallelEntity.BudgetExpenseId,
                "@Approved",bAWithDrawDetailParallelEntity.Approved,
            };
        }
    }
}