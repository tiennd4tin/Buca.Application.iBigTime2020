using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Estimate
{
    /// <summary>
    /// Class SqlServerBUTransferDetailParallelDao.
    /// </summary>
    /// <seealso cref="IBUTransferDetailParallelDao" />
    public class SqlServerBUTransferDetailParallelDao : IBUTransferDetailParallelDao
    {
        /// <summary>
        /// Deletes the ba deposit detail parallel identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteBUTransferDetailParallelById(string refId)
        {
            const string procedures = @"uspDelete_BUTransferDetailParallel_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Gets the ba deposit detailby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BUTransferDetailParallelEntity&gt;.</returns>
        public List<BUTransferDetailParallelEntity> GetBUTransferDetailParallelByRefId(string refId)
        {
            const string procedures = @"uspGet_BUTransferDetailParallel_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the ba with draw detail parallel.
        /// </summary>
        /// <param name="withDrawDetail">The with draw detail.</param>
        /// <returns>System.String.</returns>
        public string InsertBUTransferDetailParallel(BUTransferDetailParallelEntity withDrawDetail)
        {
            const string procedures = @"uspInsert_BUTransferDetailParallel";
            return Db.Insert(procedures, true, Take(withDrawDetail));
        }

        /// <summary>
        /// Updates the ba with draw detail parallel.
        /// </summary>
        /// <param name="withDrawDetail">The with draw detail.</param>
        /// <returns>System.String.</returns>
        public string UpdateBUTransferDetailParallel(BUTransferDetailParallelEntity withDrawDetail)
        {
            const string procedures = @"uspUpdate_BUTransferDetailParallel";
            return Db.Update(procedures, true, Take(withDrawDetail));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BUTransferDetailParallelEntity> Make = reader =>
            new BUTransferDetailParallelEntity
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
                ContractId = reader["ContractID"].AsString(),
                CapitalPlanId = reader["CapitalPlanID"].AsString(),
                AdvanceRecovery = reader["AdvanceRecovery"].AsDecimal(),
            };

        /// <summary>
        /// Takes the specified c a payment detail parallel entity.
        /// </summary>
        /// <param name="BUTransferDetailParallelEntity">The b a with draw detail parallel entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(BUTransferDetailParallelEntity BUTransferDetailParallelEntity)
        {
            return new object[]
            {
                "@RefDetailID",BUTransferDetailParallelEntity.RefDetailId,
                "@ParentRefDetailID",BUTransferDetailParallelEntity.ParentRefDetailId,
                "@RefID",BUTransferDetailParallelEntity.RefId,
                "@Description",BUTransferDetailParallelEntity.Description,
                "@DebitAccount",BUTransferDetailParallelEntity.DebitAccount,
                "@CreditAccount",BUTransferDetailParallelEntity.CreditAccount,
                "@Amount",BUTransferDetailParallelEntity.Amount,
                "@AmountOC",BUTransferDetailParallelEntity.AmountOC,
                "@BudgetSourceID",BUTransferDetailParallelEntity.BudgetSourceId,
                "@BudgetChapterCode",BUTransferDetailParallelEntity.BudgetChapterCode,
                "@BudgetKindItemCode",BUTransferDetailParallelEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",BUTransferDetailParallelEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",BUTransferDetailParallelEntity.BudgetItemCode,
                "@BudgetSubItemCode",BUTransferDetailParallelEntity.BudgetSubItemCode,
                "@BudgetDetailItemCode",BUTransferDetailParallelEntity.BudgetDetailItemCode,
                "@MethodDistributeID",BUTransferDetailParallelEntity.MethodDistributeId,
                "@CashWithdrawTypeID",BUTransferDetailParallelEntity.CashWithdrawTypeId,
                "@AccountingObjectID",BUTransferDetailParallelEntity.AccountingObjectId,
                "@ActivityID",BUTransferDetailParallelEntity.ActivityId,
                "@ProjectID",BUTransferDetailParallelEntity.ProjectId,
                "@FundID",BUTransferDetailParallelEntity.FundId,
                "@TaskID",BUTransferDetailParallelEntity.TaskId,
                "@ListItemID",BUTransferDetailParallelEntity.ListItemId,
                "@SortOrder",BUTransferDetailParallelEntity.SortOrder,
                "@OrgRefNo",BUTransferDetailParallelEntity.OrgRefNo,
                "@OrgRefDate",BUTransferDetailParallelEntity.OrgRefDate,
                "@FundStructureID",BUTransferDetailParallelEntity.FundStructureId,
                "@BankID",BUTransferDetailParallelEntity.BankId,
                "@BudgetProvideCode",BUTransferDetailParallelEntity.BudgetProvideCode,
                "@TopicID",BUTransferDetailParallelEntity.TopicId,
                "@BudgetExpenseID",BUTransferDetailParallelEntity.BudgetExpenseId,
                "@Approved",BUTransferDetailParallelEntity.Approved,
                "@ContractID", BUTransferDetailParallelEntity.ContractId,
                "@CapitalPlanID", BUTransferDetailParallelEntity.CapitalPlanId,
                "@AdvanceRecovery", BUTransferDetailParallelEntity.AdvanceRecovery,
            };
        }
    }
}