using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.General
{
    /// <summary>
    /// Class SqlServerGLVoucherDetailParallelDao.
    /// </summary>
    /// <seealso cref="IGLVoucherDetailParallelDao" />
    public class SqlServerGLVoucherDetailParallelDao : IGLVoucherDetailParallelDao
    {
        /// <summary>
        /// Deletes the gl voucher detail parallel by identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteGLVoucherDetailParallelById(string refId)
        {
            const string procedures = @"uspDelete_GLVoucherDetailParallel_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Gets the gl voucher detail parallel by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;GLVoucherDetailParallelEntity&gt;.</returns>
        public List<GLVoucherDetailParallelEntity> GetGLVoucherDetailParallelByRefId(string refId)
        {
            const string procedures = @"uspGet_GLVoucherDetailParallel_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the gl voucher detail parallel.
        /// </summary>
        /// <param name="withDrawDetail">The with draw detail.</param>
        /// <returns>System.String.</returns>
        public string InsertGLVoucherDetailParallel(GLVoucherDetailParallelEntity withDrawDetail)
        {
            const string procedures = @"uspInsert_GLVoucherDetailParallel";
            return Db.Insert(procedures, true, Take(withDrawDetail));
        }

        /// <summary>
        /// Updates the gl voucher detail parallel.
        /// </summary>
        /// <param name="withDrawDetail">The with draw detail.</param>
        /// <returns>System.String.</returns>
        public string UpdateGLVoucherDetailParallel(GLVoucherDetailParallelEntity withDrawDetail)
        {
            const string procedures = @"uspUpdate_GLVoucherDetailParallel";
            return Db.Update(procedures, true, Take(withDrawDetail));
        }

        private static readonly Func<IDataReader, GLVoucherDetailParallelEntity> Make = reader =>
            new GLVoucherDetailParallelEntity
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
            };

        /// <summary>
        /// Takes the specified c a payment detail parallel entity.
        /// </summary>
        /// <param name="bAWithDrawDetailParallelEntity">The b a with draw detail parallel entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(GLVoucherDetailParallelEntity bAWithDrawDetailParallelEntity)
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
                "@ContractID", bAWithDrawDetailParallelEntity.ContractId,
                "@CapitalPlanID", bAWithDrawDetailParallelEntity.CapitalPlanId,
            };
        }
    }
}